using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Fishpole
{
    public class Game : INotifyPropertyChanged
    {
        private Boolean WordsAvailable = false;
        private int IdNumber = 0;
        private int counter = 0;
        private Fish ActualFish;
        private FishList ListOne;
        private List<int> FishToRemove;
        private string _Gameword = "";
        private Boolean removeFlag = false;
        private string _TranslateButtonName = "Tłumacz";
        public string TranslateButtonName
        {
            get { return this._TranslateButtonName; }
            set
            {
                if (this._TranslateButtonName != value)
                {
                    this._TranslateButtonName = value;
                    this.NotifyPropertyChanged("TranslateButtonName");
                }
            }
        }
        private string _NotKnowButtonName = "Nie Znam";
        public string NotKnowButtonName
        {
            get { return this._NotKnowButtonName; }
            set
            {
                if (this._NotKnowButtonName != value)
                {
                    this._NotKnowButtonName = value;
                    this.NotifyPropertyChanged("NotKnowButtonName");
                }
            }
        }
        private string _KnowButtonName = "Znam";
        public string KnowButtonName
        {
            get { return this._KnowButtonName; }
            set
            {
                if (this._KnowButtonName != value)
                {
                    this._KnowButtonName = value;
                    this.NotifyPropertyChanged("KnowButtonName");
                }
            }


        }
        public string GameWord
        {
            get { return this._Gameword; }
            set
            {
                if (this._Gameword != value)
                {
                    this._Gameword = value;
                    this.NotifyPropertyChanged("GameWord");
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public enum Round
        {
            Normal,
            Last
        };



        public Game(FishList first_list)
        {

            this.ListOne = first_list;
            FishToRemove = new List<int>();
            setWord();
        }



        public Boolean changeList()
        {

            foreach (var item in ListOne)
            {
                if (item.Id == IdNumber)
                {
                    item.Level++;
                    if (item.Level == 6)
                    {
                        removeFlag = true;
                        FishToRemove.Add(item.Id);
                        counter++;
                        MessageBox.Show("Słówko nauczone!");
                    }
                }
            }

            if (removeFlag == true)
            {
                return removeElements();
            }
            return false;
        }

        private Boolean removeElements()
        {
            for (int i = 0; i < FishToRemove.Count; i++)
            {
                var item = ListOne.SingleOrDefault(x => x.Id == FishToRemove[i]);
                ListOne.Remove(item);
            }

            FishToRemove.Clear();
            removeFlag = false;
            return checkIfLast();
        }

        private Boolean checkIfLast()
        {
            if (ListOne.Count == 0)
            {
                endRound(Round.Last);
                return true;
            }
            return false;
        }
        public void saveGame()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "FishWords"; //Default file name
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filePath = dlg.FileName;
                ListToXmlFile(filePath);
            }
        }

        private void ListToXmlFile(string filePath)
        {
            using (var sw = new StreamWriter(filePath))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<Fish>));
                serializer.Serialize(sw, ListOne);
            }
        }

        public void setWord()
        {
            WordsAvailable = false;

            while (IdNumber < ListOne.Max(x => x.Id))
            {
                IdNumber++;
                foreach (var item in ListOne)
                {
                    if (item.Id == IdNumber)
                    {
                        this.GameWord = item.Word;
                        this.ActualFish = item;
                        WordsAvailable = true;
                        break;
                    }
                }
                if (WordsAvailable == true)
                    break;
            }
            if (WordsAvailable == false)
            {
                endRound(Round.Normal);
            }

        }
        public void newGame()
        {
            setWord();
            this.KnowButtonName = "Znam";
            this.NotKnowButtonName = "Nie Znam";
            this.TranslateButtonName = "Tłumacz";

        }

        private void endRound(Round round)
        {

            if (round == Round.Last)
            {
                this.GameWord = "Lista słów pusta";
                this.KnowButtonName = "Rundy zakończone";
            }
            else
            {
                this.GameWord = "Lekcja zakończona.";
                this.KnowButtonName = "Kolejna runda";
            }

            this.NotKnowButtonName = "Koniec";
            this.TranslateButtonName = "Zapisz stan gry";
            IdNumber = 0;
        }
        public void endGame()
        {
            ListOne.Clear();
        }


        public void translate()
        {
            this.GameWord = this.ActualFish.Translated;
        }


        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }

        }
    }
}

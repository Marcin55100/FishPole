using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;

namespace Fishpole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public FishList ListOne;
        private int IdNumber = 1;
        public MainWindow()
        {
            InitializeComponent();
            ListOne = new FishList();

            this.listView.ItemsSource = ListOne;
            this.addStack.DataContext = this;
            this.startButton.Visibility = System.Windows.Visibility.Hidden;

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Fish fish = new Fish();
                fish.Word = this.wordBox.Text;
                fish.Translated = this.translatedBox.Text;
                fish.Id = IdNumber;
                if (fish.Word.Length == 0 || fish.Translated.Length == 0)
                    throw new Exception("Wypełnij wszystkie pola!");

                ListOne.Add(fish);
                IdNumber++;
                this.startButton.Visibility = System.Windows.Visibility.Visible;
                this.wordBox.Clear();
                this.translatedBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
            }

        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            IdNumber = 0;
            Game game = new Game(ListOne);
            GameWindow window = new GameWindow(game, this);
            window.Visibility = System.Windows.Visibility.Visible;
            this.startButton.Visibility = System.Windows.Visibility.Hidden;
            this.Hide();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml";

            Nullable<bool> result = dlg.ShowDialog();
            string filepath = "";
            if (result == true)
            {
                filepath = dlg.FileName;

            }
            if (File.Exists(filepath))
            {
                ListOne.Clear();
                XmlFileToList(filepath);
                this.startButton.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void XmlFileToList(string filepath)
        {
            using (var sr = new StreamReader(filepath))
            {
                var deserializer = new XmlSerializer(typeof(ObservableCollection<Fish>));
                ObservableCollection<Fish> tmpList = (ObservableCollection<Fish>)deserializer.Deserialize(sr);
                IdNumber = 1;
                foreach (var item in tmpList)
                {
                    ListOne.Add(item);
                    IdNumber++;
                }
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListOne.Count == 0)
            {
                MessageBox.Show("Nie ma nic do usunięcia");
                this.startButton.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                ListOne.Remove(ListOne.Last());
                IdNumber--;
            }

        }
    }
}

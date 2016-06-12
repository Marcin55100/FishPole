using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishpole
{
    public class Fish: BasicFish,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Sentence { get; set; }
        public string Sound { get; set; }
        public string Association { get; set; }
        public string OtherMeanings { get; set; }
        public int Level { get; set; } = 0;
        public int Id { get; set; }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }

        }
    }
}

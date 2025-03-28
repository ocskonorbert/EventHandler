using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EventHandler.Model
{
    public class Event : INotifyPropertyChanged
    {
        private string name;
        private string location;
        private string country;
        private int? capacity;

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }

        public string Location
        {
            get => location;
            set { location = value; OnPropertyChanged(); }
        }

        public string Country
        {
            get => country;
            set { country = value; OnPropertyChanged(); }
        }

        public int? Capacity
        {
            get => capacity;
            set { capacity = value; OnPropertyChanged(); OnPropertyChanged(nameof(FormattedCapacity)); }
        }

        public string FormattedCapacity => Capacity.HasValue ? $"Kapacitás: {Capacity.Value} fő" : "Kapacitás: nincs megadva";

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

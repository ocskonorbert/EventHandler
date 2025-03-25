using EventHandler.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EventHandler.ViewModel
{
    public class EventSelectionViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();

        private readonly MockEventService _eventService = new MockEventService();

        public async Task LoadEventsAsync()
        {
            var data = await _eventService.GetEventsAsync();
            Events.Clear();
            foreach (var item in data)
            {
                Events.Add(item);
            }
        }

        public void AddEvent(Event newEvent)
        {
            _eventService.AddEvent(newEvent); // hozzáadjuk a mock tárolóhoz
            Events.Add(newEvent); // és a listához is
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

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

        public async Task LoadEventsAsync() // Load data from the mock data source
        {
            var data = await _eventService.GetEventsAsync();
            Events.Clear();
            foreach (var item in data)
            {
                Events.Add(item);
            }
        }

        public void AddEvent(Event newEvent) // Add data to the mock data source 
        {
            _eventService.AddEvent(newEvent); 
            Events.Add(newEvent); 
        }
        public void RemoveEventFromStorage(Event ev) // Remove data to the mock data source 
        {
            {
                _eventService.RemoveEvent(ev);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

using EventHandler.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandler
{
    public class MockEventService
    {
        private static List<Event> _mockData = new List<Event>
    {
        new Event { Name = "Zenei Fesztivál", Location = "Budapest Park", Country = "Magyarország", Capacity = 5000 },
        new Event { Name = "Tech Konferencia", Location = "Bécs", Country = "Ausztria", Capacity = 1200 },
        new Event { Name = "Művészeti Kiállítás", Location = "Szépművészeti Múzeum", Country = "Magyarország" }
    };
        // Get the mock data events
        public async Task<List<Event>> GetEventsAsync()
        {
            await Task.Delay(300); 
            return _mockData.ToList(); // Return the copy of the data
        }
        // Add new event to the mock data
        public void AddEvent(Event newEvent)
        {
            _mockData.Add(newEvent);
        }
        // Remove new event to the mock data
        public void RemoveEvent(Event ev)
        {
            _mockData.Remove(ev);
        }

    }

}

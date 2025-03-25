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

        public async Task<List<Event>> GetEventsAsync()
        {
            await Task.Delay(300); // Szimulált késleltetés
            return _mockData.ToList(); // Másolatot adunk vissza
        }

        public void AddEvent(Event newEvent)
        {
            _mockData.Add(newEvent);
        }

    }

}

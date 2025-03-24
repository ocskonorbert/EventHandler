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
        private const string MockJson = @"
    [
        {
            'Name': 'Zenei Fesztivál',
            'Location': 'Budapest Park',
            'Country': 'Magyarország',
            'Capacity': 5000
        },
        {
            'Name': 'Tech Konferencia',
            'Location': 'Bécsi Kongresszusi Központ',
            'Country': 'Ausztria',
            'Capacity': 1200
        },
        {
            'Name': 'Művészeti Kiállítás',
            'Location': 'Szépművészeti Múzeum',
            'Country': 'Magyarország',
            'Capacity': null
        }
    ]";

        public async Task<List<Event>> GetEventsAsync()
        {
            // Szimulálunk egy hálózati késleltetést
            await Task.Delay(500);

            var events = JsonConvert.DeserializeObject<List<Event>>(MockJson);
            return events;
        }
    }

}

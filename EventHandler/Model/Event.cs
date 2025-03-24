using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandler.Model
{
    public class Event
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public int? Capacity { get; set; }
        public string FormattedCapacity => Capacity.HasValue ? $"Kapacitás: {Capacity.Value} fő" : "Kapacitás: nincs megadva";
    }
}

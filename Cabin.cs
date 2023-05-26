using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsManager
{
    public class Cabin
    {
        public int Id { get; set; }
        public Cabin(int id)
        {
            Id = id;
        }
        public void OpenDoors() => Console.WriteLine($"Cabin {Id} - Doors Open!");
        public void CloseDoors() => Console.WriteLine($"Cabin {Id} - Doors Close!");
        public void PostMessage(string message) => Console.WriteLine($"Cabin {Id} - {message}!");
    }
}

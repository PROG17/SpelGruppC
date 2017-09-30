using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    public class Exit
    {
        public string Direction { get; set; }
        public Room Destination { get; set; }
        public bool Islocked { get; set; }

        public Exit(string direction, Room destination, bool islocked)
        {
            Direction = direction;
            Destination = destination;
            Islocked = islocked;
        }
    }
}

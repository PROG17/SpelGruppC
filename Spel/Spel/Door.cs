using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    public class Door
    {
        public string Direction { get; set; }
        public Room Destination { get; set; }
        public string Description { get; set; }

        public Door(string direction, Room destination, string description)
        {
            Direction = direction;
            Destination = destination;
            Description = description;
        }
    }
}

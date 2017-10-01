using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    public class Room
    {
        public string RoomName { get; set; }
        public string Description { get; set; }
        public List<Door> door = new List<Door>();
        public List<Item> items = new List<Item>();
        public List<Exit> exits = new List<Exit>();

        public Room(string roomName, string description)
        {
            RoomName = roomName;
            Description = description;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Program
    {
        static void Main(string[] args)
        {


            Room library = new Room("The library", "You see a big old library, there are lots of dusty bookshelves. In the corner there is a fire extinguisher");
            library.items.Add(new Item("extinguisher", "It looks heavy"));
            library.items.Add(new Item("broken-key", "lower piece of broken key"));

            Room mainHall = new Room("Main hall", "There are three doors, to the west, east, and north. The Door to the north is blocked with large boards.");

            Room secondFloor = new Room("Second floor", "You are on the second floor, the room is dark. There is a dusty table in the middle of the" +
                                        "room, you see a small item lying on it, it looks like a key");
            secondFloor.items.Add(new Item("broken-key", "upper piece of broken key"));
            secondFloor.items.Add(new Item("shotgun", "Contains a shotgun"));

            Room mayorsOffice = new Room("Mayors office", "You are in the mayors office");



            library.exits.Add(new Exit("north", secondFloor, false));
            library.exits.Add(new Exit("east", mainHall, false));

            mainHall.exits.Add(new Exit("west", library, false));
            mainHall.exits.Add(new Exit("east", mayorsOffice, true));

            secondFloor.exits.Add(new Exit("west", library, false));

            mayorsOffice.exits.Add(new Exit("east", mainHall, false));


            Player.CurrentLocation = mainHall;


            Console.WriteLine("Game -The dark scary house with a monster");
            Console.Write("Enter your name: ");
            Player.Name = Console.ReadLine();

            Console.WriteLine("Ok " + Player.Name + ". You just woke up in a dark hallway in what looks like a big house. You are suffering from memory loss.");

            while (true)
            {
                Console.Write("What is your action?: ");
                Console.WriteLine("Type: \n -Look\n -Go \\north\\south\\east\\west \n -Inspect");
                Player.Action(Console.ReadLine().ToLower());
                Console.Clear();
            }
        }
    }
}

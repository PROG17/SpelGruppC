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
            Room mainHall = new Room("Main hall", "There are two doors, to the west, and east. The door to the east is locked.");

            Room library = new Room("The library", "You see a big old library, there are lots of dusty bookshelves and you see a small item lying on the floor.\nIt looks like a broken-key. There is a shotgun in the corner. At the north end of the library you can see \nstairs to the seccond floor.");
            library.items.Add(new Item("shotgun", "It looks heavy"));
            library.items.Add(new Item("broken-key", "lower piece of a key"));

            Room seccondFloor = new Room("Seccond floor", "The room is dark. There is a dusty table in the middle of the room, you see a small item lying on it,\nit looks like a broken-key. There are no other exits other than the stairs to the west leading back to the library.");
            seccondFloor.items.Add(new Item("broken-key", "upper piece of a key"));
            seccondFloor.items.Add(new Item("shotgun", "Contains a shotgun"));

            Room mayorsOffice = new Room("Mayors office", "You are in the mayors office, a monster is keeping the mayor hostage.");



            library.exits.Add(new Exit("north", seccondFloor, false));
            library.exits.Add(new Exit("east", mainHall, false));

            mainHall.exits.Add(new Exit("west", library, false));
            mainHall.exits.Add(new Exit("east", mayorsOffice, true));

            seccondFloor.exits.Add(new Exit("west", library, false));

            mayorsOffice.exits.Add(new Exit("east", mainHall, false));


            Player.CurrentLocation = mainHall;


            Console.WriteLine("Game -The dark scary house with a monster");
            Console.Write("Enter your name: ");
            Player.Name = Console.ReadLine();

            Console.WriteLine("Ok " + Player.Name + ". You just woke up in a dark hallway in what looks like a big house. You are suffering from memory loss.");

            while (Player.keepPlaying)
            {
                Player.ShowActions();
                Console.Write("What is your action?: ");
                Player.Action(Console.ReadLine().ToLower());
            }
            Console.ReadLine();
        }
    }
}

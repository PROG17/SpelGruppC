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


            Room library = new Room("The library", "ett bibliotek");
            library.items.Add(new Item("extinguisher", "Its red"));
            library.items.Add(new Item("half-key", "lower piece of broken key"));

            Room mainHall = new Room("Main hall", "There are three extits to the west, east, and north. An extinguisher lies on the corner");

            Room secondFloor = new Room("Second floor", "You have now mounted the stairs");
            secondFloor.items.Add(new Item("half-key", "upper piece of broken key"));
            secondFloor.items.Add(new Item("shotgun", "Contains a shotgun"));

            Room mayorsOffice = new Room("Mayors office", "You are in the mayors office");



            library.exits.Add(new Exit("north", secondFloor, false));
            library.exits.Add(new Exit("east", mainHall, false));

            mainHall.exits.Add(new Exit("west", library, false));
            mainHall.exits.Add(new Exit("east", library, true));

            secondFloor.exits.Add(new Exit("west", library, false));

            mayorsOffice.exits.Add(new Exit("east", mainHall, false));


            Player.CurrentLocation = mainHall;


            Console.WriteLine("Welcome to our shitty game.");
            Console.Write("Enter your name: ");
            Player.Name = Console.ReadLine();

            Console.WriteLine("Ok " + Player.Name + ". You are currently picking up the love of your boring life to go on your first date together.\nBut just when you were gonna knock on the front door of her big mansion you hear her scream for help,\nso you knock the front door down and you are now entering the main hall...");

            while (true)
            {
                Console.Write("What is your action?: ");
                Player.Action(Console.ReadLine().ToLower());
            }
        }
    }
}

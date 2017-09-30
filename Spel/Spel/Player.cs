using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    public static class Player
    {

        public static string Name { get; set; }
        public static Room CurrentLocation { get; set; }
        static List<Item> Inventory = new List<Item>();

        /*Denna metod kommer att användas varje gång användaren skriver ner några instruktioner.
         * Nyckel ord för giltliga instructioner är:
         * GO (Direction)
         * USE (Item) ON (Item/Door)
         * TAKE (Item)
         * DROP (Item)
         * INSPECT (Item/Door)
         * LOOK
         */
        public static void Action(string Instructions)
        {
            string[] usedKeywords = Instructions.Split(' ');

            if (usedKeywords[0] == "go")
            {
                foreach (var exit in CurrentLocation.exits)
                {
                    if (usedKeywords[1] == exit.Direction && (exit.Islocked == false))
                    {
                        CurrentLocation = exit.Destination;
                        Console.WriteLine("You are now entering " + CurrentLocation.RoomName);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("There is no exit in that direction");
                    }
                }
            }
            else if (usedKeywords[0] == "use")
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    if (Inventory[i].Name == usedKeywords[1])
                    {
                        if (usedKeywords[2] == "on")
                        {
                            for (int j = 0; j < Inventory.Count; j++)
                            {
                                if (Inventory[i].Name == Inventory[j].Name)
                                {
                                    Console.WriteLine("The two keypieces have now merged into one key");
                                    Inventory.Add(new Item("key", "this is the key to the mayors office"));
                                    Inventory.RemoveAt(i);
                                    Inventory.RemoveAt(j);
                                }
                            }

                            if (usedKeywords[3] == "door")
                            {
                                if (CurrentLocation.RoomName == "Mainhall")
                                {
                                    for (int e = 0; e < CurrentLocation.exits.Count; e++)
                                    {
                                        if (CurrentLocation.exits[e].Islocked == true)
                                        {
                                            CurrentLocation.exits[e].Islocked = false;
                                            CurrentLocation = CurrentLocation.exits[e].Destination;
                                            Console.WriteLine("The door is now unlocked and You are now entering " + CurrentLocation.RoomName);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (usedKeywords[0] == "take")
            {
                for (int i = 0; i < CurrentLocation.items.Count; i++)
                {
                    if (usedKeywords[1] == CurrentLocation.items[i].Name)
                    {
                        Console.WriteLine("Your picked up the " + CurrentLocation.items[i].Name);
                        Inventory.Add(CurrentLocation.items[i]);
                        CurrentLocation.items.RemoveAt(i);
                    }
                }
            }
            else if (usedKeywords[0] == "drop")
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    if (usedKeywords[1] == Inventory[i].Name)
                    {
                        Console.WriteLine("Your dropped the " + Inventory[i].Name);
                        CurrentLocation.items.Add(Inventory[i]);
                        Inventory.RemoveAt(i);
                    }
                }
            }
            else if (usedKeywords[0] == "inspect")
            {
                for (int i = 0; i < CurrentLocation.items.Count; i++)
                {
                    if (usedKeywords[1] == CurrentLocation.items[i].Name)
                    {
                        Console.WriteLine(CurrentLocation.items[i].Description);
                    }
                }
            }
            else if (usedKeywords[0] == "look")
            {
                Console.WriteLine(CurrentLocation.Description);
            }
            else Console.WriteLine("That command is not valid...bitch.");
        }
    }
}

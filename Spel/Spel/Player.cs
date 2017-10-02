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

        public static bool keepPlaying = true;

        /*Denna metod kommer att användas varje gång användaren skriver ner några instruktioner.
         * Nyckel ord för giltliga instructioner är:
         * GO (Direction)
         * USE (Item) ON (Item/Door)
         * TAKE (Item)
         * DROP (Item)
         * INSPECT (Item)
         * LOOK
         */

        public static void Action(string Instructions)
        {
            string[] usedKeywords = Instructions.Split(' ');

            if (usedKeywords[0] == "go")
            {
                Console.Clear();
                foreach (var exit in CurrentLocation.exits)
                {
                    if (usedKeywords[1] == exit.Direction && (exit.Islocked == false))
                    {
                        CurrentLocation = exit.Destination;
                        Console.WriteLine("You are now entering " + CurrentLocation.RoomName);
                        break;
                    }
                    else if (usedKeywords[1] == exit.Direction && (exit.Islocked == true))
                    {
                        Console.WriteLine("The door is locked, use the key on the door if you have it.");
                        break;
                    }
                }
            }
            else if (usedKeywords[0] == "use")
            {
                Console.Clear();
                if (usedKeywords[1] == "broken-key")
                {
                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        if (Inventory[i].Name == usedKeywords[1] && usedKeywords[1] == "broken-key")
                        {
                            if (usedKeywords[2] == "on")
                            {
                                for (int j = 0; j < Inventory.Count; j++)
                                {
                                    if (Inventory[i].Name == Inventory[j].Name && usedKeywords[3] == "broken-key")
                                    {
                                        Console.WriteLine("You put the two pieces together, now its one key.");
                                        Inventory.Add(new Item("key", "this is the key to the mayors office"));
                                        Inventory.RemoveAt(i);
                                        Inventory.RemoveAt(j);
                                    }
                                }
                            }
                        }
                    }
                }
                else if ((usedKeywords[1] == "key") && (usedKeywords[2] == "on") && (usedKeywords[3] == "door") && (CurrentLocation.RoomName == "Main hall"))
                {
                    for (int e = 0; e < CurrentLocation.exits.Count; e++)
                    {
                        if (CurrentLocation.exits[e].Islocked == true)
                        {
                            bool haveShotgun = false;
                            CurrentLocation.exits[e].Islocked = false;
                            CurrentLocation = CurrentLocation.exits[e].Destination;
                            Console.WriteLine("The door is now unlocked and You are now entering " + CurrentLocation.RoomName);
                            for (int s = 0; s < Inventory.Count; s++)
                            {
                                if (Inventory[s].Name == "shotgun")
                                {
                                    haveShotgun = true;
                                    Console.WriteLine("Good thing your carried that heavy shotgun around. \nThe monster is rampaging " +
                                                      "against you. \nLocked n' Loaded: PANG!!! PANG!!! you killed the monster...\n POLICE RADIO: Nice job lituenant, you saved the mayor and killed the monster. \nYou are truely a hero among men... YOU WIN!");
                                    keepPlaying = false;
                                }
                            }
                            if (!haveShotgun)
                            {
                                Console.WriteLine("There is a monster in the office and it is rampaging against you,\ntoo bad you dont have a weapon to protect yourself with.... \nThe monster killed you...GAME OVER.");
                                keepPlaying = false;
                            }
                        }
                    }
                }
            }
            else if (usedKeywords[0] == "take")
            {
                Console.Clear();
                for (int i = 0; i < CurrentLocation.items.Count; i++)
                {
                    if (usedKeywords[1].Contains(CurrentLocation.items[i].Name))
                    {
                        Console.WriteLine("Your picked up the " + CurrentLocation.items[i].Name);
                        Inventory.Add(CurrentLocation.items[i]);
                        CurrentLocation.items.RemoveAt(i);
                    }
                }
            }
            else if (usedKeywords[0] == "drop")
            {
                Console.Clear();
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
                Console.Clear();
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
                Console.Clear();
                Console.WriteLine(CurrentLocation.Description);
            }
            else if (usedKeywords[0] == "inventory")
            {
               
                for (int i = 0; i < Inventory.Count; i++)
                {
                    if (Inventory.Count > 0)
                    {
                        
                        Console.WriteLine("item: " +Inventory[i].Name);

                    }
                }
                if (Inventory.Count == 0)
                {
                    Console.WriteLine("Empty");
                }
                    
                
            }
            else if (usedKeywords[0] == "actions")
            {
                Console.WriteLine("Available Actions: \n -Look\n -Go \\north\\south\\east\\west " +
                                  "\n -Inspect(item) \n -Take (item) \n -Drop (item) \n -Use (item) On (item\\door)");
            }
            else  {Console.WriteLine("Invalid input, try again");}

        }
        //public static void ShowActions()
        //{
        //    Console.WriteLine("Available Actions: \n -Look\n -Go \\north\\south\\east\\west " +
        //                      "\n -Inspect(item) \n -Take (item) \n -Drop (item) \n -Use (item) On (item\\door)");
        //}

        
    }
}

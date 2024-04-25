using System;
using System.Collections.Generic;

namespace NarrativeProject
{
    internal class Game
    {
        List<Room> rooms = new List<Room>();
        Room currentRoom;
        internal bool IsGameOver() => isFinished;
        static bool isFinished;
        static string nextRoom = "";
       internal static List<string> inventory = new List<string>();
        public static int playerHealth = 100;

        internal void Add(Room room)
        {
            rooms.Add(room);
            if (currentRoom == null)
            {
                currentRoom = room;
            }
        }

        internal string CurrentRoomDescription => currentRoom.CreateDescription();

        internal void ReceiveChoice(string choice)
        {
            currentRoom.ReceiveChoice(choice);
            CheckTransition();
            if (playerHealth <= 0)
            {
                Console.WriteLine("\nGame over! You died...");
                isFinished = true;
                return;
            }
        }

        internal static void Transition<T>() where T : Room
        {
            nextRoom = typeof(T).Name;
        }

        internal static void Finish()
        {
            isFinished = true;
        }

        internal void CheckTransition()
        {
            foreach (var room in rooms)
            {
                if (room.GetType().Name == nextRoom)
                {
                    nextRoom = "";
                    currentRoom = room;
                    break;
                }
            }
        }
        internal static void AddInventory(string item)
        {
            inventory.Add(item);
            Console.WriteLine($"\nAdded {item} to your inventory");
        }
        internal void DisplayInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("You have nothing in your inventory...");
            }
            else
            {
                Console.WriteLine("Inventory");
                foreach (var item in inventory)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Which item do you want to use?");
                string selectedItem = Console.ReadLine();
                if (selectedItem == "cancel")
                {
                    return;
                }
                else if (selectedItem == "teddy bear" && inventory.Contains("Teddy Bear"))
                {
                    UseItem("Teddy Bear");
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
        }
        internal static void UseItem(string item)
        {
            if (!inventory.Contains(item))
            {
                Console.WriteLine($"You don't have {item} in your inventory...");
                return;
            }
            switch (item)
            {
                case "Teddy Bear":
                    Console.WriteLine("The teddy bear reaches his small arms to give you a hug. " +
                        "\nHis hug magically heals your wounds...");
                    playerHealth += 20;
                    Console.WriteLine("\nYou feel much better...");
                    break;
                default:
                    Console.WriteLine("You cannot use this right now.");
                    break;
            }
        }
    }
}

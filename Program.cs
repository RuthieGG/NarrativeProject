using NarrativeProject.Rooms;
using System;
using System.Media;

namespace NarrativeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Add(new Bedroom());
            game.Add(new Basement());
            game.Add(new Kitchen());
            game.Add(new Hallway());
            game.Add(new LastRoom());

            while (!game.IsGameOver())
            {
                Console.WriteLine("--Inventory (press i)--");
                Console.WriteLine($"Player health: {Game.playerHealth}");
                Console.WriteLine("\n");

                Console.WriteLine(game.CurrentRoomDescription);
                

                string choice = Console.ReadLine().ToLower() ?? "";
                if (choice == "inventory" || choice == "i")
                {
                    game.DisplayInventory();
                }
                else
                {
                    Console.Clear();
                    game.ReceiveChoice(choice);
                }
     
            }

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}

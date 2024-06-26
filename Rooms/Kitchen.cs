﻿using System;

namespace NarrativeProject.Rooms
{
    internal class Kitchen : Room
    {
        internal static bool isKeyCollected;

        internal override string CreateDescription() =>
@"You step into the kitchen, feeling the darkness of the [hallway] behind you loom ominously...
You are greeted by a dusty table and a lonely [cupboard]. The rooms is filled
with cobwebs on the falling ceiling. You see a door on the floor that leads to a [basement]...
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "hallway":
                    Console.WriteLine("You return to the creepy hallway.");
                    Game.Transition<Hallway>();
                    break;
                case "cupboard":
                    InspectCupboard();
                    break;
                case "basement":
                    if (!isKeyCollected)
                    {
                        Console.WriteLine("The door is locked. Perhaps there's a key somewhere...");
                    }
                    else
                    {
                        Console.WriteLine("You unlock the door and descend to the dark basement.");
                        Game.Transition<Basement>();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
        private void InspectCupboard()
        {
            Console.WriteLine("You approach the locked cupboard. It has a note on it.");

            Console.WriteLine("\n\"To see what's inside, arrange the utensils on the table" +
                "\nin alphabetical order.\"");
            Console.WriteLine("\nWhat do you want to do? ");
            Console.WriteLine("1. Attempt arranging the utensils.");
            Console.WriteLine("2. Do nothing.");
            string choice = Console.ReadLine(); 

            switch(choice)
            {
                case "1":
                    Console.Clear();
                    ArrangeUtensils();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("You decide to do nothing.");
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
        private void ArrangeUtensils()
        {
        tryAgain: Console.WriteLine("You inspect the utensils and carefully arrange them in alphabetical order.");

                Console.WriteLine("Enter the utensils in alphabetical order. (spoon, knife, glass)");
                string input = Console.ReadLine();

                if (CorrectedUtensils(input))
                {
                    Console.Clear();
                    Console.WriteLine("\nYou hear a click from the cupboard!");
                    Console.WriteLine("It is now unlocked. You find a mysterious key.");
                isKeyCollected = true;
                Game.AddInventory("Key 2");
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You arrange the utensils...");
                    Console.WriteLine("The knife comes alive and cuts you!");
                    Game.playerHealth -= 20;
                    Console.WriteLine($"Your health is now {Game.playerHealth}");
                    Console.WriteLine("\nMaybe you didn't do it right...be careful.\n");
                }
 
            goto tryAgain;
        }
        private bool CorrectedUtensils(string input)
        {
            string[] correctOrder = { "glass", "knife", "spoon" };
            string[] arrangedUtensils = input.ToLower().Split(',');

            if (arrangedUtensils.Length != correctOrder.Length)
                return false;

            for (int i = 0; i < correctOrder.Length; i++)
            {
                if ( arrangedUtensils[i].Trim() != correctOrder[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

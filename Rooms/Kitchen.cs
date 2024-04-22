using System;

namespace NarrativeProject.Rooms
{
    internal class Kitchen : Room
    {
        internal static bool iskeyCollected;

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
                        Console.WriteLine("You tried to lift the door open but it's locked...");
                    }
                    else
                    {
                        Console.WriteLine("The door is locked. Perhaps there's a key somewhere...");
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
            Console.WriteLine("What do you want to do? ");
            Console.WriteLine("1. Attempt arranging the utensils.");
            Console.WriteLine("2. Do nothing.");
            string choice = Console.ReadLine(); 

            switch(choice)
            {
                case "1":
                    ArrangeUtensils();
                    break;
                case "2":
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
                    Console.WriteLine("You hear a click from the cupboard!");
                    Console.WriteLine("It is now unlocked. You find a mysterious key.");
                iskeyCollected = true;
                    return;
                }
                else
                {
                    Console.WriteLine("You arrange the utensils...");
                    Console.WriteLine("The knife comes alive and cuts you!");
                    Console.WriteLine("Maybe you didn't do it right...be careful.");
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

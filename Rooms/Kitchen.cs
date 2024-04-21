using System;

namespace NarrativeProject.Rooms
{
    internal class Kitchen : Room
    {
        

        internal override string CreateDescription() =>
@"You step into the kitchen, feeling the darkness of the [hallway] behind you loom ominously...
You are greeted by a dusty table and a lonely [cupboard]. The rooms is filled
with cobwebs on the falling ceiling.
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
            Console.WriteLine("1. Attempt arranging the ustensils.");
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
            Console.WriteLine("You inspect the utensils and carefully arrange them in alphabetical order.");
            if (CorrectedUtensils())
            {
                Console.WriteLine("You hear a click from the cupboard!");
                Console.WriteLine("It is now unlocked. You find a mysterious key.");
            }
            else
            {
                Console.WriteLine("You arrange the utensils");
            }
        }
        private bool CorrectedUtensils()
        {
            string[] correctOrder = { "glass", "knife", "spoon" };
            Console.WriteLine("Enter the utensils in alphabetical order.");
            string input = Console.ReadLine();
            string[] arrangedUtensils = input.ToLower().Split(',');
            for (int i = 0; i<correctOrder.Length; i++)
            {
                if (i >= arrangedUtensils.Length || arrangedUtensils[i].Trim() != correctOrder[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

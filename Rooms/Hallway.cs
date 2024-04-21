using System;


namespace NarrativeProject.Rooms
{
    internal class Hallway : Room
    {
        internal override string CreateDescription() =>
@"You find yourself in a creepy hallway with dim lighting.  
Sinister paintings line the walls. One pair of eyes in one of the paintings[1] 
seem to follow your movements. Two are waiting to be observed...[2] and [3]. You can 
go back to your [bedroom]. Far to your left, you see the [kitchen]. 
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
                
            {
                
                case "1":
                    Console.WriteLine("This painting comes to life," +
                        "\nand grabs you by the neck.");
                    break;
                case "2":
                    Console.WriteLine("This painting ");
                    break;
                case "3": ThirdPainting();
                    break;

                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                case "kitchen":
                    Console.WriteLine("You proceed to go to the kitchen.");
                    Game.Transition<Kitchen>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
        private void ThirdPainting()
        {
            Console.WriteLine("This painting is called The Whispering Woods. " +
    "\nThe painting shows a dense forest. And you can hear something coming from the painting…" +
    "\nWhat to do you want to do?" +
    "\n1.Listen closely to the whispers.\n" +
    "2.Examine the trees for clues.");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("You lean in closely, and from the painting emerges a faint whisper, " +
                        "\nrevealing a mysterious set of numbers: ");
                    break;
                case "2":
                    Console.WriteLine("You examine the trees but find nothing of interest.");
                    break;
            }
        }
    }
}
    

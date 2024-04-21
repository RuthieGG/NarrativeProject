using System;


namespace NarrativeProject.Rooms
{
    internal class Hallway : Room
    {
        internal override string CreateDescription() =>
@"You find yourself in a creepy hallway with dim lighting. 
Sinister paintings line the walls. One pair of eyes in one of the paintings[1] 
seem to follow your movements. Two are waiting to be observed...[2] and [3].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bath":
                    Console.WriteLine("You relax in the bath.");
                    break;
                case "mirror":
                    Console.WriteLine("You see the numbers 6969 written on the fog on your mirror.");
                    break;
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
    

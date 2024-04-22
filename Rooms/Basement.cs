using System;

namespace NarrativeProject.Rooms
{
    internal class Basement : Room
    {
        internal override string CreateDescription() =>
@"Descending into the basement, 
the air grows colder, and the sound of dripping water echoes off the stone walls.
A door ahead catches your eyes. It outlines faintly some light.
Beyond lies the promise of escape, the sunny windy air whispering of freedom!
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

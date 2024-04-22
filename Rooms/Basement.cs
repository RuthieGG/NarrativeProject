using System;

namespace NarrativeProject.Rooms
{
    internal class Basement : Room
    {
        internal override string CreateDescription() =>
@"Descending into the basement, 
the air grows colder, and the sound of dripping water echoes off the stone walls.
A [door] ahead catches your eyes. It outlines faintly some light.
Beyond lies the promise of escape, the sunny windy air whispering of freedom!
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "door":
                    Console.WriteLine("");
                    break;
                case "":
                    Console.WriteLine("");
                    break;
                case "bedroom":
                    Console.WriteLine("");
                    Game.Transition<Bedroom>();
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }
        }
    }
}

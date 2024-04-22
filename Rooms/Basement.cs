using System;

namespace NarrativeProject.Rooms
{
    internal class Basement : Room
    {
        internal override string CreateDescription() =>
@"Descending into the basement...
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
                case "kitchen":
                    Console.WriteLine("You go upstairs...");
                    Game.Transition<Kitchen>();
                    break;
                case "":
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

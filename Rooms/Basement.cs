using System;

namespace NarrativeProject.Rooms
{
    internal class Basement : Room
    {
        internal override string CreateDescription() =>
@"Descending into the basement...
A [door] ahead catches your eyes. It outlines faintly some light.
Beyond lies the promise of escape, the sunny windy air whispering of freedom! 
But you notice a padlock...You can walk up the stairs to the [kitchen].
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "door":
                    //if
                    //{
                    //    Console.WriteLine("You see that there is a combination lock...");
                    //    Console.WriteLine("You need to put the 4 digit numbers.");
                    //}
                    //else
                    //{ 
                    //    Console.WriteLine("The combination ");
                    //    Game.Transition<LastRoom>();
                    //}
                    break;
                case "kitchen":
                    Console.WriteLine("You go back upstairs...");
                    Game.Transition<Kitchen>();
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }
        }
    }
}

﻿using System;

namespace NarrativeProject.Rooms
{
    internal class Basement : Room
    {
        internal override string CreateDescription() =>
@"Descending into the basement...
A [door] ahead catches your eyes. It outlines faintly some light.
Beyond lies the promise of escape, the sunny windy air whispering of freedom! 
But you notice a padlock...
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "door":
                    Console.WriteLine("You see that there is a combination lock...");
                    Console.WriteLine("You need to put 4 numbers.");
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

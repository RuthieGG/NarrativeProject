﻿using System;

namespace NarrativeProject.Rooms
{
    internal class Basement : Room
    {
        private static bool isLastRoomUnlocked = false;
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
                    if(IsLastRoomUnlocked())
                    {
                        Console.WriteLine("This door is already unlock, you proceed to the next room.");
                        Game.Transition<LastRoom>();
                    }
                    else if(string.IsNullOrEmpty(Hallway.combinationCode))
                    {
                        Console.WriteLine("The door is locked. Perhaps you need to find a code...");
                    }
                    else
                    {
                        Console.Clear();
                       Jump2: Console.WriteLine("You see that it requires a combination lock...");
                        Console.WriteLine($"It requires a 4 digit combination code: ");
                        string rightCode = Console.ReadLine();

                        if(rightCode == Hallway.combinationCode)
                        {
                            Console.Clear();
                            Console.WriteLine("The lock clicks open...freedom is yours!");
                            isLastRoomUnlocked = true;
                            Game.Transition<LastRoom>();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You get electrocuted! The door to escape remains locked...");
                            Game.playerHealth -= 20;
                            Console.WriteLine($"Your health is now {Game.playerHealth}");
                            goto Jump2;
                        }
                    }
                    break;
                case "kitchen":
                    Console.WriteLine("You go back upstairs...");
                    Game.Transition<Kitchen>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
        internal static bool IsLastRoomUnlocked()
        {
            return isLastRoomUnlocked;
        }
    }
}

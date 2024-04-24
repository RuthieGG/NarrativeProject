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
                    if(string.IsNullOrEmpty(Hallway.combinationCode))
                    {
                        Console.WriteLine("The door is locked. Perhaps you need to find a code...");
                    }
                    else
                    {
                        Console.WriteLine("You see that it requires a combination lock...");
                        Console.WriteLine($"It requires a 4 digit combination code: ");
                        string rightCode = Console.ReadLine();

                        if(rightCode == Hallway.combinationCode)
                        {
                            Console.WriteLine("The lock clicks open...freedom is yours!");
                            Game.Transition<LastRoom>();
                        }
                        else
                        {
                            Console.WriteLine("You get electrocuted! The door to escape remains locked...");
                            Game.playerHealth -= 20;
                            Console.WriteLine($"Your health is now {Game.playerHealth}");
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
    }
}

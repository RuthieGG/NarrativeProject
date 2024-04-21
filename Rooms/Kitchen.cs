using System;

namespace NarrativeProject.Rooms
{
    internal class Kitchen : Room
    {
        internal static bool isKeyCollected;

        internal override string CreateDescription() =>
@"You step into the [kitchen], feeling the darkness of the [hallway] behind you loom ominously...
You are greeted by a dusty table and a lonely [cupboard]. The rooms is filled
with cobwebs on the falling ceiling.
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bedroom":
                    Console.WriteLine("You return to your bedroom.");
                    Game.Transition<Bedroom>();
                    break;
                case "6969":
                    Console.WriteLine("The chest opens and you get a key.");
                    isKeyCollected = true;
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}

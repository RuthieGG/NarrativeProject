using System;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {

        internal override string CreateDescription() =>
@"You wake up on the floor to a strange bedroom. 
The room only contains a [bed], a [drawer], 
and a broken [mirror]. There is a [teddy bear] nicely tucked in on the bed. 
And you see the door in front of you leads to a [hallway]. 
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "drawer":
                    Console.WriteLine("You open the drawer, revealing a rusty key." +
                        "its cold to the touch. You feel a chill run down your spine as you" +
                        "pocket the key.");
                    break;

                case "bathroom":
                    Console.WriteLine("You enter the bathroom.");
                    Game.Transition<Bathroom>();
                    break;
                case "door":
                    if (!AtticRoom.isKeyCollected)
                    {
                        Console.WriteLine("The door is locked.");
                    }
                    else
                    {
                        Console.WriteLine("You open the door with the key and leave your bedroom.");
                        Game.Finish();
                    }
                    break;
                case "attic":
                    Console.WriteLine("You go up and enter your attic.");
                    Game.Transition<AtticRoom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}

using System;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {

        internal override string CreateDescription() =>
@"You wake up on the cold floor of a strange bedroom. 
The room only contains a [bed], a [drawer], 
and a broken [mirror]. There is a [teddy bear] nicely tucked in on the bed. 
And you see the door in front of you that leads to a [hallway]. 
";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "drawer":
                    Console.WriteLine("You open the drawer, revealing a rusty key." +
                        "\nIt's cold to the touch. " +
                        "You feel a chill run down your spine" +
                        " as you pocket the key.");
                    break;

                case "mirror":
                    Console.WriteLine("As you approach the broken mirror," +
                        "\n you accidently activate a trap!" +
                        "\nYou are struck by flying glass fragments!");
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
                case "teddy bear":
                    Console.WriteLine("A whisper emerges from the eerie teddy bear. " +
                        "\nIts voice barely audible: 'Look under the bed...'");
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}

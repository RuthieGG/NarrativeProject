using System;
using System.Diagnostics.Eventing.Reader;

namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room
    {
        internal static bool isKeyCollected;
        internal static bool isTeddyBearCollected = false;
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
                    isKeyCollected = true;
                    break;

                case "mirror":
                    Console.WriteLine("As you approach the broken mirror," +
                        "\nyou accidently activated a trap!" +
                        "\nYou are struck by flying glass fragments!");
                    break;
                case "hallway":
                    if (!isKeyCollected)
                    {
                        Console.WriteLine("The door is locked. You need to find the key!");
                    }
                    else
                    {
                        Console.WriteLine("You open the door and it leads you to " +
                            "\na dark creepy hallway...");
                        Game.Transition<Hallway>();
                       
                    }
                    break;
                   
                case "teddy bear":
                    if (!isTeddyBearCollected)
                    {
                        Console.WriteLine("You pick up the eerie teddy bear. It talks?");
                        Console.WriteLine("\nI will heal you and keep you safe!");
                        isTeddyBearCollected = true;
                    }
                    else
                    {
                        Console.WriteLine("The teddy bear is already in your inventory...");
                    }
                    break;
                case "bed":
                    Console.WriteLine("You lift the bedsheet, reveals a pair of ominous eyes." +
                        "\nYou quickly lower the sheet.");
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class LastRoom : Room
    {
        internal override string CreateDescription() =>
           @"You open the door, expecting to be greeted by freedom.
Instead, your find yourself in a strange chamber. The illusion of
the outside suddenly fades...
At the center of the room, there is a [pedestal].
It seems like something needs to be placed to finally escape...
Or you can go back to the [basement].";
            internal override  void ReceiveChoice(string choice)
        {
            switch(choice)
            {
                case "pedestal":
                    if (Game.inventory.Contains("Teddy Bear"))
                    {
                        Console.WriteLine("You inspect the pedestal. You place" +
                            "\n the teddy bear inside the slot..." +
                            "\n The random door appears. This time, you escape" +
                            "\n for real!");
                        Game.inventory.Remove("Teddy Bear");
                        Game.Finish();   
                    }
                    else
                    {
                        Console.WriteLine("You inspect the pedestal. It seems to have a teddy bear slot..." +
                            "\nYou need to find a teddy bear...");
                    }
                    break;
                case "basement":
                    { Console.WriteLine("You proceed to go back to the basement.");
                        Game.Transition<Basement>();
                    }
                    
                    break;

            }

        }
    }
}

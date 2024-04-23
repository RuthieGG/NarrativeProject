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
the outside fades...
At the center of the room, there is a pedestal. Its missing a piece.
It seems like something needs to be placed to finally escape...";
            internal override  void ReceiveChoice(string choice)
        {
            switch(choice)
            {

            }

        }
    }
}

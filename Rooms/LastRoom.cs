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
Instead, your find yourself in a  ";
            internal override  void ReceiveChoice(string choice)
        {
            switch(choice)
            {

            }

        }
    }
}

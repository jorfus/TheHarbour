using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Media.Imaging;

namespace TheHarbour.BackEnd
{
    [Serializable]
    class RowBoat : Boat
    {
        public int MaxPassengers { get; private set; }

        public RowBoat()
        {
            TheBoat = new Uri("/Images/rowBoat.png", UriKind.Relative);
            Type = "RowBoat";

            RegistrationNumber = "R-" + RegistrationNumber;

            Weight = Rand.Next(10, 30 + 1) * 10;
            TopSpeed = Rand.Next(0, 3 + 1);
            Size = 1;
            StayTime = 2;

            MaxPassengers = Rand.Next(1, 6 + 1);
        }
    }
}

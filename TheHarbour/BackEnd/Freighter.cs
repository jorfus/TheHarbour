using System;
using System.Collections.Generic;
using System.Text;

namespace TheHarbour.BackEnd
{
    [Serializable]
    class Freighter : Boat
    {
        public int Load { get; private set; }

        public Freighter()
        {
            TheBoat = new Uri("/Images/freighter.png", UriKind.Relative);
            Type = "Freighter";

            RegistrationNumber = "L-" + RegistrationNumber;

            Weight = Rand.Next(30, 200 + 1) * 100;
            TopSpeed = Rand.Next(0, 20 + 1);
            Size = 8;
            StayTime = 7;

            Load = Rand.Next(0, 500 + 1);
        }
    }
}

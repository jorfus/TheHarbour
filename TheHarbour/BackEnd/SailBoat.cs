using System;
using System.Collections.Generic;
using System.Text;

namespace TheHarbour.BackEnd
{
    class SailBoat : Boat
    {
        public int Length { get; private set; }

        public SailBoat()
        {
            TheBoat = new Uri(@"D:\Program\Plugg\.NET\TheHarbour\TheHarbour\Images\sailBoat.png");

            RegistrationNumber = "S-" + RegistrationNumber;

            Weight = Rand.Next(80, 600 + 1) * 10;
            TopSpeed = Rand.Next(0, 12 + 1);
            Size = 4;
            StayTime = 5;

            Length = Rand.Next(10, 60 + 1);
        }
    }
}

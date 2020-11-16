using System;
using System.Collections.Generic;
using System.Text;

namespace TheHarbour.BackEnd
{
    class MotorBoat : Boat
    {
        public int HorsePower { get; private set; }

        public MotorBoat()
        {
            TheBoat = new Uri(@"D:\Program\Plugg\.NET\TheHarbour\TheHarbour\Images\motorBoat.png");

            RegistrationNumber = "M-" + RegistrationNumber;

            Weight = Rand.Next(20, 300 + 1) * 10;
            TopSpeed = Rand.Next(0, 60 + 1);
            Size = 2;
            StayTime = 4;

            HorsePower = Rand.Next(1, 100 + 1) * 10;
        }
    }
}

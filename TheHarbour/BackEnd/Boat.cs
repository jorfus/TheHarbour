using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace TheHarbour.BackEnd
{
    [Serializable]
    class Boat : INotifyPropertyChanged
    {
        string _stayTimeMessage = "N/A"; 

        static Uri[] TheBoatImages { get; set; } = { new Uri("/Images/blue.png", UriKind.Relative),
            new Uri("/Images/darkGray.png", UriKind.Relative)};
        public Uri TheBoat { get; protected set; }
        public string Type { get; protected set; }
        public string RegistrationNumber { get; protected set; }
        public int Weight { get; protected set; }
        public int TopSpeed { get; protected set; }
        protected int StayTime { get; set; }
        public string StayTimeMessage { get { return _stayTimeMessage; } private set { _stayTimeMessage = value; OnPropertyRaised("StayTimeMessage"); } }
        public int Size { get; set; }
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        [field:NonSerialized]
        protected static Random Rand { get; private set; } = new Random();

        public Boat()
        {
            int number;
            int count;

            for (count = 0; count < 3; count++)
            {
                number = Rand.Next(0, 25 + 1);
                RegistrationNumber += (char)('A' + number);
            }
        }
        public Boat(bool emptyBoat)
        {
            if (emptyBoat)
            {
                TheBoat = TheBoatImages[0];
                Type = "Vacant";
            }
            else
                TheBoat = TheBoatImages[1];

            StayTime = 0;
        }

        
        public bool CountDownStay()
        {
            int days = StayTime -= 1;

            if (days == -1)
            {
                StayTime += 1;
                StayTimeMessage = "N/A";
                return false;
            }
            else if (days > 0)
            {
                StayTime = days;
                StayTimeMessage = DepartureMessage();
                return false;
            }
            else
                return true;
        }
        string DepartureMessage()
        {
            switch (StayTime)
            {
                case 1:
                    return "Today";
                case 2:
                    return "Tomorrow";
                default:
                    return $"{StayTime} days";
                    
            }
        }
        void OnPropertyRaised(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public int GetSize()
        {
            return Size;

        }
    }
}

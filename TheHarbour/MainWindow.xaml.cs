using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TheHarbour
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AllBoats AnAllTheBoats { get; set; } = new AllBoats();
        Random Rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
            topControl.DataContext = AnAllTheBoats.TheHorizontalBoatList;
            leftControl.DataContext = AnAllTheBoats.TheLeftVerticalBoatList;
            rightControl.DataContext = AnAllTheBoats.TheRightVerticalBoatList;
        }

        void buttong_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

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
        AllBoats TheAllTheBoats { get; set; } = new AllBoats();
        
        public MainWindow()
        {
            InitializeComponent();
            topList.DataContext = topControl.DataContext = TheAllTheBoats.TheHorizontalBoatList;
            leftList.DataContext = leftControl.DataContext = TheAllTheBoats.TheLeftVerticalBoatList;
            rightList.DataContext = rightControl.DataContext = TheAllTheBoats.TheRightVerticalBoatList;
        }

        void Buttong_Click(object sender, RoutedEventArgs e)
        {
            TheAllTheBoats.NewBoats();
        }
    }
}

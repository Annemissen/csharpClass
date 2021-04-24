using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppExercises
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Switch_Row0(object sender, RoutedEventArgs e)
        {

            //var p1 = this.coord0p0.Parent.GetValue(Grid.GetColumn(this.coord0p0));
            int col1 = Grid.GetColumn(this.coord0p0);
            int col2 = Grid.GetColumn(this.coord2p0);

            Grid.SetColumn(this.coord0p0, col2);
            Grid.SetColumn(this.coord2p0, col1);
        }
        
        private void Button_Click_Switch_Row1(object sender, RoutedEventArgs e)
        {

            //var p1 = this.coord0p0.Parent.GetValue(Grid.GetColumn(this.coord0p0));
            int col1 = Grid.GetColumn(this.coord0p1);
            int col2 = Grid.GetColumn(this.coord2p1);

            Grid.SetColumn(this.coord0p1, col2);
            Grid.SetColumn(this.coord2p1, col1);
        }
    }
}

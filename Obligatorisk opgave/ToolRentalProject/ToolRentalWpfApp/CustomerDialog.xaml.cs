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
using System.Windows.Shapes;
using ToolRentalClassLibrary;

namespace ToolRentalWpfApp
{
    /// <summary>
    /// Interaction logic for CustomerDialog.xaml
    /// </summary>
    public partial class CustomerDialog : Window
    {
        private Customer customer = null;

        public CustomerDialog(Customer c)
        {
            InitializeComponent();

            customer = c;
            customerDialogGrid.DataContext = customer;
        }
    }
}

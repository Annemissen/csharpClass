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
using ToolRentalClassLibrary;

namespace ToolRentalWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ToolRentalDbContext dbContext = new ToolRentalDbContext();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void FindCustomer_Click(object sender, ExecutedRoutedEventArgs e)
        {
            string customerId = customerIdTextBox.Text;
            Console.WriteLine(customerId);
            Customer customer = dbContext.CustomerSet.Find(customerId);
            if (customer != null)
            {
                var customerDialog = new CustomerDialog(customer, dbContext);
                customerDialog.ShowDialog();
            }

        }
    }
}

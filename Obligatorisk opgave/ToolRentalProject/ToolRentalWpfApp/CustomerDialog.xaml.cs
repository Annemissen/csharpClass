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
        CollectionViewSource ReservationsViewSource;
        ToolRentalDbContext dbContext;

        public CustomerDialog(Customer c, ToolRentalDbContext dbContext)
        {
            InitializeComponent();
            this.dbContext = dbContext;

            customer = c;
            customerDialogGrid.DataContext = customer;

            ReservationsViewSource = ((CollectionViewSource)(FindResource("reservationsViewSource")));
            DataContext = this;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void reservationSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = reservationsListView.SelectedItem;
            if (selectedItem is Reservation)
            {
                Reservation reservation = (Reservation)selectedItem;
                //navnTextBox.Text = ticket.Kunde.navn;
                //tlfNrTextBox.Text = ticket.Kunde.tlfNr;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource reservationsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("reservationsViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // biografbilletViewSource.Source = [generic data source]

            //dbContext.ReservationSet.Load();
            ICollection<Reservation> reservations = customer.Reservations;
            ReservationsViewSource.Source = reservations;
        }
    }
}

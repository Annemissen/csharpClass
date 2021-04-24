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
        //CollectionViewSource ReservationsViewSource;
        private ObservableCollection<Reservation> reservations = new ObservableCollection<Reservation>();
        ToolRentalDbContext dbContext;

        public CustomerDialog(Customer c, ToolRentalDbContext dbContext)
        {
            InitializeComponent();
            this.dbContext = dbContext;

            customer = c;
            customerDialogGrid.DataContext = customer;

            List<Reservation> customersReservations = dbContext.ReservationSet.ToList().FindAll(res => res.CustomerRefId == customer.CustomerId);
            foreach (Reservation r in customersReservations)
            {
                reservations.Add(r);
            }
            Console.WriteLine("ANTAL RESERVATIONER: " + customersReservations.Count);
            lbCustomerReservations.ItemsSource = reservations;

            DataContext = this;
        }

        private void ReservationDetails(object sender, SelectionChangedEventArgs e)
        {
            Reservation res = ((sender as ListBox).SelectedItem as Reservation);
            if (res != null)
            {

                int toolId = res.ToolRefId;
                Tool tool = dbContext.ToolSet.Find(toolId);

                int toolTypeId = tool.ToolTypeRefId;
                ToolType toolType = dbContext.ToolTypeSet.Find(toolTypeId);

                tbStart.Text = res.Start.ToString();
                tbEnd.Text = res.End.ToString();
                tbToolId.Text = toolId.ToString();
                tbToolName.Text = toolType.Name;
                reservationStatusComboBox.DataContext = res;
                reservationStatusComboBox.Text = res.ReservationStatus.ToString();
            }
        }

        private void reservationStatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selectedStatus = ((sender as ComboBox).SelectedItem as String);
            Reservation res = (Reservation) lbCustomerReservations.SelectedItem;
            
            //TODO: opdater reservationsobjektet i databasen
            if (selectedStatus == "Reserveret")
            {
                var reservation = ToolRentalDBInitializer.GetToolRentalDbContext().ReservationSet.Find(res.ReservationId);
                reservation.ReservationStatus = ReservationStatus.RESERVERET;
                dbContext.SaveChanges();
            }
            else if (selectedStatus == "Udleveret")
            {
                var reservation = ToolRentalDBInitializer.GetToolRentalDbContext().ReservationSet.Find(res.ReservationId);
                reservation.ReservationStatus = ReservationStatus.UDLEVERET;
                dbContext.SaveChanges();
            }
            else if (selectedStatus == "Tilbageleveret")
            {
                var reservation = ToolRentalDBInitializer.GetToolRentalDbContext().ReservationSet.Find(res.ReservationId);
                reservation.ReservationStatus = ReservationStatus.TILBAGELEVERET;
                dbContext.SaveChanges();
            }

        }

        private void DeleteReservation(object sender, ExecutedRoutedEventArgs e)
        {
            Reservation res = (Reservation)lbCustomerReservations.SelectedItem;
            if (res != null)
            {
                tbStart.Text = "";
                tbEnd.Text = "";
                tbToolId.Text = "";
                tbToolName.Text = "";
                reservationStatusComboBox.Text = "";

                dbContext.ReservationSet.Remove(res);
                dbContext.SaveChanges();

                reservations.Clear();
                List<Reservation> customersReservations = dbContext.ReservationSet.ToList().FindAll(r => r.CustomerRefId == customer.CustomerId);
                foreach (Reservation r in customersReservations)
                {
                    reservations.Add(r);
                }
            }

        }
    }
}

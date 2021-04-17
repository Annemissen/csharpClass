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

            Console.WriteLine("Antal reservationer" + customersReservations.Count);

            lbCustomerReservations.ItemsSource = reservations;

            DataContext = this;
        }

        private void ReservationDetails(object sender, SelectionChangedEventArgs e)
        {
            Reservation res = ((sender as ListBox).SelectedItem as Reservation);
            int toolId = res.ToolRefId;
            Tool tool = dbContext.ToolSet.Find(toolId);

            int toolTypeId = tool.ToolTypeRefId;
            ToolType toolType = dbContext.ToolTypeSet.Find(toolTypeId);

            tbStart.Text = res.Start.ToString();
            tbEnd.Text = res.End.ToString();
            tbToolId.Text = toolId.ToString();
            tbToolName.Text = toolType.Name;
            tbStatus.Text = res.ReservationStatus.ToString();


            //Tool tool = dbContext.ToolSet.ToList().Find(t => t.ToolTypeRefId == )

        }
    }
}

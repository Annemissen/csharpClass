using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Data.Entity;
using EntityFrameworkModel;

namespace øvl02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KunderIBioEntities context = new KunderIBioEntities();
        CollectionViewSource KundeViewSource;
        CollectionViewSource BilletViewSource;

        public MainWindow()
        {
            InitializeComponent();
            KundeViewSource = ((CollectionViewSource)(FindResource("kundeViewSource")));
            BilletViewSource = ((CollectionViewSource)(FindResource("biografbilletViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource biografbilletViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("biografbilletViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // biografbilletViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource kundeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("kundeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // kundeViewSource.Source = [generic data source]

            context.Biografbillet.Load();
            BilletViewSource.Source = context.Biografbillet.Local;
        }

        private void ticketSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = biografbilletListView.SelectedItem;
            if (selectedItem is Biografbillet)
            {
                Biografbillet ticket = (Biografbillet)selectedItem;
                navnTextBox.Text = ticket.Kunde.navn;
                tlfNrTextBox.Text = ticket.Kunde.tlfNr;
            }
        }

        private void CreateTicketHandler(object sender, ExecutedRoutedEventArgs e)
        {
            
            Kunde customer = new Kunde()
            {
                navn = kundeNavnTextBox.Text,
                tlfNr = kundeNrTextBox.Text
            };
            Biografbillet ticket = new Biografbillet()
            {
                dato = (System.DateTime)datoDatePicker.SelectedDate,
                filmnavn = filmnavnTextBox.Text,
                id = int.Parse(idTextBox.Text),
                kundeNr = customer.tlfNr,
                stolenummer = int.Parse(stolenummerTextBox.Text),
                sæderække = int.Parse(sæderækkeTextBox.Text),
                tid = System.TimeSpan.Parse(tidTextBox.Text)
            };
            var ob = context.Kunde.Find(customer.tlfNr);
            if (ob == null)
            {
                context.Kunde.Add(customer);

                context.SaveChanges();
            }
            if (context.Biografbillet.Find(ticket.id) == null)
            {
                context.Biografbillet.Add(ticket);
                context.SaveChanges();
                BilletViewSource.View.Refresh();
            }
            
        }
    }
}

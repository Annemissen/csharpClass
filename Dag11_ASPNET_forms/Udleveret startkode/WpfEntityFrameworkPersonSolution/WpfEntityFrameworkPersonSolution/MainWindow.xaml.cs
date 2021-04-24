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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SolvedExercises {

    public partial class MainWindow : Window {

        private ObservableCollection<Person> people = new ObservableCollection<Person>();

        public MainWindow() {
            InitializeComponent();

            listBox.ItemsSource = people;
            personGrid.DataContext = people;

            Binding binding = new Binding();            
            binding.Path = new PropertyPath("Age");
            binding.Mode = BindingMode.OneWay;
            ageValueLabel.SetBinding(Label.ContentProperty, binding);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var p in Person.GetPeople())
            {
                people.Add(p);
            }
        }

        private void Edit_Dialog_Closed(object sender, EventArgs e) {
            //https://stackoverflow.com/questions/14096414/easy-way-to-refresh-listbox-in-wpf
            listBox.Items.Refresh();

            // Alternatively you can do this:
            // listBox.DisplayMemberPath = "Name";
            // listBox.DisplayMemberPath = null;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var edit = new EditDialog((Person)listBox.SelectedItem);
            edit.Closed += Edit_Dialog_Closed;
            edit.ShowDialog();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Person.getPersonModelContainer().SaveChanges();
        }
    }
}

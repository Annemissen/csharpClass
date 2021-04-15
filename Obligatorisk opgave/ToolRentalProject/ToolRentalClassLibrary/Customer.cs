using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRentalClassLibrary
{
    public class Customer : INotifyPropertyChanged
    {
        private ICollection<Reservation> reservations;


        public Customer()
        {
            Reservations = new List<Reservation>();
        }

        [Key]
        public string CustomerId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }


        public ICollection<Reservation> Reservations
        {
            get { return reservations; }
            set { reservations = value; NotifyPropertyChanged(nameof(Reservations)); }
        }

        // Returns true if adding the reservation was successfull
        public bool AddReservation(Reservation res)
        {
            bool isOverlapping = false;
            // If reservation time period does not overlap any of the existing reservations periods
            foreach (Reservation r in reservations)
            {
                //a.start < b.end && b.start < a.end;
                if (res.Start < r.End && r.Start < res.End)
                {
                    isOverlapping = true;
                }
            }

            if (!isOverlapping)
            {
                Reservations.Add(res);
                NotifyPropertyChanged(nameof(Reservations));
            }

            bool success = isOverlapping ? false : true;
            return success;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

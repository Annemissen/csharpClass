using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRentalClassLibrary
{
    public class Reservation : INotifyPropertyChanged
    {
        
        private Tool tool;
        private Customer customer;
        private ReservationStatus reservationStatus;
        private DateTime start;
        private DateTime end;

        public Reservation(Tool tool, Customer customer, DateTime start, DateTime end)
        {
            Tool = tool;
            // If adding the reservation was unsuccessfull 
            bool reservationWasSuccessfull = Tool.AddReservation(this);
            if (!reservationWasSuccessfull)
            {
                throw new Exception("Tool is not available during this period");
            }
            Customer = customer;
            ReservationStatus = ReservationStatus.PENDING;

            if (start > end)
            {
                throw new Exception("The start of the reservation period must come before the end of the period");
            }
            Start = start;
            End = end;

            customer.AddReservation(this);
        }

        public Reservation()
        {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        }

        [Key]
        public int ReservationId { get; set; }

        
        [ForeignKey("Tool")]
        public int ToolRefId { get; set; }
        public Tool Tool
        {
            get { return tool; }
            set { tool = value; NotifyPropertyChanged(nameof(Tool)); }
        }

        [ForeignKey("Customer")]
        public string CustomerRefId { get; set; }

        public Customer Customer 
        {
            get { return customer; }
            set { customer = value; NotifyPropertyChanged(nameof(Customer)); }
        }

        [Required]
        public ReservationStatus ReservationStatus
        {
            get { return reservationStatus; }
            set { reservationStatus = value; NotifyPropertyChanged(nameof(ReservationStatus)); }
        }

        [Required]
        public DateTime Start
        {
            get { return start; }
            set { start = value; NotifyPropertyChanged(nameof(Start)); }
        }

        [Required]
        public DateTime End
        {
            get { return end; }
            set { end = value; NotifyPropertyChanged(nameof(End)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        //public override String ToString()
        //{
        //    String s = tool.ToolType.Name.ToString() + ": " + tool.ToolType.Description.ToString();
        //    return s;
        //}
    }
}

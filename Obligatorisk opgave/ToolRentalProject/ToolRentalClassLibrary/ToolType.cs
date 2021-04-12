using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRentalClassLibrary
{
    public class ToolType : INotifyPropertyChanged
    {
        private string name;
        private string description;
        private double deposit;
        private double pricePrDay;

        public ToolType(string name, string description, double deposit, double pricePrDay)
        {
            Name = name;
            Description = description;
            Deposit = deposit;
            PricePrDay = pricePrDay;
        }

        public ToolType()
        {
            
        }

        [Key]
        public int Id { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged(nameof(Name)); }
        }

        public string Description
        {
            get { return description; }
            set { description = value; NotifyPropertyChanged(nameof(Description)); }
        }
        public double Deposit
        {
            get { return deposit; }
            set
            {
                if (value < 0)
                {
                    return;
                }
                deposit = value; NotifyPropertyChanged(nameof(Deposit));
            }
        }
        public double PricePrDay
        {
            get { return pricePrDay; }
            set { pricePrDay = value; NotifyPropertyChanged(nameof(PricePrDay)); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

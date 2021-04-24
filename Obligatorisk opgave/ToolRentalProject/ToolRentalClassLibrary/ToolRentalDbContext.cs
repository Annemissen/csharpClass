using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRentalClassLibrary
{
    public class ToolRentalDbContext : DbContext
    {
        public ToolRentalDbContext() : base("ToolRentalDbTestSix")
        {
            Database.SetInitializer(new ToolRentalDBInitializer());
        }

        public DbSet<Reservation> ReservationSet { get; set; }
        public DbSet<ToolType> ToolTypeSet { get; set; }
        public DbSet<Tool> ToolSet { get; set; }
        public DbSet<Customer> CustomerSet { get; set; }
    }
}

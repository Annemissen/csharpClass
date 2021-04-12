using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ToolRentalClassLibrary
{
    public class ToolRentalDBInitializer : DropCreateDatabaseAlways<ToolRentalDbContext>
    {
        public override void InitializeDatabase(ToolRentalDbContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

        /**
         * Initiating database content
         */
        protected override void Seed(ToolRentalDbContext context)
        {
            // TOOLTYPES
            context.ToolTypeSet.Add(new ToolType("Havetromle", "Bruges til græsplænen for at jævne den", 100.0, 25.5));
            context.ToolTypeSet.Add(new ToolType("Kompostkværn", "Lydsvag kompostkværn med valsesystem", 125.0, 55.0));
            context.ToolTypeSet.Add(new ToolType("Vinkelsliber", "Praktisk 800 W compact-vinkelsliber til afgratnings-, slibe- og skærearbejde", 40.0, 29.5));
            context.ToolTypeSet.Add(new ToolType("Gulvslibemaskine", "Slibemaskine til gulv", 1500.0, 95.0));
            context.ToolTypeSet.Add(new ToolType("Motorsav", "Effektiv kædesav udstyret med en kraftfuld 1800 W motor", 400, 49.0));

            context.SaveChanges();

            // TOOLS
            List<ToolType> toolTypes = context.ToolTypeSet.ToList();

            // Havetromle x2
            ToolType havetromle = toolTypes.Find(toolType => toolType.Name == "Havetromle");
            context.ToolSet.Add(new Tool(havetromle));
            context.ToolSet.Add(new Tool(havetromle));

            // Kompostkværn x2
            ToolType kompostværn = toolTypes.Find(toolType => toolType.Name == "Kompostkværn");
            context.ToolSet.Add(new Tool(kompostværn));
            context.ToolSet.Add(new Tool(kompostværn));

            // Vinkelsliber x3
            ToolType vinkelsliber = toolTypes.Find(toolType => toolType.Name == "Vinkelsliber");
            context.ToolSet.Add(new Tool(vinkelsliber));
            context.ToolSet.Add(new Tool(vinkelsliber));
            context.ToolSet.Add(new Tool(vinkelsliber));

            // Gulvslibemaskine x1
            ToolType gulvslibemaskine = toolTypes.Find(toolType => toolType.Name == "Gulvslibemaskine");
            context.ToolSet.Add(new Tool(gulvslibemaskine));

            // Motorsav x1
            ToolType motorsav = toolTypes.Find(toolType => toolType.Name == "Motorsav");
            context.ToolSet.Add(new Tool(motorsav));

            context.SaveChanges();


            // CUSTOMERS
            context.CustomerSet.Add(new Customer() { CustomerId = "anderhansen@mail.dk", Password = "anders", Name = "Anders Hansen", Address = "F. Vestersgaards Gade 16, 8000 Aarhus C" });
            context.CustomerSet.Add(new Customer() { CustomerId = "lonejensen@mail.dk", Password = "lone", Name = "Lone Jensen", Address = "Jens Baggesens Vej 42, 8200 Aarhus N" });
            context.CustomerSet.Add(new Customer() { CustomerId = "hanneandersen@mail.dk", Password = "hanne", Name = "Hanne Andersen", Address = "Langballevej 126, 8320 Mårslet" });
            context.CustomerSet.Add(new Customer() { CustomerId = "sunegammelgaard@mail.dk", Password = "sune", Name = "Sune Gammelgaard", Address = "Langballevej 126, 8320 Mårslet" });
            context.CustomerSet.Add(new Customer() { CustomerId = "daniel.pedersen@example.com", Password = "daniel", Name = "Daniel Pedersen", Address = "Kongevejen 25, 8920 Randers NV" });
            context.CustomerSet.Add(new Customer() { CustomerId = "lea.moller@example.com", Password = "lea", Name = "Lea Møller", Address = "Linde Alle 57, 8000 Aarhus C" });

            context.SaveChanges();


            // RESERVATIONS
            List<Tool> tools = context.ToolSet.ToList();
            List<Customer> customers = context.CustomerSet.ToList();

            // Anders Hansen har indsendt en anmodning om at reserverere en havetromle.
            Customer andersHansen = customers.Find(c => c.CustomerId == "anderhansen@mail.dk");
            List<Tool> havetromler = tools.FindAll(t => t.ToolType.Name == "Havetromle");
            Console.WriteLine(havetromler.Count);
            Tool havetromle1 = havetromler[0];
            context.ReservationSet.Add(new Reservation(havetromle1, andersHansen, new DateTime(2021, 4, 2), new DateTime(2021, 4, 4)));

            // Lone Jensen har afhentet en reserveret vinkelsliber
            Customer loneJensen = customers.Find(c => c.CustomerId == "lonejensen@mail.dk");
            Tool vinkelSliberOne = tools.Find(t => t.ToolType.Name == "Vinkelsliber");
            Reservation loneReservation = new Reservation(vinkelSliberOne, loneJensen, new DateTime(2021, 4, 4), new DateTime(2021, 4, 7));
            loneReservation.ReservationStatus = ReservationStatus.EXTRADITED;
            context.ReservationSet.Add(loneReservation);

            
            // Lone Jensen har indsendt en anmodning om at reserverere en havetromle.
            Tool havetromle2 = havetromler[1];
            context.ReservationSet.Add(new Reservation(havetromle2, loneJensen, new DateTime(2021, 4, 2), new DateTime(2021, 4, 4)));
            

            // Hanne Andersen har tilbageleveret en lejet kompostkværn
            Customer hanneAndersen = customers.Find(c => c.CustomerId == "hanneandersen@mail.dk");
            Tool kompostkværnOne = tools.Find(t => t.ToolType.Name == "Kompostkværn");
            Reservation hanneReservation = new Reservation(kompostkværnOne, hanneAndersen, new DateTime(2021, 4, 1), new DateTime(2021, 4, 3));
            hanneReservation.ReservationStatus = ReservationStatus.RETURNED;
            context.ReservationSet.Add(hanneReservation);


            // Sune Gammelgaard har fået accepteret sin reservation af en gulvslibemaskine
            Customer suneGammelgaard = customers.Find(c => c.CustomerId == "sunegammelgaard@mail.dk");
            Tool gulvslibemaskineOne = tools.Find(t => t.ToolType.Name == "Gulvslibemaskine");
            Reservation suneReservation = new Reservation(gulvslibemaskineOne, suneGammelgaard, new DateTime(2021, 4, 2), new DateTime(2021, 4, 4));
            hanneReservation.ReservationStatus = ReservationStatus.RESERVED;
            context.ReservationSet.Add(suneReservation);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
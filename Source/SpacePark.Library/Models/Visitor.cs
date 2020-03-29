using SpacePark.Library.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace SpacePark.Library.Models
{
   
   
    public class Visitor 
    {        
        public int VisitorID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }    
        public bool HasPaid { get; set; }
      
        public static void ChangePaymentStatus(SpaceParkContext context, Visitor VisitorToPay)
        {
            if (VisitorToPay.HasPaid == false)
            {
                VisitorToPay.HasPaid = true;

                var parking = VisitorParking.GetSpecificVisitorParking(context, VisitorToPay);

                var parkingLot = ParkingLot.GetSpecificParkingLot(context, parking);
                parkingLot.ParkingLotOccupied = false;

                context.SaveChanges();

                StandardMessaging.ThankYouForYourStay();
                //Console.WriteLine("Thank you for your stay, hope to see you soon Booyyyyyyy!");
                Console.ReadLine();
            }
            else
            {
                StandardMessaging.NoValidInput("Couldn't find you in db. Or something just doesn't work ;)");
                //Console.WriteLine("Couldn't find you in db. Or something just doesn't work");
            }
        }

        public static Visitor GetPayingVisitor(SpaceParkContext context, string visitorName)
        {
            return context.Visitors.Where(visitor => visitor.Name == visitorName && visitor.HasPaid == false).FirstOrDefault();
        }

        public static void AddVisitorToDB(SpaceParkContext context, Visitor visitor)
        {
           
            
            //visitor = new Visitor
            //{
            //   Name = visitor.Name,
            //   HasPaid = false
            //};
            context.Visitors.Add(visitor);
            context.SaveChanges();
           
        }

        public static void ShowCurrentVisitorsList(SpaceParkContext context)
        {
            var visitors = context.Visitors.Where(visitor=> visitor.HasPaid == false).ToList();
            Console.WriteLine("Current guests");    
            foreach (var visitor in visitors)
            {
                Console.WriteLine($"Name: {visitor.Name}              ID:{visitor.VisitorID}");
            }
            Console.WriteLine("\n");
        }

       

    }

}

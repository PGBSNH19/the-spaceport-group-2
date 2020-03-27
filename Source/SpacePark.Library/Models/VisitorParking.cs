using SpacePark.Library.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SpacePark.Library.Models
{
    public class VisitorParking
    {
        public int VisitorParkingID { get; set; }
        public int ParkingLotID { get; set; }
        public ParkingLot ParkingLot { get; set; }
        public int VisitorID { get; set; }
        public Visitor Visitor { get; set; }
        public DateTime DateOfEntry { get; set; }



        

        public static VisitorParking GetSpecificVisitorParking(SpaceParkContext context, Visitor visitor )
        {
                return context.VisitorParking
                    .Where(parking => parking.VisitorID == visitor.VisitorID)
                    .FirstOrDefault();
        }

        public static void AddVisitorParking(SpaceParkContext context, ParkingLot parkingSpace, Visitor visitor)
        {
            var visitorParking = new VisitorParking
            {
                VisitorID = visitor.VisitorID,
                ParkingLotID = parkingSpace.ParkingLotID
            };
            context.VisitorParking.Add(visitorParking);
            context.SaveChanges();
        }
    }
}

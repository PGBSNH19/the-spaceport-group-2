﻿using SpacePark.Library.Context;
using System;
using System.Linq;

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
                ParkingLotID = parkingSpace.ParkingLotID,
                DateOfEntry = DateTime.Now
            };
            context.VisitorParking.Add(visitorParking);
            context.SaveChanges();
        }
    }
}

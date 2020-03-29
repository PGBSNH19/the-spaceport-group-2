using SpacePark.Library.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpacePark.Library.Models
{
    public class ParkingLot
    {
        public int ParkingLotID { get; set; }
        public bool ParkingLotOccupied { get; set; }
        public int SpacePortID { get; set; }
        public SpacePort SpacePort { get; set; }


        public static ParkingLot GetSpecificParkingLot(SpaceParkContext context, VisitorParking parking)
        {

            return context.ParkingLots
                    .Where(parkingLot => parkingLot.ParkingLotID == parking.ParkingLotID)
                    .FirstOrDefault();                               
        }

        public static void CheckParkingSpaces(SpaceParkContext context, SpacePort spacePort)
        {
            var rec = context.ParkingLots.FirstOrDefault();

            if (rec == null)
            {
                for (int i = 0; i < spacePort.ParkingSpace; i++)
                {
                    ParkingLot parking = new ParkingLot
                    {
                        ParkingLotOccupied = false,
                        SpacePortID = spacePort.SpacePortID
                    };

                    context.ParkingLots.Add(parking);
                    context.SaveChanges();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark.Library.Models
{
    public class ParkingLot
    {
        public int ParkingLotID { get; set; }
        public bool ParkingLotOccupied { get; set; }

      
        public int SpacePortID { get; set; }

        public ICollection<VisitorParking> VisitorParking { get; set; }
    }
}

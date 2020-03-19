using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark.Library.Models
{
    public class ParkingLot
    {
        public int ParkingLotID { get; set; }
        public bool ParkingLotOccupied { get; set; }

        public int VisitorID { get; set; }
        public Visitor Visitor { get; set; }

        public int SpacePortID { get; set; }
        public SpacePort SpacePort { get; set; }
    }
}

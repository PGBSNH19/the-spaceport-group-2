using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark.Library.Models
{                   //ParkeringsRutan
    public class Parking
    {
        public int ParkingID { get; set; }
        public bool ParkingOccupied { get; set; }
        public int SpacePortID { get; set; }
    }
}

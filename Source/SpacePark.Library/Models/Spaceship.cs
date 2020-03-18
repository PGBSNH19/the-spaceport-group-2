using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark.Library.Models
{
    public class Spaceship
    {
        public int SpaceshipID { get; set; }      
        public int VisitorID { get; set; }
        public Visitor Visitor { get; set; }
        public ParkingLot ParkingLot { get; set;  }
        public int ParkingLotID { get; set; }
    }
}
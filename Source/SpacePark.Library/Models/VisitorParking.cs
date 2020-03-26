using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
    }
}

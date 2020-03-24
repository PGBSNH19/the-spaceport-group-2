using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpacePark.Library.Models
{
    public enum IsOccupied
    {
        Occupied,
        NotOccupied
    }

    public class VisitorParking
    {
        public int VisitorParkingID { get; set; }
        public int ParkingLotID { get; set; }
        public ParkingLot ParkingLot { get; set; }
        public int VisitorID { get; set; }

        
        public Visitor Visitor { get; set; }

        // public ICollection<Visitor> Visitors { get; set; }
        //public int ParkingNO { get; set; }


        [NotMapped]
        public IsOccupied Status { get; set; }

    }
}

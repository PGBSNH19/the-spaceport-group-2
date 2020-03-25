using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpacePark.Library.Models
{

    public class VisitorParking
    {
        public int VisitorParkingID { get; set; }
        public Parking Parking { get; set; }
        public int ParkingID { get; set; }
        public Visitor Visitor { get; set; }
        public int VisitorID { get; set; }
        public DateTime ArrivalDate { get; set; }
        public Receipt Receipt { get; set; }
        public int ReceiptID { get; set; }
    }
}

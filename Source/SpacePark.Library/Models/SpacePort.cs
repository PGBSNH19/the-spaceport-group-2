using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpacePark.Library.Models
{
    public enum PortStatus
    {
        Open,
        Closed
    }

    public class SpacePort
    {
        [NotMapped]
        public string Name { get; set; } //William Added
        public int SpacePortID { get; set; }
        public int ParkingSpace { get; set; }
        public PortStatus Status { get; set; }


        public List<ParkingLot> ParkingLots { get; set; } = new List<ParkingLot>(); 
              
    }
}
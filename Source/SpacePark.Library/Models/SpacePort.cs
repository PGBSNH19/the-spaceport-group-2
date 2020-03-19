using System;
using System.Collections.Generic;
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
        public int SpacePortID { get; set; }
        public int ParkingSpace { get; set; }
        public PortStatus Status { get; set; }

        public List<ParkingLot> ParkingLots { get; set; }
    }
}
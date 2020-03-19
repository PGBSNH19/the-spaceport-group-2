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
        public string Name { get; set; } //William Added
        public int SpacePortID { get; set; }
        public int ParkingSpace { get; set; }
        public PortStatus Status { get; set; }

        public List<ParkingLot> ParkingLots { get; set; }

        public SpacePort(string Name,int SpacePortID, int ParkingSpace, PortStatus Status)
        {
            this.SpacePortID = SpacePortID;
            this.ParkingSpace = ParkingSpace;
            this.Status = Status;
        }

    }
}
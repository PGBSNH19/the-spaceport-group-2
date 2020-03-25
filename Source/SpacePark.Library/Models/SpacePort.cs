using SpacePark.Library.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SpacePark.Library.Models
{
    public enum PortStatus
    {
        Open,
        Closed
    }
                // This is the whole parkingLot
    public class SpacePort
    {
        [NotMapped]
        public string Name { get; set; } //William Added
        public int SpacePortID { get; set; }
        public int ParkingSpace { get; set; } // Amount of Parkings
        public PortStatus Status { get; set; }
        public List<Parking> Parkings { get; set; } = new List<Parking>();

        public static SpacePort CreateSpacePort(SpaceParkContext context)
        {
            var exist = context.SpacePorts.FirstOrDefault();       
            var pSpots = new SpacePort
            {
                ParkingSpace = 5,
                Status = PortStatus.Open
            };

            if (exist == null)
            {
                context.SpacePorts.Add(pSpots);
                context.SaveChanges();

            }

            return pSpots;
        }
    }
}
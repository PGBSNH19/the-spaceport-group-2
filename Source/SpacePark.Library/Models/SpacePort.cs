﻿using SpacePark.Library.Context;
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

    public class SpacePort
    {
        [NotMapped]
        public string Name { get; set; } //William Added

        public int SpacePortID { get; set; }
        public int ParkingSpace { get; set; }
        public PortStatus Status { get; set; }


        public List<ParkingLot> ParkingLots { get; set; } = new List<ParkingLot>();


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


        //public List<ParkingLot> ParkingLots { get; set; }

        //public SpacePort(string Name, int SpacePortID, int ParkingSpace, PortStatus Status)
        //{
        //    this.ParkingLots = ParkingLots;
        //    this.Name = Name;
        //    this.SpacePortID = SpacePortID;
        //    this.ParkingSpace = ParkingSpace;
        //    this.Status = Status;
        //}




    }
}
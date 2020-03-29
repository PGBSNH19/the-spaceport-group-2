using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpacePark.Library.Context;
using SpacePark.Library.Models;

namespace SpacePark
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new SpaceParkContext();
            // Creates a brand new SpacePort Garage if we do not have one already
            SpacePort spacePort = SpacePort.CreateSpacePort(context);
            ParkingLot.CheckParkingSpaces(context, spacePort);

            Menu.GenerateProgram(context);
        }

    } 
}

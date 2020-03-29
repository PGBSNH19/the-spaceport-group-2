using SpacePark.Library.Context;
using SpacePark.Library.Models;

namespace SpacePark
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new SpaceParkContext();

            SpacePort spacePort = SpacePort.CreateSpacePort(context);
            ParkingLot.CheckParkingSpaces(context, spacePort);

            Menu.GenerateProgram(context);
        }
    } 
}

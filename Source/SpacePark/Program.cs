using System;
using System.Linq;
using System.Threading.Tasks;
using SpacePark.Library.Context;
using SpacePark.Library.Models;

namespace SpacePark
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new SpaceParkContext();

            CreateHeader();

            // Creates a brand new SpacePort Garage...We only need on to start with!
            //SpacePort spacePort = CreateSpacePort(context);


            var availableSpaces = context.ParkingLots.ToList();

            foreach (var item in availableSpaces)
            {
                Console.WriteLine(item.ParkingLotID);
            }


            while (availableSpaces.Count <= 5)
            {
                availableSpaces = context.ParkingLots.ToList();

                Console.WriteLine($"Available spaces: { availableSpaces.Count }");
                Console.WriteLine($"            Welcome to !\n\n");
                Console.WriteLine("Please enter your information");
                Console.WriteLine();
                Console.Write("Name: ");
                var visitorName = Console.ReadLine();
                var visitorArray = await PeopleAPI.ProcessPeople(visitorName);

                // Adding visitor to DB
                var theVisitor = visitorArray.VisitorResult[0];
                Visitor visitor = new Visitor
                {
                    Name = theVisitor.Name,
                    Status = HasPaid.NotPaid
                };
                context.Visitors.Add(visitor);
                context.SaveChanges();

                // Occupying a single parkinglot/space
                var parkingspace = new ParkingLot
                {
                    ParkingLotOccupied = true
                };
                context.ParkingLots.Add(parkingspace);
                context.SaveChanges();

                // Bringing it together in VisitorParking to keep track of who parked where
                var visitorParking = new VisitorParking
                {
                    VisitorID = visitor.VisitorID,
                    ParkingLotID = parkingspace.ParkingLotID
                };
                context.VisitorParking.Add(visitorParking);
                context.SaveChanges();

                Console.WriteLine($"Available spaces: { availableSpaces.Count }");

            }
            Console.WriteLine($"Available spaces: { availableSpaces.Count }");














            //while (pSpots.ParkingLots.Count <= 5)
            //{
            //    if (visitorArray.VisitorResult.Length != 0 || visitorArray.VisitorResult == null)
            //    {

            //        foreach (var v in visitorArray.VisitorResult)
            //        {
            //            if (v.Name.ToLower().Contains(visitorName.ToLower()))
            //            {
            //                var theVisitor = visitorArray.VisitorResult[0];
            //                Console.WriteLine(theVisitor.Name);
            //                Console.WriteLine();

            //                Console.WriteLine();
            //                Console.WriteLine($"Which ship are you flying today?");
            //                var visitorShip = Console.ReadLine();
            //                var starWars = await StarwarsAPI.ProcessSpaceShips(visitorShip);

            //                Console.WriteLine(starWars.Spaceships[0].Name);


            //                Visitor visitor = new Visitor
            //                {
            //                    Name = theVisitor.Name,
            //                    Status = HasPaid.NotPaid,
            //                };


            //                context.Visitors.Add(visitor);
            //                context.SaveChanges();
            //                ParkingLot parkingLot = new ParkingLot
            //                {

            //                    ParkingLotOccupied = true,
            //                    ParkingLotNO = 1
            //                };

            //                context.ParkingLots.Add(parkingLot);
            //                context.SaveChanges();

            //                VisitorParking visitorParking = new VisitorParking
            //                {
            //                    ParkingLotID = parkingLot.ParkingLotID,
            //                    VisitorID = visitor.VisitorID,
            //                    ParkingNO = 1
            //                };

            //                context.VisitorParking.Add(visitorParking);
            //                context.SaveChanges();

            //            }

            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("I'm sorry to inform you that you do not have the required qualifications to enter our SpacePort.");
            //        Console.WriteLine();
            //    }

            //}

        }

        private static SpacePort CreateSpacePort(SpaceParkContext context)
        {
            var pSpots = new SpacePort
            {
                ParkingSpace = 5,
                Status = PortStatus.Open
            };
            context.SpacePorts.Add(pSpots);
            context.SaveChanges();
            return pSpots;
        }

        private static void CreateHeader()
        {
            var header = new[]
           {
                    @"       ,---.                                  ,------.         ,---.               ,--.           ",
                    @"      '   .-'  ,---.  ,--,--. ,---. ,---.     |  .--. ' ,---. /  .-',--.,--. ,---. |  |           ",
                    @"      `.  `-. | .-. |' ,-.  || .--'| .-. :    |  '--'.'| .-. :|  `-,|  ||  || .-. :|  |           ",
                    @"      .-'    || '-' '\ '-'  |\ `--.\   --.    |  |\  \ \   --.|  .-''  ''  '\   --.|  |           ",
                    @"      `-----' |  |-'  `--`--' `---' `----'    `--' '--' `----'`--'   `----'  `----'`--'  .         ",
                    @"              `--'                                                                                "

            };

            Console.WindowWidth = 100;
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (string line in header)
            {
                Console.WriteLine(line);
            }
        }
    } 
}

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

            // Creates a brand new SpacePort Garage if we do not have one already
            SpacePort spacePort = CreateSpacePort(context);

            CheckParkingSpaces(context, spacePort);

            CreateHeader();

            await DisplayMenu(context);
        }

        private static async Task DisplayMenu(SpaceParkContext context)
        {
            while (true)
            {
                Console.WriteLine("Press 1 to park: ");
                Console.WriteLine("Press 2 to pay: ");
                Console.WriteLine();
                Console.Write(">>> ");
                var userChoice = Convert.ToInt32(Console.ReadLine());

                if (userChoice == 1)
                {
                    Console.Clear();
                    await RentParkingSpace(context);
                }
                else
                {
                    Console.Clear();
                    await ClearParkingSpace(context);
                }
            }
        }

        private static async Task ClearParkingSpace(SpaceParkContext context)
        {
            // Not yet implemented!
            Console.Write("Name: ");
            var visitorName = Console.ReadLine();
            Console.WriteLine(visitorName);
        }

        private static async Task RentParkingSpace(SpaceParkContext context)
        {
            var parkingSpaces = context.Parkings.ToList();

            var occupiedSpaces = context.Parkings.Where(p => p.ParkingOccupied == true).ToList();

            if (occupiedSpaces.Count == 5)
            {
                Console.WriteLine("We full!");
            }
            else
            {
                foreach (var parkingSpace in parkingSpaces)
                {
                    Console.Clear();
                    if (parkingSpace.ParkingOccupied == false)
                    {
                        Console.WriteLine($"            Welcome to !\n\n");
                        Console.WriteLine("Please enter your information");
                        Console.WriteLine();
                        Console.Write("Name: ");
                        var visitorName = Console.ReadLine();
                        var visitorArray = await PeopleAPI.ProcessPeople(visitorName);

                        // Adding visitor to DB
                        Visitor visitor = AddVisitorToDB(context, visitorArray);

                        // Changing parking space to occupado!
                        parkingSpace.ParkingOccupied = true;

                        // Bringing it together in VisitorParking to keep track of who parked where
                        UpdateVisitorParking(context, parkingSpace, visitor);

                        break;
                    }
                }
            }
        }

        private static void CheckParkingSpaces(SpaceParkContext context, SpacePort spacePort)
        {
            var rec = context.Parkings.FirstOrDefault();

            if (rec == null)
            {
                for (int i = 0; i < spacePort.ParkingSpace; i++)
                {
                    Parking parking = new Parking
                    {
                        ParkingOccupied = false,
                        ParkingID = spacePort.SpacePortID
                    };

                    context.Parkings.Add(parking);
                    context.SaveChanges();
                }
            }
        }

        private static void UpdateVisitorParking(SpaceParkContext context, Parking parkingSpace, Visitor visitor)
        {
            var visitorParking = new VisitorParking
            {
                VisitorID = visitor.VisitorID,
                ParkingID = parkingSpace.ParkingID
            };
            context.VisitorParking.Add(visitorParking);
            context.SaveChanges();
        }

        private static Visitor AddVisitorToDB(SpaceParkContext context, VisitorArray visitorArray)
        {
            var theVisitor = visitorArray.VisitorResult[0];
            Visitor visitor = new Visitor
            {
                Name = theVisitor.Name,
                Status = HasPaid.NotPaid
            };
            context.Visitors.Add(visitor);
            context.SaveChanges();
            return visitor;
        }

        private static SpacePort CreateSpacePort(SpaceParkContext context)
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

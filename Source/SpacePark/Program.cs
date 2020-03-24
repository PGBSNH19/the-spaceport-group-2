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

            while (true)
            {
                Console.WriteLine("Press 1 to park: ");
                Console.WriteLine("Press 2 to pay: ");
                var userChouice = Convert.ToInt32(Console.ReadLine());

                if (userChouice == 1)
                {
                    Console.Clear();
                    await RentParkingSpace(context);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Paying");
                }
            }
        }

        private static async Task VacateParkingSpace(SpaceParkContext context)
        {
            Console.WriteLine("Enter your ");
            Console.WriteLine();
            Console.Write("Name: ");
            var visitorName = Console.ReadLine();
        }

        private static async Task RentParkingSpace(SpaceParkContext context)
        {
            var parkingSpaces = context.ParkingLots.ToList();

            foreach (var parkingSpace in parkingSpaces)
            {
                while (parkingSpace.ParkingLotOccupied == false)
                {
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

                    // Bringing it together in VisitorParking to keep track of who parked where
                    var visitorParking = new VisitorParking
                    {
                        VisitorID = visitor.VisitorID,
                        ParkingLotID = parkingSpace.ParkingLotID
                    };

                    // Changing parking space to occupado!
                    parkingSpace.ParkingLotOccupied = true;

                    context.VisitorParking.Add(visitorParking);
                    context.SaveChanges();
                }
            }
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

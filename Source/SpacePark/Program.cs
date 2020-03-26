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
       static List<ParkingLot> occupiedSpaces; 

        static async Task Main(string[] args)
        {
            using var context = new SpaceParkContext();

            // Creates a brand new SpacePort Garage if we do not have one already
            SpacePort spacePort = SpacePort.CreateSpacePort(context);

            CheckParkingSpaces(context, spacePort);

            await Menu(context);
        }
        private static async Task Menu(SpaceParkContext context)
        {
            var temp ="0";
            do
            {
                CreateHeader();
                Visitor.ShowCurrentVisitors(context);
                Console.WriteLine("Press 1 => Park");
                Console.WriteLine("Press 2 => Pay");
                Console.WriteLine("Press 0 => Exit");
                temp= Console.ReadLine();

                Console.Clear();
                switch (temp)
                {
                    case "1":
                        await RentParkingSpace(context);
                        Console.Clear();
                        break;
                    case "2":
                        ClearParkingSpace(context);
                        Console.Clear();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("No valid input");
                        break;
                }
            } while (temp != "0");
        }

        private static void ClearParkingSpace(SpaceParkContext context)
        {
            Console.Write("Name: ");
            var visitorName = Console.ReadLine();

            Console.WriteLine(visitorName);
            Visitor VisitorToPay = context.Visitors.Where(visitor => visitor.Name == visitorName && visitor.HasPaid == false).FirstOrDefault();

            if (VisitorToPay.HasPaid == false)
            {
                VisitorToPay.HasPaid = true;
                VisitorParking parking = context.VisitorParking
                    .Where(parking => parking.VisitorID == VisitorToPay.VisitorID)
                    .FirstOrDefault();
                
                ParkingLot parkingLot = context.ParkingLots
                    .Where(parkingLot => parkingLot.ParkingLotID == parking.ParkingLotID)
                    .FirstOrDefault();
                parkingLot.ParkingLotOccupied = false;

                context.SaveChanges();

                Console.WriteLine("Thank you for your stay, hope to see you soon Booyyyyyyy!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Couldn't find you in db. Or something just doesn't work");
            }
        }

        private static async Task RentParkingSpace(SpaceParkContext context)
        {
            var parkingSpaces = context.ParkingLots.ToList();

            occupiedSpaces = context.ParkingLots
                .Where(p => p.ParkingLotOccupied == true)
                .ToList();

            if (occupiedSpaces.Count == 5)
            {
                Console.WriteLine("Max Capacity Reached!");
                Console.ReadLine();
            }
            else
            {
                foreach (var parkingSpace in parkingSpaces)
                {
                    Console.Clear();
                    if (parkingSpace.ParkingLotOccupied == false)
                    {
                        Console.WriteLine("Please enter your information");
                        Console.WriteLine();
                        Console.Write("Name: ");
                        var visitorName = Console.ReadLine();
                        var visitorArray = await PeopleAPI.ProcessPeople(visitorName);

                        var checkVisitor = visitorArray.VisitorResult
                            .Where(x => x.Name.Contains(visitorName))
                            .FirstOrDefault();

                        Console.Write("Ship: ");
                        var shipName = Console.ReadLine();
                        var ships = await StarwarsAPI.ProcessSpaceShips(shipName);

                        var checkShip = ships.Spaceships
                            .Where(x => x.Name.Contains(shipName))
                            .FirstOrDefault();

                        // Adding visitor to DB
                        if (checkVisitor != null && !string.IsNullOrWhiteSpace(visitorName)
                            && checkShip != null && !string.IsNullOrWhiteSpace(shipName))
                        {
                            Spaceship spaceShip = Spaceship.CreateShip(ships);
                            Visitor visitor = Visitor.AddVisitorToDB(context, visitorArray);
                            Console.WriteLine($"Your have now parked at parking number: {parkingSpace.ParkingLotID} please remember your visitor ID : {visitor.VisitorID} SpaceShip: {spaceShip.Name}");
                            Console.ReadLine();

                            // Changing parking space to occupado!
                            parkingSpace.ParkingLotOccupied = true;

                            // Bringing it together in VisitorParking to keep track of who parked where
                            VisitorParking.AddVisitorParking(context, parkingSpace, visitor);
                        }
                        else
                        {
                            Console.WriteLine("Try again! Security has been notified of your presence puny human pleb kekW getrekt son..!");
                            Console.ReadLine();
                        }
                    break;
                    }
                }
            }
        }

        private static void CheckParkingSpaces(SpaceParkContext context, SpacePort spacePort)
        {
            var rec = context.ParkingLots.FirstOrDefault();

            if (rec == null)
            {
                for (int i = 0; i < spacePort.ParkingSpace; i++)
                {
                    ParkingLot parking = new ParkingLot
                    {
                        ParkingLotOccupied = false,
                        SpacePortID = spacePort.SpacePortID
                    };

                    context.ParkingLots.Add(parking);
                    context.SaveChanges();
                }
            }
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

            Console.WriteLine("\n\n");
        }
    } 
}

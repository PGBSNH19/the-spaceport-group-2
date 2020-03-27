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
                temp = Console.ReadLine();

                Console.Clear();
                switch (temp)
                {
                    case "1":
                        await RentParkingSpace(context);
                        Console.Clear();
                        break;
                    case "2":
                        UpdateVisitorAndParkingLot(context);
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

        private static string ReadUserInput(string message)
        {           
            Console.Write(message);
            var output = Console.ReadLine();
          
            return output;
        }

        private static void UpdateVisitorAndParkingLot(SpaceParkContext context)
        {
            var visitorName = ReadUserInput("Name: ");
          
            Visitor VisitorToPay = Visitor.GetPayingVisitor(context, visitorName);                               
          
            if (VisitorToPay.HasPaid == false)
            {
                VisitorToPay.HasPaid = true;

                var parking = VisitorParking.GetSpecificVisitorParking(context, VisitorToPay);
               
                var parkingLot = ParkingLot.GetSpecificParkingLot(context, parking);
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
            var parkingSpaces = context.ParkingLots.Where(p => p.ParkingLotOccupied == false).ToList();
       
            if (parkingSpaces.Count >= 1)
            {
                Console.WriteLine("Please enter your information");
                Console.WriteLine();

                var visitorName = ReadUserInput("Name: ");
                var visitorArray = await PeopleAPI.GetStarWarsCharacters(visitorName);
                               
                var currentVisitor = visitorArray.VisitorResult
                           .Where(x => x.Name.ToLower().Contains(visitorName.ToLower()))
                           .FirstOrDefault();

                var shipName = ReadUserInput("Ship: ");
                var ships = await PeopleAPI.GetStarWarsSpaceShips(shipName);

                var checkShip = ships.Spaceships
                    .Where(x => x.Name.Contains(shipName))
                    .FirstOrDefault();

                var theParking = parkingSpaces.First();

                // Adding visitor to DB
                if (currentVisitor != null && !string.IsNullOrWhiteSpace(visitorName)
                    && checkShip != null && !string.IsNullOrWhiteSpace(shipName))
                {
                    Spaceship spaceShip = Spaceship.CreateShip(ships);
                    Visitor visitor = Visitor.AddVisitorToDB(context, visitorArray);
                    Console.WriteLine($"Your have now parked at parking number: {theParking.ParkingLotID} please remember your visitor ID : {visitor.VisitorID} SpaceShip: {spaceShip.Name}");
                    Console.ReadLine();

                    // Changing parking space to occupado!
                    theParking.ParkingLotOccupied = true;

                    // Bringing it together in VisitorParking to keep track of who parked where
                    VisitorParking.AddVisitorParking(context, theParking, visitor);
                }
                else
                {
                    Console.WriteLine("Try again! Security has been notified of your presence puny human pleb kekW getrekt son..!");
                    Console.ReadLine();
                }                            
            }
            else
            {
                Console.WriteLine("Max Capacity Reached!");
                Console.ReadLine();
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

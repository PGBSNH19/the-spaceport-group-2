using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
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
            //Not yet implemented!
            Console.Write("Name: ");
            var visitorName = Console.ReadLine();
            Console.WriteLine(visitorName);

            var visitors = context.Visitors.Where(v => v.HasPaid == false).ToList();           
          
            foreach (var v in visitors)
            {
                if(visitorName == v.Name)
                {
                    v.HasPaid = true;
                    
                    context.SaveChanges();

                    var visitorParking = context.VisitorParking.Where(c => c.VisitorID == v.VisitorID).ToList();
                    
                    foreach (var p in occupiedSpaces)
                    {

                       if(p.ParkingLotID == visitorParking[0].ParkingLotID)
                        {
                            p.ParkingLotOccupied = false;
                            context.SaveChanges();
                        }

                    }
                }
            }

        }

        private static async Task RentParkingSpace(SpaceParkContext context)
        {
            var parkingSpaces = context.ParkingLots.ToList();

           occupiedSpaces = context.ParkingLots.Where(p => p.ParkingLotOccupied == true).ToList();

            if (occupiedSpaces.Count == 5)
            {
                Console.WriteLine("We full!");
            }
            else
            {
                foreach (var parkingSpace in parkingSpaces)
                {
                    Console.Clear();
                    if (parkingSpace.ParkingLotOccupied == false)
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
                        parkingSpace.ParkingLotOccupied = true;

                        // Bringing it together in VisitorParking to keep track of who parked where
                        UpdateVisitorParking(context, parkingSpace, visitor);

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
                        ParkingLotID = spacePort.SpacePortID
                    };

                    context.ParkingLots.Add(parking);
                    context.SaveChanges();
                }
            }
        }

        private static void UpdateVisitorParking(SpaceParkContext context, ParkingLot parkingSpace, Visitor visitor)
        {
            var visitorParking = new VisitorParking
            {
                VisitorID = visitor.VisitorID,
                ParkingLotID = parkingSpace.ParkingLotID
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
                HasPaid = false
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

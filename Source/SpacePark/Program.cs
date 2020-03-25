﻿using System;
using System.Linq;
using System.Threading.Tasks;
using SpacePark.Library.Context;
using SpacePark.Library.Models;

namespace SpacePark
{
    class Program
    {
        static readonly SpaceParkContext context = new SpaceParkContext();

        static async Task Main(string[] args)
        {

            CreateHeader();
            // SpacePort spacePort = new SpacePort();           

            //Creates spaceport, adds into DB IF no spaceport exists
            SpacePort pSpots = SpacePort.CreateSpacePort(context);

            //rec checks if there is rows in parkinglots table, if not it creates the correct amount of parkinglots
            var rec = context.ParkingLots.FirstOrDefault();

            if (rec == null)
            {

                for (int i = 0; i < pSpots.ParkingSpace; i++)
                {
                    ParkingLot parking = new ParkingLot
                    {
                        ParkingLotOccupied = false,
                        SpacePortID = pSpots.SpacePortID

                    };

                    context.ParkingLots.Add(parking);
                    context.SaveChanges();
                }

            }


            while (pSpots.ParkingLots.Count <= 5)
            {
                Console.WriteLine($"            Welcome to !\n\n");
                Console.WriteLine("Please enter your information");
                Console.WriteLine();
                Console.Write("Name: ");
                var visitorName = Console.ReadLine();
                var visitorArray = await PeopleAPI.ProcessPeople(visitorName);

                if (visitorArray.VisitorResult.Length != 0 || visitorArray.VisitorResult == null)
                {

                    foreach (var v in visitorArray.VisitorResult)
                    {
                        if (v.Name.ToLower().Contains(visitorName.ToLower()))
                        {
                            var theVisitor = visitorArray.VisitorResult[0];
                            Console.WriteLine(theVisitor.Name);
                            Console.WriteLine();

                            Console.WriteLine();
                            Console.WriteLine($"Which ship are you flying today?");
                            var visitorShip = Console.ReadLine();
                            var starWars = await StarwarsAPI.ProcessSpaceShips(visitorShip);

                            Console.WriteLine(starWars.Spaceships[0].Name);


                            Visitor visitor = new Visitor
                            {
                                Name = theVisitor.Name,
                                Status = HasPaid.NotPaid,
                            };

                            context.Visitors.Add(visitor);
                            context.SaveChanges();


                            var parkings = context.ParkingLots.ToArray();

                            foreach (var parking in parkings)
                            {
                                if (parking.ParkingLotOccupied != true)
                                {
                                    VisitorParking visitorParking = new VisitorParking
                                    {
                                        ParkingLotID = parking.ParkingLotID,
                                        VisitorID = visitor.VisitorID

                                    };

                                    var change = context.ParkingLots.Where(p => p.ParkingLotID == parking.ParkingLotID).ToList();
                                    var change2 = context.ParkingLots.Where(p => p.ParkingLotOccupied == true).ToList();
                                    foreach (var c in change)
                                    {
                                        c.ParkingLotOccupied = true;
                                        context.SaveChanges();
                                    };

                                    context.VisitorParking.Add(visitorParking);
                                    context.SaveChanges();
                                    break;

                                }
                                else if (parking.ParkingLotOccupied == true)
                                {

                                }


                            }

                        }

                    }
                }

                else
                {
                    Console.WriteLine("I'm sorry to inform you that you do not have the required qualifications to enter our SpacePort.");
                    Console.WriteLine();
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




        }



    } 
}

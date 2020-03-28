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
            string userChoice;
            do
            {
                StandardMessaging.Logo();
                Visitor.ShowCurrentVisitorsList(context);
                
                StandardMessaging.MenuChoice();
                userChoice = StandardMessaging.OutputStringReadUserInput("=> ");
                Console.Clear();

                //Console.WriteLine("Press 1 => Park");
                //Console.WriteLine("Press 2 => Pay");
                //Console.WriteLine("Press 0 => Exit");
                //userChoice = Console.ReadLine();

                switch (userChoice)
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
                        StandardMessaging.NoValidInput("You can only choose from the alternatives. Try again!");
                        //Console.WriteLine("No valid input");
                        break;
                }
            } while (userChoice != "0");
        }

        //private static string ReadUserInput(string message)
        //{           
        //    Console.Write(message);
        //    var output = Console.ReadLine();
          
        //    return output;
        //}

        private static void UpdateVisitorAndParkingLot(SpaceParkContext context)
        {
            var visitorName = StandardMessaging.OutputStringReadUserInput("Name: ");
          
            Visitor VisitorToPay = Visitor.GetPayingVisitor(context, visitorName);                               
          
            if (VisitorToPay.HasPaid == false)
            {
                VisitorToPay.HasPaid = true;

                var parking = VisitorParking.GetSpecificVisitorParking(context, VisitorToPay);
               
                var parkingLot = ParkingLot.GetSpecificParkingLot(context, parking);
                parkingLot.ParkingLotOccupied = false;

                context.SaveChanges();

                StandardMessaging.ThankYouForYourStay();
                //Console.WriteLine("Thank you for your stay, hope to see you soon Booyyyyyyy!");
                Console.ReadLine();
            }

            else
            {
                StandardMessaging.NoValidInput("Couldn't find you in db. Or something just doesn't work ;)");
                //Console.WriteLine("Couldn't find you in db. Or something just doesn't work");
            }
        }
        
        private static async Task RentParkingSpace(SpaceParkContext context)
        {
            var parkingSpaces = context.ParkingLots.Where(p => p.ParkingLotOccupied == false).ToList();
       
            if (parkingSpaces.Count >= 1)
            {
                var currentParkingSpace = parkingSpaces.First();
                StandardMessaging.EnterInformationBelow();
                //Console.WriteLine("Please enter your information");
                Console.WriteLine();

                var visitorName = StandardMessaging.OutputStringReadUserInput("Name: ");
                var visitorArray = await PeopleAPI.GetStarWarsCharacters(visitorName);
                var currentVisitor = PeopleAPI.EvaluateCharacter(context, visitorArray, visitorName, currentParkingSpace);

                var shipName = StandardMessaging.OutputStringReadUserInput("Ship: ");
                var ships = await PeopleAPI.GetStarWarsSpaceShips(shipName);                            
                var currentShip = PeopleAPI.EvaluateShips(context, ships, shipName, currentVisitor, currentParkingSpace);

              

                // Adding visitor to DB               
                //Spaceship spaceShip = Spaceship.CreateShip(ships);
               
                // Bringing it together in VisitorParking to keep track of who parked where
                VisitorParking.AddVisitorParking(context, currentParkingSpace, currentVisitor);
               
            }
            else
            {
                StandardMessaging.ParkingLotFull();
                //Console.WriteLine("Max Capacity Reached!");
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

        //private static void CreateHeader()
        //{
        //    var header = new[]
        //   {
        //            @"       ,---.                                  ,------.         ,---.               ,--.           ",
        //            @"      '   .-'  ,---.  ,--,--. ,---. ,---.     |  .--. ' ,---. /  .-',--.,--. ,---. |  |           ",
        //            @"      `.  `-. | .-. |' ,-.  || .--'| .-. :    |  '--'.'| .-. :|  `-,|  ||  || .-. :|  |           ",
        //            @"      .-'    || '-' '\ '-'  |\ `--.\   --.    |  |\  \ \   --.|  .-''  ''  '\   --.|  |           ",
        //            @"      `-----' |  |-'  `--`--' `---' `----'    `--' '--' `----'`--'   `----'  `----'`--'  .         ",
        //            @"              `--'                                                                                "

        //    };

        //    Console.WindowWidth = 100;
        //    Console.WriteLine("\n\n");
        //    Console.ForegroundColor = ConsoleColor.DarkYellow;
        //    foreach (string line in header)
        //    {
        //        Console.WriteLine(line);
        //    }

        //    Console.WriteLine("\n\n");
        //}
    } 
}

using SpacePark.Library.Context;
using System;
using System.Linq;

namespace SpacePark.Library.Models
{
    public static class Menu
    {
        public static void GenerateProgram(SpaceParkContext context)
        {
            string userChoice;
            do
            {
                StandardMessaging.Logo();
                Visitor.ShowCurrentVisitorsList(context);

                StandardMessaging.MenuChoice();
                userChoice = StandardMessaging.OutputStringReadUserInput("=> ");
                Console.Clear();

                ExecuteUserChoice(context, userChoice);
            } while (userChoice != "0");
        }

        private static void ExecuteUserChoice(SpaceParkContext context, string userChoice)
        {
            switch (userChoice)
            {
                case "1":
                    RentParkingSpace(context);
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
                    break;
            }
        }
        
        private static void RentParkingSpace(SpaceParkContext context)
        {
            var parkingSpaces = context.ParkingLots.Where(p => p.ParkingLotOccupied == false).ToList();

            if (parkingSpaces.Count >= 1)
            {
                var currentParkingSpace = parkingSpaces.First();
                StandardMessaging.EnterInformationBelow();
                Console.WriteLine();

                var visitorName = StandardMessaging.OutputStringReadUserInput("Name: ");
                if (visitorName != null && !string.IsNullOrWhiteSpace(visitorName))
                {
                    var visitor = DataAPI.EvaluateCharacter(visitorName);
                    if (visitor != null)
                    {
                        var shipName = StandardMessaging.OutputStringReadUserInput("Ship: ");
                        var ship = DataAPI.EvaluateShips(shipName);

                        if (ship != null)
                        {
                            Visitor.AddVisitorToDB(context, visitor);
                            currentParkingSpace.ParkingLotOccupied = true;
                            VisitorParking.AddVisitorParking(context, currentParkingSpace, visitor);
                        }
                    }
                }
            }
            else
            {
                StandardMessaging.ParkingLotFull();
                Console.ReadLine();
            }
        }

        private static void UpdateVisitorAndParkingLot(SpaceParkContext context)
        {
            var visitorName = StandardMessaging.OutputStringReadUserInput("Name: ");

            Visitor VisitorToPay = Visitor.GetPayingVisitor(context, visitorName);
            Receipt.GetReceipt(VisitorToPay);
            Visitor.ChangePaymentStatus(context, VisitorToPay);
        }
    }
}

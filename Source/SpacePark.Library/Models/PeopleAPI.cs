using SpacePark.Library.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpacePark.Library.Models
{
    public class PeopleAPI
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<VisitorArray> GetStarWarsCharacters(string name)
        {
            var peopleNames = client.GetStreamAsync(
                $"https://swapi.co/api/people/?search={ name }");
            var names = await JsonSerializer.DeserializeAsync<VisitorArray>(await peopleNames);
            return names;
        }

        public static async Task<Spaceship> GetStarWarsSpaceShips(string Name)
        {
            var shipNames = client.GetStreamAsync(
                $"https://swapi.co/api/starships/?search={ Name }");

            return (await JsonSerializer.DeserializeAsync<Spaceship>(await shipNames));
        }

        public static Visitor EvaluateCharacter(SpaceParkContext context, VisitorArray visitorArray, string visitorName, ParkingLot currentParkingSpace)
        {
            var currentVisitor = visitorArray.VisitorResult
                           .Where(x => x.Name.Contains(visitorName))
                           .FirstOrDefault();

            if (currentVisitor != null && !string.IsNullOrWhiteSpace(visitorName))
            {                                                                           
                return visitorArray.VisitorResult[0];
            }

            else
            {
                Console.WriteLine("Try again! Security has been notified of your presence puny human pleb kekW getrekt son..!");
                Console.ReadLine();
                
                return null;
            }
        }

        public static Spaceship EvaluateShips(SpaceParkContext context, Spaceship SpaceShipArray, string shipName, Visitor currentVisitor, ParkingLot currentParkingSpace)
        {
            var currentShip = SpaceShipArray.Spaceships
                          .Where(x => x.Name.Contains(shipName))
                          .FirstOrDefault();

            if (currentShip != null && !string.IsNullOrWhiteSpace(shipName))
            {
                Visitor.AddVisitorToDB(context, currentVisitor);
                // Changing parking space to occupado!
                currentParkingSpace.ParkingLotOccupied = true;
                // Bringing it together in VisitorParking to keep track of who parked where
                VisitorParking.AddVisitorParking(context, currentParkingSpace, currentVisitor);

                Console.WriteLine($"Your have now parked at parking number: {currentParkingSpace.ParkingLotID} please remember your visitor ID : {currentVisitor.VisitorID}");
                Console.ReadLine();

                return SpaceShipArray.Spaceships[0];

            }

            else
            {
                Console.WriteLine("Try again! Security has been notified of your presence puny human pleb kekW getrekt son..!");
                Console.ReadLine();
                return null;
            }
        }
    }    
}

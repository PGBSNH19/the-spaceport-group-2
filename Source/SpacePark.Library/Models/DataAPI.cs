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
    public static class DataAPI
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<VisitorArray> GetStarWarsCharacter(string visitorName)
        {
            if (visitorName.Length >=1 && !string.IsNullOrEmpty(visitorName) && !string.IsNullOrWhiteSpace(visitorName))
            {
                var peopleNames = client.GetStreamAsync(
                $"https://swapi.co/api/people/?search={ visitorName }");
                var names = await JsonSerializer.DeserializeAsync<VisitorArray>(await peopleNames);

                return names;
            }
            else
            {
                return null;
            }
        }

        public static async Task<Spaceship> GetStarWarsSpaceShips(string Name)
        {
            if (Name.Length >=1 && !string.IsNullOrEmpty(Name) && !string.IsNullOrWhiteSpace(Name))
            {
                var shipNames = client.GetStreamAsync(
               $"https://swapi.co/api/starships/?search={ Name }");

                var shipResult = await JsonSerializer.DeserializeAsync<Spaceship>(await shipNames);
                return shipResult;
            }
            else
            {
                return null;
            }

        }

        public static Visitor EvaluateCharacter(string visitorName)
        {
            var visitors = GetStarWarsCharacter(visitorName);
            var visitor = visitors.Result.VisitorResult.FirstOrDefault();

            if (visitor != null)
            {
                return visitor;
            }
            else
            {
                Console.WriteLine("Something went wrong when fethcing Charachters");
                Console.ReadLine();

                return null;
            }
        }

        public static Spaceship EvaluateShips(string shipName)
        {
            var ships = GetStarWarsSpaceShips(shipName);
            var ship = ships.Result.Spaceships.FirstOrDefault();

            if (ship != null)
            {
                return ship;
            }
            else
            {
                Console.WriteLine("Something went wrong when fethcing spaceShip");
                return null;
            }
        }
    }    
}

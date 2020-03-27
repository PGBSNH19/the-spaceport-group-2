using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpacePark.Library.Models
{
    public class PeopleAPI
    {

        //[JsonPropertyName("results")]
        //public Visitor[] VisitorResult { get; set; }

        //[JsonPropertyName("results")]
        //public Spaceship[] Spaceships { get; set; }


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


        public static async Task<Visitor> Evaluate(string name)
        {
            var StarWarsCharacter = await GetStarWarsCharacters(name);

            if (StarWarsCharacter != null)
            {

                //return new Visitor(name, false);
                return StarWarsCharacter.VisitorResult[0];

            }

            else
            {
                return null;
            }
           

        }


    }

    
}

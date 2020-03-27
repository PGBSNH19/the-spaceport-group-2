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

        [JsonPropertyName("results")]
        public PeopleAPI[] VisitorResult { get; set; }

        [JsonPropertyName("results")]
        public Spaceship[] Spaceships { get; set; }

        private static readonly HttpClient client = new HttpClient();

        public static async Task<PeopleAPI> GetStarWarsCharacters(string name)
        {
            var peopleNames = client.GetStreamAsync(
                $"https://swapi.co/api/people/?search={ name }");
            var names = await JsonSerializer.DeserializeAsync<PeopleAPI>(await peopleNames);
            return names;
        }

        public static async Task<Spaceship> GetStarWarsSpaceShips(string Name)
        {
            var shipNames = client.GetStreamAsync(
                $"https://swapi.co/api/starships/?search={ Name }");

            return (await JsonSerializer.DeserializeAsync<Spaceship>(await shipNames));
        }


        public static async Visitor Evaluate(string name)
        {
            var StarWarsCharacter = await GetStarWarsCharacters(name);

            if (StarWarsCharacter != null)
            {
                return new Visitor(StarWarsCharacter.VisitorResult[0]
                    .Select(visitor => visitor.Name)
                    .FirstOrDefault());
            }
            else
            {
                return null;
            }

        }


    }

    
}

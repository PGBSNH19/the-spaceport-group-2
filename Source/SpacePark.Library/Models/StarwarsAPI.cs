using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpacePark.Library.Models
{
    public class StarwarsAPI
    {
        public string Name { get; set; }

        private static readonly HttpClient client = new HttpClient();

        public static async Task<SpaceShipArray> ProcessSpaceShips(string Name)
        {
            var shipNames = client.GetStreamAsync(
                $"https://swapi.co/api/starships/?search={ Name }");
            
            return (await JsonSerializer.DeserializeAsync<SpaceShipArray>(await shipNames));
        }
    }

    public class SpaceShipArray
    {
        [JsonPropertyName("results")]
        public Spaceship[] Spaceships { get; set; }
    }
}

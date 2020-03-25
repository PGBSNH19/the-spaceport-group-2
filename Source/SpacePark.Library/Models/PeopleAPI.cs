using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpacePark.Library.Models
{
    public class PeopleAPI
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<VisitorArray> ProcessPeople(string name)
        {
            var peopleNames = client.GetStreamAsync(
                $"https://swapi.co/api/people/?search={ name }");
            var names = await JsonSerializer.DeserializeAsync<VisitorArray>(await peopleNames);
            return names;
        }
    }
}

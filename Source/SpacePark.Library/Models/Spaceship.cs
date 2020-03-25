using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpacePark.Library.Models
{
    public class Spaceship
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public Visitor Visitor { get; set; }
        public int VisitorID { get; set; }
        public Parking Parking { get; set;}
        public int ParkingID { get; set; }
    }
}
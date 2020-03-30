using System.Text.Json.Serialization;

namespace SpacePark.Library.Models
{
    public class Spaceship
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        public int VisitorID { get; set; }
        public Visitor Visitor { get; set; }
        public ParkingLot ParkingLot { get; set;}
        public int ParkingLotID { get; set; }

        [JsonPropertyName("results")]
        public Spaceship[] Spaceships { get; set; }
    }
}
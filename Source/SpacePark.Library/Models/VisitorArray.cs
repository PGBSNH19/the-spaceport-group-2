using System.Text.Json.Serialization;

namespace SpacePark.Library.Models
{
    public class VisitorArray
    {
        [JsonPropertyName("results")]
        public Visitor[] VisitorResult { get; set; }
    }
}
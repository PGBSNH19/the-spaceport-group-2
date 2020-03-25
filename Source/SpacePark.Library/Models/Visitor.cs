using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace SpacePark.Library.Models
{
   
   
    public class Visitor
    {      
        public int VisitorID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }    
        public bool HasPaid { get; set; }

      

    }

}

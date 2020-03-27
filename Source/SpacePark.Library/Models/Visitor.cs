using SpacePark.Library.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
      
        public static Visitor GetPayingVisitor(SpaceParkContext context, string visitorName)
        {
            return context.Visitors.Where(visitor => visitor.Name == visitorName && visitor.HasPaid == false).FirstOrDefault();
        }

        public static void AddVisitorToDB(SpaceParkContext context, Visitor visitor)
        {
           
            
            //visitor = new Visitor
            //{
            //   Name = visitor.Name,
            //   HasPaid = false
            //};
            context.Visitors.Add(visitor);
            context.SaveChanges();
           
        }

        public static void ShowCurrentVisitors(SpaceParkContext context)
        {
            var visitors = context.Visitors.Where(visitor=> visitor.HasPaid == false).ToList();
            Console.WriteLine("Current guests");    
            foreach (var visitor in visitors)
            {
                Console.WriteLine($"Name: {visitor.Name}              ID:{visitor.VisitorID}");
            }
            Console.WriteLine("\n");
        }

       

    }

}

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

        public static Visitor AddVisitorToDB(SpaceParkContext context, VisitorArray visitorArray)
        {
            var theVisitor = visitorArray.VisitorResult[0];
            Visitor visitor = new Visitor
            {
                Name = theVisitor.Name,
                HasPaid = false
            };
            context.Visitors.Add(visitor);
            context.SaveChanges();
            return visitor;
        }

        public static void ShowCurrentVisitors(SpaceParkContext context)
        {
            var visitors = context.Visitors.Where(visitor=> visitor.HasPaid == false).ToList();
            Console.WriteLine("Current guests");
            //Console.ForegroundColor = ConsoleColor.Green;
            foreach (var visitor in visitors)
            {
                Console.WriteLine(/*string.Format("{0,6} {1,15}", */$"Name: {visitor.Name}              ID:{visitor.VisitorID}")/*)*/;
            }
            Console.WriteLine("\n");
        }

    }

}

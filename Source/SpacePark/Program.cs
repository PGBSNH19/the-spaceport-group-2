using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;
using SpacePark.Library.Context;
using SpacePark.Library.Models;

namespace SpacePark
{
    class Program
    {
        static readonly SpaceParkContext context = new SpaceParkContext();

     

        static async Task Main(string[] args)
        {
            var visitorName = Console.ReadLine();
            var visitorArray = await PeopleAPI.ProcessPeople(visitorName);

            var theVisitor = visitorArray.VisitorResult[0];
            Console.WriteLine(theVisitor.Name);
        }

     
        
            
           
        
       
    } 
}

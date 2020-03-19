using System;
using System.Threading.Tasks;
using SpacePark.Library.Context;
using SpacePark.Library.Models;

namespace SpacePark
{
    class Program
    {
        static readonly SpaceParkContext context = new SpaceParkContext();
        
        static async Task Main(string[] args)
        {
            SpacePort spacePort = new SpacePort("SpaceRefuel",1,20,PortStatus.Open);
            
            
            Console.WriteLine($"Welcome to {spacePort.Name}:)\n\n");

            Console.WriteLine($"Which ship are you flying today?");
            var visitorShip = Console.ReadLine();
            var starWars = await StarwarsAPI.ProcessSpaceShips(visitorShip);

            Console.WriteLine(starWars.Spaceships[0].Name);
        }
    } 
}

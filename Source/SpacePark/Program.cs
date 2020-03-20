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
            CreateHeader();
            SpacePort spacePort = new SpacePort("SpaceRefuel",1,20,PortStatus.Open);

            Console.WriteLine($"            Welcome to {spacePort.Name}!\n\n");
            Console.WriteLine("Please enter your information");
            Console.WriteLine();
            Console.Write("Name: ");
            var visitorName = Console.ReadLine();
            var visitorArray = await PeopleAPI.ProcessPeople(visitorName);

            if (visitorArray.VisitorResult.Length != 0)
            {

                foreach (var v in visitorArray.VisitorResult)
                {
                    if (v.Name.ToLower().Contains(visitorName))
                    {
                        var theVisitor = visitorArray.VisitorResult[0];
                        Console.WriteLine(theVisitor.Name);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"Which ship are you flying today?");
                        var visitorShip = Console.ReadLine();
                        var starWars = await StarwarsAPI.ProcessSpaceShips(visitorShip);

                        Console.WriteLine(starWars.Spaceships[0].Name);
                    }

                }
            }

            else
            {
                Console.WriteLine("I'm sorry to inform you that you do not have the required qualifications to enter our SpacePort.");
                Console.WriteLine();
            }

        }


        private static void CreateHeader()
        {
            var header = new[]
           {
                    @"       ,---.                                  ,------.         ,---.               ,--.           ",
                    @"      '   .-'  ,---.  ,--,--. ,---. ,---.     |  .--. ' ,---. /  .-',--.,--. ,---. |  |           ",
                    @"      `.  `-. | .-. |' ,-.  || .--'| .-. :    |  '--'.'| .-. :|  `-,|  ||  || .-. :|  |           ",
                    @"      .-'    || '-' '\ '-'  |\ `--.\   --.    |  |\  \ \   --.|  .-''  ''  '\   --.|  |           ",
                    @"      `-----' |  |-'  `--`--' `---' `----'    `--' '--' `----'`--'   `----'  `----'`--'  .         ",
                    @"              `--'                                                                                "

            };

            Console.WindowWidth = 100;
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (string line in header)
            {
                Console.WriteLine(line);
            }




        }




    } 
}

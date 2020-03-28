using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark.Library.Models
{
    public class StandardMessaging
    {

        public static void Logo()
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

            Console.WriteLine("\n\n");
        }

        public static void MenuChoice()
        {
            Console.WriteLine("Press 1 => Park");
            Console.WriteLine("Press 2 => Pay");
            Console.WriteLine("Press 0 => Exit");
        }

        public static void EnterInformationBelow()
        {
            Console.WriteLine("Please enter your information below:");

        }

        public static void ParkingLotFull()
        {
            Console.WriteLine("Max Capacity Reached!");

        }

        public static void ThankYouForYourStay()
        {
            Console.WriteLine("Thank you for your stay, hope to see you soon Booyyyyyyy!");

        }

        public static string OutputStringReadUserInput(string message)
        {
            Console.Write(message);
            var output = Console.ReadLine();

            return output;
        }

        public static void NoValidInput(string wrongMessaging)
        {
            Console.WriteLine($"There's no valid input! {wrongMessaging}");
        }
    }
}

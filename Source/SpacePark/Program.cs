using System;
using SpacePark.Library.Models;

namespace SpacePark
{
    class Program
    {
        static void Main(string[] args)
        {

            Visitor v = new Visitor();
            v.Status = HasPaid.Paid;
            Console.WriteLine(v.Status);
            
            Console.WriteLine();
        }
    } 
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark.Library.Models
{
    public class Receipt
    {
        public int ReceiptID { get; set; }
        public int SpaceCredit { get; set; }
        public int VisitorID { get; set; }
        public Visitor Visitor { get; set; }
        public DateTime Date { get; set; }

        public Receipt(Visitor Visitor)
        {
            
            SpaceCredit = 500;
            this.Visitor = Visitor;
            this.Date = DateTime.Now;
        }

        public static void GetReceipt(Visitor Visitor)
        {
            var Receipt = new Receipt(Visitor);
            Console.WriteLine($"{Receipt.SpaceCredit} space credits\n{Receipt.Visitor.Name}\n{Receipt.Date}");
        }
    }
} 
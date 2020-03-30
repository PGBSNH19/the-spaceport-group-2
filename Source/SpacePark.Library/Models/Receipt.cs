using System;

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
            Date = DateTime.Now;
        }

        public static void GetReceipt(Visitor Visitor)
        {
            Console.WriteLine("\n\nHere is your receipt: \n");
            var Receipt = new Receipt(Visitor);
            Console.WriteLine($"{Receipt.SpaceCredit} space credits\n{Receipt.Visitor.Name}\n{Receipt.Date}\n\n");
        }
    }
} 
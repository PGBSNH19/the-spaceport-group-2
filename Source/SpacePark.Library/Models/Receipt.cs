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
    }
} 
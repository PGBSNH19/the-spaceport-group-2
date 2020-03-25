using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark.Library.Models
{
    public class Receipt
    {
        public int ReceiptID { get; set; }
        public int SpaceCredit { get; set; }
        public DateTime TimestampDateOfPayment { get; set; }
    }
} 
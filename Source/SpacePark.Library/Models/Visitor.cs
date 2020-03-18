using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePark.Library.Models
{
    public enum HasPaid
    {
        NotPaid,
        Paid
    }
   
    public class Visitor
    {      
        public int VisitorID { get; set; }
        public string Name { get; set; }
        public HasPaid Status { get; set; }
        
    }
}

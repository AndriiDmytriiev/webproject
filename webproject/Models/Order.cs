using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webproject.Models
{
    public class Order
    {
        public int Id { get; set; }       
        public string Status { get; set; }
        public int Qty { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EstimatedDate { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }

    }
}

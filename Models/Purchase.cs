using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Purchase
    {
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ReceptNumber { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; } 
        public int CoachId { get; set; }
    }
}

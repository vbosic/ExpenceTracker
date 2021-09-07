using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenceTracker.Models
{
    public class Outcome
    {
        public int Id { get; set; }
        public int TargetId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get;set; }
        public virtual Target Target { get; set; }
    }
}

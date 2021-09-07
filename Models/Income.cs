using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenceTracker.Models
{
    public class Income
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public double Ammount { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual User User { get; set; }
        public virtual Source Source { get; set; }
    }
}

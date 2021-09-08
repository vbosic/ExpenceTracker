using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenceTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int? IncomeId { get; set; }
        public int? OutcomeId { get; set; }
        public virtual Role Role {get; set;}
        public virtual ICollection<Income> Incomes {get; set;}
        public virtual ICollection<Outcome> Outcomes {get; set;}
        public string Token { get; set; }
    }
}

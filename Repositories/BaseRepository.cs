using ExpenceTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenceTracker.Repositories
{
    
    public abstract class BaseRepository
    {
        protected readonly ETContext _context;
        public BaseRepository(ETContext context)
        {
            _context = context;
        }
    }
}

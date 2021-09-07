using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenceTracker.Filters
{
    public class BaseResponse<T> where T : class
    {
        public List<T> Data { get; set; }
        public int Count { get; set; }
    }
}

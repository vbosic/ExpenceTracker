using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ExpenceTracker.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) 
            :base ($"Entity \"{name}\" ({key}) was not found.")
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

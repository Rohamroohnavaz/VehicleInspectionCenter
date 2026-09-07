using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionCenter.Domain.DomainExceptions
{
    public class NullLoginDataException : Exception
    {
        public NullLoginDataException(string message) : base(message)
        { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoding.Core.Exceptions
{
    public class ApprovalRequiredException : Exception
    {
        public ApprovalRequiredException(string message):base(message) 
        { 
        
        }
    }
}

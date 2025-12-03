using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Domain.Exceptions
{
    public class CableNotFoundException(string message) : Exception(message)
    {
    }
}

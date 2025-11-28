using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple1_Domain.Exceptions
{
    public class SaleNotFoundException (string message) : Exception(message)
    {
    }
}

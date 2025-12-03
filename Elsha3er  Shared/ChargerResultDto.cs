using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Shared
{
    public class ChargerResultDto
    {
        public int ChargerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Shared
{
    public class AddHeadPhoneResultDto
    {
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}

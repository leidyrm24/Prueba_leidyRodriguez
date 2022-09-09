using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_leidyRodriguez.Models
{
    public class CITY
    {
        [Key]
        public int CODE { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "DESCRIPCTION")]
        public string DESCRIPCTION { get; set; }
    }
}

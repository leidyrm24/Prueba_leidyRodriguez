using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_leidyRodriguez.Models
{
    public class SELLER
    {
        [Key]

        public int CODE { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "NAME")]
        public string NAME { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "LAST_NAME")]
        public string LAST_NAME { get; set; }


        [Required]
        [StringLength(20)]
        [Display(Name = "DOCUMENT")]
        public string DOCUMENT { get; set; }

        [Required]
        [Display(Name = "CITY_ID")]
        public int CITY_ID { get; set; }
    }
}

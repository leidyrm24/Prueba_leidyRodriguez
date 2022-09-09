using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Front_Leidy.Models
{
    public class CITY
    {

        [Display(Name = "CODE")] public int CODE { get; set; }
        [Display(Name = "DESCRIPCTION")] public string DESCRIPCTION { get; set; }
      
    }
}

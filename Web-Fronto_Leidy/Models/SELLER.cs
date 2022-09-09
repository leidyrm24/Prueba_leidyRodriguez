using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Front_Leidy.Models
{
    public class SELLER
    {
        [Display(Name = "CODE")] public int CODE { get; set; }
        [Display(Name = "NAME")] public string NAME { get; set; }
        [Display(Name = "LAST_NAME")] public string LAST_NAME { get; set; }
        [Display(Name = "DOCUMENT")] public string DOCUMENT { get; set; }
        [Display(Name = "CITY_ID")] public int CITY_ID { get; set; }
        [Display(Name = "DESCRIPCTION")] public string DESCRIPCTION { get; set; }




    }
}

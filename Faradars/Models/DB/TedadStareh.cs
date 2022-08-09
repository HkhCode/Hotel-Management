using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Faradars.Models.DB
{
    public class TedadStareh
    {


        [Key]
        public int TedadStareh_ID { get; set; }


        [Display(Name = "تعداد ستاره")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        [MaxLength(100, ErrorMessage = ErrorMessage.MaxLenghtMsg)]
        public string TedadStareh_Name { get; set; }

        public virtual ICollection<JozeyatHotel> JozeyatStareh { get; set; }


    }
}

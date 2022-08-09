using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Faradars.Models.DB
{
    public class OstanHotel
    {
        [Key]
        public int Ostan_ID { get; set; }


        [Display(Name = "استان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        [MaxLength(100, ErrorMessage = ErrorMessage.MaxLenghtMsg)]
        public string Ostan_Name { get; set; }

        public virtual ICollection<JozeyatHotel> JozeyatOstan { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Faradars.Models.DB
{
    public class TedadTakhtHotel
    {


        [Key]
        public int TedadTakh_ID { get; set; }


        [Display(Name = "تعداد تخت")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMessage.RequierdMsg)]
        [MaxLength(100, ErrorMessage = ErrorMessage.MaxLenghtMsg)]
        public string TedadTakh_Name { get; set; }

        public virtual ICollection<JozeyatHotel> JozeyatTakht { get; set; }



    }
}

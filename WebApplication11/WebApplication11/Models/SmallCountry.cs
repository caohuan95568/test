using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication11.Models
{
    public class SmallCountry
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string SmallCountryName{ get; set; }
    }
}
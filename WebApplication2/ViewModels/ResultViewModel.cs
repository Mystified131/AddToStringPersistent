﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.ViewModels
{
    public class ResultViewModel
    {
        [Required]
        public String NewElement { get; set; }
        public string TheString { get; set; }
    }
}

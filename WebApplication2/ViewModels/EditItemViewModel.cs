﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.ViewModels
{
    public class EditItemViewModel
    {
        [Required]
        public String NewElement2 { get; set; }
        public String TheString { get; set; }
    }
}

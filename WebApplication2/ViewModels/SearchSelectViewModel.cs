using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.ViewModels
{
    public class SearchSelectViewModel
    {
        [Required]
        public String Searchstr { get; set; }
    }
}

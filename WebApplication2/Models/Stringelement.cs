using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Stringelement
    {
        public int ID { get; set; }
        public string Element { get; set; }


        public Stringelement(string element)
        {
            Element = element;
        }
    }
}

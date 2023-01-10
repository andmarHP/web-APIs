using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Boleto
    {
        public int IdBoleto { get; set; }
        public string Name { get; set; }
        public string Base64 { get; set; }
    }
}
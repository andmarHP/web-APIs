using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Boleto
    {
        public Boleto()
        {
            folio = Guid.NewGuid().ToString().Replace("-",".");
        }
        public string ?folio { get; set; }
        public string Name { get; set; }
    }
}
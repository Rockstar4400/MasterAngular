using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Domain
{
    public class Toy
    {
        public int ToyId { get; set; }
        public int CompanyId { get; set; }
        public string ToyName { get; set; }
        public string Description { get; set; }
        public int AgeRestriction { get; set; }
        public Company Company { get; set; }
        public decimal Price { get; set; }

    }
}

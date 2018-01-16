using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opgave2.Models
{
    public class ShoppingList
    {
        public List<Product> ProductList { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    }
}

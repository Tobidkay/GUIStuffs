using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opgave2.Models
{
    public class ShoppingListModel
    {
        public List<Product> ProductList { get; set; } = new List<Product>();
        public string Name { get; set; }

        private Guid id;
        public Guid Id {
            get
            {
                if (this.id == Guid.Empty)
                {
                    this.id = Guid.NewGuid();
                }
                return this.id;
            }
            set => this.id = value;
        }
    }

    public class Product
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Amout { get; set; }
    }
}

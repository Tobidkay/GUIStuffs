using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opgave2.Models
{
    using Opgave2.Model;

    [Serializable]
    public class HomeModel
    {
        public HomeModel()
        {
            ShoppingLists = LogToFile.LogToFileInstance.LoadProductsFromFile() ?? new List<ShoppingListModel>();

        }
        public List<ShoppingListModel> ShoppingLists { get; set; }
    }
}

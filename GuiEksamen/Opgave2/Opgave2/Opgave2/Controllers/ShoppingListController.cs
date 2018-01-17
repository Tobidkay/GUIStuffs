using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Opgave2.Controllers
{
    using Opgave2.Model;
    using Opgave2.Models;

    public class ShoppingListController : Controller
    {
        private HomeModel ProductListsList = new HomeModel();
        // GET: ShoppingListModel
        public ActionResult Index(Guid? Id)
        {
            ShoppingListModel newlist = null;
            if (Id == null)
            {
                newlist = new ShoppingListModel();
            }
            else
            {
                if (this.ProductListsList.ShoppingLists.Any(i => i.Id == Id))
                {
                    newlist = this.ProductListsList.ShoppingLists.Find(i => i.Id == Id);
                }
                else
                {
                    newlist = new ShoppingListModel();
                }
            }
            return View(newlist);
        }

        // POST: ShoppingListModel/Create
        [HttpPost]
        public ActionResult Create(Guid id ,int amout, string Productname, int price, string Name)
        {
            if (ModelState.IsValid)
            {
                var addList = this.ProductListsList.ShoppingLists.Find(i => i.Id == id);
                if (addList == null)
                {
                    addList = new ShoppingListModel();
                    this.ProductListsList.ShoppingLists.Add(addList);
                }
                if (amout == 0)
                {
                    var itemToRemove = addList.ProductList.Find(a => a.ProductName == Productname);
                    addList.ProductList.Remove(itemToRemove);
                    LogToFile.LogToFileInstance.SaveProductsToFile(this.ProductListsList.ShoppingLists);
                    return this.View("Index", addList);
                }
                else
                {
                    var productToAdd = new Product()
                                           {
                                               Amout = amout,
                                               ProductName = Productname,
                                               Price = price
                                           };

                    addList.Name = Name;
                    addList.ProductList.Add(productToAdd);

                    LogToFile.LogToFileInstance.SaveProductsToFile(this.ProductListsList.ShoppingLists);
                    return this.View("Index", addList);
                }               
            }
            else
            {
                return this.View("Index");
            }
        }

       
    }
}
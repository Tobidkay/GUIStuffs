using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave2.Model
{
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.IO;

    using Newtonsoft.Json;

    using Opgave2.Models;

    class LogToFile
    {
        private LogToFile() { }

        private static readonly LogToFile logToFileInstance = new LogToFile();

        public static LogToFile LogToFileInstance => logToFileInstance;

        private readonly string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\ShoppingLists.json";


        public void SaveProductsToFile(List<ShoppingListModel> ProductsToSave)
        {
            if (ProductsToSave == null || ProductsToSave.Count < 1)
            {
                return;
            }
            File.WriteAllText(this.filepath, JsonConvert.SerializeObject(ProductsToSave, Formatting.Indented, new JsonSerializerSettings
                                                                                                                  {
                                                                                                                      NullValueHandling = NullValueHandling.Ignore
                                                                                                                      
                                                                                                                  }));
        }


        public List<ShoppingListModel> LoadProductsFromFile()
        {
            var ListToReturn = new List<ShoppingListModel>();
            try
            {
                ListToReturn = JsonConvert.DeserializeObject<List<ShoppingListModel>>(
                    File.ReadAllText(this.filepath),
                    new JsonSerializerSettings
                        {   
                            NullValueHandling = NullValueHandling.Ignore
                        });
                return ListToReturn;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
        }
    }

}

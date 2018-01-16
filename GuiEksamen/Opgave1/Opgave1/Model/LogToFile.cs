using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1.Model
{
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.IO;

    using Newtonsoft.Json;

    class LogToFile
    {
        private LogToFile() { }

        private static readonly LogToFile logToFileInstance = new LogToFile();

        public static LogToFile LogToFileInstance => logToFileInstance;

        private readonly string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Products.json";

        private readonly string filepathSale = AppDomain.CurrentDomain.BaseDirectory + "\\Sale.json";

        public void SaveProductsToFile(ObservableCollection<Product> ProductsToSave)
        {
            if (ProductsToSave == null || ProductsToSave.Count < 1)
            {
                return;
            }
            File.WriteAllText(this.filepath, JsonConvert.SerializeObject(ProductsToSave, Formatting.Indented, new JsonSerializerSettings
                                                                                                                  {
                                                                                                                      NullValueHandling = NullValueHandling.Ignore,
                                                                                                                      TypeNameHandling = TypeNameHandling.Objects
                                                                                                                  }));
        }


        public void SaveSaleToFile(Sale saleToSave)
        {
            if (saleToSave == null)
            {
                return;
            }
            saleToSave.SaveId = Guid.NewGuid().ToString();
            File.AppendAllText(this.filepathSale, JsonConvert.SerializeObject(saleToSave, Formatting.Indented, new JsonSerializerSettings
                                                                                                                  {
                                                                                                                      NullValueHandling = NullValueHandling.Ignore,
                                                                                                                      TypeNameHandling = TypeNameHandling.Objects
                                                                                                                  }));
        }
        public ObservableCollection<Product> LoadProductsFromFile()
        {
            var ListToReturn = new ObservableCollection<Product>();
            try
            {
                ListToReturn = JsonConvert.DeserializeObject<ObservableCollection<Product>>(
                    File.ReadAllText(this.filepath),
                    new JsonSerializerSettings
                        {
                            TypeNameHandling = TypeNameHandling.Objects,
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

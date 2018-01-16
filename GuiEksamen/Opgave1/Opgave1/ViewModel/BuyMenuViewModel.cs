using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1.ViewModel
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Opgave1.Model;

    class BuyMenuViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Product> productsAvailable = LogToFile.LogToFileInstance.LoadProductsFromFile() ?? new ObservableCollection<Product>();

        public ObservableCollection<Product> ProductsAvailable
        {
            get => this.productsAvailable;
            set
            {
                if (this.productsAvailable == value)
                {
                    return;
                }
                else
                {
                    this.productsAvailable = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        private ObservableCollection<SaleProduct> productsToBuy = new ObservableCollection<SaleProduct>();

        public ObservableCollection<SaleProduct> ProductsToBuy
        {
            get => this.productsToBuy;
            set
            {
                if (this.productsToBuy == value)
                {
                    return;
                }
                else
                {
                    this.productsToBuy = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public void AddToBuy(Object param)
        {
            var productToBuy = (Product)param;
            var saleProduct = new SaleProduct()
                                  {
                                      Name = productToBuy.Name,
                                      Price = productToBuy.Price
                                  };
            if (ProductsToBuy.FirstOrDefault(x => x.Name == saleProduct.Name) != null)
            {
                var productToUpdate = ProductsToBuy.FirstOrDefault(x => x.Name == saleProduct.Name);
                var stuff = Int32.Parse(productToUpdate.Count);
                stuff++;
                productToUpdate.Count = stuff.ToString();

            }
        }

        private Sale pToBuy = new Sale();

        public Sale PToBuy
        {
            get => this.pToBuy;
            set
            {
                if (this.pToBuy == value)
                {
                    return;
                }
                this.pToBuy = value;
                this.NotifyPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

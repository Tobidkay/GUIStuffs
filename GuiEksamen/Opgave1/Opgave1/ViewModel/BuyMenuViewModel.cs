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
    using System.Windows;

    using Opgave1.Model;
    using Opgave1.View;

    using Prism.Commands;

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

        private Sale sale = new Sale();

        public Sale Sale
        {
            get => this.sale;
            set
            {
                if (this.sale == value)
                {
                    return;
                }
                this.sale = value;
                this.NotifyPropertyChanged();
            }
        }

        private Product selectedProduct;

        public Product SelectedProduct
        {
            get => this.selectedProduct;
            set
            {
                if (this.selectedProduct == value)
                {
                    return;
                }
                else
                {
                    this.selectedProduct = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        private SaleProduct selectedSaleProduct;

        public SaleProduct SelectedSaleProduct
        {
            get => this.selectedSaleProduct;
            set
            {
                if (this.selectedSaleProduct == value)
                {
                    return;
                }
                this.selectedSaleProduct = value;
                this.NotifyPropertyChanged();
            }
        }

        private string cashIn;

        public string CashIn
        {
            get => this.cashIn;
            set
            {
                if (this.cashIn == value)
                {
                    return;
                }
                this.cashIn = value;
                this.NotifyPropertyChanged();
            }
        }


        private DelegateCommand<Object> addToBuyCommand;

        public DelegateCommand<Object> AddToBuyCommand =>
            this.addToBuyCommand ?? (this.addToBuyCommand = new DelegateCommand<Object>(this.AddToBuy));

        public void AddToBuy(Object param)
        {
            var productToBuy = (Product)param;
            var saleProduct = new SaleProduct()
                                  {
                                      Name = productToBuy.Name,
                                      Price = productToBuy.Price
                                  };
            if (Sale.ProductsToBuy.FirstOrDefault(x => x.Name == saleProduct.Name) != null)
            {
                var productToUpdate = Sale.ProductsToBuy.FirstOrDefault(x => x.Name == saleProduct.Name);
                var count = Int32.Parse(productToUpdate.Count);
                count++;
                productToUpdate.Count = count.ToString();
                var totalPrice = Int32.Parse(productToUpdate.TotalPrice) + Int32.Parse(productToUpdate.Price);
                productToUpdate.TotalPrice = totalPrice.ToString();
                var index = Sale.ProductsToBuy.IndexOf(Sale.ProductsToBuy.FirstOrDefault(x => x.Name == saleProduct.Name));
                Sale.ProductsToBuy[index] = productToUpdate;
            }
            else
            {
                saleProduct.Count = "1";
                saleProduct.TotalPrice = productToBuy.Price;
                this.Sale.ProductsToBuy.Add(saleProduct);
            }
            Sale.calcTotalSalePrice();
        }

        private DelegateCommand<Object> removeBuyItemCommand;

        public DelegateCommand<Object> RemoveBuyItemCommand =>
            this.removeBuyItemCommand ?? (this.removeBuyItemCommand = new DelegateCommand<Object>(this.RemoveBuyItem));

        public void RemoveBuyItem(Object param)
        {
            var productToRemove = (SaleProduct)param;
            var productInList = Sale.ProductsToBuy.FirstOrDefault(x => x.Name == productToRemove.Name);
            if (Int32.Parse(productInList.Count) == 1)
            {
                Sale.ProductsToBuy.Remove(productInList);
            }
            else
            {
                var count = Int32.Parse(productInList.Count);
                count--;
                productInList.Count = count.ToString();
                var totalPrice = Int32.Parse(productInList.TotalPrice) - Int32.Parse(productInList.Price);
                productInList.TotalPrice = totalPrice.ToString();
                var index = Sale.ProductsToBuy.IndexOf(
                    Sale.ProductsToBuy.FirstOrDefault(x => x.Name == productInList.Name));
                Sale.ProductsToBuy[index] = productInList;
            }
            Sale.calcTotalSalePrice();
        }

        private DelegateCommand mobilePayCommand;

        public DelegateCommand MobilePayCommand =>
            this.mobilePayCommand ?? (this.mobilePayCommand = new DelegateCommand(this.MobilePayment));

        public void MobilePayment()
        {
            Sale.PaymentMethod = "Mobile Pay";
            Sale.CashBack = "0";
            var saleWindow = new SaleWindow();
            saleWindow.Title = "Complete Sale?";
            saleWindow.DataContext = this.Sale;
            if (saleWindow.ShowDialog() == true)
            {
                LogToFile.LogToFileInstance.SaveSaleToFile(Sale);
                Sale = new Sale();
            }
        }

        private DelegateCommand cashCommand;

        public DelegateCommand CashCommand =>
            this.cashCommand ?? (this.cashCommand = new DelegateCommand(this.CashPayment));

        public void CashPayment()
        {
            if (this.cashIn == null)
            {
                MessageBox.Show("Cant pay with cash, with no cash");
            }
            else if (Int32.Parse(cashIn) < Int32.Parse(Sale.TotalPrice))
            {
                MessageBox.Show("Cant give products for free!");
            }
            else
            {
                Sale.PaymentMethod = "Cash";
                Sale.calcCashBack(CashIn);
                var saleWindow = new SaleWindow();
                saleWindow.Title = "Complete Sale?";
                saleWindow.DataContext = this.Sale;
                if (saleWindow.ShowDialog() == true)
                {
                    LogToFile.LogToFileInstance.SaveSaleToFile(Sale);
                    Sale = new Sale();
                }
            }
           
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

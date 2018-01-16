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

    using Prism.Commands;

    class ProductManagementViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Product> products = LogToFile.LogToFileInstance.LoadProductsFromFile() ?? new ObservableCollection<Product>();

        public ObservableCollection<Product> Products
        {
            get => this.products;
            set
            {
                if (this.products == value)
                {
                    return;
                }
                else
                {
                    this.products = value;
                    this.NotifyPropertyChanged();
                }
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

        private string newProductCode;

        private string newName;

        private string newPrice;

        public string NewProductCode
        {
            get => this.newProductCode;
            set
            {
                if (this.newProductCode == value)
                {
                    return;
                }
                this.newProductCode = value;
                this.NotifyPropertyChanged();
            }
        }

        public string NewName
        {
            get => this.newName;
            set
            {
                if (this.newName == value)
                {
                    return;
                }
                this.newName = value;
                this.NotifyPropertyChanged();
            }
        }

        public string NewPrice
        {
            get => this.newPrice;
            set
            {
                if (this.newPrice == value)
                {
                    return;
                }
                this.newPrice = value;
                this.NotifyPropertyChanged();
            }
        }

        private DelegateCommand addCommand;

        public DelegateCommand AddCommand => this.addCommand ?? (this.addCommand = new DelegateCommand(this.AddNewProduct));

        public void AddNewProduct()
        {
            var p = new Product(this.newProductCode, this.newName, this.newPrice);           
            this.Products.Add(p);
            LogToFile.LogToFileInstance.SaveProductsToFile(this.products);
        }

        private DelegateCommand removeCommand;

        public DelegateCommand RemoveCommand =>
            this.removeCommand ?? (this.removeCommand = new DelegateCommand(this.RemoveProduct));

        public void RemoveProduct()
        {
            Products.Remove(SelectedProduct);
            LogToFile.LogToFileInstance.SaveProductsToFile(this.products);
        }

        private DelegateCommand<Object> editCommand;

        public DelegateCommand<Object> EditCommand =>
            this.editCommand ?? (this.editCommand  = new DelegateCommand<Object>(this.EditProduct));

        public void EditProduct(Object param)
        {
            var ProductToEdit = (Product)param;
            ProductToEdit.ProductCode = this.newProductCode;
            ProductToEdit.Name = this.newName;
            ProductToEdit.Price = this.newPrice;
            LogToFile.LogToFileInstance.SaveProductsToFile(this.products);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

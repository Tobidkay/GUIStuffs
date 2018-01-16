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

    using Prism.Commands;

    class ProductManagementViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<AProduct> products = new ObservableCollection<AProduct>();

        public ObservableCollection<AProduct> Products
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

        private AProduct selectedProduct = new Product();

        public AProduct SelectedProduct
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

        private AProduct newProduct = new Product();

        public AProduct NewProduct
        {
            get => this.newProduct;
            set
            {
                if (this.newProduct == value)
                {
                    return;
                }
                else
                {
                    this.newProduct = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        private DelegateCommand addCommand;

        public DelegateCommand AddCommand => this.addCommand ?? (this.addCommand = new DelegateCommand(this.AddNewProduct));

        public void AddNewProduct()
        {
            if (this.newProduct == null)
            {
                MessageBox.Show("Cannot add a empty object!");
            }
            else
            {
                Products.Add(this.newProduct);
                this.NewProduct = null;
            }
            
        }

        private DelegateCommand removeCommand;

        public DelegateCommand RemoveCommand =>
            this.removeCommand ?? (this.removeCommand = new DelegateCommand(this.RemoveProduct));

        public void RemoveProduct()
        {
            Products.Remove(SelectedProduct);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

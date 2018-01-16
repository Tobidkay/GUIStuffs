using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1.Model
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class Product: AProduct
    {
        public Product()
        {
            
        }

        public Product(string productCode, string name, string price)
        {
            this.productCode = productCode;
            this.name = name;
            this.price = price;
        }

        private string productCode;

        private string name;

        private string price;

        public string ProductCode
        {
            get => this.productCode;
            set
            {
                if (this.productCode == value)
                {
                    return;
                }
                this.productCode = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (this.name == value)
                {
                    return;
                }
                this.name = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Price
        {
            get => this.price;
            set
            {
                if (this.price == value)
                {
                    return;
                }
                this.price = value;
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

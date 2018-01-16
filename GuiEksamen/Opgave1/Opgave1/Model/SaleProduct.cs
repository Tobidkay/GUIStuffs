using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1.Model
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class SaleProduct: INotifyPropertyChanged
    {
        private string count;

        private string name;

        private string price;

        private string totalPrice;

        public string Count
        {
            get => this.count;
            set
            {
                if (this.count == value)
                {
                    return;
                }
                this.count = value;
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

        public string TotalPrice
        {
            get => this.totalPrice;
            set
            {
                if (this.totalPrice == value)
                {
                    return;
                }
                this.totalPrice = value;
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

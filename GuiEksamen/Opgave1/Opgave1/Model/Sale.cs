using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1.Model
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class Sale: INotifyPropertyChanged
    {
        private ObservableCollection<SaleProduct> productsToBuy = new ObservableCollection<SaleProduct>();

        private string totalPrice;

        private string paymentMethod;

        private string cashBack;

        public string SaveId;

        public ObservableCollection<SaleProduct> ProductsToBuy
        {
            get => this.productsToBuy;
            set
            {
                if (this.productsToBuy == value)
                {
                    return;
                }
                this.productsToBuy = value;
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

        public string PaymentMethod
        {
            get => this.paymentMethod;
            set
            {
                if (this.paymentMethod == value)
                {
                    return;
                }
                this.paymentMethod = value;
                this.NotifyPropertyChanged();
            }
        }

        public string CashBack
        {
            get => this.cashBack;
            set
            {
                if (this.cashBack == value)
                {
                    return;
                }
                this.cashBack = value;
                this.NotifyPropertyChanged();
            }
        }

        public void calcTotalSalePrice()
        {
            var TotalSalePrice = new int();
            foreach (var product in this.productsToBuy)
            {
                TotalSalePrice += Int32.Parse(product.TotalPrice);
            }
            TotalPrice = TotalSalePrice.ToString();
        }

        public void calcCashBack(string cashIn)
        {
            var cashBack1 = Int32.Parse(TotalPrice) - Int32.Parse(cashIn);
            CashBack = cashBack1.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

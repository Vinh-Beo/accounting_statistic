using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace iCa.Models
{
    public class OrderToSheetModel:BaseViewModel
    {
        private long _Id;
        public long Id { get => _Id; set { _Id = value; OnPropertyChanged("Id"); } }

        private int _Attribute;
        public int Attribute { get => _Attribute; set { _Attribute = value; OnPropertyChanged("Attribute"); } }

        private string _Code;
        public string Code { get => _Code; set { _Code = value; OnPropertyChanged("Code"); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged("Name"); } }

        private string _WeightUnit;
        public string WeightUnit { get => _WeightUnit; set { _WeightUnit = value; OnPropertyChanged("WeightUnit"); } }
        private string _Weight;
        public string Weight { get => _Weight; set { _Weight = value; OnPropertyChanged("Weight"); } }
        private string _Price;
        public string Price { get => _Price; set { _Price = value; OnPropertyChanged("Price"); } }

        private int _DiscountRate;
        public int DiscountRate { get => _DiscountRate; set { _DiscountRate = value; OnPropertyChanged("DiscountRate"); } }
        private int _DiscountMoney;
        public int DiscountMoney { get => _DiscountMoney; set { _DiscountMoney = value; OnPropertyChanged("DiscountMoney"); } }
        private int _Discount;
        public int Discount { get => _Discount; set { _Discount = value; OnPropertyChanged("Discount"); } }
        private double _MoneyBeforeTax;
        public double MoneyBeforeTax { get => _MoneyBeforeTax; set { _MoneyBeforeTax = value; OnPropertyChanged("MoneyBeforeTax"); } }
        private int _Tax;
        public int Tax { get => _Tax; set { _Tax = value; OnPropertyChanged("Tax"); } }
        private int _TaxMoney;
        public int TaxMoney { get => _TaxMoney; set { _TaxMoney = value; OnPropertyChanged("TaxMoney"); } }
        private double _MoneyAfterTax;
        public double MoneyAfterTax { get => _MoneyAfterTax; set { _MoneyAfterTax = value; OnPropertyChanged("MoneyAfterTax"); } }
    }
}

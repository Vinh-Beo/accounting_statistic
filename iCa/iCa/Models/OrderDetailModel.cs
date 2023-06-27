using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Utils;

namespace iCa.Models
{
    public class OrderDetailModel : BaseViewModel
    {
        private string _Title;
        public string Title { get => _Title; set { _Title = value; OnPropertyChanged("Title"); } }
        private string _Price;
        public string Price { get => _Price; set { _Price = value; OnPropertyChanged("Price"); } }
        private string _Weight;
        public string Weight { get => _Weight; set { _Weight = value; OnPropertyChanged("Weight"); } }
        private double _Total;
        public double Total { get => _Total; set { _Total = value; OnPropertyChanged("Total"); } }
        private int _Counter;
        public int Counter { get => _Counter; set { _Counter = value; OnPropertyChanged("Counter"); } }
        private ObservableCollection<OrderModel> _Orders;
        public ObservableCollection<OrderModel> Orders { get => _Orders; set { _Orders = value; OnPropertyChanged("Orders"); } }
    }
}

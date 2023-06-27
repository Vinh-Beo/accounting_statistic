using iCa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Utils;

namespace iCa.ViewModels.Main.Order.Detail.ItemsList
{
    public class ItemsListViewModel:BaseViewModel
    {
        #region Common prop
        private bool _IsBusy;
        public bool IsBusy { get => _IsBusy; set { _IsBusy = value; OnPropertyChanged("IsBusy"); } }

        private bool _ResponseOK;
        public bool ResponseOK { get => _ResponseOK; set { _ResponseOK = value; OnPropertyChanged("ResponseOK"); } }
        private string _ResponseMessage;
        public string ResponseMessage { get => _ResponseMessage; set { _ResponseMessage = value; OnPropertyChanged("ResponseMessage"); } }
        #endregion
        #region Working prop
        private List<OrderModel> _Items;
        public List<OrderModel> Items { get => _Items; set { _Items = value; OnPropertyChanged("Items"); } }

        private double _PriceTotal;
        public double PriceTotal { get => _PriceTotal; set { _PriceTotal = value; OnPropertyChanged("PriceTotal"); } }
        private double _WeightTotal;
        public double WeightTotal { get => _WeightTotal; set { _WeightTotal = value; OnPropertyChanged("WeightTotal"); } }
        #endregion
    }
}

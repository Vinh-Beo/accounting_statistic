using iCa.Models;
using iCa.ViewModels.Main.Order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Utils;

namespace iCa.ViewModels.Main
{
    class MainViewModel:BaseViewModel
    {
        #region Common prop
        private bool _IsBusy;
        public bool IsBusy { get => _IsBusy; set { _IsBusy = value; OnPropertyChanged("IsBusy"); } }

        private bool _ResponseOK;
        public bool ResponseOK { get => _ResponseOK; set { _ResponseOK = value; OnPropertyChanged("ResponseOK"); } }
        private string _ResponseMessage;
        public string ResponseMessage { get => _ResponseMessage; set { _ResponseMessage = value; OnPropertyChanged("ResponseMessage"); } }
        #endregion
        #region Orders
        private OrdersViewModel _Order;
        public OrdersViewModel Order { get => _Order; set { _Order = value; OnPropertyChanged("Order"); } }
        #endregion
    }
}

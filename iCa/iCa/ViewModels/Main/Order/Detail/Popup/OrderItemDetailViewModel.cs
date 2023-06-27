using Common;
using iCa.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Utils;

namespace iCa.ViewModels.Main.Order.Detail.Popup
{
    public class OrderItemDetailViewModel:BaseViewModel
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
        private ObservableCollection<OrderModel> _Orders;
        public ObservableCollection<OrderModel> Orders { get => _Orders; set { _Orders = value; OnPropertyChanged("Orders"); } }
        #endregion
    }
}

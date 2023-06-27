using CommunityToolkit.Mvvm.Input;
using iCa.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Utils;

namespace iCa.ViewModels.Main.Order.Menu
{
    public class OrderMenuViewModel:BaseViewModel
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
        private OrderModel _Info;
        public OrderModel Info { get => _Info; set { _Info = value; OnPropertyChanged("Info"); } }
        #endregion
        #region Cmd
        public Action DisplEdit;
        public ICommand EditCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplEdit?.Invoke();
                }));
            }
        }
        public Action DisplDelete;
        public ICommand DeleteCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplDelete?.Invoke();
                }));
            }
        }
        #endregion
    }
}

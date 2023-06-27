using CommunityToolkit.Mvvm.Input;
using iCa.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Utils;

namespace iCa.ViewModels.Main.Order.Menu.Edit
{
    public class EditOrderViewModel:BaseViewModel
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
        public Action<OrderModel> DisplOK;
        public ICommand OKCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    try
                    {
                        Info.Total = double.Parse(Info.Weight) * double.Parse(Info.Price);
                    }
                    catch (Exception)
                    {
                        ResponseOK = false;
                        ResponseMessage = "Nhập sai thông tin. Vui lòng kiểm tra lại...";
                        return;
                    }
                    DisplOK?.Invoke(Info);
                }));
            }
        }
        public Action DisplClose;
        public ICommand CancelCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplClose?.Invoke();
                }));
            }
        }
        #endregion
    }
}

using Common;
using CommunityToolkit.Mvvm.Input;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using iCa.Helper.Gesture;
using iCa.Models;
using iCa.ViewModels.Common;
using iCa.Views;
using iCa.Views.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utils;
using static Google.Apis.Sheets.v4.SheetsService;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;
using static System.Net.Mime.MediaTypeNames;

namespace iCa.ViewModels.Main.Order
{
    public class OrdersViewModel : BaseViewModel
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
        private ProductCode userName;
        public ProductCode UserName { get => userName; set { userName = value; OnPropertyChanged("UserName"); } }

        private double _Total;
        public double Total { get => _Total; set { _Total = value; OnPropertyChanged("Total"); } }
        #endregion

        
        #region Cmd
        public ICommand SaveCmd
        {
            get
            {
                return new RelayCommand(new Action(async() =>
                {
                    
                }));
            }
        }
        public Action DisplAdd;
        public ICommand AddCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplAdd?.Invoke();
                }));
            }
        }
        public Action DisplDeleteAll;
        public ICommand DeleteAllCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplDeleteAll?.Invoke();
                }));
            }
        }
        public Action DisplDetail;
        public ICommand DetailCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplDetail?.Invoke();
                }));
            }
        }
        public Action<OrderModel> DisplSel;
        public ICommand MenuCmd
        {
            get
            {
                return new RelayCommand<object>(new Action<object>((obj) =>
                {
                    if (obj == null)
                    {
                        return;
                    }
                    OrderModel _order = obj as OrderModel;
                    DisplSel?.Invoke(_order);
                }));
            }
        }
        public ICommand TotalCmd
        {
            get
            {
                return new RelayCommand<object>(new Action<object>((obj) =>
                {
                    Total = 0;
                    foreach (OrderModel item in Orders)
                    {
                        Total += item.Total;
                    }
                }));
            }
        }
        #endregion

        public OrdersViewModel()
        {

        }

        public Action<AlertType,string,string> DisplShowPopup;
    }
}
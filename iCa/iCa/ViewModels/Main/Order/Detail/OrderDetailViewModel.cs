using Common;
using CommunityToolkit.Mvvm.Input;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using iCa.Models;
using iCa.ViewModels.Main.Order.Detail.ItemsList;
using iCa.Views.Main.Order.Detail.ItemsList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utils;
using Xamarin.Forms;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;

namespace iCa.ViewModels.Main.Order.Detail
{
    public class OrderDetailViewModel:BaseViewModel
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

        private ObservableCollection<OrderDetailModel> _Details;
        public ObservableCollection<OrderDetailModel> Details { get => _Details; set { _Details = value; OnPropertyChanged("Details"); } }

        private int _ItemNumbers;
        public int ItemNumbers { get => _ItemNumbers; set { _ItemNumbers = value; OnPropertyChanged("ItemNumbers"); } }

        SpreadsheetsResource.ValuesResource _googleSheetValues;
        #endregion
        #region Cmd
        public Action DisplBack;
        public ICommand BackCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplBack?.Invoke();
                }));
            }
        }
        public ICommand LoadCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {

                    ObservableCollection<OrderDetailModel> _templst = new ObservableCollection<OrderDetailModel>();

                    var _Query = Orders.Select(x => x.Name).GroupBy(s => s).Select(g => new { Name = g.Key, Count = g.Count() });
                    foreach (var _result in _Query)
                    {
                        List<OrderModel> list = Orders.Where(p=>p.Name == _result.Name).ToList();

                        OrderDetailModel _vm = new OrderDetailModel()
                        {
                            Total = 0,
                            Counter = _result.Count,
                            Title = _result.Name,
                            Orders = new ObservableCollection<OrderModel>()
                        };
                        foreach (OrderModel item in list)
                        {
                            _vm.Total += item.Total;
                            _vm.Orders.Add(item);
                        }
                        _templst.Add(_vm);
                    }


                    foreach (var item in _templst)
                    {
                        var _lst = item.Orders.Select(x => x.Price).GroupBy(s => s).Select(g => new { Price = g.Key, Count = g.Count() });
                        foreach (var _res in _lst)
                        {
                            List<OrderModel> _list = item.Orders.Where(p => p.Price == _res.Price).ToList();

                            // Set total
                            double _weightTotal = 0;
                            double _total = 0;
                            int _count = 0;

                            foreach (OrderModel _ord in _list)
                            {
                                _count += 1;
                                _weightTotal += double.Parse(_ord.Weight);
                                _total += _ord.Total;
                            }

                            OrderDetailModel _lvInfo = new OrderDetailModel()
                            {
                                Title = item.Title,
                                Weight = _weightTotal.ToString(),
                                Price = _list[0].Price.ToString(),
                                Total = _total,
                                Counter = _count,
                                Orders = new ObservableCollection<OrderModel>(_list)
                            };
                            Details.Add(_lvInfo);
                            ItemNumbers += 1;
                        }
                    }
                    //var _Query = Details.Select(x => x.Price).GroupBy(s => s).Select(g => new { Price = g.Key, Count = g.Count() });
                    //foreach (var _result in _Query)
                    //{
                    //    List<OrderModel> _list = _vm.Orders.Where(p => p.Price == _result.Price).ToList();

                    //    // Set price total
                    //    double _priceTotal = 0;
                    //    foreach (OrderModel item in _list)
                    //    {
                    //        _priceTotal += double.Parse(item.Price);
                    //    }

                    //    // Set weight total
                    //    double _weightTotal = 0;
                    //    foreach (OrderModel item in _list)
                    //    {
                    //        _weightTotal += double.Parse(item.Weight);
                    //    }

                    //    // Set height
                    //    double _height = 0;
                    //    if (Xamarin.Forms.Device.Idiom == TargetIdiom.Phone)
                    //    {
                    //        _height = FormBase.DeviceInfo.Height * 0.2;
                    //    }
                    //    else if (Xamarin.Forms.Device.Idiom == TargetIdiom.Tablet)
                    //    {
                    //        _height = FormBase.DeviceInfo.Height * 0.2;
                    //    }
                    //    else
                    //    {
                    //        _height = FormBase.DeviceInfo.Height * 0.2;
                    //    }

                    //    ItemsListView _lvInfo = new ItemsListView()
                    //    {
                    //        HeightRequest = _height,
                    //        BindingContext = new ItemsListViewModel()
                    //        {
                    //            IsBusy = false,
                    //            ResponseOK = true,
                    //            ResponseMessage = "",
                    //            Items = _list,
                    //            PriceTotal = _priceTotal,
                    //            WeightTotal = _weightTotal,
                    //        }
                    //    };
                    //    spnlMain.Children.Add(_lvInfo);
                    //}
                }));
            }
        }

        public Action<ObservableCollection<OrderDetailModel>> DisplCreateSheet;
        public ICommand SaveCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplCreateSheet?.Invoke(Details);
                }));
            }
        }
        #endregion
    }
}

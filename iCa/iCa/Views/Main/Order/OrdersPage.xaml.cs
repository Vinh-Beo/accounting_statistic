using iCa.Models;
using iCa.Views.Main.Order.Menu;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using iCa.ViewModels.Main.Order;
using iCa.Views.Main.Order.Menu.Add;
using iCa.ViewModels.Main.Order.Menu.Add;
using iCa.ViewModels.Main.Order.Menu;
using iCa.ViewModels.Main.Order.Menu.Edit;
using iCa.Views.Main.Order.Menu.Edit;
using iCa.ViewModels.Main.Order.Menu.Delete;
using iCa.Views.Main.Order.Menu.Delete;
using iCa.ViewModels.Main.Order.Detail;
using iCa.Views.Main.Order.Detail;
using System.Collections.ObjectModel;
using Common;
using iCa.ViewModels.Common;
using iCa.Views.Common;
using iCa.ViewModels.Main.Order.Detail.Popup;
using iCa.Views.Main.Order.Detail.Popup;
using System.Diagnostics.Contracts;
using iCa.Language;

namespace iCa.Views.Main.Order
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {
        public OrdersPage()
        {
            //InitializeComponent();
        }
        public OrdersPage(OrdersViewModel _vm)
        {
            InitializeComponent();
            this.BindingContext = _vm as OrdersViewModel;


            _vm.DisplExportExportToSheet += new Action<ObservableCollection<OrderDetailModel>>(async(_orders) =>
            {
                if (PopupNavigation.Instance.PopupStack.Count > 0)
                {
                    await _vm.AppNavigator.PopAllAsync(true);
                }
                CreateSheetNameViewModel _vmSheet = new CreateSheetNameViewModel()
                {
                    IsBusy = false,
                    ResponseOK = true,
                    ResponseMessage = "",
                    Name = "",
                };

                CreateSheetNamePopup _pSheet = new CreateSheetNamePopup()
                {
                    BindingContext = _vmSheet
                };
                await _vm.AppNavigator.PushAsync(_pSheet);

                _vmSheet.DisplOK += new Action<string>(async (_name) =>
                {
                    if (PopupNavigation.Instance.PopupStack.Count > 0)
                    {
                        await _vm.AppNavigator.PopAllAsync(true);
                    }
                    ConfirmFillDataToSheetViewModel _vmConfirm = new ConfirmFillDataToSheetViewModel()
                    {
                        IsBusy = false,
                        ResponseOK = true,
                        ResponseMessage = "",
                        SheetName = _name,
                        Details = new ObservableCollection<OrderDetailModel>(_orders),
                        Message = AppResources.FillDataTo + " " + _name
                    };
                    ConfirmFillDataToSheetPopup _pConfirm = new ConfirmFillDataToSheetPopup()
                    {
                        BindingContext = _vmConfirm
                    };

                    await _vm.AppNavigator.PushAsync(_pConfirm);

                    _vmConfirm.DisplClose += new Action(async () =>
                    {
                        if (PopupNavigation.Instance.PopupStack.Count > 0)
                        {
                            await _vm.AppNavigator.PopAllAsync(true);
                        }
                    });
                });
                _vmSheet.DisplBack += new Action(async () =>
                {
                    if (PopupNavigation.Instance.PopupStack.Count > 0)
                    {
                        await _vm.AppNavigator.PopAllAsync(true);
                    }
                });
            });
            _vm.DisplAdd += new Action(async () =>
            {
                if (PopupNavigation.Instance.PopupStack.Count > 0)
                {
                    await _vm.AppNavigator.PopAllAsync(true);
                }
                AddNewOrderViewModel _vmAdd = new AddNewOrderViewModel()
                {
                    IsBusy = false,
                    ResponseOK = true,
                    ResponseMessage = "",
                    Info = new OrderModel()
                    {
                        CreateTime = DateTime.Now
                    }
                };

                AddNewOrderPopup _pAdd = new AddNewOrderPopup()
                {
                    BindingContext = _vmAdd
                };

                await _vm.AppNavigator.PushAsync(_pAdd);
                #region Register event
                _vmAdd.DisplOK += new Action<OrderModel>(async (_info) =>
                {
                    _vm.Orders.Add(_info);
                    await _vm.AppNavigator.PopAsync();
                });
                _vmAdd.DisplClose += new Action(async () =>
                {
                    await _vm.AppNavigator.PopAsync();
                });
                #endregion
            });
            _vm.DisplDeleteAll += new Action(() =>
            {
                _vm.Orders.Clear();
            });
            _vm.DisplDetail += new Action(async() =>
            {
                if (PopupNavigation.Instance.PopupStack.Count > 0)
                {
                    await _vm.AppNavigator.PopAllAsync(true);
                }
                OrderDetailViewModel _vmDetail = new OrderDetailViewModel()
                {
                    IsBusy = false,
                    ResponseOK = true,
                    ResponseMessage = "",
                    Orders = _vm.Orders,
                    Details = new ObservableCollection<OrderDetailModel>(),
                    ItemNumbers = 0
                };
                if (_vmDetail.LoadCmd != null || _vmDetail.LoadCmd.CanExecute(null))
                {
                    _vmDetail.LoadCmd.Execute(null);
                }
                OrderDetailPage _pDetail = new OrderDetailPage(_vmDetail);
                await _vm.AppNavigator.NavigateAsync(_pDetail);
                _vmDetail.DisplCreateSheet += new Action<ObservableCollection<OrderDetailModel>>(async (_orders) =>
                {
                    if (PopupNavigation.Instance.PopupStack.Count > 0)
                    {
                        await _vm.AppNavigator.PopAllAsync(true);
                    }
                    CreateSheetNameViewModel _vmSheet = new CreateSheetNameViewModel()
                    {
                        IsBusy = false,
                        ResponseOK = true,
                        ResponseMessage = "",
                        Name = "",
                    };

                    CreateSheetNamePopup _pSheet = new CreateSheetNamePopup()
                    {
                        BindingContext = _vmSheet
                    };
                    await _vm.AppNavigator.PushAsync(_pSheet);

                    _vmSheet.DisplOK += new Action<string>(async(_name) =>
                    {
                        if (PopupNavigation.Instance.PopupStack.Count > 0)
                        {
                            await _vm.AppNavigator.PopAllAsync(true);
                        }
                        ConfirmFillDataToSheetViewModel _vmConfirm = new ConfirmFillDataToSheetViewModel()
                        {
                            IsBusy = false,
                            ResponseOK = true,
                            ResponseMessage = "",
                            SheetName = _name,
                            Details = new ObservableCollection<OrderDetailModel>(_orders),
                            Message =AppResources.FillDataTo + " " + _name
                        };
                        ConfirmFillDataToSheetPopup _pConfirm = new ConfirmFillDataToSheetPopup()
                        {
                            BindingContext = _vmConfirm
                        };

                        await _vm.AppNavigator.PushAsync( _pConfirm );

                        _vmConfirm.DisplClose += new Action(async() =>
                        {
                            if (PopupNavigation.Instance.PopupStack.Count > 0)
                            {
                                await _vm.AppNavigator.PopAllAsync(true);
                            }
                        });
                    });
                    _vmSheet.DisplBack += new Action(async() =>
                    {
                        if (PopupNavigation.Instance.PopupStack.Count > 0)
                        {
                            await _vm.AppNavigator.PopAllAsync(true);
                        }
                    });
                });
            });
            _vm.DisplSel += new Action<OrderModel>(async (_order) =>
            {
                if (PopupNavigation.Instance.PopupStack.Count > 0)
                {
                    await _vm.AppNavigator.PopAllAsync(true);
                }

                OrderMenuViewModel _vmMenu = new OrderMenuViewModel()
                {
                    IsBusy = false,
                    ResponseOK = true,
                    ResponseMessage = "",
                    Info = _order
                };
                OrderMenuPopup _pMenu = new OrderMenuPopup()
                {
                    BindingContext = _vmMenu
                };
                await _vm.AppNavigator.PushAsync(_pMenu);
                _vmMenu.DisplEdit += new Action(async() =>
                {
                    if (PopupNavigation.Instance.PopupStack.Count > 0)
                    {
                        await _vm.AppNavigator.PopAllAsync(true);
                    }
                    EditOrderViewModel _vmEdit = new EditOrderViewModel()
                    {
                        IsBusy = false,
                        ResponseOK = true,
                        ResponseMessage = "",
                        Info = _order
                    };
                    EditOrderPopup _pEdit = new EditOrderPopup()
                    {
                        BindingContext = _vmEdit
                    };
                    await _vm.AppNavigator.PushAsync(_pEdit);
                    _vmEdit.DisplOK += new Action<OrderModel>((_ord) =>
                    {
                        _order = _ord;
                        _vm.AppNavigator.PopAsync(true);
                    });
                    _vmEdit.DisplClose += new Action(() =>
                    {
                        _vm.AppNavigator.PopAsync(true);
                    });
                });
                _vmMenu.DisplDelete += new Action(async() =>
                {
                    if (PopupNavigation.Instance.PopupStack.Count > 0)
                    {
                        await _vm.AppNavigator.PopAllAsync(true);
                    }
                    DeleteOrderViewModel _vmDelete = new DeleteOrderViewModel()
                    {
                        IsBusy = false,
                        ResponseOK = true,
                        ResponseMessage = "",
                        Info = _order
                    };
                    DeleteOrderPopup _pDelete = new DeleteOrderPopup()
                    {
                        BindingContext = _vmDelete
                    };
                    await _vm.AppNavigator.PushAsync(_pDelete);
                    _vmDelete.DisplClose += new Action(() =>
                    {
                        _vm.Orders.Remove(_order);
                        _vm.AppNavigator.PopAsync(true);
                    });
                });
            });
        }

        private void Handle_Refresh(object sender, EventArgs e)
        {

        }

        private void Handle_Scrolled(object sender, ScrolledEventArgs e)
        {

        }

        async void Handle_TouchActionAsync(object sender, Gesture.TouchActionEventArgs args)
        {
            
        }

        private void Handle_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (BindingContext == null)
            {
                return;
            }
            if (BindingContext.GetType() != typeof(OrdersViewModel))
            {
                return;
            }
            OrdersViewModel _vm = BindingContext as OrdersViewModel;
            if (e.SelectedItem == null)
            {
                return;
            }
            if (e.SelectedItem.GetType() != typeof(OrderModel))
            {
                return;
            }
            OrderModel _obj = (OrderModel)e.SelectedItem;

            if (_vm.MenuCmd != null && _vm.MenuCmd.CanExecute(_obj))
            {
                _vm.MenuCmd.Execute(_obj);
            }
        }

        private void Handle_PlusClicked(object sender, EventArgs e)
        {
            if (BindingContext == null)
            {
                return;
            }
            if (BindingContext.GetType() != typeof(OrdersViewModel))
            {
                return;
            }
            OrdersViewModel _vm = BindingContext as OrdersViewModel;
        }

        private void Handle_MinusClicked(object sender, EventArgs e)
        {
            if (BindingContext == null)
            {
                return;
            }
            if (BindingContext.GetType() != typeof(OrdersViewModel))
            {
                return;
            }
            OrdersViewModel _vm = BindingContext as OrdersViewModel;
        }
    }
}
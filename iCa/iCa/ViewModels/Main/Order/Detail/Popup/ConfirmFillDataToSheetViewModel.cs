using Common;
using CommunityToolkit.Mvvm.Input;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using iCa.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utils;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;
using System.Collections.ObjectModel;
using ICa.Language;
using iCa.Language;

namespace iCa.ViewModels.Main.Order.Detail.Popup
{
    public class ConfirmFillDataToSheetViewModel:BaseViewModel
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
        private string _SheetName;
        public string SheetName { get => _SheetName; set { _SheetName = value; OnPropertyChanged("SheetName"); } }

        private ObservableCollection<OrderDetailModel> _Details;
        public ObservableCollection<OrderDetailModel> Details { get => _Details; set { _Details = value; OnPropertyChanged("Details"); } }
        private string _Message;
        public string Message { get => _Message; set { _Message = value; OnPropertyChanged("Message"); } }
        #endregion
        #region Cmd
        public ICommand OKCmd
        {
            get
            {
                return new RelayCommand(new Action(async () =>
                {
                    IsBusy = true;
                    ResponseOK = true;
                    ResponseMessage = "";
                    try
                    {
                        await Task.Factory.StartNew(() =>
                        {
                            // Create title
                            SpreadsheetsResource.ValuesResource _googleSheetValues = FormBase.Service.Spreadsheets.Values;
                            var range = $"{SheetName}!A1:M";

                            var valueRange = new ValueRange
                            {
                                Values = ItemsMapper.CreateTitle()
                            };

                            var appendRequest = _googleSheetValues.Append(valueRange, UserConstant.Spreadsheet_id, range);
                            appendRequest.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
                            appendRequest.Execute();


                            // Fill data
                            var rangeData = $"{SheetName}!A1:M";
                            int _cnt = 0;
                            foreach (OrderDetailModel _order in Details)
                            {
                                _cnt += 1;
                                var valueRangeData = new ValueRange
                                {
                                    Values = ItemsMapper.MapToRangeData(_order, _cnt)
                                };
                                appendRequest = _googleSheetValues.Append(valueRangeData, UserConstant.Spreadsheet_id, rangeData);
                                appendRequest.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
                                appendRequest.Execute();
                            }
                        });
                    }
                    catch (Exception e)
                    {
                        ResponseOK = false;
                        ResponseMessage = e.ToString();
                        return;
                    }
                    IsBusy = false;
                    ResponseOK = true;
                    ResponseMessage = AppResources.Success;
                    DisplClose?.Invoke();
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

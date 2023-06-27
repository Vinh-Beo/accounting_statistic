using Common;
using CommunityToolkit.Mvvm.Input;
using Google.Apis.Sheets.v4.Data;
using iCa.Models;
using iCa.Language;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utils;

namespace iCa.ViewModels.Main.Order.Detail.Popup
{
    public class CreateSheetNameViewModel:BaseViewModel
    {
        #region Common prop
        private bool _IsBusy;
        public bool IsBusy { get => _IsBusy; set { _IsBusy = value; OnPropertyChanged("IsBusy"); } }

        private bool _ResponseOK;
        public bool ResponseOK { get => _ResponseOK; set { _ResponseOK = value; OnPropertyChanged("ResponseOK"); } }
        private string _ResponseMessage;
        public string ResponseMessage { get => _ResponseMessage; set { _ResponseMessage = value; OnPropertyChanged("ResponseMessage"); } }
        #endregion
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged("Name"); } }
        #region Cmd
        public Action<string> DisplOK;
        public ICommand OKCmd
        {
            get
            {
                return new RelayCommand(new Action(async () =>
                {
                    #region Check input
                    if (String.IsNullOrEmpty(Name))
                    {
                        ResponseOK = false;
                        ResponseMessage = AppResources.NoInput;
                        return;
                    }
                    Name = Name.Trim();
                    #endregion
                    IsBusy = true;
                    ResponseOK = true;
                    ResponseMessage = "";
                    try
                    {
                        await Task.Factory.StartNew(() =>
                        {
                            // Add new Sheet
                            var addSheetRequest = new AddSheetRequest();
                            addSheetRequest.Properties = new SheetProperties();
                            addSheetRequest.Properties.Title = Name;
                            BatchUpdateSpreadsheetRequest batchUpdateSpreadsheetRequest = new BatchUpdateSpreadsheetRequest();
                            batchUpdateSpreadsheetRequest.Requests = new List<Request>();
                            batchUpdateSpreadsheetRequest.Requests.Add(new Request
                            {
                                AddSheet = addSheetRequest
                            });

                            var batchUpdateRequest = FormBase.Service.Spreadsheets.BatchUpdate(batchUpdateSpreadsheetRequest, UserConstant.Spreadsheet_id);
                            batchUpdateRequest.Execute();
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
                    DisplOK?.Invoke(Name);
                }));
            }
        }
        public Action DisplBack;
        public ICommand CancelCmd
        {
            get
            {
                return new RelayCommand(new Action(() =>
                {
                    DisplBack?.Invoke();
                }));
            }
        }
        #endregion
    }
}

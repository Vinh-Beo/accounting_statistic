using Common;
using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace iCa.ViewModels.Common
{
    public class AlertDialogViewModel:BaseViewModel
    {
        #region Working prop
        private AlertType _Type;
        public AlertType Type { get => _Type; set { _Type = value; OnPropertyChanged("Type"); } }

        private string _Message;
        public string Message { get => _Message; set { _Message = value; OnPropertyChanged("Message"); } }

        private string _Description;
        public string Description { get => _Description; set { _Description = value; OnPropertyChanged("Description"); } }
        #endregion
    }
}

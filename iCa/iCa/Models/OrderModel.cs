using CommunityToolkit.Mvvm.Input;
using iCa.ViewModels;
using System;
using System.Windows.Input;
using Utils;

namespace iCa.Models
{
    public class OrderModel:BaseViewModel
    {
        private long _Id;
        public long Id { get => _Id; set { _Id = value; OnPropertyChanged("Id"); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged("Name"); } }
        private string _Type;
        public string Type { get => _Type; set { _Type = value; OnPropertyChanged("Type"); } }
        private string _Weight;
        public string Weight { get => _Weight; set { _Weight = value; OnPropertyChanged("Weight"); } }
        private string _Price;
        public string Price { get => _Price; set { _Price = value; OnPropertyChanged("Price"); } }
        private double _Total;
        public double Total { get => _Total; set { _Total = value; OnPropertyChanged("Total"); } }
        private DateTime _CreateTime;
        public DateTime CreateTime { get => _CreateTime; set { _CreateTime = value; OnPropertyChanged("CreateTime"); } }
        #region Cmd
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
        #endregion
    }
}

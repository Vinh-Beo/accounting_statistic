using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace iCa.Models
{
    public static class ItemsMapper
    {
        public static List<OrderModel> MapFromRangeData(IList<IList<object>> values)
        {
            var items = new List<OrderModel>();
            foreach (var value in values)
            {
                OrderModel item = new OrderModel()
                {
                    Id = long.Parse(value[0].ToString()),
                    Name = value[1].ToString(),
                    Weight = value[2].ToString(),
                    Price = value[3].ToString()
                };
                items.Add(item);
            }
            return items;
        }
        public static IList<IList<object>> MapToRangeData(OrderDetailModel item,int _id)
        {

            OrderToSheetModel _sheetModel = new OrderToSheetModel()
            {
                Id = _id,
                Attribute = 1,
                Code = "",
                Name = item.Title,
                WeightUnit = UserConstant.WeightUnit,
                Weight = item.Weight,
                Price = item.Price,
                DiscountRate = 0,
                DiscountMoney = 0,
                MoneyBeforeTax = item.Total,
                Tax = 0,
                TaxMoney = 0,
                Discount = 0,
                MoneyAfterTax = item.Total
            };
            var objectList = new List<object>() 
            { 
                _sheetModel.Id,
                _sheetModel.Attribute,
                _sheetModel.Code,
                _sheetModel.Name,
                _sheetModel.WeightUnit,
                _sheetModel.Weight,
                _sheetModel.Price + "000",
                _sheetModel.DiscountRate,
                _sheetModel.DiscountMoney,
                _sheetModel.MoneyBeforeTax * 1000,
                _sheetModel.Tax,
                _sheetModel.Discount,
                _sheetModel.MoneyAfterTax * 1000
            };
            var rangeData = new List<IList<object>> { objectList };
            return rangeData;
        }

        public static IList<IList<object>> CreateTitle()
        {
            var objectList = new List<object>()
            {
                "STT",
                "Tính chất",
                "Mã hàng",
                "Tên hàng",
                "Đơn vị tính",
                "Số lượng",
                "Đơn giá",
                "Tỷ lệ chiết khấu",
                "Tiền chiết khấu",
                "Thành tiền trước thuế",
                "Thuế suất",
                "Tiền thuế",
                "Tiền sau thuế"
            };
            var rangeData = new List<IList<object>> { objectList };
            return rangeData;
        }
    }
}

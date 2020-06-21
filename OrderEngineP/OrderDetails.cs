using System.Collections.Generic;

namespace OrderEngineP
{
    public class OrderDetails
    {
        public int OrderId { get; set; }

        public int TotalAmount { get; set; }

        public List<Product> ProductList { get; set; }

        public OrderDetails(int orderId)
        {
            OrderId = orderId;
        }

        public int GetTotalOrderAmount()
        {
            TotalAmount = 0;
            return TotalAmount;
        }

        public List<Product> AddSkuIds(string skuId,int price)
        {            
            List<Product> SkuList = new List<Product>();
            
            return SkuList;
        }
    }
}
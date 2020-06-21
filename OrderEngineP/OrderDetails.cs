using System.Collections.Generic;

namespace OrderEngineP
{
    public class OrderDetails
    {
        public int OrderId { get; set; }

        public int TotalAmount { get; set; }

        private readonly List<Product> ProductList;

        public OrderDetails(int orderId)
        {
            OrderId = orderId;
            ProductList = new List<Product>();
        }

        public int GetTotalOrderAmount()
        {
            TotalAmount = 0;
            return TotalAmount;
        }

        public void AddSkuIds(string skuId,int price)
        {
            Product _product = new Product();
            _product.SkuId = skuId;
            _product.Price = price;
            ProductList.Add(_product);           
          
        }

        public List<Product> GetProduct()
        {
            if (ProductList.Count >0) return ProductList;

           return null;
        }
    }
}
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace OrderEngineP
{
    public class OrderDetails
    {
        public int OrderId { get; set; }

        public int OrderofSkuIds { get; set; }

        public int TotalAmount { get; set; }

        private readonly List<Product> ProductList;

        private readonly List<Order> OrderList;

        private readonly List<Promotion> PromotionList;

        public OrderDetails(int orderId)
        {
            OrderId = orderId;
            OrderList = new List<Order>();
            ProductList = new List<Product>();
            PromotionList = new List<Promotion>();
        }

        public int GetTotalOrderAmount()
        {
            TotalAmount = 0;
            if (OrderList.Count > 0 && ProductList.Count > 0 && PromotionList.Count > 0)
            {
                foreach (var item in OrderList)
                {
                    Promotion p = GetPromotion(item.SkuId);
                    if (p != null)
                    {
                        int noids = p.NoOfUnit;
                        int price = p.Price;
                        if (item.NoOfSkuId == noids)
                        {
                            TotalAmount = TotalAmount + price;
                        }
                        else if (item.NoOfSkuId > noids)
                        {
                            int x = item.NoOfSkuId - noids;
                            TotalAmount = TotalAmount + price + x * (ProductList.Where(y => y.SkuId == item.SkuId).SingleOrDefault().Price);
                        }

                        else if (item.NoOfSkuId < noids)
                        {

                            TotalAmount = TotalAmount + item.NoOfSkuId * (ProductList.Where(y => y.SkuId == item.SkuId).SingleOrDefault().Price);
                        }
                    }
                    else
                    {
                        TotalAmount = TotalAmount + item.NoOfSkuId * (ProductList.Where(y => y.SkuId == item.SkuId).SingleOrDefault().Price);
                    }
                }

               
                
            }
            return TotalAmount;
        }

        public void AddSkuIds(string skuId,int price)
        {
            Product _product = new Product();
            _product.SkuId = skuId;
            _product.Price = price;
            if (!ProductList.Contains(_product))
            {
                ProductList.Add(_product);
            }
          
        }

        public void orderDetails(int noOfSkuId, string skuId)
        {
            Order _order = new Order();
            _order.SkuId = skuId;
            _order.NoOfSkuId = noOfSkuId;
          
            if (!OrderList.Contains(_order))
            {
                OrderList.Add(_order);
            }

        }

        public void AddPromotion(int noOfUnit,string skuId, string description,int price)
        {
            Promotion _promotion = new Promotion();
            _promotion.SkuId = skuId;
            _promotion.NoOfUnit = noOfUnit;
            _promotion.Description = description;
            _promotion.Price = price;
            if (!PromotionList.Contains(_promotion))
            {
                PromotionList.Add(_promotion);
            }

        }

        public Product GetProduct(string skuId)
        {
            if (ProductList.Count > 0)
            {
                return ProductList.Where(x =>x.SkuId== skuId).SingleOrDefault();
            }

           return null;
        }

        public Promotion GetPromotion(string skuId)
        {
            if (PromotionList.Count > 0)
            {
                return PromotionList.Where(x => x.SkuId == skuId).SingleOrDefault();
            }

            return null;
        }

        public bool ProductListIsEmpty()
        {
            return ProductList.Count == 0;
        }

        public bool PromotionListIsEmpty()
        {
            return PromotionList.Count == 0;
        }

    }
}
using System.Collections.Generic;
using System.Linq;

namespace OrderEngineP
{
    public class OrderDetails
    {
        public int OrderId { get; set; }

        public int TotalAmount { get; set; }

        private readonly List<Product> ProductList;

        private readonly List<Promotion> PromotionList;

        public OrderDetails(int orderId)
        {
            OrderId = orderId;
            ProductList = new List<Product>();
            PromotionList = new List<Promotion>();
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
            if (ProductList.Count > 0 && !ProductList.Contains(_product))
            {
                ProductList.Add(_product);
            }
          
        }

        public void AddPromotion(int noOfUnit,string skuId, string description,int price)
        {
            Promotion _promotion = new Promotion();
            _promotion.SkuId = skuId;
            _promotion.NoOfUnit = noOfUnit;
            _promotion.Description = description;
            _promotion.Price = price;
            if (PromotionList.Count > 0 && !PromotionList.Contains(_promotion))
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
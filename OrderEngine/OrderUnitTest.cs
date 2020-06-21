using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderEngineP;

namespace OrderEngine
{
    [TestClass]
    public class OrderUnitTest
    {
        [TestMethod]
        public void CreateOrderDetails()
        {
            int orderId = 1;
            var orderdetails = new OrderDetails(orderId);
            Assert.AreEqual(1,orderdetails.OrderId);
            Assert.AreEqual(0, orderdetails.TotalAmount);
        }

        [TestMethod]
        public void CreateOrderDetails_Product()
        {            
            int orderId = 1;
            var orderdetails = new OrderDetails(orderId);           
            orderdetails.AddSkuIds("A",50);
            Assert.AreEqual(1, orderdetails.OrderId);
            Assert.IsTrue(orderdetails.GetProduct("A").Price == 50);
        }

        [TestMethod]
        public void CreateOrderDetails_Product_Empty()
        {
            int orderId = 1;
            var orderdetails = new OrderDetails(orderId);
            Assert.IsTrue(orderdetails.ProductListIsEmpty());
        }

        [TestMethod]
        public void CreateOrderDetails_ProductwithPromotion()
        {
            int orderId = 1;
            var orderdetails = new OrderDetails(orderId);
            orderdetails.AddSkuIds("A", 50);
            orderdetails.AddSkuIds("B", 30);
            orderdetails.AddSkuIds("C", 20);
            orderdetails.AddSkuIds("D", 15);
            orderdetails.AddPromotion(3, "A", "3 A's of 130", 130);
            orderdetails.AddPromotion(2, "B", "2 B's of 45", 45);
            Assert.IsTrue(orderdetails.GetPromotion("A").Price == 130);
        }
    }
}

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
            orderdetails.AddSkuIds();
            Assert.AreEqual(1, orderdetails.OrderId);
            Assert.IsTrue(orderdetails.ProductList.Count == 0);

        }
    }
}

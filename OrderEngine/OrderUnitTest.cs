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
            
        }
    }
}

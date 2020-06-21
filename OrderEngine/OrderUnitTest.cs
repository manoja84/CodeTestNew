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
            var orderdetails = new OrderDetails(1);
            Assert.AreEqual(1,orderdetails.OrderId);          
            
        }
    }
}

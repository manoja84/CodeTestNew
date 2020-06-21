using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderEngineP;
using Moq;

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

        [TestMethod]
        public void CreateOrderDetails_ProductwithPromotion_returnTotalAmount()
        {
            int orderId = 1;
            var orderdetails = new OrderDetails(orderId);
            orderdetails.AddSkuIds("A", 50);
            orderdetails.AddSkuIds("B", 30);
            orderdetails.AddSkuIds("C", 20);
            orderdetails.AddSkuIds("D", 15);
            orderdetails.AddPromotion(3, "A", "3 A's of 130", 130);
            orderdetails.AddPromotion(2, "B", "2 B's of 45", 45);
            orderdetails.orderDetails(1, "A");
            orderdetails.orderDetails(1, "B");
            orderdetails.orderDetails(1, "C");
            Assert.IsTrue(orderdetails.GetTotalOrderAmount() == 100);
        }

        [TestMethod]
        public void CreateOrderDetails_ProductwithPromotionMixedSkids_returnTotalAmount()
        {
            int orderId = 1;
            var orderdetails = new OrderDetails(orderId);
            orderdetails.AddSkuIds("A", 50);
            orderdetails.AddSkuIds("B", 30);
            orderdetails.AddSkuIds("C", 20);
            orderdetails.AddSkuIds("D", 15);
            orderdetails.AddPromotion(3, "A", "3 A's for 130", 130);
            orderdetails.AddPromotion(2, "B", "2 B's for 45", 45);
            orderdetails.AddPromotion(1, "C & D", "C & D for 30", 30);
            orderdetails.orderDetails(3, "A");
            orderdetails.orderDetails(5, "B");
            orderdetails.orderDetails(1, "C");
            orderdetails.orderDetails(1, "D");
            Assert.IsTrue(orderdetails.GetTotalOrderAmount() == 280);
        }

        [TestMethod]
        public void CreateOrderDetails_ProductwithPromotionNewPromotionCode_returnTotalAmount()
        {
            int orderId = 1;
            var orderdetails = new OrderDetails(orderId);
            orderdetails.AddSkuIds("A", 50);
            orderdetails.AddSkuIds("B", 30);
            orderdetails.AddSkuIds("C", 20);
            orderdetails.AddSkuIds("D", 15);
            orderdetails.AddSkuIds("X", 10);
            orderdetails.AddPromotion(3, "A", "3 A's for 130", 130);
            orderdetails.AddPromotion(2, "B", "2 B's for 45", 45);
            orderdetails.AddPromotion(1, "C & D", "C & D for 30", 30);
            orderdetails.AddPromotion(1, "X", "X for 10", 10);
            orderdetails.orderDetails(3, "A");
            orderdetails.orderDetails(5, "B");
            orderdetails.orderDetails(1, "C");
            orderdetails.orderDetails(1, "D");
            orderdetails.orderDetails(1, "X");
            Assert.IsTrue(orderdetails.GetTotalOrderAmount() == 290);
        }

        [TestMethod]
        public void TestEmptyOrder_moq()
        {
            var mockorder = new Mock<IOrderDetails>();
            mockorder
                .Setup(dp => dp.GetOrderId())
                .Returns(0);

            var dict = new OrderDetails(mockorder.Object);
            Assert.AreEqual(dict.OrderId, 0);
        }
    }
}

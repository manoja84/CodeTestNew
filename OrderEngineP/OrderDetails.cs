namespace OrderEngineP
{
    public class OrderDetails
    {
        public int OrderId { get; set; }

      

        public OrderDetails(int orderId)
        {
            OrderId = orderId;
        }
    }
}
namespace OrderEngineP
{
    public class OrderDetails
    {
        public int OrderId { get; set; }

        public int TotalAmount { get; set; }

        public OrderDetails(int orderId)
        {
            OrderId = orderId;
        }

        public int GetTotalOrderAmount()
        {
            TotalAmount = 0;
            return TotalAmount;
        }
    }
}
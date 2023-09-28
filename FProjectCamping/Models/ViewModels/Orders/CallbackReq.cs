namespace FProjectCamping.Models.ViewModels.Orders
{
    public class CallbackReq
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; }

        public bool IsSuccessed { get; set; }
    }
}
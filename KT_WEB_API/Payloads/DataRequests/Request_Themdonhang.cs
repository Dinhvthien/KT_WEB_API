namespace KT_WEB_API.Payloads.DataRequests
{
    public class Request_Themdonhang
    {
        public int ProductDetailId { get; set; }
        public int PropertyDetailParentId { get; set; }
        public List<int> PropertyDetailId { get; set; }
        public int ProductId { get; set; }
        public int Soluong { get; set; }

    }
}

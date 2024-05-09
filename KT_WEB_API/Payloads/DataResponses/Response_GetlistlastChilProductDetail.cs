namespace KT_WEB_API.Payloads.DataResponses
{
    public class Response_GetlistlastChilProductDetail
    {
        public string ProductDetailName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double ShellPrice { get; set; }
        public int? ParentId { get; set; }
    }
}

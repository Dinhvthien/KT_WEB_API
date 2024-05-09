using KT_WEB_API.DataContext;
using KT_WEB_API.Entities;
using KT_WEB_API.Payloads.DataResponses;

namespace KT_WEB_API.Payloads.Converters
{
    public class Getlist
    {
        private readonly AppDbContext _context;
        public Getlist()
        {
            _context = new AppDbContext();
        }
        public Response_GetlistlastChilProductDetail DataRespomseChiTietHoaDon(ProductDetails productDetails)
        {
            return new Response_GetlistlastChilProductDetail()
            {
                ProductDetailName = productDetails.ProductDetailName,
                Quantity = productDetails.Quantity,
                Price = productDetails.Price,
                ShellPrice  = productDetails.ShellPrice,
                ParentId = productDetails.ParentId,
            };
        }
    }
}

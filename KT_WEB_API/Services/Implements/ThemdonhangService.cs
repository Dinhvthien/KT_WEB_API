using KT_WEB_API.DataContext;
using KT_WEB_API.Entities;
using KT_WEB_API.Payloads.Converters;
using KT_WEB_API.Payloads.DataRequests;
using KT_WEB_API.Payloads.DataResponses;
using KT_WEB_API.Payloads.Responses;
using KT_WEB_API.Services.Interfaces;
using System.Collections.Generic;

namespace KT_WEB_API.Services.Implements
{
    public class ThemdonhangService : IThemdonhangService
    {
        private readonly AppDbContext _context;
        private readonly ResponseThemdonhang _responsethemdonhang;
        private readonly ResponseGetlist<Response_GetlistlastChilProductDetail> _responsegetlist;
        private readonly Getlist _glConverter;

        public ThemdonhangService(ResponseThemdonhang responsethemdonhang)
        {
            _context = new AppDbContext();
            _responsethemdonhang = responsethemdonhang;
            _responsegetlist = new ResponseGetlist<Response_GetlistlastChilProductDetail>();
            _glConverter = new Getlist();
        }

        public List<ResponseGetlist<Response_GetlistlastChilProductDetail>> Getlast()
        {
            // Truy vấn LINQ để lấy các bản ghi không có bản ghi con
            var lastProductDetail = _context.ProductDetails.Where(p => !_context.ProductDetails.Any(child => child.ParentId == p.ProductDetailId)).ToList();

            List<ProductDetails> listchid = new List<ProductDetails>();
            List<ResponseGetlist<Response_GetlistlastChilProductDetail>> responseGetlists = new List<ResponseGetlist<Response_GetlistlastChilProductDetail>>();
            foreach (var item in lastProductDetail)
            {
                var response = _responsegetlist.ResponseSuccses(_glConverter.DataRespomseChiTietHoaDon(item));
                responseGetlists.Add(response);
            }
            return responseGetlists;
        }

        public ResponseThemdonhang Themdonhang(List<Request_Themdonhang> listdh)
        {
            foreach (var item in listdh)
            {
                if (item.PropertyDetailId.Count() == 0)
                {
                    return _responsethemdonhang.ResponseError(404, "Bạn chưa có thuộc tính sản phẩm nào");
                }
                if (!_context.Products.Any(c => c.ProductId == item.ProductId))
                {
                    return _responsethemdonhang.ResponseError(404, "không tìm thấy sản phẩm");
                }
                if (!_context.ProductDetails.Any(c => c.ProductDetailId == item.ProductDetailId))
                {
                    return _responsethemdonhang.ResponseError(404, "không tìm thấy sản phẩm chi tiết");
                }
                if (!_context.ProductDetailPropertyDetails.Any(c => c.ProductDetailId == item.ProductDetailId && c.PropertyDetailId == item.PropertyDetailParentId && c.ProductId == item.ProductId))
                {
                    return _responsethemdonhang.ResponseError(404, "Không tìm thấy ProductDetailPropertyDetails nào như vậy cả ");
                }
                var getNameProductdetail = _context.ProductDetails.SingleOrDefault(c => c.ProductDetailId == item.PropertyDetailParentId).ProductDetailName;
                string getNamePropertys = "";

                List<PropertyDetails> propertyDetails = new List<PropertyDetails>();
                foreach (var items in item.PropertyDetailId)
                {
                    if (!_context.PropertyDetails.Any(c => c.PropertyDetailId == items))
                    {
                        return _responsethemdonhang.ResponseError(404, "Không tìm thấy thuộc tính");
                    }
                    var Property = _context.PropertyDetails.SingleOrDefault(c => c.PropertyDetailId == items);
                    propertyDetails.Add(Property);
                }

                foreach (var name in propertyDetails.OrderBy(c => c.PropertyId))
                {
                    getNamePropertys += name.PropertyDetailDetail + " ";
                }
                var NameProductDetail = getNameProductdetail + " " + getNamePropertys;
                var findProductDetailChil = _context.ProductDetails.FirstOrDefault(c => c.ProductDetailName.Trim().ToLower().Contains(NameProductDetail.Trim().ToLower()));

                if (findProductDetailChil == null)
                {
                    return _responsethemdonhang.ResponseError(404, "Không tìm thấy sản phẩm nào như vậy cả ");
                }
                if (findProductDetailChil.Quantity < item.Soluong)
                {
                    return _responsethemdonhang.ResponseError(404, $"số lượng sản phẩm {NameProductDetail} không đủ");
                }
                findProductDetailChil.Quantity -= item.Soluong;
                _context.ProductDetails.Update(findProductDetailChil);
            }
            _context.SaveChanges();
            return _responsethemdonhang.ResponseSuccses("Them don hang thanh cong");
        }
    }
}

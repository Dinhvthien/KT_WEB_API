using KT_WEB_API.Payloads.DataRequests;
using KT_WEB_API.Payloads.DataResponses;
using KT_WEB_API.Payloads.Responses;

namespace KT_WEB_API.Services.Interfaces
{
    public interface IThemdonhangService
    {
        public ResponseThemdonhang Themdonhang(List<Request_Themdonhang> listdh);
        public List<ResponseGetlist<Response_GetlistlastChilProductDetail>> Getlast();
        public ResponseThemdonhang Updatepd(Request_Themdonhang dh);
    }
}

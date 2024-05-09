using KT_WEB_API.Payloads.DataRequests;
using KT_WEB_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KT_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemdonhangController : ControllerBase
    {
        private readonly IThemdonhangService _hoaDonService;
        public ThemdonhangController(IThemdonhangService hoaDonService)
        {
            _hoaDonService = hoaDonService;
        }
        [HttpPost("ThemHoaDon")]
        public IActionResult ThemHoaDon(List<Request_Themdonhang> request)
        {
            return Ok(_hoaDonService.Themdonhang(request));
        }
        [HttpGet]
        public IActionResult DSProductdetailchild()
        {
            var dsHd = _hoaDonService.Getlast();
            return Ok(dsHd);
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using QRCodeScanner.Models;
using QRCodeScanner.Services;
using System.Diagnostics;

namespace QRCodeScanner.Controllers
{
    public class HomeController : Controller
    {
        IWebHostEnvironment _webHostEnvironment;
        private readonly QRCodeService qrCodeService = new QRCodeService();

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            // 若網站路徑是在 D:/Desktop 表示是用 F5 偵錯，PORT=44335
            if (_webHostEnvironment.WebRootPath.StartsWith("D:\\Desktop"))
            {
                ViewBag.DecodeUrl = "https://localhost:44335/Home/QRDecoder";
            }
            // 否則是位在發佈之後的 IIS 站台，PORT=6600
            else
            {
                ViewBag.DecodeUrl = "http://localhost:6600/Home/QRDecoder";
            }

            return View();
        }

        public string QRDecoder(string base64Str)
        {
            return qrCodeService.DecodeBarOrQRCode(base64Str);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

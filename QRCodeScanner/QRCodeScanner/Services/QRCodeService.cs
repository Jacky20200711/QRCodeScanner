using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using ZXing;

namespace QRCodeScanner.Services
{
    public class QRCodeService
    {
        /// <summary>
        /// 返回 QRCode 解碼之後的內容
        /// </summary>
        public string DecodeBarOrQRCode(string base64Str)
        {
            try
            {
                // 解碼 AJAX 送過來的 base64 字串
                var base64Data = Regex.Match(base64Str, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                var byteArray = Convert.FromBase64String(base64Data);

                // 將 byte 轉成 stream
                MemoryStream memoryStream = new MemoryStream(byteArray);

                // 解碼 QRCode
                BarcodeReader reader = new BarcodeReader();
                var barcodeBitmap = (Bitmap)Image.FromStream(memoryStream);
                var result = reader.Decode(barcodeBitmap);
                return result == null ? "解碼失敗" : result.Text;
            }
            catch (Exception)
            {
                return "解碼失敗";
            }
        }
    }
}

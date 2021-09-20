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
                
                // 如果解碼失敗，增加圖片亮度並重新再試一次
                if(result == null)
                {
                    barcodeBitmap = SetImageLight(barcodeBitmap, 30);
                    result = reader.Decode(barcodeBitmap);
                }

                barcodeBitmap.Dispose();
                return result == null ? "解碼失敗" : result.Text;
            }
            catch (Exception)
            {
                return "解碼失敗";
            }
        }

        /// <summary>
        /// 調整圖案亮度(若 degree 大於 0 會變亮，小於 0 則會變暗)
        /// </summary>
        /// <param name="b">原始圖片</param>
        /// <param name="degree">每個像素要添加的亮度</param>
        /// <returns></returns>
        private Bitmap SetImageLight(Bitmap b, int degree)
        {
            if (b == null)
            {
                return null;
            }

            if (degree < -255) degree = -255;
            if (degree > 255) degree = 255;

            try
            {
                int width = b.Width;
                int height = b.Height;
                int pix = 0;
                BitmapData data = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* p = (byte*)data.Scan0;
                    int offset = data.Stride - width * 3;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // 添加當前像素的亮度
                            for (int i = 0; i < 3; i++)
                            {
                                pix = p[i] + degree;
                                if (degree < 0) p[i] = (byte)Math.Max(0, pix);
                                if (degree > 0) p[i] = (byte)Math.Min(255, pix);
                            }
                            p += 3;
                        }
                        p += offset;
                    }
                }

                b.UnlockBits(data);
                return b;
            }
            catch
            {
                return null;
            }
        }
    }
}

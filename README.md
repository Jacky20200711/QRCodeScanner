# 專案目標  
實作 Web 版本的 QRCode 掃描器  
&emsp;  
# 使用技術  
1.使用 ZXing.Net 解析 QRCode  
2.使用 System.Drawing.Common 調整圖片亮度  
3.使用 webcamjs 開啟視訊鏡頭並截圖  
&emsp;  
# 開發環境  
Win10(家用版) + Visual Studio 2019 + .NET Core 3.1 MVC  
&emsp;  
# 安裝套件  
Install-Package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation --version 3.1.18  
Install-Package ZXing.Net -Version 0.16.6  
Install-Package ZXing.Net.Bindings.ZKWeb.System.Drawing -Version 0.16.5  
Install-Package System.Drawing.Common -Version 5.0.2  
&emsp;  
# 首頁  
![image](https://github.com/Jacky20200711/QRCodeScanner/blob/main/DEMO_01.PNG?raw=true)  
# 測試方式  
1.開啟電腦相機的存取權限(以 Win10 為範例)  
開始上右鍵 > 設定 > 隱私權 > 相機 > 開啟權限  
&emsp;  
2.運行網站後，相機照到的內容會顯示在首頁的框框裡  
讓 QRCode 入鏡後 > 點選[截圖並傳送] > 會跳出 alert 訊息框並顯示解碼後的內容  

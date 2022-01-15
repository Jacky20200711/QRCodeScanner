# 專案目標  
實作 Web 版本的 QRCode 掃描器  
&emsp;  
# 使用技術  
1.使用 ZXing.Net 解析 QRCode  
2.使用 webcamjs 開啟視訊鏡頭並截圖  
3.使用 AJAX 持續將截圖送到後端分析  
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
2.運行網站後，鏡頭照到的內容會顯示在框框裡，讓您的條碼入鏡即可  
※可以解析常見的一維或二維條碼  

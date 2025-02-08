// See https://aka.ms/new-console-template for more information
using NETCore.Encrypt;
using PuppeteerSharp;

Console.WriteLine("Hello, World 1 !");


//await GenerateScreenshot();
AESEncrypt();

#region GenerateScreenshot
static async Task GenerateScreenshot()
{
    var browser = await Puppeteer.LaunchAsync(new LaunchOptions
    {
        Headless = false,
        ExecutablePath = @"C:\Users\Administrator\.continue\.utils\.chromium-browser-snapshots\chromium\win64-1349996\chrome-win\chrome.exe"
    });
    var page = await browser.NewPageAsync();
    await page.GoToAsync("http://oa.jiankeyan.com/Home/DepartmentIndex");
    await page.ScreenshotAsync("screenshot.png");
    await browser.CloseAsync();
}
#endregion
#region 加密
static void AESEncrypt()
{
    string key = "dotnetshare-encryptionkey"; // 密钥
    string iv = "dotnetshare-encryptioniv";   // 初始化向量（IV）

    // 加密
    string encrypted = EncryptProvider.AESEncrypt("geyujia", key, iv);
    Console.WriteLine($"加密结果: {encrypted}");

    // 解密
    string decrypted = EncryptProvider.AESDecrypt(encrypted, key, iv);
    Console.WriteLine($"解密结果: {decrypted}");
}
#endregion
Console.WriteLine("Hello, World 2 !");
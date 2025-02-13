// See https://aka.ms/new-console-template for more information

#region 正则表达式匹配手机号
//using System.Text.RegularExpressions;


//string phoneNumber = "12345678900";
//bool isValid = IsValidPhoneNumber(phoneNumber);
//Console.WriteLine($"Phone number {phoneNumber} is valid: {isValid}");

//// 正则表达式匹配手机号
//static bool IsValidPhoneNumber(string phoneNumber)
//{
//    string pattern = @"^1[3-9]\d{9}$";
//    return Regex.IsMatch(phoneNumber, pattern);
//}

#endregion


using Newtonsoft.Json;
using System.Text;

// 构造请求数据
var requestData = new
{
    prompt = "Hello, DeepSeek!", // 示例请求参数
    max_tokens = 50
};

// 调用 API
var response = await DeepSeekApiHelper.CallDeepSeekAPI(requestData);

// 输出结果
Console.WriteLine("API 响应:");
Console.WriteLine(response);

class DeepSeekApiHelper
{
    private static string apiKey = ""; // 替换为你的 API 密钥
    private static string apiUrl = "https://api.siliconflow.cn/v1/chat/completions"; // 硅基流动  https://api.deepseek.com/v1/endpoint
    public  static async Task<string> CallDeepSeekAPI(object requestData)
    {
        using (var client = new HttpClient())
        {
            // 设置请求头
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            // 将请求数据序列化为 JSON
            var jsonContent = JsonConvert.SerializeObject(requestData);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // 发送 POST 请求
            var response = await client.PostAsync(apiUrl, httpContent);

            // 检查响应状态
            if (response.IsSuccessStatusCode)
            {
                // 读取响应内容
                var responseJson = await response.Content.ReadAsStringAsync();
                return responseJson;
            }
            else
            {
                // 处理错误
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"API 调用失败: {response.StatusCode}\n{errorResponse}");
            }
        }
    }
}


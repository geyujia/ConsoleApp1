// See https://aka.ms/new-console-template for more information


using System.Text.RegularExpressions;


string phoneNumber = "12345678900";
bool isValid = IsValidPhoneNumber(phoneNumber);
Console.WriteLine($"Phone number {phoneNumber} is valid: {isValid}");

// 正则表达式匹配手机号
static bool IsValidPhoneNumber(string phoneNumber)
{
    string pattern = @"^1[3-9]\d{9}$";
    return Regex.IsMatch(phoneNumber, pattern);
}




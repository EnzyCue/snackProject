using Api.Snack.Models;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Api.Snack.Models.Woolworths;
using System.Text.Json;
using Api.Snack.Helpers;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Api.Snack.Services
{
    public class WoolworthsService
    {
        private readonly string _woolworthsProductEndpoint = "https://www.woolworths.com.au/apis/ui/product/detail/";
        private readonly string _user_agent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36";
        private readonly string _cookie1 = "_abck";
        private readonly string _cookie2 = "bm_sz";

        public async Task GetWoolworthsProduct(Product product)
        {
            // go from id -> html url
            string url = $"{_woolworthsProductEndpoint}{product.Id}";
            var cookies = GetCookies(url);
            
            // create http client and make request
            var client = new HttpClient();
            var message = new HttpRequestMessage(new HttpMethod("GET"), url);
            message.Headers.Add("user-agent", _user_agent);
            message.Headers.Add("cookie", $"{_cookie1}={cookies.Item1}; {_cookie2}={cookies.Item2}");

            var response = await client.SendAsync(message);

            var woolworthsproductinfo = await response.Content.ReadFromJsonAsync<WoolworthsProductInfo>();

            product.Price = woolworthsproductinfo.Product.Price;
            product.Image = woolworthsproductinfo.Product.LargeImageFile;
            product.Name = woolworthsproductinfo.Product.DisplayName;
            product.SaveAmount = woolworthsproductinfo.Product.SavingsAmount;
            product.PricePerHundredGrams = woolworthsproductinfo.Product.CupPrice;
           
        }

        private (string, string) GetCookies(string url)
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                // Navigate to Url
                driver.Navigate().GoToUrl(url);

                // Get cookie details with named cookie 'foo'
                var cookie1 = driver.Manage().Cookies.GetCookieNamed(_cookie1);
                var cookie2 = driver.Manage().Cookies.GetCookieNamed(_cookie2);

                return (cookie1.Value, cookie2.Value);
            }
            finally
            {
                driver.Quit();
            }

            throw new Exception("Failed to fetch cookies");
        }
    }
}
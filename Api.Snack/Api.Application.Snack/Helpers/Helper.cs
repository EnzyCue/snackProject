using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Api.Application.Snack.Helpers
{
    public static class Helper
    {
        public static decimal ConvertToPrice(string input)
        {
            bool hasDecimal = false;

            var priceStr = new string(input
                .Where(
                x =>
                {
                    if (char.IsDigit(x))
                        return true;

                    if (x == '.' && !hasDecimal)
                    {
                        hasDecimal = true;
                        return true;
                    }

                    return false;
                })
                .ToArray());

            var price = decimal.Parse(priceStr);

            price = Math.Truncate(price * 100) / 100;

            return price;
        }

        public static string GetCookies()
        {
            string url = "https://www.woolworths.com.au/shop/productdetails/479502";
            string _cookie1 = "_abck";
            string _cookie2 = "bm_sz";

            IWebDriver driver = new ChromeDriver();

            try
            {
                // Navigate to Url
                driver.Navigate().GoToUrl(url);

                // Get cookie details with named cookie 'foo'
                var cookie1 = driver.Manage().Cookies.GetCookieNamed(_cookie1);
                var cookie2 = driver.Manage().Cookies.GetCookieNamed(_cookie2);

                return $"{_cookie1}={cookie1.Value}; {_cookie2}={cookie2.Value}";
            }
            finally
            {
                driver.Quit();
            }

            throw new Exception("Failed to fetch cookies");
        }
    }
}
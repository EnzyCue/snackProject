using Api.Snack.Models;
using HtmlAgilityPack;
using System.Net;

namespace Api.Snack.Services
{
    public class WoolworthsService
    {
        private readonly string _woolworthsProductEndpoint = "https://www.woolworths.com.au/apis/ui/product/detail/";
        private readonly string _user_agent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36";
        /*        private readonly string _woolworthsProductEndpoint = "https://www.woolworths.com.au/shop/productdetails/";*/

        public async Task GetWoolworthsProduct(Product product)
        {
            // go from id -> html url
            string url = $"{_woolworthsProductEndpoint}{product.Id}";

            // use html agility pack to extract the information about the product
            /*            var web = new HtmlWeb();
                        var htmlDoc = web.Load(url);*/

            // ---- Scrape data ----

            //Scrape Image
            /*            var image = htmlDoc.DocumentNode.SelectSingleNode("//img[@class='main-image-v2 u-noOutline']");*/

            // create http client and make request
            HttpWebRequest req = new HttpWebRequest(url);
            req.Method = "GET";
            var resp2 = req.GetResponse();

            WebRequest myReq = WebRequest.Create(url);

            var resp = myReq.GetResponse();

            var client = new HttpClient();
            var message = new HttpRequestMessage(new HttpMethod("GET"), url);
            message.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");
        }
    }
}
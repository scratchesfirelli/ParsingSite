using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace SbResultsParsing.Controllers
{
    [Route("api/[controller]")]
    public class ParsingController : Controller
    {
        // GET api/values
        [Route("GetHtml")]
        [HttpGet]
        public async Task<string> GetHtmAsString()
        {
            string url = "https://sb-results.sports998.com/en-gb/info-centre/sportsbook-info/results/1/normal/1";
            string html = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (WebResponse response = await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }
    }
}

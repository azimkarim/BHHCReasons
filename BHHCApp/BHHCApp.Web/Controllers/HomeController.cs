using BHHCApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BHHCApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string apiBaseUrl = "https://localhost:5001/api/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Reasons()
        {
            // Consume web RESTful api
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiBaseUrl + "/reasons";
                using (var res = await client.GetAsync(endpoint))
                {
                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return View(res.Content);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error fetching records");
                    }
                }
                return View();
            }
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

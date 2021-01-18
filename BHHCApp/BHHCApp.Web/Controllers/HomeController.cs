using BHHCApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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
            // Consume web RESTful api and pass model to the view page
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                var responseTask = client.GetAsync("reasons");
                responseTask.Wait();

                var res = responseTask.Result;
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    using (var contentStream = await res.Content.ReadAsStreamAsync())
                    {
                        var model = await JsonSerializer.DeserializeAsync<ReasonViewModel>(contentStream);
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error fetching records");
                    return View(Enumerable.Empty<ReasonViewModel>());
                }
            }
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

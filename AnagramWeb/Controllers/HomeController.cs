using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AnagramWeb.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Results(string word)
        {
            var response = await _httpClient.GetAsync("http://localhost:55896/api/Anagram/Get?value=" + word);

            var anagramsContent = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();

            Models.AnagramsViewModel model = JsonConvert.DeserializeObject<Models.AnagramsViewModel>(anagramsContent);

            return PartialView("~/Views/Home/PartialViews/Results.cshtml", model);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
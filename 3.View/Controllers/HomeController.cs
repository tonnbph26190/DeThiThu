using _2.DATA.Models;
using _3.View.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _3.View.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient http;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            http = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var api = "https://localhost:7086/api/NhanViens";
            var res = await http.GetFromJsonAsync<List<NhanVien>>(api);
            return View(res);
        }

        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var api = "https://localhost:7086/api/NhanViens/" + id.ToString();
            await http.DeleteAsync(api);
            return RedirectToAction("Index");


        }
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {
            var api = "https://localhost:7086/api/NhanViens/" + id.ToString();
            var res = await http.GetFromJsonAsync<NhanVien>(api);
            return View(res);


        }

        [HttpGet]
        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid id,NhanVien? nv)
        {
            var api = "https://localhost:7086/api/NhanViens/" + id.ToString();
            if (HttpMethods.IsGet(HttpContext.Request.Method))
            {
               
                var data=await http.GetFromJsonAsync<NhanVien>(api);
                if (data.ID!=Guid.Empty)
                {
                    return View(data);
                }
                
            }
            else
            {
                var res = await http.PutAsJsonAsync<NhanVien>(api, nv);
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(nv);
            }

            return RedirectToAction("Index");


        }
        [HttpPost("[action]")]
        [HttpGet("[action]")]
        public async Task<IActionResult> Create(NhanVien nv)
        {
            var api = "https://localhost:7086/api/NhanViens";
            var res = await http.PostAsJsonAsync<NhanVien>(api, nv);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
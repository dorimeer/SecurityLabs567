using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Front.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Front.Controllers
{
    public class AccountController : Controller
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //model.Password = Hasher.HashPassword(model.Password);
                var json = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var result = await HttpClient.PostAsync($"http://localhost:5000/SingIn", json);
                if (result.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception();
                }
            }
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel(){};
            return View(model);
        }

        public async Task Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //model.Password = Hasher.HashPassword(model.Password);
                var json = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var result = await HttpClient.PostAsync($"http://localhost:5000/SingUp", json);
                Console.WriteLine(await result.Content.ReadAsStringAsync());
            }
        }
    }
}
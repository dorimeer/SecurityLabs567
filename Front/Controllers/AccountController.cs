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
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(model.Password);
                model.Password = Hasher.HashPassword(model.Password);
                var json = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var result = await HttpClient.PostAsync($"http://localhost:5000/SingIn", json);
            }
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel(){};
            return View(model);
        }

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Password = Hasher.HashPassword(model.Password);
                var json = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                await HttpClient.PostAsync($"http://localhost:5000/SingUp", json);
            }
            return View(model);
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecuritySobolDori.Labs567.BLL.DTO;
using SecuritySobolDori.Labs567.BLL.Interfaces;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("/SingIn")]
    public class SignInController
    {
        private readonly ISignInService _signInService;

        public SignInController(ISignInService signInService)
        {
            _signInService = signInService;
        }

        [HttpPost]
        public async Task<string> SignIn(string login, string password) => await _signInService.SignIn(login, password);
    }
}
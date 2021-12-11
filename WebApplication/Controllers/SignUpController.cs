using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecuritySobolDori.Labs567.BLL.Interfaces;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("/SingIn")]
    public class SignUpController
    {
        private readonly ISignUpService _signUpService;

        public SignUpController(ISignUpService signUpService)
        {
            _signUpService = signUpService;
        }
        
        [HttpPost]
        public async Task<string> SignUp(string login, string password) => await _signUpService.SignUp(login, password);
    }
}
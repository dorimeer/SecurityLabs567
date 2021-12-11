using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecuritySobolDori.Labs567.BLL.DTO;
using SecuritySobolDori.Labs567.BLL.Interfaces;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("/SingUp")]
    public class SignUpController
    {
        private readonly ISignUpService _signUpService;

        public SignUpController(ISignUpService signUpService)
        {
            _signUpService = signUpService;
        }
        
        [HttpPost]
        public async Task SignUp(AccountDTO accountDto) => await _signUpService.SignUp(accountDto);
    }
}
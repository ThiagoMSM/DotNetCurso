using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.Usecases.User.Register;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;

namespace MyRecipeBook.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        //define o tipo, q volta o tipo q tá naquela classe:
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Register(RequestRegisterUserJson req)
        {
            var useCase = new RegisterUserUseCase();
            var res = useCase.Execute(req);
            
            return Created(string.Empty, res);
        }
    }
}

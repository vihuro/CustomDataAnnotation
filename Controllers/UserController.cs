using Microsoft.AspNetCore.Mvc;
using teste_fluentvalidation.Models;
using teste_fluentvalidation.Ultius;
using teste_fluentvalidation.Utiuls;

namespace teste_fluentvalidation.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class UserController : CustomResponse
    {
        [HttpPost]
        public ActionResult<User> CreateUser(UserDto request)
        {
            try
            {
                var teste = new User()
                {
                    Password = request.Password,
                    Name = request.Name,
                    UserName = request.UserName,
                };
                if (!teste.IsValid())
                {
                    return ResponseErrorValidations(teste.GetValidationErros().ToList());
                }


                return new User();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

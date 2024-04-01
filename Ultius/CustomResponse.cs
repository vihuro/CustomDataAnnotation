using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace teste_fluentvalidation.Ultius
{
    public class CustomResponse : ControllerBase
    {
        protected ActionResult ResponseErrorValidations(List<ValidationResult> validations)
        {
            var errors = validations.SelectMany(validationResult => validationResult.MemberNames
                .Select(memberName => new { MemberName = memberName, ErrorMessage = validationResult.ErrorMessage }))
                .GroupBy(x => x.MemberName)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(x => x.ErrorMessage).ToList()
                );

            return BadRequest(new
            {
                sucess = false,
                errors = errors
            });
        }

        public class Erros
        {
            public List<string> MemberNames { get; set; }
        }
    }
}

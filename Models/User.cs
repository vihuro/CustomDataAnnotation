using System.ComponentModel.DataAnnotations;
using teste_fluentvalidation.Ultius;

namespace teste_fluentvalidation.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [StringValidator(Minimum = 3, Maximum = 10)]

        public string UserName { get; set; }
        [MinLength(30, ErrorMessage = "Precissa dessa aqui")]
        public string Password { get; set; }
    }
}

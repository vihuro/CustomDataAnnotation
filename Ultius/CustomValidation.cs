using System.ComponentModel.DataAnnotations;

namespace teste_fluentvalidation.Utiuls
{
    public static class CustomValidation
    {
        public static bool IsValid(this object value)
        {
            var context = new ValidationContext(value,null,null);
            var result = new List<ValidationResult>();

            var validations = Validator.TryValidateObject(value, context, result, true);

            return validations;
        }

        public static IEnumerable<ValidationResult> GetValidationErros(this object value)
        {
            var result = new List<ValidationResult>();
            var context = new ValidationContext(value, null, null);

            Validator.TryValidateObject(value, context, result, true);

            return result;
        }
    }
}

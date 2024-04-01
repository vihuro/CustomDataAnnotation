using System.ComponentModel.DataAnnotations;

namespace teste_fluentvalidation.Ultius
{
    public class StringValidator : ValidationAttribute
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public bool Required { get; set; } = true;

        public StringValidator()
        {
            Minimum = 0;
            Maximum = 255;
        }
        public override bool IsValid(object value)
        {
            var stringValue = value as string;
            if (string.IsNullOrEmpty(stringValue)) return false;

            var length = stringValue.Length;

            return length >= Minimum && length <= Maximum;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var stringValue = value as string;
            if (string.IsNullOrEmpty(stringValue) && Required)
            {
                var errorMessage = $"O campo é obrigatório!.";

                return new ValidationResult(errorMessage, new[] { validationContext.MemberName });
            }
            if (stringValue.Length < Minimum || stringValue.Length > Maximum)
            {
                string errorMessage = string.IsNullOrEmpty(ErrorMessage) ?
                    $"O comprimento da string deve estar entre {Minimum} e {Maximum} caracteres." :
                    ErrorMessage;
                return new ValidationResult(errorMessage, new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;

        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FI.WebAtividadeEntrevista.Validation
{
    public class RequiredIfIdNotExistsAttribute : ValidationAttribute
    {
        private readonly string _idPropertyName;

        public RequiredIfIdNotExistsAttribute(string idPropertyName)
        {
            _idPropertyName = idPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var idProperty = validationContext.ObjectType.GetProperty(_idPropertyName);

            if (idProperty == null)
            {
                return new ValidationResult($"Property '{_idPropertyName}' not found.");
            }

            var idValue = idProperty.GetValue(validationContext.ObjectInstance);

            if (idValue == null && value == null)
            {
                return new ValidationResult($"{validationContext.DisplayName} is required.");
            }

            return ValidationResult.Success;
        }
    }
}

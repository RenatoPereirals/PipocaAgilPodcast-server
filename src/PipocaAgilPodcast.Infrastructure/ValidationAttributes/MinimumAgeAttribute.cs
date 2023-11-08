using System.ComponentModel.DataAnnotations;

namespace PipocaAgilPodcast.Infrastructure.ValidationAttributes;

    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimunAge;
        public MinimumAgeAttribute(int minimunAge)
        {
            _minimunAge = minimunAge;
        }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value is DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            if(dateOfBirth > today.AddYears(-age)) // Verifica se o aniversário ocorreu este ano
            {
                age--;
            }

            if(age < _minimunAge)
            {
                return new ValidationResult($"Você deve ter pelo menos {_minimunAge} anos.");
            }
        }
        return ValidationResult.Success;
    }
}

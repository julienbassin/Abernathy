using Abernathy.Demographics.Service.Models.DTOs;
using FluentValidation;

namespace Abernathy.Demographics.Service.ModelsValidator
{
    public class PatientValidator : ValidatorBase<PatientDto>
    {
        public PatientValidator()
        {
            RuleFor(p => p.FirstName).NotNull()
                                     .MaximumLength(10);

            RuleFor(p => p.LastName).NotEmpty();

            RuleFor(p => p.Age).NotNull()
                               .GreaterThan(10);

            RuleFor(p => p.DateOfBirth).NotNull();

        }
    }
}
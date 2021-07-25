using FluentValidation;

namespace Abernathy.Demographics.Service.ModelsValidator
{
    public class ValidatorBase<TEntity> : AbstractValidator<TEntity> where TEntity : class
    {
    }
}
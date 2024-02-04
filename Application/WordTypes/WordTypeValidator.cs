using Domain;
using FluentValidation;

namespace Application.WordTypes
{
    public class WordTypeValidator : AbstractValidator<WordType>
    {
        public WordTypeValidator()
        {
            RuleFor(x => x.Type).NotEmpty();
        }
    }
}

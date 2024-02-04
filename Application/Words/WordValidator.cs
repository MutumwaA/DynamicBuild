
using Domain;
using FluentValidation;

namespace Application.Words
{
    public class WordValidator : AbstractValidator<Word>
    {
        public WordValidator()
        {
            RuleFor(x => x.WordTypeId).NotEmpty();
            RuleFor(x => x.Value).NotEmpty();
        }
    }
}

using Domain;
using FluentValidation;

namespace Application.Sentences
{
    public class SentenceValidator : AbstractValidator<Sentence>
    {
        public SentenceValidator()
        {
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}

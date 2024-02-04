using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Sentences
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Sentence Sentence { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator()
                {
                    RuleFor(x => x.Sentence).SetValidator(new SentenceValidator());
                }
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                request.Sentence.CreatedAt = DateTime.Now;

                await _context.Sentences.AddAsync(request.Sentence);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create sentence");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}

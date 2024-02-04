using Application.Core;
using Application.Sentences;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.WordTypes
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public WordType WordType { get; set; }
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
                    RuleFor(x => x.WordType).SetValidator(new WordTypeValidator());
                }
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                await _context.WordTypes.AddAsync(request.WordType);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create sentence");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}

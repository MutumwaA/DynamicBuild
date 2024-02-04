using Application.Core;
using MediatR;
using Persistence;

namespace Application.Words
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var word = await _context.Words.FindAsync(request.Id);

                if (word == null) return null;

                word.IsDeleted = true;

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete the word");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}

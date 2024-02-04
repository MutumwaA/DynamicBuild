using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.WordTypes
{
     public class Edit
        {
            public class Command : IRequest<Result<Unit>>
            {
                public WordType WordType { get; set; }
            }

            public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator()
                {
                    RuleFor(x => x.WordType).SetValidator(new WordTypeValidator());
                }
            }

            public class Handler : IRequestHandler<Command, Result<Unit>>
            {
                private readonly DataContext _context;
                private readonly IMapper _mapper;

                public Handler(DataContext context, IMapper mapper)
                {
                    _mapper = mapper;
                    _context = context;
                }

                public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
                {
                    var wordType = await _context.WordTypes.FindAsync(request.WordType.Id);

                    if (wordType == null) return null;

                    _mapper.Map(request.WordType, wordType);

                    var result = await _context.SaveChangesAsync() > 0;

                    if (!result) return Result<Unit>.Failure("Failed to update wordType");

                    return Result<Unit>.Success(Unit.Value);
                }
            }
        }
}

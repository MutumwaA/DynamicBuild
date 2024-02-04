using Application.Core;
using Application.Sentences;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Words
{
    public class Details
    {
        public class Query : IRequest<Result<WordsDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<WordsDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<WordsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var word = await _context.Words
                    .ProjectTo<WordsDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return Result<WordsDto>.Success(word);
            }
        }
    }
}

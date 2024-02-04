using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Words
{
    public class List
    {
        public class Query : IRequest<Result<List<WordsDto>>>
        {
            public WordParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<WordsDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<WordsDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryResults = await _context.Words
                         .Where(x => x.WordTypeId == request.Params.WordTypeId)
                         .ProjectTo<WordsDto>(_mapper.ConfigurationProvider)
                         .ToListAsync();

                return Result<List<WordsDto>>
                    .Success(queryResults);
            }
        }
    }
}

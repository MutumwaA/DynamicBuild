using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WordTypes
{
    public class List
    {
        public class Query : IRequest<Result<List<WordTypeDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<WordTypeDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<WordTypeDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryResults = await _context.WordTypes
                         .ProjectTo<WordTypeDto>(_mapper.ConfigurationProvider)
                         .ToListAsync();

                return Result<List<WordTypeDto>>
                    .Success(queryResults);
            }
        }
    }
}

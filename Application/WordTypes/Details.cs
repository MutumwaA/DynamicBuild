using Application.Core;
using Application.Sentences;
using Application.Words;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.WordTypes
{
    public class Details
    {
        public class Query : IRequest<Result<WordTypeDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<WordTypeDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<WordTypeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var word = await _context.WordTypes
                    .ProjectTo<WordTypeDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return Result<WordTypeDto>.Success(word);
            }
        }
    }
}

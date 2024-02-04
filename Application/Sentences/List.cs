using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Sentences
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<SentenceDto>>>
        {
            public SentenceParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<SentenceDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<PagedList<SentenceDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Sentences
                    .OrderBy(d => d.CreatedAt)
                    .ProjectTo<SentenceDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                return Result<PagedList<SentenceDto>>
                    .Success(await PagedList<SentenceDto>.CreateAsync(query,
                        request.Params.PageNumber, request.Params.PageSize));
            }
        }
    }
}

using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Sentences
{
    public class Details
    {
        public class Query : IRequest<Result<SentenceDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<SentenceDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<SentenceDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var sentence = await _context.Sentences
                    .ProjectTo<SentenceDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return Result<SentenceDto>.Success(sentence);
            }
        }
    }
}

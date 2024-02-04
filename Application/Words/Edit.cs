﻿using Application.Core;
using Application.Sentences;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Words
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Word Word { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Word).SetValidator(new WordValidator());
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
                var word = await _context.Sentences.FindAsync(request.Word.Id);

                if (word == null) return null;

                _mapper.Map(request.Word, word);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update word");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}

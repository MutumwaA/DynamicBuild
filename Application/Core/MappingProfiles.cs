using Application.Sentences;
using Application.Words;
using Application.WordTypes;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            CreateMap<Word, WordsDto>();
            CreateMap<WordType, WordTypeDto>();
            CreateMap<Sentence, SentenceDto>();
        }
    }
}

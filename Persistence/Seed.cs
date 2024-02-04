using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Words.Any() && !context.WordTypes.Any())
            {
                var wordTypes = new List<WordType>
                {
                    new WordType { Type = "Noun"},
                    new WordType { Type = "Verb" },
                    new WordType { Type = "Adjective"},
                    new WordType { Type = "Adverb"},
                    new WordType { Type = "Adverb"},
                    new WordType { Type = "Pronoun"},
                    new WordType { Type = "Preposition"},
                    new WordType { Type = "Conjunction" },
                    new WordType { Type = "Determiner"},
                    new WordType { Type = "Exclamation"},
                };

                await context.WordTypes.AddRangeAsync(wordTypes);
                await context.SaveChangesAsync();
                var words = new List<Word>
                {
                    new Word {  Value = "dog", WordTypeId = wordTypes[0].Id },
                    new Word {  Value = "cat", WordTypeId = wordTypes[0].Id },
                    new Word {  Value = "house", WordTypeId = wordTypes[0].Id },
                    new Word {  Value = "tree", WordTypeId = wordTypes[0].Id },
                    new Word {  Value = "car", WordTypeId = wordTypes[0].Id },
                    new Word {  Value = "run", WordTypeId = wordTypes[1].Id },
                    new Word {  Value = "jump", WordTypeId = wordTypes[1].Id },
                    new Word {  Value = "sing", WordTypeId = wordTypes[1].Id },
                    new Word {  Value = "dance", WordTypeId = wordTypes[1].Id },
                    new Word {  Value = "swim" , WordTypeId = wordTypes[1].Id},
                    new Word {  Value = "happy"  , WordTypeId = wordTypes[2].Id},
                    new Word {  Value = "sad"  , WordTypeId = wordTypes[2].Id},
                    new Word {  Value = "tall"  , WordTypeId = wordTypes[2].Id},
                    new Word {  Value = "short" , WordTypeId = wordTypes[2].Id },
                    new Word {  Value = "colorful" , WordTypeId = wordTypes[2].Id },
                    new Word {  Value = "quickly"  , WordTypeId = wordTypes[3].Id},
                    new Word {  Value = "slowly" , WordTypeId = wordTypes[3].Id},
                    new Word {  Value = "loudly"  , WordTypeId = wordTypes[3].Id},
                    new Word {  Value = "softly" , WordTypeId = wordTypes[3].Id },
                    new Word {  Value = "happily" , WordTypeId = wordTypes[3].Id},
                    new Word {  Value = "he"  , WordTypeId = wordTypes[4].Id},
                    new Word {  Value = "she" , WordTypeId = wordTypes[4].Id},
                    new Word {  Value = "it"  , WordTypeId = wordTypes[4].Id},
                    new Word {  Value = "they" , WordTypeId = wordTypes[4].Id},
                    new Word {  Value = "we"  , WordTypeId = wordTypes[4].Id},
                    new Word {  Value = "under" , WordTypeId = wordTypes[5].Id},
                    new Word {  Value = "over"  , WordTypeId = wordTypes[5].Id},
                    new Word {  Value = "between" , WordTypeId = wordTypes[5].Id},
                    new Word {  Value = "beside"  , WordTypeId = wordTypes[5].Id},
                    new Word {  Value = "inside" , WordTypeId = wordTypes[5].Id},
                    new Word {  Value = "and"  , WordTypeId = wordTypes[6].Id},
                    new Word {  Value = "but" , WordTypeId = wordTypes[6].Id},
                    new Word {  Value = "or" , WordTypeId = wordTypes[6].Id },
                    new Word {  Value = "so" , WordTypeId = wordTypes[6].Id},
                    new Word {  Value = "yet"  , WordTypeId = wordTypes[6].Id},
                    new Word {  Value = "the" , WordTypeId = wordTypes[7].Id},
                    new Word {  Value = "a"  , WordTypeId = wordTypes[7].Id},
                    new Word {  Value = "an" , WordTypeId = wordTypes[7].Id},
                    new Word {  Value = "some"  , WordTypeId = wordTypes[7].Id},
                    new Word {  Value = "many" , WordTypeId = wordTypes[7].Id},
                    new Word {  Value = "wow"  , WordTypeId = wordTypes[8].Id},
                    new Word {  Value = "oh" , WordTypeId = wordTypes[8].Id},
                    new Word {  Value = "alas"  , WordTypeId = wordTypes[8].Id},
                    new Word {  Value = "ouch" , WordTypeId = wordTypes[8].Id},
                    new Word {  Value = "hurray"  , WordTypeId = wordTypes[8].Id},
                };

                await context.Words.AddRangeAsync(words);
                await context.SaveChangesAsync();

            }

        }
    }
}

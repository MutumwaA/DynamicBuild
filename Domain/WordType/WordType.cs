namespace Domain
{
    public class WordType : Base
    {
        public string Type { get; set; }
        public List<Word> Words { get; set; }
        public bool IsDeleted { get; set; }
    }
}

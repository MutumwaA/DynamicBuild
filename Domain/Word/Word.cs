namespace Domain
{
    public class Word : Base
    {
        public Guid WordTypeId { get; set; }
        public WordType WordType { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
    }
}

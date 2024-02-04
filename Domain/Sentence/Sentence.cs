namespace Domain
{
    public class Sentence : Base
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public Boolean IsDeleted { get; set; } = false;
    }
}

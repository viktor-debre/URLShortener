namespace URLShortener.Models.Entities
{
    public class URL : BaseEntity
    {
        public string FullUrl { get; set; }

        public string? ShortUrl { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set;}
    }
}

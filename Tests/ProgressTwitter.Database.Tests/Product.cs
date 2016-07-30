namespace ProgressTwitter.Database.Tests
{
    using ProgressTwitter.Database.Attributes;
    using ProgressTwitter.Entities.Base;

    [CollectionName("Products")]
    public class Product : Entity
    {
        public decimal Price { get; set; }
    }
}

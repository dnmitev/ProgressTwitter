namespace ProgressTwitter.Entities
{
    public class FavouriteTwitterUser : BaseEntity
    {
        public string TwitterId { get; set; }

        public string Name { get; set; }

        public string ScreenName { get; set; }

        public string ImageSrc { get; set; }
    }       
}
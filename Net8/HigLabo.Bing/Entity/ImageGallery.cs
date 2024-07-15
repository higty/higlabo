namespace HigLabo.Bing
{
    public class ImageGallery
    {
        public Person? Creator { get; set; }
        public string Description { get; set; } = "";
        public UInt32? FollowersCount { get; set; }
        public UInt32? ImagesCount { get; set; }
        public string Name { get; set; } = "";
        public string Source { get; set; } = "";
        public string ThumbnailUrl { get; set; } = "";
    }
}

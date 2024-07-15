namespace HigLabo.Bing
{
    public  class MediaSize
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return $"{Width}*{Height}";
        }
    }
}

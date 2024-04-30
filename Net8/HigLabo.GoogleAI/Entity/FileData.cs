namespace HigLabo.GoogleAI
{
    public class FileData
    {
        public string MimeType { get; set; } = "";
        public string FileUri { get; set; } = "";
        public FileData() { }
        public FileData(string mimeType, string fileUri)
        {
            MimeType = mimeType;
            FileUri = fileUri;
        }

        public override string ToString()
        {
            return this.FileUri;
        }
    }
}

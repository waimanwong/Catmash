namespace Catmash.Domain
{
    public class Image
    {
        public string Id { get; private set; }
        public string Url { get; private set; }

        public Image(string id, string url)
        {
            Id = id;
            Url = url;
        }

        /// <summary>
        /// Private constructor for EF
        /// </summary>
        private Image() {  }
    }

}

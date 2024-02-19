namespace OqtaneSSR.Client.Models
{
    public class MissingConstructor
    {
        //public MissingConstructor() { }

        public MissingConstructor(string url)
        {
            Uri uri = new Uri(url);
            Host = uri.Host;
        }

        public string Host { get; set; }
    }

}

namespace OqtaneSSR.Client.Models
{
    public class PageState
    {
        public string DefaultRenderMode { get; set; }
        public string InteractiveRenderMode { get; set; }
        public string PagePath { get; set; }
        public List<Module> Modules { get; set; }
        public Uri Uri { get; set; }
        public Dictionary<string, string> QueryString { get; set; }
        public Shared.Runtime Runtime { get; set; }
    }
}

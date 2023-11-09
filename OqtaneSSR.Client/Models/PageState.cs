namespace OqtaneSSR.Client.Models
{
    public class PageState
    {
        public string InteractiveRenderMode { get; set; }
        public string PagePath { get; set; }
        public List<Module> Modules { get; set; }
    }
}

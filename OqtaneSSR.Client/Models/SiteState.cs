namespace OqtaneSSR.Client.Models
{
    // this class is used for passing state between components and services on the client
    public class SiteState
    {
        public string RemoteIPAddress { get; set; } // passed from server as cannot be reliably retrieved on client

        private dynamic _properties;
        public dynamic Properties => _properties ?? (_properties = new PropertyDictionary());

        public void AppendHeadContent(string content)
        {
            if (string.IsNullOrEmpty(Properties.HeadContent))
            {
                Properties.HeadContent = content;
            }
            else if (!Properties.HeadContent.Contains(content))
            {
                Properties.HeadContent += content;
            }
        }
    }
}

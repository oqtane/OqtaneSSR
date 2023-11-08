using Microsoft.AspNetCore.Components;
using OqtaneSSR.Client.Models;
using OqtaneSSR.Client.Components.Router;

namespace OqtaneSSR.Client.Components.Modules
{
    public abstract class ModuleBase : ComponentBase
    {
        [CascadingParameter]
        protected PageState PageState { get; set; }

        [CascadingParameter]
        protected Module ModuleState { get; set; }

        [Parameter]
        public DynamicRenderMode DynamicRenderMode { get; set; }

        public void AddModuleMessage(string message, string type)
        {
			DynamicRenderMode.AddModuleMessage(message, type);
        }
    }
}
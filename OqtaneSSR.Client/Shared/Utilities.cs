using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace OqtaneSSR.Client.Shared
{
    public static class Utilities
    {
        public static IComponentRenderMode GetRenderMode(string renderMode)
        {
            switch (renderMode)
            {
                case "InteractiveServer":
                    return RenderMode.InteractiveServer;
                case "InteractiveWebAssembly":
                    return RenderMode.InteractiveWebAssembly;
                case "InteractiveAuto":
                    return RenderMode.InteractiveAuto;
            }
            return null;
        }
    }
}

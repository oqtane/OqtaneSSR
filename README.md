# OqtaneSSR

This is a POC for the new Blazor SSR capabilities in .NET 8. This project was originally created using the Blazor Web template (with WebAssembly chosen for Interactivity) on RC2. It has been modified to emulate Oqtane's dynamic approach to routing, component rendering, etc... which means that many of the default behaviors of the default Blazor Web template have been customized or overridden.

The appsettings.json (https://github.com/oqtane/OqtaneSSR/blob/main/OqtaneSSR/appsettings.json) contains a Modules property where you can define the pages and modules which should be rendered in your site. The initial configuration matches the standard appearance for the Blazor template, however you can experiment with the project by changing the configuration.

```
"Modules": [
  {
    "PagePath": "/",
    "PageName": "Home",
    "ThemeType": "OqtaneSSR.Components.Themes.MainLayout, OqtaneSSR",
    "PaneName": "Default",
    "ContainerType": "OqtaneSSR.Components.Containers.Container, OqtaneSSR",
    "ModuleType": "OqtaneSSR.Client.Components.Home, OqtaneSSR.Client",
    "RenderMode": "InteractiveServer"
  },
  {
    "PagePath": "/counter",
    "PageName": "Counter",
    "ThemeType": "OqtaneSSR.Components.Themes.MainLayout, OqtaneSSR",
    "PaneName": "Default",
    "ContainerType": "OqtaneSSR.Components.Containers.Container, OqtaneSSR",
    "ModuleType": "OqtaneSSR.Client.Components.Counter, OqtaneSSR.Client",
    "RenderMode": "InteractiveWebAssembly"
  },
  {
    "PagePath": "/weather",
    "PageName": "Weather",
    "ThemeType": "OqtaneSSR.Components.Themes.MainLayout, OqtaneSSR",
    "PaneName": "Default",
    "ContainerType": "OqtaneSSR.Components.Containers.Container, OqtaneSSR",
    "ModuleType": "OqtaneSSR.Client.Components.Weather, OqtaneSSR.Client",
    "RenderMode": "Server"
  }
]
```

Currently the project only has 1 theme - MainLayout. The Theme supports 3 Panes - Default, Footer, and Right. There are 2 Containers - however Container2 currently throws a run-time error. There are 3 Modules - Home (which loads content from an API endpoint), Counter (which demonstrates interactivity), and Weather (which demonstrates StreamRendering). There are 4 RenderModes - InteractiveServer, InteractiveWebAssembly, InteractiveAuto, and Server.

# Differences from Default Blazor Web Template

- Does not use any @page components (all @page components migrated to Client project and converted into standard components)
- Uses a fallback route mapped to the App root component
- Uses a custom SiteRouter rather than the default Blazor router (which simply maps the current Url path to some Module metadata)
- The SiteRouter is implemented in the Server project and uses Server rendering
- The SiteRouter has a variety of child components to simulate the nested behavior of components in Oqtane (ie. themes -> containers -> modules)
- Uses DynamicComponent and RenderFragment to construct the UI dynamically

# Known Problems

- if you specify the same interactive rendermode for all modules (ie. InteractiveServer) the pages will not be rendered properly. This seems to be an issue with Blazor in RC2
- if you use Container2 it is using instance-based @rendermode attributes ie. <DynamicComponent Type="@_type" @rendermode="RenderMode.InteractiveServer"></DynamicComponent> which is supposed to work but throws a run-time error related to serialization. The reason why the otheer Container works is because it is using a custom DynamicRenderMode component which wraps an InteractiveServer, InteractiveWebAssembly, and InteractiveAuto component which internally use @attribute [RenderModeInteractiveServer]
- PageState and ModuleState do not flow from the Router to the Module components. This is because they are using CascadingParameters which cannot cross the boundary from non-interactive to interactive in Blazor SSR. There is an alternate solution which is partially implemented but not fully working.

# Next Steps

This project is a work in progress. The goal is simulate as many core concepts of Oqtane as possible to evaluate the challenges or gaps which may exist that would prevent Oqtane from supporting Blazor SSR.



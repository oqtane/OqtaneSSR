# OqtaneSSR

This is a POC for the new Blazor SSR capabilities in .NET 8. This project was originally created using the Blazor Web template (with WebAssembly chosen for Interactivity) on RC2. It has been modified to emulate Oqtane's dynamic approach to routing, component rendering, etc... which means that many of the default behaviors of the default Blazor Web template have been customized or overridden.

The appsettings.json (https://github.com/oqtane/OqtaneSSR/blob/main/OqtaneSSR/appsettings.json) contains an InteractiveRenderMode property where you can set the interactive render mode for the application, and a Modules property where you can define the pages and modules which should be rendered in your site. The initial configuration matches the standard appearance for the Blazor template, however you can experiment with the project by modifying the configuration (ie. adding/removing modules, changing module properties, etc...).

```
  "InteractiveRenderMode": "InteractiveServer",
  "Modules": [
    {
      "PagePath": "/",
      "PageName": "Home",
      "ThemeType": "OqtaneSSR.Client.Components.Themes.MainLayout, OqtaneSSR.Client",
      "PaneName": "Default",
      "ContainerType": "OqtaneSSR.Client.Components.Containers.Container, OqtaneSSR.Client",
      "ModuleTitle": "Data",
      "ModuleType": "OqtaneSSR.Client.Components.Modules.Home, OqtaneSSR.Client",
      "RenderMode": "Static"
    },
    {
      "PagePath": "/counter",
      "PageName": "Counter",
      "ThemeType": "OqtaneSSR.Client.Components.Themes.MainLayout, OqtaneSSR.Client",
      "PaneName": "Default",
      "ContainerType": "OqtaneSSR.Client.Components.Containers.Container, OqtaneSSR.Client",
      "ModuleTitle": "Counter",
      "ModuleType": "OqtaneSSR.Client.Components.Modules.Counter, OqtaneSSR.Client",
      "RenderMode": "Interactive"
    },
    {
      "PagePath": "/weather",
      "PageName": "Weather",
      "ThemeType": "OqtaneSSR.Client.Components.Themes.MainLayout, OqtaneSSR.Client",
      "PaneName": "Default",
      "ContainerType": "OqtaneSSR.Client.Components.Containers.Container, OqtaneSSR.Client",
      "ModuleTitle": "Weather",
      "ModuleType": "OqtaneSSR.Client.Components.Modules.Weather, OqtaneSSR.Client",
      "RenderMode": "Static"
    }
  ]
```

![image](https://github.com/oqtane/OqtaneSSR/assets/4840590/9b24568b-4d64-40d3-98fa-122dfb37c3b6)

Currently the project only has 1 theme - MainLayout. The Theme supports 3 Panes - Default, Footer, and Right. There is 1 Container - Container. There are 3 Modules - Home (which loads content from an ITextService), Counter (which demonstrates interactivity), and Weather (which demonstrates StreamRendering). There are 4 RenderModes - InteractiveServer, InteractiveWebAssembly, InteractiveAuto, and Server.

# Differences from Default Blazor Web Template

- Does not use any @page components (all @page components migrated to Client project and converted into standard components)
- Uses a fallback route mapped to the App root component
- Uses a custom SiteRouter rather than the default Blazor router (which simply maps the current Url path to some Module metadata)
- The SiteRouter uses Server rendering
- The SiteRouter has a variety of child components to simulate the nested behavior of components in Oqtane (ie. themes -> panes -> containers -> modules)
- Uses DynamicComponent and RenderFragment to construct the UI dynamically
- Accesses HttpContext in App.razor
- Home component utilizes a Service interface with 2 implementations managed by dependency injection - Client implementation uses HttpClient/API Controller when running on InteractiveWebAssembly/InteractiveAuto render mode, and Server implementation uses direct server access when running on InteractiveServer/Server render mode
- Utilizes a DynamicRenderFragment component to replace the functionality of DynamicComponent (which cannot be used when transitioning from a non-interactive to interactive rendermode due to its unserializable Type parameter)
- Demonstrates how to deal with [CascadingParameter] transitions across RenderMode boundaries

# Known Problems

- workarounds were found for all prior issues

# Next Steps

This project is a work in progress. The goal is to simulate as many core concepts of Oqtane as possible to evaluate the challenges or gaps which may exist in Blazor SSR for supporting a modular application framework like Oqtane.



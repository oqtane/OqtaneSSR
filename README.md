# Please Note

The concepts demonstrated in this POC have been implemented in the Oqtane Framework and were released as part of version 5.1 (March 27, 2024). There is not expected to be any further enhancements to this POC, however it will remain accessible for educational purposes to the .NET community.

# OqtaneSSR

This is a POC for the new Blazor Server-Side Rendering (SSR) capabilities in .NET 8 - demonstrating some of the dynamic capabilities of the Oqtane CMS and Application Framework (https://www.oqtane.org) - which was developed on earlier versions of interactive Blazor. 

This POC project was originally created using the standard Blazor Web template (with WebAssembly chosen for Interactivity). It has been modified to emulate the dynamic approach to routing, component rendering, etc... which means that many of the default behaviors of the default Blazor Web template have been customized or overridden.

The appsettings.json (OqtaneSSR/appsettings.json) contains a DefaultRenderMode where you can specify the detault render mode for the entire application (Static or Interactive), an InteractiveRenderMode property where you can set the render mode for interactive modules (ie. InteractiveServer, InteractiveWebAssembly, InteractiveAuto) and a Modules property where you can define the pages and modules which should be rendered in your site. The initial configuration matches the standard appearance and behavior for the Blazor Web template, however you can experiment with the project by modifying the configuration (ie. adding/removing modules, changing module properties, etc...).

```
  "DefaultRenderMode": "Static",
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

![image](https://github.com/oqtane/OqtaneSSR/assets/4840590/770b64c8-4852-4e16-be7f-0ebb168ce9bb)

Currently the project only has 1 theme - MainLayout. The Theme supports 3 Panes - Default, Footer, and Right. There is 1 Container - Container. There are 3 Modules - Home (which loads content from an ITextService), Counter (which demonstrates interactivity), and Weather (which demonstrates StreamRendering). There are 2 RenderModes - Static and Interactive.

# Differences from Default Blazor Web Template

- Does not use any @page components (all @page components migrated to Client project and converted into standard components)
- Uses a fallback route mapped to the App root component
- Uses a custom SiteRouter rather than the default Blazor router (which simply maps the current Url path to some Module metadata)
- The SiteRouter has a variety of child components to simulate the nested behavior of components in Oqtane (ie. themes -> panes -> containers -> modules)
- Uses DynamicComponent and RenderFragment to construct the UI dynamically
- Accesses HttpContext in App.razor
- Home component utilizes a Service interface with 2 implementations managed by dependency injection - Client implementation uses HttpClient/API Controller when running on InteractiveWebAssembly/InteractiveAuto render mode, and Server implementation uses direct server access when running on InteractiveServer/Server render mode
- Utilizes a DynamicRenderMode component to replace the functionality of DynamicComponent (which cannot be used when transitioning from a non-interactive to interactive rendermode due to its unserializable Type parameter)
- Demonstrates how to deal with [CascadingParameter] transitions across RenderMode boundaries
- Demonstrates how to deal with Scoped Service transitions across RenderMode boundaries
- demonstrates how to use a standard HTML Form and data-enhance attribute to create interactivity within a static component (see DynamicRenderMode)
- NavMenu constructed dynamically from PagePaths in Modules collection

# Known Problems

- StreamRendering is required in order for rendering to work properly. This issue has been reported to Microsoft and is still open - https://github.com/dotnet/aspnetcore/issues/54157




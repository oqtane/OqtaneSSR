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

Currently the project only has 1 theme - MainLayout. The Theme supports 3 Panes - Default, Footer, and Right. There are 2 Containers - however Container2 does not currently work as expected because of issues with rendermode attributes in RC2. There are 3 Modules - Home (which loads content from an API endpoint), Counter (which demonstrates interactivity), and Weather (which demonstrates StreamRendering). There are 4 RenderModes - InteractiveServer, InteractiveWebAssembly, InteractiveAuto, and Server.






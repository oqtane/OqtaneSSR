using Microsoft.AspNetCore.Components;
using OqtaneSSR.Client.Models;
using OqtaneSSR.Providers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CascadingPageStateServiceCollectionExtensions
    {
        public static IServiceCollection AddCascadingPageState(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddCascadingValue<Task<PageState>>(services =>
            {
                var pageStateProvider = services.GetRequiredService<PageStateProvider>();
                return new PageStateCascadingValueSource(pageStateProvider);
            });
        }

        private sealed class PageStateCascadingValueSource : CascadingValueSource<Task<PageState>>, IDisposable
        {
            private readonly PageStateProvider _pageStateProvider;

            public PageStateCascadingValueSource(PageStateProvider pageStateProvider)
                : base(pageStateProvider.GetPageStateAsync, isFixed: false)
            {
                _pageStateProvider = pageStateProvider;
                pageStateProvider.PageStateChanged += HandlePageStateChanged;
            }

            private void HandlePageStateChanged(Task<PageState> newPageStateTask)
            {
                _ = NotifyChangedAsync(newPageStateTask);
            }

            public void Dispose()
            {
                _pageStateProvider.PageStateChanged -= HandlePageStateChanged;
            }
        }
    }
}


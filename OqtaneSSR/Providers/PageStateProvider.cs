using OqtaneSSR.Client.Models;

namespace OqtaneSSR.Providers
{
    public abstract class PageStateProvider
    {
        public abstract Task<PageState> GetPageStateAsync();

        public event PageStateChangedHandler PageStateChanged;

        protected void NotifyPageStateChanged(Task<PageState> task)
        {
            ArgumentNullException.ThrowIfNull(task);

            PageStateChanged?.Invoke(task);
        }
    }

    public delegate void PageStateChangedHandler(Task<PageState> task);
}

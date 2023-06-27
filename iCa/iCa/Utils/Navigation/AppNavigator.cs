using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Events;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Utils
{
    public class AppNavigator : IAppNavigator, IPopupNavigation
    {
        public IReadOnlyList<PopupPage> PopupStack => throw new NotImplementedException();

        public event EventHandler<PopupNavigationEventArgs> Pushing;
        public event EventHandler<PopupNavigationEventArgs> Pushed;
        public event EventHandler<PopupNavigationEventArgs> Popping;
        public event EventHandler<PopupNavigationEventArgs> Popped;

        public Task GoBackAsync(bool animated = false, object data = null)
        {
            return MainThread.InvokeOnMainThreadAsync(() => Shell.Current.Navigation.PopModalAsync(animated));
        }

        public Task NavigateToRootAsync(bool animated = false)
        {
            return MainThread.InvokeOnMainThreadAsync(() => Shell.Current.Navigation.PopToRootAsync());
        }

        public Task NavigateAsync(Page page, bool animated = false, object args = null)
        {
            return MainThread.InvokeOnMainThreadAsync(() =>  Shell.Current.Navigation.PushModalAsync(page));
        }

        public Task<bool> OpenUrlAsync(string url)
        {
            throw new NotImplementedException();
        }

        public Task PopAllAsync(bool animate = true)
        {
            return MainThread.InvokeOnMainThreadAsync(() => PopupNavigation.Instance.PopAllAsync(animate));
        }

        public Task PopAsync(bool animate = true)
        {
            return MainThread.InvokeOnMainThreadAsync(() => PopupNavigation.Instance.PopAsync(animate));
        }

        public Task PushAsync(PopupPage page, bool animate = true)
        {
            return MainThread.InvokeOnMainThreadAsync(() => PopupNavigation.Instance.PushAsync(page));
        }

        public Task RemovePageAsync(PopupPage page, bool animate = true)
        {
            throw new NotImplementedException();
        }

        public Task ShareAsync(string text, string title = null)
        {
            throw new NotImplementedException();
        }

        public Task ShowSnackbarAsync(string message, Action action = null, string actionText = null)
        {
            throw new NotImplementedException();
        }
    }
}

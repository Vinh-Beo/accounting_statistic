using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Utils
{
    public interface IAppNavigator
    {
        Task GoBackAsync(bool animated = false, object data = default);

        Task NavigateAsync(Page page, bool animated = false, object args = default);

        Task NavigateToRootAsync(bool animated = false);

        Task<bool> OpenUrlAsync(string url);

        Task ShareAsync(string text, string title = default);

        Task ShowSnackbarAsync(string message, Action action = null, string actionText = null);
    }
}

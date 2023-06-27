using CommunityToolkit.Mvvm.ComponentModel;

namespace Utils
{
    public class BaseViewModel: ObservableRecipient
    {
        public AppNavigator AppNavigator { get; }

        public BaseViewModel()
        {
            AppNavigator = new AppNavigator();
        }
    }
}

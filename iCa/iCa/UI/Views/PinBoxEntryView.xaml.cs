using System;
using Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinBoxEntryView : ContentView
    {
        private int _pincodeLength = 6;
        public PinBoxEntryView()
        {
            InitializeComponent();
            for (int i = 0; i < _pincodeLength; i++)
            {
                Entry _entry = new Entry()
                {
                    FontFamily = "BoldFont",
                    FontSize = 24,
                    IsPassword = false,
                    Keyboard = Keyboard.Numeric,
                    MaxLength = 1,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HeightRequest = Dimens.EntryHeight,
                    MinimumHeightRequest = Dimens.EntryHeight,
                    TabIndex = i,
                };


                _entry.TextColor = AppColors.TextEntryPrimaryColor;
                if (Application.Current.UserAppTheme == OSAppTheme.Light)
                {
                    _entry.TextColor = AppColors.TextEntryPrimaryColor;
                }
                else if (Application.Current.UserAppTheme == OSAppTheme.Dark)
                {
                    _entry.TextColor = AppColors.TextEntryPrimaryDarkColor;
                }
                _entry.TextChanged += Handle_TextChanged;
                spnlMain.Children.Add(_entry);
            }
        }
        
        private void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            if (sender.GetType() != typeof(Entry))
            {
                return;
            }
            Entry _entry = (Entry)sender;
            int _tabIndex = _entry.TabIndex;
            if (!String.IsNullOrEmpty(_entry.Text))
            {
                if (spnlMain.Children.Count == _tabIndex + 1)
                {
                    return;
                }
                Entry _nextEntry = spnlMain.Children[_tabIndex + 1] as Entry;
                if (_nextEntry == null)
                {
                    return;
                }
                _nextEntry.Focus();
            }
            else
            {
                if (_tabIndex == 0)
                {
                    return;
                }
                Entry _preEntry = spnlMain.Children[_tabIndex - 1] as Entry;
                if (_preEntry == null)
                {
                    return;
                }
                _preEntry.Focus();
            }
        }
    }
}
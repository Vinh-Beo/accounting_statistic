using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sharpnado.MaterialFrame;
using System.Windows.Input;
using Gesture;

namespace UI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchBarView : MaterialFrame
	{
		public SearchBarView ()
		{
			InitializeComponent ();
		}

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(SearchBarView),
        null);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        nameof(Placeholder),
        typeof(string),
        typeof(SearchBarView),
        null);

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }


        public static readonly BindableProperty SearchCommandProperty = BindableProperty.Create(
        nameof(SearchCommand),
        typeof(ICommand),
        typeof(SearchBarView),
        null);
        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }

        public static readonly BindableProperty SearchCommandParameterProperty = BindableProperty.Create(
        nameof(SearchCommandParameter),
        typeof(object),
        typeof(SearchBarView),
        null);
        public object SearchCommandParameter
        {
            get { return GetValue(SearchCommandParameterProperty); }
            set { SetValue(SearchCommandParameterProperty, value); }
        }

        
        public event EventHandler<TextChangedEventArgs> TextChanged;
        private void Handle_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextChanged?.Invoke(sender,e);
        }
        public event EventHandler<FocusEventArgs> Focused;
        private void SearchBar_Focused(object sender, FocusEventArgs e)
        {
            Focused?.Invoke(sender, e);
        }

        public event EventHandler<FocusEventArgs> Unfocused;

        private void SearchBar_Unfocused(object sender, FocusEventArgs e)
        {
            Unfocused?.Invoke(sender, e);
        }
    }
}
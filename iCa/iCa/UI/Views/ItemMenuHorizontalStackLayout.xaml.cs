using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemMenuHorizontalStackLayout : StackLayout
	{
		public ItemMenuHorizontalStackLayout()
		{
			InitializeComponent ();
		}
        public static readonly BindableProperty ResourceIdProperty = BindableProperty.Create(
        nameof(ResourceId),
        typeof(string),
        typeof(ItemMenuHorizontalStackLayout),
        null);
        public string ResourceId
        {
            get => (string)GetValue(ResourceIdProperty);
            set => SetValue(ResourceIdProperty, value);
        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(ItemMenuHorizontalStackLayout),
        null);
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly BindableProperty TintColorProperty = BindableProperty.Create(
        nameof(TintColor),
        typeof(Color),
        typeof(ItemMenuHorizontalStackLayout),
        default(Color));

        public Color TintColor
        {
            get => (Color)GetValue(TintColorProperty);
            set => SetValue(TintColorProperty, value);
        }
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            "Command",
            typeof(ICommand),
            typeof(TapGestureRecognizer),
            null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter",
            typeof(object),
            typeof(TapGestureRecognizer),
            null);

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
    }
}
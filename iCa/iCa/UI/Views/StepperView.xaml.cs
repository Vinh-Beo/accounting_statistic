using Sharpnado.MaterialFrame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StepperView : MaterialFrame
    {
        public StepperView()
        {
            InitializeComponent();
        }
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value),
        typeof(double),
        typeof(StepperView),
        default(double));

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }


        public static readonly BindableProperty MaximumProperty = BindableProperty.Create(
        nameof(Maximum),
        typeof(double),
        typeof(StepperView),
        default(double));

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, Maximum);
        }

        public static readonly BindableProperty MinimumProperty = BindableProperty.Create(
        nameof(Minimum),
        typeof(double),
        typeof(StepperView),
        default(double));

        public double Minimum
        {
            get => (double)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, Minimum);
        }

        public static readonly BindableProperty IncrementProperty = BindableProperty.Create(
        nameof(Increment),
        typeof(double),
        typeof(StepperView),
        default(double));

        public double Increment
        {
            get => (double)GetValue(IncrementProperty);
            set => SetValue(IncrementProperty, Increment);
        }


        public event EventHandler PlusClicked;
        private void PlusBtn_Clicked(object sender, EventArgs e)
        {
            if (Value < Maximum)
            {
                Value = Math.Round(Value + Increment, 3);
                PlusClicked?.Invoke(sender, e);
            }
        }

        public event EventHandler MinusClicked;
        private void MinusBtn_Clicked(object sender, EventArgs e)
        {
            if (Value > Minimum)
            {
                Value = Math.Round(Value - Increment, 3);
                MinusClicked?.Invoke(sender, e);
            }
        }
    }
}
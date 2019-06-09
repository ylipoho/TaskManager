using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pleasework.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
            fontSizeValue.Text = fontSizeStepper.Value.ToString();
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Application.Current.Resources[Constants.ResourceKey.AppFontSize] = fontSizeStepper.Value;
            fontSizeValue.Text = fontSizeStepper.Value.ToString();
        }

        private void ColorSwitch_Toggled(object sender, ToggledEventArgs e)
        { 
            Application.Current.Resources[Constants.ResourceKey.AppBackgroundColor] = colorSwitch.IsToggled ? Color.DimGray : Color.MintCream;
        }
    }
}
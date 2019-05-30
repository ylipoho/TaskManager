using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Application.Current.Resources[Constants.ResourceKey.AppFontSize] = fontSizeStepper.Value;
        }
    }
}
using pleasework.Enums;
using pleasework.Models;
using pleasework.Service;
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
	public partial class RegistrationPage : ContentPage
	{
		public RegistrationPage ()
		{
			InitializeComponent ();
		}

        private void Add_Clicked(object sender, EventArgs e)
        {
            if (password.Text == password2.Text && login.Text != string.Empty && password.Text != string.Empty && role.SelectedItem != null &&
                Enum.TryParse<Role>(role.SelectedIndex.ToString(), out Role userRole))
            {
                User user = new User()
                {
                    Login = login.Text,
                    Password = password.Text,
                    UserRole = (Role)userRole + 1
                };
                try
                {
                    DatabaseService.AddUser(user);
                    Navigation.PopModalAsync();
                }
                catch (Exception ex)
                {
                    DisplayAlert("error", ex.Message, "understand");
                }

            }
            else
            {
                DisplayAlert("error", "invalid input", "understand");
            }
        }
    }
}
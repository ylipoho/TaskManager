using pleasework.Models;
using pleasework.Service;
using pleasework.View;
using System;
using Xamarin.Forms;

namespace pleasework
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async void AutorizationButton_ClickedAsync(object sender, EventArgs e)
        {
            string login = loginEntry.Text;
            string password = passwordEntry.Text;

            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    var userResult = await DatabaseService.GetUserByLoginAndPassword(login, password);

                    if (userResult != null)
                    {
                        User user = new User();
                        user.Login = userResult.Login;
                        user.Password = userResult.Password;
                        user.UserRole = userResult.UserRole;

                        SessionService sessionService = new SessionService(user);

                        await Navigation.PushModalAsync(new UserTabbedPage(sessionService));
                    }
                    else
                    {
                        await DisplayAlert("error", "user not found", "understand");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("error", ex.Message, "understand");
                }
            }
            else
            {
                await DisplayAlert("error", "enter login and password", "understand");
            }
        }

        private void RegistrationButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegistrationPage());
        }
    }
}

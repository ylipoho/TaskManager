using pleasework.Models;
using pleasework.Service;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pleasework.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskCreatorPage : ContentPage
	{
        public SessionService currentSessionService;
        public List<User> Users { get; set; }



		public TaskCreatorPage (SessionService sessionService)
		{
			InitializeComponent ();
            this.currentSessionService = sessionService;
		}
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (name.Text != string.Empty)
            {
                try
                {
                    var date = datePicker.Date;
                    var time = timePicker.Time;

                    Models.Task task = new Models.Task
                    {
                        Title = name.Text,
                        Description = description.Text,
                        Deadline = new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds),
                        Creator = currentSessionService.sessionUser.Login
                    };

                    if (performerSwitch.IsToggled) // true - for user, false - for role
                    {
                        task.Performer = userPerformer.SelectedItem.ToString();
                    }
                    else
                    {
                        task.ForRole = rolePerformer.SelectedItem.ToString();                            
                    }
                    
                    DatabaseService.AddTask(task);
                }
                catch (Exception ex)
                {
                    DisplayAlert("error", ex.Message, "understand");
                }

            }
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (performerSwitch.IsToggled)
            {
                rolePerformer.IsEnabled = false;
                rolePerformer.SelectedItem = "";
                userPerformer.IsEnabled = true;
            }
            else
            {
                rolePerformer.IsEnabled = true;
                userPerformer.IsEnabled = false;
                userPerformer.SelectedItem = "";
            }
        }
    }
}
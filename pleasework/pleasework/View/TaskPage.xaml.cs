using pleasework.Models;
using pleasework.Service;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Task = pleasework.Models.Task;

namespace pleasework.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskPage : ContentPage
	{
        Task _task;

		public TaskPage (object item)
		{
			InitializeComponent ();
            
            if (item is Task task)
            {
                this._task = task;
                title.Text = "TITLE " + task.Title ?? "";
                description.Text = "DESCRIPTION " + task.Description ?? "";
                deadline.Text = "DEADLNE " + (task.Deadline != null ? task.Deadline.ToString() : "");
                creator.Text = "CREATOR " + task.Creator ?? "";
                performer.Text = "PERFORMER " + task.Performer ?? "";
                forRole.Text = "FOR " + task.ForRole ?? "";

                if (task.Priority != null)
                {
                    priority.Text = "PRIORITY " + task.Priority.ToString();
                    if (task.Priority == Enums.Priority.criticaaal.ToString())
                    {
                        priority.TextColor = Color.Red;
                    }
                }
                else
                {
                    priority.Text = "PRIORITY ";
                }

                status.Text = "STATUS " + (task.IsDone ? "done" : "in proccess");
            }
            else
            {
                DisplayAlert("error", "error x(", "understand");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (_task != null)
            {
                DatabaseService.DeleteTask(_task);
                DisplayAlert("info", "successfuly deleted", "understand");
                Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("error", "error x(", "understand");
            }
        }

        private void ChangeStatus_Clicked(object sender, EventArgs e)
        {
            DatabaseService.UpdateTask(_task);
            Navigation.PopModalAsync();
        }
    }
}
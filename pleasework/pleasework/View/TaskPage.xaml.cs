using pleasework.Models;
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

		public TaskPage (object item)
		{
			InitializeComponent ();

            Task task = item as Task;

            if (task != null)
            {
                title.Text = task.Title;
                description.Text = task.Description;
                deadline.Text = task.Deadline.ToString();
                creator.Text = task.Creator;
                performer.Text = task.Performer;
                forRole.Text = task.ForRole;
                priority.Text = task.Priority;
                status.Text = task.IsDone;
            }
            else
            {
                DisplayAlert("error", "error x(", "understand");
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
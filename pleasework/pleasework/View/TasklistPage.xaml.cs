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
	public partial class TasklistPage : ContentPage
	{
        public SessionService currentSessionService;

        public List<Models.Task> Tasks { get; set; }

		public TasklistPage (SessionService sessionService)
		{
            InitializeComponent();

            this.currentSessionService = sessionService;
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Tasks = await DatabaseService.GetAllTasks();

            User user = currentSessionService.sessionUser;

            if (user.UserRole != Enums.Role.admin)
            {
                Tasks = Tasks.Where(x => x.Creator == user.Login || x.Performer == user.Login || 
                            x.Performer == user.UserRole.ToString()).ToList();
            }
            
            TaskListView.ItemsSource = Tasks;
                       
        }
             
        private void TaskListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushModalAsync(new TaskPage(e.Item));
        }

        private async void FilterPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.OnAppearing();

            Tasks = await DatabaseService.GetAllTasks();

            User user = currentSessionService.sessionUser;

            if (user.UserRole != Enums.Role.admin)
            {
                Tasks = Tasks.Where(x => x.Creator == user.Login || x.Performer == user.Login ||
                                    x.Performer == user.UserRole.ToString()).ToList();
            }

            switch (filterPicker.SelectedItem)
            {
                case "all by priority":
                    List<Models.Task> c, h, m, l;
                    c = Tasks.Where(x => x.Priority == Priority.criticaaal.ToString()).ToList();
                    h = Tasks.Where(x => x.Priority == Priority.high.ToString()).ToList();
                    m = Tasks.Where(x => x.Priority == Priority.medium.ToString()).ToList();
                    l = Tasks.Where(x => x.Priority == Priority.low.ToString()).ToList();
                    Tasks = c;
                    Tasks.AddRange(h);
                    Tasks.AddRange(m);
                    Tasks.AddRange(l);
                    break;
                case "only done":
                    Tasks = Tasks.Where(x => x.IsDone == true).ToList();
                    break;
                case "only unfinished":
                    Tasks = Tasks.Where(x => x.IsDone == false).ToList();
                    break;
                case "only critical":
                    Tasks = Tasks.Where(x => x.Priority == Priority.criticaaal.ToString()).ToList();
                    break;
            }
            
            TaskListView.ItemsSource = Tasks;
        }
    }
}
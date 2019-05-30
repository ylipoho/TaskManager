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
            TaskListView.ItemsSource = Tasks;

            // фильтрацию

        }
             
        private void TaskListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushModalAsync(new TaskPage(e.Item));
        }
    }
}
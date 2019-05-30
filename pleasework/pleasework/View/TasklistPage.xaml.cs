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

        public List<pleasework.Models.Task> Tasks { get; set; }

		public TasklistPage ()
		{
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //tasksListView = new ListView();
            //tasksListView.ItemsSource = Tasks = DatabaseService.GetAllTasks().Result;
            
        }
        
        private void DeleteTaskButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("info", "delete button tapped", "understand");
        }

        private void TasksListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("info", "item tapped", "understand");
        }
    }
}
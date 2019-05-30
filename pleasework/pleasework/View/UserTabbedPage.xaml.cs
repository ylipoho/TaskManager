using pleasework.Enums;
using pleasework.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pleasework.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserTabbedPage : TabbedPage
    {
        public UserTabbedPage (SessionService sessionService)
        {
            InitializeComponent();
                        
            Children.Add(new TasklistPage(sessionService) { Title = "Tasks" });

            Role role = sessionService.sessionUser.UserRole;
            
            if (role == Role.admin || role == Role.manager || role == Role.developer)
            {
                Children.Add(new TaskCreatorPage(sessionService) { Title = "New Task"});
            }

            if (role == Role.admin)
            {
                Children.Add(new UserCreatorPage() { Title = "New User"});
            }

            Children.Add(new SettingsPage() { Title = "Settings" });
        }
    }
}
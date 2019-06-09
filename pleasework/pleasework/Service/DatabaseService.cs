using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using pleasework.Models;
using Task = System.Threading.Tasks.Task;

namespace pleasework.Service
{
    public class DatabaseService
    {
        private static FirebaseClient FirebaseClient => new FirebaseClient("https://xamarinfirebase-9c674.firebaseio.com/");

        public DatabaseService()
        {
        }

        public static async void AddUser(User user)
        {
            await FirebaseClient.Child(nameof(User)).PostAsync(user);
        }

        public static async Task<List<User>> GetAllUsers()
        {
            return (await FirebaseClient
                 .Child(nameof(User))
                 .OnceAsync<User>()).Select(x => new User
                 {
                     Login = x.Object.Login,
                     Password = x.Object.Password,
                     UserRole = x.Object.UserRole
                 }).ToList();
        }

        public static async Task<User> GetUserByLoginAndPassword(string login, string password)
        {
            return (await FirebaseClient
                 .Child(nameof(User))
                 .OnceAsync<User>()).Select(x => new User
                 {
                     Login = x.Object.Login,
                     Password = x.Object.Password,
                     UserRole = x.Object.UserRole
                 }).FirstOrDefault(x => x.Login == login && x.Password == password);
        }

        
        public static async void AddTask(Models.Task task)
        {
            await FirebaseClient.Child(nameof(Task)).PostAsync(task);
        }
        
        public static async Task<List<Models.Task>> GetAllTasks()
        {
            return (await FirebaseClient
                 .Child(nameof(Task))
                 .OnceAsync<Models.Task>()).Select(x => new Models.Task
                 {
                     Title = x.Object.Title,
                     Description = x.Object.Description,
                     Deadline = x.Object.Deadline,
                     Performer = x.Object.Performer,
                     Priority = x.Object.Priority,
                     ForRole = x.Object.ForRole,
                     Creator = x.Object.Creator,
                     IsDone = x.Object.IsDone
                 }).ToList();
        }

        public static async void DeleteTask(Models.Task task)
        {
            var toDeleteTask = (await FirebaseClient
                 .Child(nameof(Task))
                 .OnceAsync<Models.Task>()).FirstOrDefault(a => a.Object.Title == task.Title && a.Object.Description ==task.Description && 
                                                                a.Object.Deadline == task.Deadline);

            if (toDeleteTask != null)
            {
                await FirebaseClient.Child(nameof(Task)).Child(toDeleteTask.Key).DeleteAsync();
            }
        }

        public static void UpdateTask(Models.Task task)
        {
            DeleteTask(task);
            task.IsDone = !task.IsDone;
            AddTask(task);
        }

        /*public static async Task<Role> AddRole(Role role)
        {
            role.Id = Guid.NewGuid().ToString();

            await FirebaseClient
                .Child(nameof(Role))
                .PostAsync(JsonConvert.SerializeObject(role));

            return role;
        }

        public static async Task<IEnumerable<Role>> GetAllRoles()
        {
            return (await FirebaseClient
                    .Child(nameof(Role))
                    .OnceAsync<Role>())
                .Select(x => x.Object);
        }*/
    }
}

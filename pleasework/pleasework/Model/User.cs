using pleasework.Enums;

namespace pleasework.Models
{
    public class User 
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public Role UserRole { get; set; }
    }
}

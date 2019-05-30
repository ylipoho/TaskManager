using pleasework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pleasework.Service

{
    public class SessionService
    {
        public User sessionUser { get; set; }

        public SessionService(User user)
        {
            this.sessionUser = new User();

            this.sessionUser.Login = user.Login;
            this.sessionUser.Password = user.Login;
            this.sessionUser.UserRole = user.UserRole;
        }

    }
}

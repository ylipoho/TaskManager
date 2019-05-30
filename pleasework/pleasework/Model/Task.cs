using System;
using System.Collections.Generic;
using System.Text;
using pleasework.Enums;

namespace pleasework.Models
{
    public class Task
    {
        public string Title { get; set; }

        public string Description { get; set; } 

        public string Priority { get; set; } 

        public string IsDone { get; set; } // true - done

        public DateTime Deadline { get; set; }

        public string Creator { get; set; }

        public string ForRole { get; set; } 

        public string Performer { get; set; }
    }


}

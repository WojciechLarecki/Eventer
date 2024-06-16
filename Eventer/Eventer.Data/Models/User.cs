using System;
using System.Collections.Generic;

namespace Eventer.Data.Models
{
    public partial class User
    {
        public User()
        {
            Events = new HashSet<Event>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte Role { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}

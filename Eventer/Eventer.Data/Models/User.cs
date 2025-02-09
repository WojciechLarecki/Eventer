using System.ComponentModel.DataAnnotations;

namespace Eventer.Data.Models
{
    public partial class User
    {
        public User()
        {
            Events = new HashSet<Event>();
        }

        public Guid Id { get; set; }
        
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
        
        public byte Role { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}

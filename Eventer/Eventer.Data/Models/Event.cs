using System.ComponentModel.DataAnnotations;

namespace Eventer.Data.Models
{
    public partial class Event
    {
        public Event()
        {
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? JoinDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

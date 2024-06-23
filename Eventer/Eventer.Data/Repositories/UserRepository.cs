using Eventer.Data.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Data.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(EventerContext context) : base(context)
        {
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public User? Find(Guid id)
        {
            return _context.Users.Find(id);
        }

        public void Delete(Guid id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
                _context.Users.Remove(user);
        }
    }
}

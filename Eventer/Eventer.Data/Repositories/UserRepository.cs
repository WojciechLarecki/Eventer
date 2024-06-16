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

        public User? Find(Guid id)
        {
            return _context.Users.Find(id);
        }
    }
}

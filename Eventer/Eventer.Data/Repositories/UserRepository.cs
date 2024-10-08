﻿using Eventer.Data.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public User? Find(Guid id)
        {
            return _context.Users.Find(id);
        }

        public async Task<User?> FindAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Delete(User user)
        {
            // delete user's links to events.
            foreach (var @event in user.Events)
            {
                @event.Users.Remove(user);
            }

            _context.Users.Remove(user);
        }

        public User? FindFull(Guid id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Events)
                .FirstOrDefault();
        }

        public async Task<User?> FindFullAsync(Guid id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .Include(u => u.Events)
                .FirstOrDefaultAsync();
        }
    }
}

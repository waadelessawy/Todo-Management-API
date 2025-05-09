using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _context;

        public ToDoRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ToDoItem item)
        {
            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.ToDoItems.FindAsync(id);
            if (item != null)
            {
                _context.ToDoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ToDoItem>> GetAllAsync() => await _context.ToDoItems.ToListAsync();

        public async Task<ToDoItem?> GetByIdAsync(Guid id) => await _context.ToDoItems.FindAsync(id);

        public async Task UpdateAsync(ToDoItem item)
        {
            _context.ToDoItems.Update(item);
            await _context.SaveChangesAsync();
        }
        

    }
}

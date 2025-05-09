using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RepositoriesInterfaces
{
    public interface IToDoRepository
    {
        Task<ToDoItem?> GetByIdAsync(Guid id);
        Task<List<ToDoItem>> GetAllAsync();
        Task AddAsync(ToDoItem item);
        Task UpdateAsync(ToDoItem item);
        Task DeleteAsync(Guid id);
    }
}

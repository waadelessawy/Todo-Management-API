using BLL.Models;
using DAL.Entities;
using Helpers;
using Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServicesInterfaces
{
    public interface IToDoService
    {
        public Task<ResponseObject> GetAllAsync();
        public Task<ResponseObject> GetByIdAsync(Guid id);
        public Task<ResponseObject> CreateAsync(CreateToDoItem dto);
        public Task<ResponseObject> UpdateAsync(UpdateToDoItem dto);
        public Task<ResponseObject> DeleteAsync(Guid id);
    }
}

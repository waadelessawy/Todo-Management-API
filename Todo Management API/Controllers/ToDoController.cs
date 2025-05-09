using BLL.Models;
using BLL.Services;
using BLL.ServicesInterfaces;
using Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Todo_Management_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        [Route("GetAllToDos")]
        public async Task<ResponseObject> GetAll()
        {
            //var request = HttpContext.Request;
            //string path = HttpContext.Request.Path.ToString();
            return await _toDoService.GetAllAsync();
        }

        [HttpPost]
        [Route("CreateToDoItem")]
        public async Task<ResponseObject> Create(CreateToDoItem dto)
        {
            return await _toDoService.CreateAsync(dto);

        }
        [HttpDelete]
        [Route("DeleteToDoItem")]
        public async Task<ResponseObject> Delete(Guid id)
        {
            return await _toDoService.DeleteAsync(id);

        }
        [HttpPost]
        [Route("UpdateToDoItem")]
        public async Task<ResponseObject> Update(UpdateToDoItem dto)
        {
            return await _toDoService.UpdateAsync(dto);

        }

    }
}

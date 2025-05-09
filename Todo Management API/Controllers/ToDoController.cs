using BLL.Models;
using BLL.Services;
using BLL.ServicesInterfaces;
using Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Todo_Management_API.Controllers
{
    /// <summary>
    /// This controller is responsible for managing CRUD operations of ToDo items
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }
        /// <summary>
        /// Get all ToDo items
        /// </summary>
        /// <returns>The unified object across all apis containing the response data</returns>
        [HttpGet]
        [Route("GetAllToDos")]
        public async Task<ResponseObject> GetAll()
        {
            //var request = HttpContext.Request;
            //string path = HttpContext.Request.Path.ToString();
            return await _toDoService.GetAllAsync();
        }

        /// <summary>
        /// Creates ToDo item
        /// </summary>
        /// <param name="toDoItem">The ToDo Item's basic info data object</param>
        /// <returns>The unified object across all apis containing the response data</returns>
        [HttpPost]
        [Route("CreateToDoItem")]
        public async Task<ResponseObject> Create(CreateToDoItem toDoItem)
        {
            return await _toDoService.CreateAsync(toDoItem);

        }
        /// <summary>
        /// Deletes ToDo item
        /// </summary>
        /// <param name="id">The Id of the ToDo item to be deleted</param>
        /// <returns>The unified object across all apis containing the response data</returns>
        [HttpDelete]
        [Route("DeleteToDoItem")]
        public async Task<ResponseObject> Delete(Guid id)
        {
            return await _toDoService.DeleteAsync(id);

        }
        /// <summary>
        /// Updates ToDo item
        /// </summary>
        /// <param name="toDoItem">The ToDo Item's basic info data object</param>
        /// <returns>The unified object across all apis containing the response data</returns>
        [HttpPost]
        [Route("UpdateToDoItem")]
        public async Task<ResponseObject> Update(UpdateToDoItem toDoItem)
        {
            return await _toDoService.UpdateAsync(toDoItem);

        }

    }
}

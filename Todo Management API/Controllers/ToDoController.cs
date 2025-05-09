using BLL.Models;
using BLL.Services;
using BLL.ServicesInterfaces;
using Helpers;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ResponseObject> GetAll() => await _toDoService.GetAllAsync();

    [HttpPost]
    public async Task<ResponseObject> Create(CreateToDoItem dto)
    {
       return await _toDoService.CreateAsync(dto);
        
    }

}

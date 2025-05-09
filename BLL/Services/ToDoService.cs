using Azure;
using BLL.Models;
using BLL.ServicesInterfaces;
using DAL.Entities;
using Helpers;
using Helpers.Enums;
using Microsoft.VisualBasic;
using Repositories.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;

        public ToDoService(IToDoRepository repository) 
        {
            _repository = repository;
        }

        public async Task<ResponseObject> GetAllAsync()
        {
            ResponseObject response = new ResponseObject();
            try
            {
                response.Success = true;
                response.Data = await _repository.GetAllAsync();
                return response;
            }
            catch (Exception ex) 
            {
                response.Success = false;
                response.ErrorMessages.Add(ex.Message);
                return response;
            }
            
        }

        public async Task<ResponseObject> GetByIdAsync(Guid id) 
        {
            ResponseObject response = new ResponseObject();
            try
            {
                if(id == null || id == Guid.Empty)
                {
                    response.Success = false;
                    response.ErrorMessages.Add("Invalid Input");
                }

                response.Success = true;
                response.Data = await _repository.GetByIdAsync(id);
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessages.Add(ex.Message);
                return response;
            }

        }  

        public async Task<ResponseObject> CreateAsync(CreateToDoItem dto)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                if (dto == null || dto.Title == null || dto.Title == string.Empty || dto.Priority == null)
                {
                    response.Success = false;
                    response.ErrorMessages.Add("Invalid Input");
                }

                response.Success = true;
                var item = new ToDoItem(dto.Title, dto.Description, dto.Priority, dto.DueDate);
                await _repository.AddAsync(item);

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessages.Add(ex.Message);
                return response;
            }
            
        }

        public async Task<ResponseObject> UpdateAsync(UpdateToDoItem dto)
        {
            ResponseObject response = new ResponseObject();
            try
            {
                if (dto == null || dto.Title == null || dto.Title == string.Empty || dto.Priority == null || dto.Status == null)
                {
                    response.Success = false;
                    response.ErrorMessages.Add("Invalid Input");
                }


                response.Success = true;
                var item = await _repository.GetByIdAsync(dto.Id);

                if(item == null)
                {
                    response.Success = false;
                    response.ErrorMessages.Add("Item is not found");
                }

                item.Update(dto.Title, dto.Description, dto.Status, dto.Priority, dto.DueDate);
                await _repository.UpdateAsync(item);

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessages.Add(ex.Message);
                return response;
            }

            
        }

        public async Task<ResponseObject> DeleteAsync(Guid id) 
        {

            ResponseObject response = new ResponseObject();
            try
            {
                await _repository.DeleteAsync(id);
                response.Success = true;

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessages.Add(ex.Message);
                return response;
            }
        } 
    }

}

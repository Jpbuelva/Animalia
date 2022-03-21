using Domain.Service.Contracts;
using Domain.Service.Interfaces;
using Infraestructure.Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<Response<UserResponse>> Get(int? identification, string name, string spice, bool? hasPet)
        {
            Response<UserResponse> response = new Response<UserResponse>();
            try
            {
                response.Data = await _userService.Get(identification, name, spice, hasPet);
            }
            catch (Exception ex)
            {
                response.Header.Code = 500;
                response.Header.Message = ex.Message;
            }

            return response;

        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<Response<CollectionResponse>> Getall()
        {
            Response<CollectionResponse> response = new Response<CollectionResponse>();
            try
            {
                response.Data = await _userService.GetAll();
            }
            catch (Exception ex)
            {
                response.Header.Code = 500;
                response.Header.Message = ex.Message;
            }
            return response;
        }
        [HttpPost]
        public async Task<Response<bool>> Insert(List<UserDto> user)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response.Data = await _userService.Insert(user);
            }
            catch (Exception ex)
            {
                response.Header.Code = 500;
                response.Header.Message = ex.Message;
            }
            return response;
        }
        [HttpPut]
        public async Task<Response<bool>> Update(UserDto user)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response.Data = await _userService.Update(user);
            }
            catch (Exception ex)
            {
                response.Header.Code = 500;
                response.Header.Message = ex.Message;
            }
            return response;
        }
        [HttpDelete]
        public async Task<Response<bool>> Delete(int identification)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                response.Data = await _userService.Delete(identification);
            }
            catch (Exception ex)
            {
                response.Header.Code = 500;
                response.Header.Message = ex.Message;
            }
            return response;
        }
    }
}

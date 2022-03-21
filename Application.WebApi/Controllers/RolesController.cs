using Domain.Service.Contracts;
using Domain.Service.Interfaces;
using Infraestructure.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolesController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        [Route("GetAll")]
        public  Response<List<Roles>> Getall()
        {
            Response<List<Roles>> response = new Response<List<Roles>>();
            try
            {
                response.Data =  _rolService.GetAll();
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

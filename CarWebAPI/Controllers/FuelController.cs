using ApplicationService.DTOs;
using ApplicationService.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelController : ControllerBase
    {
        private FuelService fuelService = new FuelService();


        [HttpGet]
        public IEnumerable<FuelDTO> Get()
        {
            return (fuelService.Get());
        }


        [HttpGet("{id}")]
        public FuelDTO GetById(int id)
        {
            return (fuelService.GetById(id));
        }


        [HttpPost]
        public string Save(FuelDTO fuelDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (fuelService.Save(fuelDTO))
            {
                message.Code = 200;
                message.Body = "Fuel is saved.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Fuel was not saved.";
            }

            return $"{message.Code} {message.Body}";

        }
        [HttpPut]
        [Route("{id}")]
        public Messages.ResponseMessage Put([FromBody] FuelDTO fuelDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (!fuelDTO.Validate())
            {
                message.Code = 500;
                message.Error = "Data is not valid!";
                return message;
            }
            if (fuelService.Update(fuelDTO))
            {
                message.Code = 200;
                message.Body = "Fuel is updated.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Fuel is not updated.";
            }

            return message;

        }

        [HttpDelete]
        [Route("{id}")]
        public Messages.ResponseMessage Delete(int id)
        {
            Messages.ResponseMessage response = new Messages.ResponseMessage();

            if (fuelService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Fuel is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Fuel is not deleted.";
            }

            return response;
        }
    }
}

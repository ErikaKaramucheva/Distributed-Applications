using ApplicationService.DTOs;
using ApplicationService.Implementations;
using CarWebAPI.Messages;
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
    public class CarStatusController : ControllerBase
    {
        private CarStatusService statusService = new CarStatusService();


        [HttpGet]
        public IEnumerable<CarStatusDTO> Get()
        {
            return (statusService.Get());
        }


        [HttpGet("{id}")]
        public CarStatusDTO GetById(int id)
        {
            return statusService.GetById(id);
        }


        [HttpPost]
        public string Save(CarStatusDTO statusDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();

            if (statusService.Save(statusDTO))
            {
                message.Code = 200;
                message.Body = "Car Status is saved.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Car Status is not saved.";
            }

            return $"{message.Code} {message.Body}";
        }
        [HttpPut]
        [Route("{id}")]
        public Messages.ResponseMessage Put([FromBody] CarStatusDTO statusDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (!statusDTO.Validate())
            {
                message.Code = 500;
                message.Error = "Data is not valid!";
                return message;
            }
            if (statusService.Update(statusDTO))
            {
                message.Code = 200;
                message.Body = "Status is updated.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Status is not updated.";
            }

            return message;

        }

        [HttpDelete]
        [Route("{id}")]
        public Messages.ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (statusService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Car Status is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Status is not deleted.";
            }

            return (response);
        }
    }
}

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
    public class CarClassController : ControllerBase
    {
        private CarClassService classService = new CarClassService();


        [HttpGet]
        public IEnumerable<CarClassDTO> Get()
        {
            return (classService.Get());
        }


        [HttpGet("{id}")]
        public CarClassDTO GetById(int id)
        {
            return (classService.GetById(id));
        }


        [HttpPost]
        public string Save(CarClassDTO carClassDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (classService.Save(carClassDTO))
            {
                message.Code = 200;
                message.Body = "CarClass is saved.";
            }
            else
            {
                message.Code = 500;
                message.Body = "CarClass is not saved.";
            }

            return $"{message.Code} {message.Body}";

        }
        [HttpPut]
        [Route("{id}")]
        public Messages.ResponseMessage Put([FromBody] CarClassDTO carClassDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (!carClassDTO.Validate())
            {
                message.Code = 500;
                message.Error = "Data is not valid!";
                return message;
            }
            if (classService.Update(carClassDTO))
            {
                message.Code = 200;
                message.Body = "CarClass is updated.";
            }
            else
            {
                message.Code = 500;
                message.Body = "CarClass is not updated.";
            }

            return message;

        }

        [HttpDelete]
        [Route("{id}")]
        public Messages.ResponseMessage Delete(int id)
        {
            Messages.ResponseMessage response = new Messages.ResponseMessage();

            if (classService.Delete(id))
            {
                response.Code = 200;
                response.Body = "CarClass is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "CarClass is not deleted.";
            }

            return response;
        }
    }
}

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
    public class CarController : ControllerBase
    {
        private CarService carService = new CarService();


        [HttpGet]
        public IEnumerable<CarDTO> Get()
        {
            return (carService.Get());
        }


        [HttpGet("{id}")]
        public CarDTO GetById(int id)
        {
            return (carService.GetById(id));
        }

        [HttpGet("MyAds/{user_id}")]
        public IEnumerable<CarDTO> GetByUserId(string user_id)
        {
            return carService.GetByUserId(user_id);
        }


        [HttpPost]
        public string Save(CarDTO carDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (carService.Save(carDTO))
            {
                message.Code = 200;
                message.Body = "Car is saved.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Car is not saved.";
            }

            return $"{message.Code} {message.Body}";

        }
        [HttpPut]
        [Route("{id}")]
        public Messages.ResponseMessage Put([FromBody] CarDTO carDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (!carDTO.Validate())
            {
                message.Code = 500;
                message.Error = "Data is not valid!";
                return message;
            }
            if (carService.Update(carDTO))
            {
                message.Code = 200;
                message.Body = "Car is updated.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Car is not updated.";
            }

            return message;

        }

        [HttpDelete]
        [Route("{id}")]
        public Messages.ResponseMessage Delete(int id)
        {
            Messages.ResponseMessage response = new Messages.ResponseMessage();

            if (carService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Car is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Car is not deleted.";
            }

            return response;
        }
    }
}

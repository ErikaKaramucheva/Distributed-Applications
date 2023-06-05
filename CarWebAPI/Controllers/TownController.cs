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
    public class TownController : ControllerBase
    {
        private TownService townService = new TownService();


        [HttpGet]
        public IEnumerable<TownDTO> Get()
        {
            return (townService.Get());
        }


        [HttpGet("{id}")]
        public TownDTO GetById(int id)
        {
            return townService.GetById(id);
        }


        [HttpPost]
        public string Save(TownDTO townDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();

            if (townService.Save(townDTO))
            {
                message.Code = 200;
                message.Body = "Town is saved.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Town is not saved.";
            }

            return $"{message.Code} {message.Body}";
        }
        [HttpPut]
        [Route("{id}")]
        public Messages.ResponseMessage Put([FromBody] TownDTO townDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (!townDTO.Validate())
            {
                message.Code = 500;
                message.Error = "Data is not valid!";
                return message;
            }
            if (townService.Update(townDTO))
            {
                message.Code = 200;
                message.Body = "Town is updated.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Town is not updated.";
            }

            return message;

        }

        [HttpDelete]
        [Route("{id}")]
        public Messages.ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (townService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Town is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Town is not deleted.";
            }

            return (response);
        }
    }
}

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
    public class TransmissionController : ControllerBase
    {
        private TransmissionService transmissionService = new TransmissionService();


        [HttpGet]
        public IEnumerable<TransmissionDTO> Get()
        {
            return (transmissionService.Get());
        }


        [HttpGet("{id}")]
        public TransmissionDTO GetById(int id)
        {
            return transmissionService.GetById(id);
        }


        [HttpPost]
        public string Save(TransmissionDTO transmissionDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();

            if (transmissionService.Save(transmissionDTO))
            {
                message.Code = 200;
                message.Body = "Transmission is saved.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Transmission is not saved.";
            }

            return $"{message.Code} {message.Body}";
        }
        [HttpPut]
        [Route("{id}")]
        public Messages.ResponseMessage Put([FromBody] TransmissionDTO transmissionDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (!transmissionDTO.Validate())
            {
                message.Code = 500;
                message.Error = "Data is not valid!";
                return message;
            }
            if (transmissionService.Update(transmissionDTO))
            {
                message.Code = 200;
                message.Body = "Transmission is updated.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Transmission is not updated.";
            }

            return message;

        }

        [HttpDelete]
        [Route("{id}")]
        public Messages.ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (transmissionService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Transmission is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Transmission is not deleted.";
            }

            return (response);
        }
    }
}

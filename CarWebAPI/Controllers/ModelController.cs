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
    public class ModelController : ControllerBase
    {
        private ModelService modelService = new ModelService();


        [HttpGet]
        public IEnumerable<ModelDTO> Get()
        {
            return (modelService.Get());
        }


        [HttpGet("{id}")]
        public ModelDTO GetById(int id)
        {
            return (modelService.GetById(id));
        }


        [HttpPost]
        public string Save(ModelDTO modelDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (modelService.Save(modelDTO))
            {
                message.Code = 200;
                message.Body = "Model is saved.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Model was not saved.";
            }

            return $"{message.Code} {message.Body}";

        }
        [HttpPut]
        [Route("{id}")]
        public Messages.ResponseMessage Put([FromBody] ModelDTO modelDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (!modelDTO.Validate())
            {
                message.Code = 500;
                message.Error = "Data is not valid!";
                return message;
            }
            if (modelService.Update(modelDTO))
            {
                message.Code = 200;
                message.Body = "Model is updated.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Model is not updated.";
            }

            return message;

        }

        [HttpDelete]
        [Route("{id}")]
        public Messages.ResponseMessage Delete(int id)
        {
            Messages.ResponseMessage response = new Messages.ResponseMessage();

            if (modelService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Model is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Model is not deleted.";
            }

            return response;
        }
    }
}

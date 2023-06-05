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
    public class BrandController : ControllerBase
    {
        private BrandService brandService = new BrandService();


        [HttpGet]
        public IEnumerable<BrandDTO> Get()
        {
            return (brandService.Get());
        }


        [HttpGet("{id}")]
        public BrandDTO GetById(int id)
        {
            return (brandService.GetById(id));
        }


        [HttpPost]
        public Messages.ResponseMessage Save(BrandDTO brandDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (!brandDTO.Validate())
            {
                message.Code = 500;
                message.Error = "Data is not valid!";
                return message;
            }

            if (brandService.Save(brandDTO))
            {
                message.Code = 200;
                message.Body = "Brand is saved.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Brand is not saved.";
            }

            return message;
        }
        [HttpPut]
        [Route("{id}")]
        public Messages.ResponseMessage Put([FromBody] BrandDTO brandDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (!brandDTO.Validate())
            {
                message.Code = 500;
                message.Error = "Data is not valid!";
                return message;
            }
            if (brandService.Update(brandDTO))
            {
                message.Code = 200;
                message.Body = "Brand is updated.";
            }
            else
            {
                message.Code = 500;
                message.Body = "Brand is not updated.";
            }

            return message;

        }

        [HttpDelete]
        [Route("{id}")]
        public Messages.ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (brandService.Delete(id))
            {
                response.Code = 200;
                response.Body = "Brand is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "Brand is not deleted.";
            }

            return response;
        }
    }
}

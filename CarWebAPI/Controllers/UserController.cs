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
    public class UserController : ControllerBase
    {
        private UserService userService = new UserService();


        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            return (userService.Get());
        }


        [HttpGet("{id}")]
        public UserDTO GetById(int id)
        {
            return userService.GetById(id);
        }

        [HttpGet("{username}/{password}")]
        public bool Login(LoginDTO loginDTO)
        {
            return userService.Login(loginDTO);
        }

        [HttpPost]
        public string Save(UserDTO userDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();

            if (userService.Save(userDTO))
            {
                message.Code = 200;
                message.Body = "User is saved.";
            }
            else
            {
                message.Code = 500;
                message.Body = "User is not saved.";
            }

            return $"{message.Code} {message.Body}";
        }
        [HttpPut]
        [Route("{id}")]
        public Messages.ResponseMessage Put([FromBody] UserDTO userDTO)
        {
            Messages.ResponseMessage message = new Messages.ResponseMessage();
            if (!userDTO.Validate())
            {
                message.Code = 500;
                message.Error = "Data is not valid!";
                return message;
            }
            if (userService.Update(userDTO))
            {
                message.Code = 200;
                message.Body = "User is updated.";
            }
            else
            {
                message.Code = 500;
                message.Body = "User is not updated.";
            }

            return message;

        }

        [HttpDelete]
        [Route("{id}")]
        public Messages.ResponseMessage Delete(int id)
        {
            ResponseMessage response = new ResponseMessage();

            if (userService.Delete(id))
            {
                response.Code = 200;
                response.Body = "User is deleted.";
            }
            else
            {
                response.Code = 500;
                response.Body = "User is not deleted.";
            }

            return (response);
        }
    }
}

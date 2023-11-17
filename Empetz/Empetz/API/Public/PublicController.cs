using AutoMapper;
using Domain.Models;
using Domain.Services.Public.DTOs;
using Domain.Services.Public.Interfaces;
using Empetz.API.Public.RequestObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Empetz.API.Public
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        private IPublicService _publicInterface;
        protected IMapper _mapper;

        public PublicController(IPublicService publicInterface, IMapper mapper)
        {
            _publicInterface = publicInterface;
            mapper = _mapper;
        }

        [HttpGet]
        [Route("user/Login")]
        public ActionResult MobileNumberValidation(LoginRequest loginRequest)
        {
            MoblieNumberVarificationObject mobileNumberValidation = _mapper.Map<MoblieNumberVarificationObject>(loginRequest);
            SystemUser user = _publicInterface.MobleNumberVarification(mobileNumberValidation);
            if (user != null)
            {
                return Ok("Mobile Number Exist");
            }
            else
            {
                return BadRequest("Mobile Number is not exist");
            }

        }
        [HttpPost]
        [Route("user/signup")]
        public ActionResult Register(SystemUser systemUser)
        {
            SystemUser user = _publicInterface.register(systemUser);
            if (user != null)
            {
                return Ok("Registration Success!!");
            }
            else
            {
                return BadRequest("Registration failed...!!");
            }
        }



    }
}


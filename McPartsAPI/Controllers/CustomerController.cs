using AutoMapper;
using Mcparts.Business.Dtos;
using Mcparts.Business.Services;
using Mcparts.Business.Services.IServices.IServiceMappings;
using Mcparts.DataAccess.Dtos;
using Mcparts.DataAccess.Models;
using Mcparts.Infrastructure.Interfaces;
using McPartsAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;

namespace McPartsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersService _service;
        private readonly IMapper _mapper;
        private readonly IUsersService _userService;

        public CustomerController(ICustomersService service, IMapper mapper, IUsersService _userService)
        {
            _service = service;
            _mapper = mapper;
            this._userService = _userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<customerdtoGet>>> GetAll()
        {
            Expression<Func<customer, bool>> expression = p => p.isdeleted == false;
            var data = await _service.GetListByExpressionAsync(expression);
            var requestpayload = _mapper.Map<List<customerdtoGet>>(data);
            return Ok(requestpayload);

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<customerdtoGet>> GetDataById([FromRoute] string id)
        {
            Expression<Func<customer, bool>> expression = p => p.isdeleted == false && p.id == id;
            var data = await _service.GetSingleEntityByExpressionAsync(expression);
            var requestpayload = _mapper.Map<customerdtoGet>(data);
            return Ok(requestpayload);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<bool>> Create([FromBody] customerdto data)
        {
            await _service.AddAsync(data);

            var userdata = new usersdto()
            {
                firstname = data.name,
                primarycontactnumber  = data.number,
                secondarycontactnumber = data.phonenumber,
                email = data.emailaddress

            };
            _userService.AddAsync(userdata);

            return Ok(data.id);

        }

        [HttpPost]
        [Route("SignUp")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> SignUp([FromBody] customersignupdto data)
        {
            var customerdata = new customerdto()
            {
                name = data.name,
                number = data.number,
                emailaddress = data.email,
                password = data.password,
            };

            await _service.AddAsync(customerdata);

            var userdata = new usersdto()
            {
                firstname = data.name,
                primarycontactnumber = data.number,
                password = data.password,
                email = data.email,
                usertype = ApplicationConstants.UserTypeMember,
                registereddate = DateTime.UtcNow,
                userstatusid = ApplicationConstants.UserStatusActive

            };
            await _userService.AddAsync(userdata);

            return Ok(true);

        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<bool>> Update([FromBody] customerdtoGet data)
        {
            var requestpayload = _mapper.Map<customerdto>(data);
            await _service.UpdateAsync(requestpayload);
            return Ok(true);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            Expression<Func<customer, bool>> expression = p => p.id == id;
            await _service.DeleteSoftByExpressionAsync(expression);
            return Ok(true);
        }
    }
}

using AutoMapper;
using Mcparts.Business.Dtos;
using Mcparts.Business.Services;
using Mcparts.Business.Services.IServices.IServiceMappings;
using Mcparts.DataAccess.Dtos;
using Mcparts.DataAccess.Models;
using Mcparts.Infrastructure.Interfaces;
using Mcparts.Infrastructure.Security;
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
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UsersController(IUsersService service, IMapper mapper, IConfiguration config)
        {
            _service = service;
            _mapper = mapper;
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<usersdtoGet>>> GetAll()
        {
            Expression<Func<users, bool>> expression = p => p.isdeleted == false;
            var data = await _service.GetListByExpressionAsync(expression);
            var requestpayload = _mapper.Map<List<usersdtoGet>>(data);
            return Ok(requestpayload);

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<usersdtoGet>> GetDataById([FromRoute] string id)
        {
            Expression<Func<users, bool>> expression = p => p.isdeleted == false && p.id == id;
            var data = await _service.GetSingleEntityByExpressionAsync(expression);
            var requestpayload = _mapper.Map<usersdtoGet>(data);
            return Ok(requestpayload);
        }

        [HttpPost]
        [Route("create")]

        public async Task<ActionResult<bool>> Create([FromBody] usersdto data)
        {
            if ((string.IsNullOrEmpty(data.email)) || (string.IsNullOrEmpty(data.primarycontactnumber)))
                return BadRequest();

            Expression<Func<users, bool>> expression = p => p.isdeleted == false && p.email == data.email;

            var verifyData = await _service.GetSingleEntityByExpressionAsync(expression);

            if (verifyData is not null)
            {
                return BadRequest($"Customer email already exists");
            }

            expression = p => p.isdeleted == false && p.primarycontactnumber == data.primarycontactnumber;

            verifyData = await _service.GetSingleEntityByExpressionAsync(expression);

            if (verifyData is not null)
            {
                return BadRequest($"Customer number already exists");
            }

            //string tempfirstname4letters = (data.firstname.Length > 4) ? data.firstname.Substring(0, 4) : data.firstname;
            //string tempPrimary4letters = (data.primarycontactnumber.Length > 4) ? data.primarycontactnumber.Substring(0, 4) : data.primarycontactnumber;

            //data.temporarypassword = tempfirstname4letters.ToLower() + tempPrimary4letters.ToLower();
            data.createdatutc = DateTime.UtcNow;
            data.updatedatutc = DateTime.UtcNow;
            var passwordDetails = AesOperationWithoutKey.EncryptString(data.password);
            data.passwordencrypyted = passwordDetails.EncryptedPassword;
            data.passwordkey = passwordDetails.Key;
            data.passwordiv = passwordDetails.IV;

            data.password = null;
            await _service.AddAsync(data);
            return Ok(data.id);

        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<bool>> Update([FromBody] usersdtoGet data)
        {
            var requestpayload = _mapper.Map<usersdto>(data);
            if ((string.IsNullOrEmpty(data.email)) || (string.IsNullOrEmpty(data.primarycontactnumber)))
                return BadRequest();

            Expression<Func<users, bool>> expression = p => p.isdeleted == false && p.id == data.id;

            var verifyData = await _service.GetSingleEntityByExpressionAsync(expression);

            if(verifyData is null)
                return BadRequest($"Customer doesn't exists");

            if (verifyData.email != data.email)
            {
                expression = p => p.isdeleted == false && p.email == data.email;

                verifyData = await _service.GetSingleEntityByExpressionAsync(expression);

                if (verifyData is not null)
                {
                    return BadRequest($"Customer email already exists");
                }
            }

            if (verifyData.primarycontactnumber != data.primarycontactnumber)
            {
                expression = p => p.isdeleted == false && p.primarycontactnumber == data.primarycontactnumber;

                verifyData = await _service.GetSingleEntityByExpressionAsync(expression);

                if (verifyData is not null)
                {
                    return BadRequest($"Customer number already exists");
                }
            }

            
            await _service.UpdateAsync(requestpayload);
            return Ok(true);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            Expression<Func<users, bool>> expression = p => p.id == id;
            await _service.DeleteSoftByExpressionAsync(expression);
            return Ok(true);
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<ActionResult<bool>> ForgotPassword([FromBody] UserForgotPasswordDto userData)
        {
            Expression<Func<users, bool>> expressionEmployees = p => p.email.ToLower() == userData.Email.ToLower();
            var emaildata = await _service.GetSingleEntityByExpressionAsync(expressionEmployees);

            if (emaildata is null)
            {
                return NotFound();
            }
            
            return Ok(true);
        }

        [HttpPost]
        [Route("ForgotPasswordConfirmation")]
        public async Task<ActionResult<bool>> ForgotPasswordConfirmation([FromBody] UserForgotPasswordConfirmationDto userData)
        {
            Expression<Func<users, bool>> expressionEmployees = p => p.email.ToLower() == userData.Email.ToLower();
            var emaildata = await _service.GetSingleEntityByExpressionAsync(expressionEmployees);

            if (emaildata is null)
            {
                return NotFound();
            }
            else
            {
                emaildata.password = userData.Password;

            }
            await _service.UpdateAsync(emaildata);

            return Ok(true);
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<usersdtoGet>> Login([FromBody] UserLoginDto userData)
        {
            
            
            Expression<Func<users, bool>> expressionEmployees = p => p.email.ToLower() == userData.email.ToLower();
            var emaildata = await _service.GetSingleEntityByExpressionAsync(expressionEmployees);

            if (emaildata is null)
            {
                return NotFound();
            }
            else
            {
                emaildata.password = AesOperationWithoutKey.DecryptStringFromBytes(emaildata.passwordencrypyted, emaildata.passwordkey, emaildata.passwordiv);
            }

            if (emaildata.temporarypassword == null)
            {
                //it means password reset happened
                if (emaildata.password == userData.password)
                {

                    var returnData = _mapper.Map<usersdtoGet>(emaildata);
                    var token = TokenService.GenerateJwtToken(returnData.id, returnData.firstname + returnData.lastname, userData.email, _config);
                    returnData.token = token;
                    return returnData;
                }
                else
                    return Unauthorized();
            }
            else
            {
                //it means password reset happened
                if (emaildata.temporarypassword == userData.password)
                {
                    var returnData = _mapper.Map<usersdtoGet>(emaildata);
                    var token = TokenService.GenerateJwtToken(returnData.id, returnData.firstname + returnData.lastname, userData.email, _config);
                    returnData.token = token;
                    return returnData;
                }
                else
                    return Unauthorized();
            }
        }

    }
}

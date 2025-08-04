using AutoMapper;
using Mcparts.Business.Dtos;
using Mcparts.Business.Services;
using Mcparts.Business.Services.IServices.IServiceMappings;
using Mcparts.DataAccess.Dtos;
using Mcparts.DataAccess.Models;
using Mcparts.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;

namespace McPartsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductSubCategoryController : ControllerBase
    {
        private readonly IProductSubCategoryService _service;
        private readonly IMapper _mapper;
        //private readonly TokenProvider _tokenProvider;

        public ProductSubCategoryController(IProductSubCategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<productsubcategorydtoGet>>> GetAll()
        {
            Expression<Func<productsubcategory, bool>> expression = p => p.isdeleted == false;
            var data = await _service.GetListByExpressionAsync(expression);
            var requestpayload = _mapper.Map<List<productsubcategorydtoGet>>(data);
            return Ok(requestpayload);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<productgroupdtoGet>> GetDataById([FromRoute] string id)
        {
            Expression<Func<productsubcategory, bool>> expression = p => p.isdeleted == false && p.id == id;
            var data = await _service.GetSingleEntityByExpressionAsync(expression);
            var requestpayload = _mapper.Map<productsubcategorydtoGet>(data);
            return Ok(requestpayload);
        }

        [HttpGet]
        [Route("{CategoryId}")]
        public async Task<ActionResult<productgroupdtoGet>> GetDataByCategoryId([FromRoute] string CategoryId)
        {
            Expression<Func<productsubcategory, bool>> expression = p => p.isdeleted == false && p.productcategoryid == CategoryId;
            var data = await _service.GetSingleEntityByExpressionAsync(expression);
            var requestpayload = _mapper.Map<productsubcategorydtoGet>(data);
            return Ok(requestpayload);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<bool>> Create([FromBody] productsubcategorydto data)
        {
            await _service.AddAsync(data);
            return Ok(data.id);

        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<bool>> Update([FromBody] productcategorydtoGet data)
        {
            var requestpayload = _mapper.Map<productsubcategorydto>(data);
            await _service.UpdateAsync(requestpayload);
            return Ok(true);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            Expression<Func<productsubcategory, bool>> expression = p => p.id == id;
            await _service.DeleteSoftByExpressionAsync(expression);
            return Ok(true);
        }
    }
}

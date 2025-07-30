using AutoMapper;
using Mcparts.Business.Dtos;
using Mcparts.Business.Services;
using Mcparts.Business.Services.IServices.IServiceMappings;
using Mcparts.DataAccess.Dtos;
using Mcparts.DataAccess.Models;
using Mcparts.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;

namespace McPartsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMetadataController : ControllerBase
    {
        private readonly IProductMetadataService _service;
        private readonly IMapper _mapper;
        //private readonly TokenProvider _tokenProvider;

        public ProductMetadataController(IProductMetadataService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<productmetadatadtoGet>>> GetAll()
        {
            Expression<Func<productmetadata, bool>> expression = p => p.isdeleted == false;
            var data = await _service.GetListByExpressionAsync(expression);
            var requestpayload = _mapper.Map<List<productmetadatadtoGet>>(data);
            return Ok(requestpayload);

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<productmetadatadtoGet>> GetDataById([FromRoute] string id)
        {
            Expression<Func<productmetadata, bool>> expression = p => p.isdeleted == false && p.id == id;
            var data = await _service.GetSingleEntityByExpressionAsync(expression);
            var requestpayload = _mapper.Map<productmetadatadtoGet>(data);
            return Ok(requestpayload);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<bool>> Create([FromBody] productmetadatadto data)
        {
            await _service.AddAsync(data);
            return Ok(data.id);

        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<bool>> Update([FromBody] productmetadatadtoGet data)
        {
            var requestpayload = _mapper.Map<productmetadatadto>(data);
            await _service.UpdateAsync(requestpayload);
            return Ok(true);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            Expression<Func<productmetadata, bool>> expression = p => p.id == id;
            await _service.DeleteSoftByExpressionAsync(expression);
            return Ok(true);
        }
    }
}

using Mcparts.DataAccess.Dtos;
using Mcparts.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace McPartsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private IProductsSevice itemsSevice;

        public ProductsController(ILogger<ProductsController> logger, IProductsSevice itemsSevice)
        {
            _logger = logger;
            this.itemsSevice = itemsSevice;
        }

        //[HttpGet(Name = "GetAllItemCategory")]
        //public async Task<ActionResult<IEnumerable<JObject>>> GetAll()
        //{
        //    var d = await itemCategorySevice.GetAll();
        //    return  Ok(d);
            
        //}

        [HttpGet]
        public async Task<IEnumerable<JObject>> GetAll()
        {
            return await itemsSevice.GetAll();
        }

        [HttpGet]
        [Route("GetSearchFilter")]
        public async Task<IEnumerable<JObject>> GetSearchFilter()
        {
            return await itemsSevice.GetAllSearchFilterData();
        }

        [HttpPost]
        [Route("Search")]
        public async Task<IEnumerable<JObject>> Search([FromBody]JObject filter)
        {
            return await itemsSevice.Search(filter);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<JObject> GetbyId([FromRoute] string id)
        {
            return await itemsSevice.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public async Task<bool> Create([FromBody] ProductsDtoPost data)
        {
            return await itemsSevice.Create(data);
        }

        [HttpPut]
        [Route("update")]
        public async Task<bool> Update([FromBody] ProductsDto data)
        {
            return await itemsSevice.Update(data);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Update([FromRoute] string id)
        {
            return await itemsSevice.Delete(id);
        }
    }
}

//using Mcparts.DataAccess.Dtos;
//using Mcparts.Infrastructure.Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json.Linq;

//namespace McPartsAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ItemCategoryController : ControllerBase
//    {
//        private readonly ILogger<ItemCategoryController> _logger;
//        private IItemCategorySevice itemCategorySevice;

//        public ItemCategoryController(ILogger<ItemCategoryController> logger, IItemCategorySevice itemCategorySevice)
//        {
//            _logger = logger;
//            this.itemCategorySevice = itemCategorySevice;
//        }

//        //[HttpGet(Name = "GetAllItemCategory")]
//        //public async Task<ActionResult<IEnumerable<JObject>>> GetAll()
//        //{
//        //    var d = await itemCategorySevice.GetAll();
//        //    return  Ok(d);
            
//        //}

//        [HttpGet]
//        public async Task<IEnumerable<JObject>> GetAll()
//        {
//            return await itemCategorySevice.GetAll();
//        }

//        [HttpGet]
//        [Route("{id}")]
//        public async Task<JObject> GetbyId([FromRoute] string id)
//        {
//            return await itemCategorySevice.GetById(id);
//        }

//        [HttpPost]
//        [Route("create")]
//        public async Task<bool> Create([FromBody] ItemCategoryDtoPost data)
//        {
//            return await itemCategorySevice.Create(data);
//        }

//        [HttpPut]
//        [Route("update")]
//        public async Task<bool> Update([FromBody] ItemCategoryDto data)
//        {
//            return await itemCategorySevice.Update(data);
//        }

//        [HttpDelete]
//        [Route("{id}")]
//        public async Task<bool> Update([FromRoute] string id)
//        {
//            return await itemCategorySevice.Delete(id);
//        }
//    }
//}

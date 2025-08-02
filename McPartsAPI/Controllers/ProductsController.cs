using AutoMapper;
using ExcelDataReader;
using Mcparts.Business.Dtos;
using Mcparts.Business.Services;
using Mcparts.Business.Services.IServices.IServiceMappings;
using Mcparts.Business.Services.Services;
using Mcparts.DataAccess.Dtos;
using Mcparts.DataAccess.Models;
using Mcparts.Infrastructure.Interfaces;
using Mcparts.Infrastructure.Services;
using McPartsAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

namespace McPartsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _service;
        private readonly IProductsGetSevice _productsGetService;
        
        private readonly IMapper _mapper;
        private readonly IProductMetadataService _productMetadataService;
        private readonly IProductMetadataValuesService _productMetadataValueService;
        private readonly IProductMapperService _productMapperService;
        private readonly HelperMethods _helperMethods = new HelperMethods();
        //private readonly TokenProvider _tokenProvider;

        public ProductsController(IProductsService service,
            IProductMetadataService _productMetadataService,
            IProductMetadataValuesService _productMetadataValueService,
            IProductsGetSevice _productsGetService,
            IProductMapperService _productMapperService,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            this._productMetadataService = _productMetadataService;
            this._productMetadataValueService = _productMetadataValueService;
            this._productMapperService = _productMapperService;
            this._productsGetService = _productsGetService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<productsdtoGet>>> GetAll()
        {
            Expression<Func<products, bool>> expression = p => p.isdeleted == false;
            var data = await _service.GetListByExpressionAsync(expression);
            var requestpayload = _mapper.Map<List<productsdtoGet>>(data);
            return Ok(requestpayload);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<productsdtoGet>> GetDataById([FromRoute] string id)
        {
            Expression<Func<products, bool>> expression = p => p.isdeleted == false && p.id == id;
            var data = await _service.GetSingleEntityByExpressionAsync(expression);
            var requestpayload = _mapper.Map<productsdtoGet>(data);
            return Ok(requestpayload);
        }

        [HttpGet]
        [Route("GetProductGroupCategroyData")]
        public async Task<ActionResult<List<ProductGroupCategoriesDto>>> GetProductGroupCategroyData()
        {
            var data = await _productsGetService.GetProductsGroupCategory();
            //Expression<Func<products, bool>> expression = p => p.isdeleted == false && p.id == id;
            //var data = await _service.GetSingleEntityByExpressionAsync(expression);
            //var requestpayload = _mapper.Map<productsdtoGet>(data);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetSearchFilterAllByCategory/{productcategoryid}")]
        public async Task<ActionResult<List<SearchFilterAll>>> GetSearchFilterAllByCategory(string productcategoryid)
        {
            var data = await _productsGetService.GetSearchFilterAllByCategory(productcategoryid);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetSearchFilterAllBySubCategory/{productsubcategoryid}")]
        public async Task<ActionResult<List<SearchFilterAll>>> GetSearchFilterAllBySubCategory(string productsubcategoryid)
        {
            var data = await _productsGetService.GetSearchFilterAllBySubCategory(productsubcategoryid);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetProductDataBySubCategoryWithCount/{productcategoryid}")]
        public async Task<ActionResult<List<ProductDataBySubCategoryWithCount>>> GetProductDataBySubCategoryWithCount(string productcategoryid)
        {
            var data = await _productsGetService.GetProductDataBySubCategoryWithCount(productcategoryid);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetProductDataBySubCategorySubsetWithCount/{productsubcategoryid}")]
        public async Task<ActionResult<List<ProductDataBySubCategoryWithCount>>> GetProductDataBySubCategorySubsetWithCount(string productsubcategoryid)
        {
            var data = await _productsGetService.GetProductDataBySubCategorySubsetWithCount(productsubcategoryid);
            return Ok(data);
        }

        [HttpPost]
        [Route("GetProductDataBySubCategoryWithCountForMetadata")]
        public async Task<ActionResult<List<ProductDataBySubCategoryWithCountForMetadata>>> GetProductDataBySubCategoryWithCountForMetadata([FromBody] SearchFilterInput searchFilterInput)
        {
            var data = await _productsGetService.GetProductDataBySubCategoryWithCountForMetadata(searchFilterInput.metadatavalueid, searchFilterInput.categoryId);
            return Ok(data);
        }

        //[HttpGet]
        //[Route("GetSearchFilterAllByCategory/{productcategoryid}")]
        //public async Task<ActionResult<List<ProductDataBySubCategoryWithCount>>> GetSearchFilterAllByCategory(string productcategoryid)
        //{
        //    var data = await _productsGetService.GetSearchFilterAllByCategory(productcategoryid);
        //    return Ok(data);
        //}

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<bool>> Create([FromBody] productsdto data)
        {
            await _service.AddAsync(data);
            return Ok(data.id);

        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<bool>> Update([FromBody] productsdtoGet data)
        {
            var requestpayload = _mapper.Map<productsdto>(data);
            await _service.UpdateAsync(requestpayload);
            return Ok(true);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            Expression<Func<products, bool>> expression = p => p.id == id;
            await _service.DeleteSoftByExpressionAsync(expression);
            return Ok(true);
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<ActionResult<bool>> Upload(IFormFile? csvData)
        {
            var enc = CodePagesEncodingProvider.Instance.GetEncoding(1252);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var data = new MemoryStream();
            await csvData.CopyToAsync(data);


            List<string> productNames = new List<string>();
            List<string> headers = new List<string>();
            List<productsdto> listProducts = new List<productsdto>();
            List<string> slnos = new List<string>();
            List<productmapperdto> listProductMapper = new List<productmapperdto>();

            Dictionary<string, List<string>> dictionaryMetadata = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> dictionaryMetValues = new Dictionary<string, List<string>>();

            

            using (var reader = ExcelReaderFactory.CreateReader(data))
            {
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                DataTable metadataexceltable = result.Tables["Metadata"];
                foreach (DataColumn dc in metadataexceltable.Columns)
                {
                    if (string.IsNullOrEmpty(dc.ColumnName))
                        continue;

                    dictionaryMetadata.Add(dc.ColumnName.ToString(), new List<string>());
                }
                foreach (DataRow row in metadataexceltable.Rows)
                {
                    foreach(KeyValuePair<string, List<string>> entry in dictionaryMetadata)
                    {
                        var socketHead = row[entry.Key].ToString();
                        if (string.IsNullOrEmpty(socketHead))
                            continue;

                        entry.Value.Add(socketHead);
                    }
                }

                foreach (DataTable table in result.Tables)
                {
                    if (table.TableName == "List Data")
                        continue;

                    if (table.TableName == "SOCKET HEAD")
                    {
                        var met = dictionaryMetadata["SOCKET HEAD"];
                        var dataMetadataVValues = _helperMethods.ProcessHeaderAndData(table, "", "", dictionaryMetadata, "SOCKET HEAD");
                        await _helperMethods.SaveMetadataAndValues(met, _productMetadataService,
                            dataMetadataVValues, _productMetadataValueService, _helperMethods.categoryidSocketHead, _helperMethods.subcategoryIdSocketHead);
                    }
                    if (table.TableName == "PLAIN WASHER")
                    {
                        var met = dictionaryMetadata["PLAIN WASHER"];
                        var dataMetadataVValues = _helperMethods.ProcessHeaderAndData(table, "", "", dictionaryMetadata, "PLAIN WASHER");
                        await _helperMethods.SaveMetadataAndValues(met, _productMetadataService,
                           dataMetadataVValues, _productMetadataValueService, _helperMethods.categoryWasher, _helperMethods.subcategoryWasherPlain);
                    }
                    if (table.TableName == "SPRING WASHER")
                    {
                        
                        var met = dictionaryMetadata["SPRING WASHER"];
                        var dataMetadataVValues = _helperMethods.ProcessHeaderAndData(table, "", "", dictionaryMetadata, "SPRING WASHER");
                        await _helperMethods.SaveMetadataAndValues(met, _productMetadataService,
                           dataMetadataVValues, _productMetadataValueService, _helperMethods.categoryWasher, _helperMethods.subcategoryWasherSpring);
                    }
                    if (table.TableName == "DOWEL PIN M6")
                    {
                        var met = dictionaryMetadata["DOWEL PIN M6"];
                        var dataMetadataVValues = _helperMethods.ProcessHeaderAndData(table, "", "", dictionaryMetadata, "DOWEL PIN M6");
                        await _helperMethods.SaveMetadataAndValues(met, _productMetadataService,
                           dataMetadataVValues, _productMetadataValueService, _helperMethods.categoryPin, _helperMethods.subcategoryPinM6);
                    }
                    if (table.TableName == "DOWEL PIN H6")
                    {
                        var met = dictionaryMetadata["DOWEL PIN H6"];
                        var dataMetadataVValues = _helperMethods.ProcessHeaderAndData(table, "", "", dictionaryMetadata, "DOWEL PIN H6");
                        await _helperMethods.SaveMetadataAndValues(met, _productMetadataService,
                           dataMetadataVValues, _productMetadataValueService, _helperMethods.categoryPin, _helperMethods.subcategoryPinH6);
                    }
                }

                var metadata = await _productMetadataService.GetAllAsync();
                var metadatavalues = await _productMetadataValueService.GetAllAsync();

                foreach (DataTable table in result.Tables)
                {
                    if (table.TableName == "List Data")
                        continue;

                    if (table.TableName == "SOCKET HEAD")
                    {
                        var met = dictionaryMetadata["SOCKET HEAD"];
                        var failedList = await _helperMethods.ProcessSOCKETHEADMainFunction(table, metadata, metadatavalues, _service, _productMapperService, met);
                    }
                    if (table.TableName == "PLAIN WASHER")
                    {
                        var met = dictionaryMetadata["PLAIN WASHER"];
                        var failedList = await _helperMethods.ProcessPlainWasherMainFunction(table, metadata, metadatavalues, _service, _productMapperService, met);
                    }
                    if (table.TableName == "SPRING WASHER")
                    {
                        var met = dictionaryMetadata["SPRING WASHER"];
                        var failedList = await _helperMethods.ProcessSpringWasherMainFunction(table, metadata, metadatavalues, _service, _productMapperService, met);
                    }
                    if (table.TableName == "DOWEL PIN M6")
                    {
                        var met = dictionaryMetadata["DOWEL PIN M6"];
                        var failedList = await _helperMethods.ProcessDowelPinM6DMainFunction(table, metadata, metadatavalues, _service, _productMapperService, met);
                    }
                    if (table.TableName == "DOWEL PIN H6")
                    {
                        var met = dictionaryMetadata["DOWEL PIN H6"];
                        var failedList = await _helperMethods.ProcessDowelPinH6DMainFunction(table, metadata, metadatavalues, _service, _productMapperService, met);
                    }
                }
            }
            return true;
        }
    }
}

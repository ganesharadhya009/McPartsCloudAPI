using AutoMapper;
using ExcelDataReader;
using Mcparts.Business.Dtos;
using Mcparts.Business.Services;
using Mcparts.Business.Services.IServices.IServiceMappings;
using Mcparts.Business.Services.Services;
using Mcparts.DataAccess.Dtos;
using Mcparts.DataAccess.Models;
using Mcparts.Infrastructure.Interfaces;
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
        private readonly IMapper _mapper;
        private readonly IProductMetadataService _productMetadataService;
        private readonly IProductMetadataValuesService _productMetadataValueService;
        private readonly IProductMapperService _productMapperService;
        //private readonly TokenProvider _tokenProvider;

        public ProductsController(IProductsService service,
            IProductMetadataService _productMetadataService,
            IProductMetadataValuesService _productMetadataValueService,
            IProductMapperService _productMapperService,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            this._productMetadataService = _productMetadataService;
            this._productMetadataValueService = _productMetadataValueService;
            this._productMapperService = _productMapperService;
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

            var metadata = await _productMetadataService.GetAllAsync();
            var metadatavalues = await _productMetadataValueService.GetAllAsync();

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

                    string categoryid= null;
                    string subcategoryId = null;
                    if (table.TableName == "SOCKET HEAD")
                    {
                        //var dataMetadataVValues = HelperMethods.ProcessHeaderAndData(table, "", "", dictionaryMetadata, "SOCKET HEAD");
                        //var met = dictionaryMetadata["SOCKET HEAD"];
                        //List<productmetadatadto> listproductMetadataDto = new List<productmetadatadto>();
                        //foreach (var mData in met)
                        //{
                        //    var productMetadataDtoData = HelperMethods.GetProductMetadataDTO( mData, HelperMethods.categoryidSocketHead, HelperMethods.subcategoryIdSocketHead);
                        //    await _productMetadataService.AddAsync(productMetadataDtoData);
                        //    int partnumbercount = 1;
                        //    foreach(var mValue in dataMetadataVValues)
                        //    {
                        //        foreach (var vd in mValue.Value)
                        //        {
                        //            var metvaluesdto = HelperMethods.GetProductMetadatavaluesDTO(vd, partnumbercount.ToString(), productMetadataDtoData.id);
                        //            await _productMetadataValueService.AddAsync(metvaluesdto);
                        //            partnumbercount++;
                        //        }
                        //    }
                        //    listproductMetadataDto.Add(productMetadataDtoData);
                        //}
                        var failedList = await HelperMethods.ProcessSOCKETHEADMainFunction(table, metadata, metadatavalues, _service, _productMapperService);
                    }
                    if (table.TableName == "PLAIN WASHER")
                    {
                        //var dataMetadataVValues = HelperMethods.ProcessHeaderAndData(table, "", "", dictionaryMetadata, "PLAIN WASHER");
                        //var met = dictionaryMetadata["PLAIN WASHER"];
                        //List<productmetadatadto> listproductMetadataDto = new List<productmetadatadto>();
                        //foreach (var mData in met)
                        //{
                        //    var productMetadataDtoData = HelperMethods.GetProductMetadataDTO(mData, HelperMethods.categoryWasher, HelperMethods.subcategoryWasherPlain);
                        //    await _productMetadataService.AddAsync(productMetadataDtoData);
                        //    int partnumbercount = 1;
                        //    foreach (var mValue in dataMetadataVValues)
                        //    {
                        //        foreach (var vd in mValue.Value)
                        //        {
                        //            var metvaluesdto = HelperMethods.GetProductMetadatavaluesDTO(vd, partnumbercount.ToString(), productMetadataDtoData.id);
                        //            await _productMetadataValueService.AddAsync(metvaluesdto);
                        //            partnumbercount++;
                        //        }
                        //    }
                        //    listproductMetadataDto.Add(productMetadataDtoData);
                        //}
                        var failedList = await HelperMethods.ProcessPlainWasherMainFunction(table, metadata, metadatavalues, _service, _productMapperService);
                    }
                    if (table.TableName == "SPRING WASHER")
                    {
                        //var dataMetadataVValues = HelperMethods.ProcessHeaderAndData(table, "", "", dictionaryMetadata, "SPRING WASHER");
                        //var met = dictionaryMetadata["SPRING WASHER"];
                        //List<productmetadatadto> listproductMetadataDto = new List<productmetadatadto>();
                        //foreach (var mData in met)
                        //{
                        //    var productMetadataDtoData = HelperMethods.GetProductMetadataDTO(mData, HelperMethods.categoryWasher, HelperMethods.subcategoryWasherSpring);
                        //    await _productMetadataService.AddAsync(productMetadataDtoData);
                        //    int partnumbercount = 1;
                        //    foreach (var mValue in dataMetadataVValues)
                        //    {
                        //        foreach (var vd in mValue.Value)
                        //        {
                        //            var metvaluesdto = HelperMethods.GetProductMetadatavaluesDTO(vd, partnumbercount.ToString(), productMetadataDtoData.id);
                        //            await _productMetadataValueService.AddAsync(metvaluesdto);
                        //            partnumbercount++;
                        //        }
                        //    }
                        //    listproductMetadataDto.Add(productMetadataDtoData);
                        //}
                        var failedList = await HelperMethods.ProcessSpringWasherMainFunction(table, metadata, metadatavalues, _service, _productMapperService);
                    }
                    if (table.TableName == "DOWEL PIN M6")
                    {
                        //var dataMetadataVValues = HelperMethods.ProcessHeaderAndData(table, "", "", dictionaryMetadata, "DOWEL PIN M6");
                        var met = dictionaryMetadata["DOWEL PIN M6"];
                        //List<productmetadatadto> listproductMetadataDto = new List<productmetadatadto>();
                        //foreach (var mData in met)
                        //{
                        //    var productMetadataDtoData = HelperMethods.GetProductMetadataDTO(mData, HelperMethods.categoryPin, HelperMethods.subcategoryPinM6);
                        //    await _productMetadataService.AddAsync(productMetadataDtoData);
                        //    int partnumbercount = 1;
                        //    foreach (var mValue in dataMetadataVValues)
                        //    {
                        //        foreach (var vd in mValue.Value)
                        //        {
                        //            var metvaluesdto = HelperMethods.GetProductMetadatavaluesDTO(vd, partnumbercount.ToString(), productMetadataDtoData.id);
                        //            await _productMetadataValueService.AddAsync(metvaluesdto);
                        //            partnumbercount++;
                        //        }
                        //    }
                        //    listproductMetadataDto.Add(productMetadataDtoData);
                        //}
                        //var failedList = await HelperMethods.ProcessSpringWasherMainFunction(table, metadata, metadatavalues, _service, _productMapperService);
                    }
                    if (table.TableName == "DOWEL PIN H6")
                    {
                        //var dataMetadataVValues = HelperMethods.ProcessHeaderAndData(table, "", "", dictionaryMetadata, "DOWEL PIN H6");

                        //var met = dictionaryMetadata["DOWEL PIN H6"];
                        //List<productmetadatadto> listproductMetadataDto = new List<productmetadatadto>();
                        //foreach (var mData in met)
                        //{
                        //    var productMetadataDtoData = HelperMethods.GetProductMetadataDTO(mData, HelperMethods.categoryPin, HelperMethods.subcategoryPinH6);
                        //    await _productMetadataService.AddAsync(productMetadataDtoData);
                        //    int partnumbercount = 1;
                        //    foreach (var mValue in dataMetadataVValues)
                        //    {
                        //        foreach (var vd in mValue.Value)
                        //        {
                        //            var metvaluesdto = HelperMethods.GetProductMetadatavaluesDTO(vd, partnumbercount.ToString(), productMetadataDtoData.id);
                        //            await _productMetadataValueService.AddAsync(metvaluesdto);
                        //            partnumbercount++;
                        //        }
                        //    }
                        //    listproductMetadataDto.Add(productMetadataDtoData);
                        //}
                        //var failedList = await HelperMethods.ProcessSpringWasherMainFunction(table, metadata, metadatavalues, _service, _productMapperService);
                    }

                    if (table.TableName == "Sheet1")
                    {
                        //foreach (DataRow row in table.Rows)
                        //{
                        //    var name = row["Name"].ToString();

                        //    var code = row["code"].ToString();

                        //    var metadataName = row["metadata name"].ToString();

                        //    var metadataInstance = metadata.FirstOrDefault(p => p.name.ToLower() == metadataName.ToLower());

                        //    var productmetadatavaluesdto = new productmetadatavaluesdto()
                        //    {
                        //        id = Guid.NewGuid().ToString(),
                        //        name = name,
                        //        description = name,
                        //        partnumbercode = code,
                        //        productmetdataid = metadataInstance.id,
                        //    };
                        //    await _productMetadataValueService.AddAsync(productmetadatavaluesdto);

                        //}
                    }
                }
            }
            return true;
        }
    }
}

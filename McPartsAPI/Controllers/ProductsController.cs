using AutoMapper;
using ExcelDataReader;
using Mcparts.Business.Dtos;
using Mcparts.Business.Services;
using Mcparts.Business.Services.IServices.IServiceMappings;
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

                foreach(DataTable table in result.Tables)
                {
                    if (table.TableName == "List Data")
                        continue;

                    string categoryid= null;
                    string subcategoryId = null;
                    if (table.TableName == "SOCKET HEAD")
                    {
                        categoryid = "b1404928-4100-4d11-be64-ab0d897e7953";
                        subcategoryId = "4fa08198-358f-4e1c-b64a-38239893ec7f";
                    

                        var columnHeaders = table.Columns;
                        foreach (DataRow row in table.Rows)
                        {
                            var slNo = row["SL NO"].ToString();
                            try
                            {
                                //create products
                                if (row["NAME"] != null && row["NAME"].ToString() != "")
                                {
                                    var product = new productsdto()
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        name = row["NAME"].ToString(),
                                        unitmeasureid = "88184107-81be-452b-a28f-086426d6f225",
                                        lotsize = 25
                                    };
                                    var code = HelperMethods.GetProductCodeForSocketHeads(metadatavalues, row);
                                    product.partnumber = code;
                                    listProducts.Add(product);
                                    await _service.AddAsync(product);
                                    //cretae mapper

                                    var material = row["MATERIAL"].ToString();
                                    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "MATERIAL".ToLower());
                                    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == material.ToLower());
                                    var productmapper = new productmapperdto()
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        productid = product.id,
                                        productcategoryid = categoryid,
                                        productsubcategoryid = subcategoryId,
                                        productgroupid = "36f5679d-3f43-4d0e-a540-6fd27b17c8be",
                                        productmetadataid = metadataSingle.id,
                                        productmetadatavaluesid = metvalue.id
                                    };
                                    
                                    listProductMapper.Add(productmapper);
                                    await _productMapperService.AddAsync(productmapper);

                                    var threadType = row["THREAD TYPE"].ToString();
                                    metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "THREAD TYPE".ToLower());
                                    metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == threadType.ToLower());
                                    productmapper = new productmapperdto()
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        productid = product.id,
                                        productcategoryid = categoryid,
                                        productsubcategoryid = subcategoryId,
                                        productgroupid = "36f5679d-3f43-4d0e-a540-6fd27b17c8be",
                                        productmetadataid = metadataSingle.id,
                                        productmetadatavaluesid = metvalue.id
                                    };
                                    listProductMapper.Add(productmapper);
                                    await _productMapperService.AddAsync(productmapper);

                                    var threadPitch = row["THREAD PITCH"].ToString();
                                    metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "THREAD PITCH".ToLower());
                                    metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == threadPitch.ToLower());
                                    productmapper = new productmapperdto()
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        productid = product.id,
                                        productcategoryid = categoryid,
                                        productsubcategoryid = subcategoryId,
                                        productgroupid = "36f5679d-3f43-4d0e-a540-6fd27b17c8be",
                                        productmetadataid = metadataSingle.id,
                                        productmetadatavaluesid = metvalue.id
                                    };
                                    listProductMapper.Add(productmapper);
                                    await _productMapperService.AddAsync(productmapper);

                                    var FORM = row["FORM"].ToString();
                                    metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "FORM".ToLower());
                                    metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == FORM.ToLower());
                                    productmapper = new productmapperdto()
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        productid = product.id,
                                        productcategoryid = categoryid,
                                        productsubcategoryid = subcategoryId,
                                        productgroupid = "36f5679d-3f43-4d0e-a540-6fd27b17c8be",
                                        productmetadataid = metadataSingle.id,
                                        productmetadatavaluesid = metvalue.id
                                    };
                                    listProductMapper.Add(productmapper);
                                    await _productMapperService.AddAsync(productmapper);

                                    var driveType = row["DRIVE TYPE"].ToString();
                                    metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "DRIVE TYPE".ToLower());
                                    metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == driveType.ToLower());
                                    productmapper = new productmapperdto()
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        productid = product.id,
                                        productcategoryid = categoryid,
                                        productsubcategoryid = subcategoryId,
                                        productgroupid = "36f5679d-3f43-4d0e-a540-6fd27b17c8be",
                                        productmetadataid = metadataSingle.id,
                                        productmetadatavaluesid = metvalue.id
                                    };
                                    listProductMapper.Add(productmapper);
                                    await _productMapperService.AddAsync(productmapper);

                                    var property = row["PROPERTY CLASS"].ToString();
                                    metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "PROPERTY CLASS".ToLower());
                                    metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == property.ToLower());
                                    productmapper = new productmapperdto()
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        productid = product.id,
                                        productcategoryid = categoryid,
                                        productsubcategoryid = subcategoryId,
                                        productgroupid = "36f5679d-3f43-4d0e-a540-6fd27b17c8be",
                                        productmetadataid = metadataSingle.id,
                                        productmetadatavaluesid = metvalue.id
                                    };
                                    listProductMapper.Add(productmapper);
                                    await _productMapperService.AddAsync(productmapper);

                                    var surfaceFinish = row["SURFACE FINISH"].ToString();
                                    metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "SURFACE FINISH".ToLower());
                                    metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == surfaceFinish.ToLower());
                                    productmapper = new productmapperdto()
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        productid = product.id,
                                        productcategoryid = categoryid,
                                        productsubcategoryid = subcategoryId,
                                        productgroupid = "36f5679d-3f43-4d0e-a540-6fd27b17c8be",
                                        productmetadataid = metadataSingle.id,
                                        productmetadatavaluesid = metvalue.id
                                    };
                                    listProductMapper.Add(productmapper);
                                    await _productMapperService.AddAsync(productmapper);

                                    var SIZE = row["SIZE"].ToString();
                                    metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "SIZE".ToLower());
                                    metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == SIZE.ToLower());
                                    productmapper = new productmapperdto()
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        productid = product.id,
                                        productcategoryid = categoryid,
                                        productsubcategoryid = subcategoryId,
                                        productgroupid = "36f5679d-3f43-4d0e-a540-6fd27b17c8be",
                                        productmetadataid = metadataSingle.id,
                                        productmetadatavaluesid = metvalue.id
                                    };
                                    listProductMapper.Add(productmapper);
                                    await _productMapperService.AddAsync(productmapper);

                                    var length = row["L"].ToString();
                                    metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "Length".ToLower());
                                    metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == length.ToLower());
                                    productmapper = new productmapperdto()
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        productid = product.id,
                                        productcategoryid = categoryid,
                                        productsubcategoryid = subcategoryId,
                                        productgroupid = "36f5679d-3f43-4d0e-a540-6fd27b17c8be",
                                        productmetadataid = metadataSingle.id,
                                        productmetadatavaluesid = metvalue.id
                                    };
                                    listProductMapper.Add(productmapper);
                                    await _productMapperService.AddAsync(productmapper);

                                    var d2 = row["D2"].ToString();
                                    metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "D2".ToLower());
                                    metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == d2.ToLower());
                                    productmapper = new productmapperdto()
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        productid = product.id,
                                        productcategoryid = categoryid,
                                        productsubcategoryid = subcategoryId,
                                        productgroupid = "36f5679d-3f43-4d0e-a540-6fd27b17c8be",
                                        productmetadataid = metadataSingle.id,
                                        productmetadatavaluesid = metvalue.id
                                    };
                                    listProductMapper.Add(productmapper);
                                    await _productMapperService.AddAsync(productmapper);

                                    var K = row["K"].ToString();
                                    metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "K".ToLower());
                                    metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == K.ToLower());
                                    productmapper = new productmapperdto()
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        productid = product.id,
                                        productcategoryid = categoryid,
                                        productsubcategoryid = subcategoryId,
                                        productgroupid = "36f5679d-3f43-4d0e-a540-6fd27b17c8be",
                                        productmetadataid = metadataSingle.id,
                                        productmetadatavaluesid = metvalue.id
                                    };
                                    listProductMapper.Add(productmapper);
                                    await _productMapperService.AddAsync(productmapper);

                                    var S = row["S"].ToString();
                                    metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "S".ToLower());
                                    metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == S.ToLower());
                                    productmapper = new productmapperdto()
                                    {
                                        id = Guid.NewGuid().ToString(),
                                        productid = product.id,
                                        productcategoryid = categoryid,
                                        productsubcategoryid = subcategoryId,
                                        productgroupid = "36f5679d-3f43-4d0e-a540-6fd27b17c8be",
                                        productmetadataid = metadataSingle.id,
                                        productmetadatavaluesid = metvalue.id
                                    };
                                    listProductMapper.Add(productmapper);
                                    await _productMapperService.AddAsync(productmapper);



                                }
                            }
                            catch (Exception ex)
                            {
                                slnos.Add(slNo);
                            }

                        }


                        //foreach (var column in columnHeaders)
                        //{
                        //    var test = row[((System.Data.DataColumn)column).ColumnName];
                        //    if(!string.IsNullOrEmpty(test?.ToString()))
                        //    {
                               
                        //    }
                        //    //var orderId = row.Field<string>(((System.Data.DataColumn)column).ColumnName);
                        //}

                    }
                    if (table.TableName == "PLAIN WASHER")
                    {

                    }
                }
            }

            //using (var reader = ExcelReaderFactory.CreateReader(data))
            //{
            //    do
            //    {
            //        int i = 0;
            //        while (reader.Read())
            //        {
            //            if (i == 0)
            //            {
            //                i++;
            //                headers.Add(reader.GetString(1));
            //                continue;
            //            }

            //            var name = reader.GetString(1);
            //            if (string.IsNullOrEmpty(name))
            //            {
            //                i++;
            //                continue;
            //            }
            //            else
            //            {
            //                if(!productNames.Contains(name))
            //                {
            //                    productNames.Add(name);
            //                }
            //            }
            //            i++;
            //        }
            //    } while (reader.NextResult());
            //}


           

            return true;
        }
    }
}

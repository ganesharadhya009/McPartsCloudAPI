using Mcparts.Business.Dtos;
using Mcparts.Business.Services.IServices.IServiceMappings;
using Mcparts.Business.Services.Services;
using Mcparts.DataAccess.Dtos;
using Mcparts.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Security.Claims;
using System.Xml.Linq;

namespace McPartsAPI.Helpers
{
    
    public class HelperMethods
    {
        public  string categoryidSocketHead = "b1404928-4100-4d11-be64-ab0d897e7953";
        public  string subcategoryIdSocketHead = "4fa08198-358f-4e1c-b64a-38239893ec7f";
        public  string groupIdSocketHead = "36f5679d-3f43-4d0e-a540-6fd27b17c8be";

        public  string categoryWasher = "3691290b-c9ae-43e4-a6ed-f1885d7987c2";
        public  string subcategoryWasherPlain = "29e2d40b-02b4-4d13-ba80-e74c33cb7069";
        public  string subcategoryWasherSpring = "32b58073-f6f9-48da-a604-0e5d8379f161";
        public  string groupIdWasher = "23d0f96c-ed6f-4259-8e50-678f58b1b2af";

        public  string categoryPin = "5995d01b-8a8d-44e9-bb3a-cc520caf6bdb";
        public  string subcategoryPinM6 = "e488be40-3ea9-405f-92af-a64aedd7850a";
        public  string subcategoryPinH6 = "fce7635b-f3ee-415a-b744-8ec7799833fb";
        public  string groupIPin = "f360b031-bb25-4cc6-b9e9-163df1836df6";




        public  string GetProductCodeForSocketHeads(IEnumerable<productmetadatavaluesdto> metadataValues, DataRow row)
        {
            var materialType = row["MATERIAL"].ToString();
            var threadType = row["THREAD TYPE"].ToString();
            var threadPitch = row["THREAD PITCH"].ToString();
            var FORM = row["FORM"].ToString();
            var driveType = row["DRIVE TYPE"].ToString();
            var property = row["PROPERTY CLASS"].ToString();
            var surfaceFinish = row["SURFACE FINISH"].ToString();
            var SIZE = row["SIZE"].ToString();
            var length = row["L"].ToString();
            var d2 = row["D2"].ToString();
            var K = row["K"].ToString();
            var S = row["S"].ToString();

            var code = $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == materialType.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == threadType.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == threadPitch.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == FORM.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == driveType.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == property.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == surfaceFinish.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == SIZE.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == length.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == d2.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == K.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == S.ToLower())?.partnumbercode}";

            return code;
        }

        public  string GetProductCode(IEnumerable<productmetadatavaluesdto> metadataValues, DataRow row, List<string> metadata)
        {
            string code = string.Empty;
            foreach (var met in metadata)
            {
                var metexcelvalue = row[met].ToString();
                code = code + $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == metexcelvalue.ToLower())?.partnumbercode}";
            }
            return code;
        }

        public  string GetProductCodeForPinM6(IEnumerable<productmetadatavaluesdto> metadataValues, DataRow row, List<string> metadata)
        {
            string code = string.Empty;
            foreach(var met  in metadata)
            {
                var metexcelvalue =  row[met].ToString();
                code = code + $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == metexcelvalue.ToLower())?.partnumbercode}";
            }
           // var materialType = row["MATERIAL"].ToString();
           // var threadType = row["THREAD TYPE"].ToString();
           //// var threadPitch = row["THREAD PITCH"].ToString();
           // //var FORM = row["FORM"].ToString();
           // //var driveType = row["DRIVE TYPE"].ToString();
           // //var property = row["PROPERTY CLASS"].ToString();
           // var surfaceFinish = row["SURFACE FINISH"].ToString();
           // var driveType = row["DRIVE TYPE"].ToString();
           // var property = row["PROPERTY CLASS"].ToString();
           // var SIZE = row["SIZE"].ToString();
           // var length = row["L"].ToString();
           // var d2 = row["D2"].ToString();
           // var K = row["K"].ToString();
           // var S = row["S"].ToString();

           // var code = $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == materialType.ToLower())?.partnumbercode}" +
           //     $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == threadType.ToLower())?.partnumbercode}" +
           //     $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == threadPitch.ToLower())?.partnumbercode}" +
           //     $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == FORM.ToLower())?.partnumbercode}" +
           //     $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == driveType.ToLower())?.partnumbercode}" +
           //     $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == property.ToLower())?.partnumbercode}" +
           //     $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == surfaceFinish.ToLower())?.partnumbercode}" +
           //     $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == SIZE.ToLower())?.partnumbercode}" +
           //     $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == length.ToLower())?.partnumbercode}" +
           //     $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == d2.ToLower())?.partnumbercode}" +
           //     $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == K.ToLower())?.partnumbercode}" +
           //     $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == S.ToLower())?.partnumbercode}";

            return code;
        }

        public  string GetProductCodeForPlainWasher(IEnumerable<productmetadatavaluesdto> metadataValues, DataRow row)
        {
            var materialType = row["MATERIAL"].ToString();
            var threadType = row["THREAD TYPE"].ToString();
            var threadPitch = row["THREAD PITCH"].ToString();
            var FORM = row["FORM"].ToString();
            var driveType = row["DRIVE TYPE"].ToString();
            var property = row["PROPERTY CLASS"].ToString();
            var surfaceFinish = row["SURFACE FINISH"].ToString();
            var SIZE = row["SIZE"].ToString();
            //var length = row["L"].ToString();
            var d1 = row["D1"].ToString();
            var d2 = row["D2"].ToString();
            var S = row["S"].ToString();

            var code = $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == materialType.ToLower())?.partnumbercode}" +
               $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == threadType.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == surfaceFinish.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == SIZE.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == d1.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == d2.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == S.ToLower())?.partnumbercode}";

            return code;
        }

        public  string GetProductCodeForSpringWasher(IEnumerable<productmetadatavaluesdto> metadataValues, DataRow row)
        {
            var materialType = row["MATERIAL"].ToString();
            var threadType = row["THREAD TYPE"].ToString();
            var threadPitch = row["THREAD PITCH"].ToString();
            var FORM = row["FORM"].ToString();
            var driveType = row["DRIVE TYPE"].ToString();
            var property = row["PROPERTY CLASS"].ToString();
            var surfaceFinish = row["SURFACE FINISH"].ToString();
            var SIZE = row["SIZE"].ToString();
            //var length = row["L"].ToString();
            var d1Min = row["D1 MIN"].ToString();
            var D1MAX = row["D1 MAX"].ToString();
            var D2MAX = row["D2 MAX"].ToString();
            var S = row["S"].ToString();

            var code = $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == materialType.ToLower())?.partnumbercode}" +
               $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == threadType.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == surfaceFinish.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == SIZE.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == d1Min.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == D1MAX.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == D2MAX.ToLower())?.partnumbercode}" +
                $"{metadataValues.FirstOrDefault(p => p.name.ToLower() == S.ToLower())?.partnumbercode}";

            return code;
        }

        public  Dictionary<string, List<string>> ProcessHeaderAndData(DataTable table, string category, string subcategory, Dictionary<string, List<string>> dictionaryMetadata, string name)
        {
            Dictionary<string, List<string>> dictionaryMetValues = new Dictionary<string, List<string>>();
            var values = dictionaryMetadata[name];
            foreach (var met in values)
            {
                List<string> metValuesList = new List<string>();
                foreach (DataRow row in table.Rows)
                {
                    var metvalues = row[met].ToString();
                    if (!string.IsNullOrEmpty(metvalues))
                    {
                        if (!metValuesList.Contains(metvalues))
                            metValuesList.Add(metvalues);
                    }
                }
                dictionaryMetValues.Add(met, metValuesList);
            }
            return dictionaryMetValues;
        }

        public  async Task SaveMetadataAndValues(List<string> met, 
            IProductMetadataService _productMetadataService, 
            Dictionary<string, List<string>> dataMetadataVValues,
            IProductMetadataValuesService _productMetadataValueService, string category, string subcategory)
        {
            List<productmetadatadto> listproductMetadataDto = new List<productmetadatadto>();
            foreach (var mData in met)
            {
                var productMetadataDtoData = GetProductMetadataDTO(mData, category, subcategory);
                await _productMetadataService.AddAsync(productMetadataDtoData);
                int partnumbercount = 1;
                var KeyData = dataMetadataVValues[mData];
                //foreach (var mValue in dataMetadataVValues)
                //{
                foreach (var vd in KeyData)
                {
                    var metvaluesdto = GetProductMetadatavaluesDTO(vd, partnumbercount.ToString(), productMetadataDtoData.id);
                    await _productMetadataValueService.AddAsync(metvaluesdto);
                    partnumbercount++;
                }
                //}
                listproductMetadataDto.Add(productMetadataDtoData);
            }
        }

        public  productmapperdto GetProductMapperDTO(productsdto product, string categoryid, string subcategoryId, 
            string productGroupId, string metadataId, string metadataValueId,
            string metadataName, string metadatavalueName)
        {
            return new productmapperdto()
            {
                id = Guid.NewGuid().ToString(),
                productid = product.id,
                productcategoryid = categoryid,
                productsubcategoryid = subcategoryId,
                productgroupid = productGroupId,
                productmetadataid = metadataId,
                productmetadatavaluesid = metadataValueId,
                productmetadataname = metadataName,
                productmetadatavaluesname = metadatavalueName
               
            };
        }

        public  productsdto GetProductsDTO(string productName)
        {
            return new productsdto()
            {
                id = Guid.NewGuid().ToString(),
                name = productName,
                unitmeasureid = "88184107-81be-452b-a28f-086426d6f225",
                lotsize = 25
            };
        }

        public  productmetadatadto GetProductMetadataDTO(string name, string category, string subcat)
        {
            return new productmetadatadto()
            {
                id = Guid.NewGuid().ToString(),
                name = name,
                description = name,
                controltype = "List",
                issearchable = true,
                ismultiselect = true,
                isiconsupported = true,
                productcategoryid = category,
                productsubcategoryid = subcat
            };
        }

        public  productmetadatavaluesdto GetProductMetadatavaluesDTO(string name, string partnumber, string metadataid)
        {
            return new productmetadatavaluesdto()
            {
                id = Guid.NewGuid().ToString(),
                name = name,
                description = name,
                partnumbercode = partnumber,
                productmetdataid = metadataid
            };
        }

        //public  async Task ProcessSpringWasher(DataRow row,
        //  IEnumerable<productmetadatadto> metadata,
        //  IEnumerable<productmetadatavaluesdto> metadataValues,
        //  IProductsService _service,
        //  IProductMapperService _productMapperService)
        //{
        //    var name = row["NAME"].ToString();
        //    var productsdto = GetProductsDTO(name);
        //    var code = GetProductCodeForSpringWasher(metadataValues, row);
        //    productsdto.partnumber = code;
        //    await _service.AddAsync(productsdto);


        //    var data = ProcessDataRowMetadataValues("MATERIAL", row, metadata, metadataValues, categoryWasher, subcategoryWasherSpring);
        //    var productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdWasher, data.MetadataId, data.MetadataValueId, data.MetadataIdName, data.MetadataValueName);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("THREAD TYPE", row, metadata, metadataValues, categoryWasher, subcategoryWasherSpring);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    //data = ProcessThreadPitch(row, metadata, metadataValues);
        //    //productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdPlainWasher, data.MetadataId, data.MetadataIdValue);
        //    //await _productMapperService.AddAsync(productMapperDto);

        //    //data = ProcessForm(row, metadata, metadataValues);
        //    //productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdPlainWasher, data.MetadataId, data.MetadataIdValue);
        //    //await _productMapperService.AddAsync(productMapperDto);

        //    //data = ProcessDriveType(row, metadata, metadataValues);
        //    //productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdPlainWasher, data.MetadataId, data.MetadataIdValue);
        //    //await _productMapperService.AddAsync(productMapperDto);

        //    //data = ProcessPropertyClass(row, metadata, metadataValues);
        //    //productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdPlainWasher, data.MetadataId, data.MetadataIdValue);
        //    //await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("SURFACE FINISH", row, metadata, metadataValues, categoryWasher, subcategoryWasherSpring);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("SIZE", row, metadata, metadataValues, categoryWasher, subcategoryWasherSpring);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("D1 MIN", row, metadata, metadataValues, categoryWasher, subcategoryWasherSpring);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("D1 MAX", row, metadata, metadataValues, categoryWasher, subcategoryWasherSpring);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("D2 MAX", row, metadata, metadataValues, categoryWasher, subcategoryWasherSpring);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    //data = ProcessK(row, metadata, metadataValues);
        //    //productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdPlainWasher, data.MetadataId, data.MetadataIdValue);
        //    //await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("S", row, metadata, metadataValues, categoryWasher, subcategoryWasherSpring);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //}

        //public  async Task ProcessPlainWasher(DataRow row,
        //   IEnumerable<productmetadatadto> metadata,
        //   IEnumerable<productmetadatavaluesdto> metadataValues,
        //   IProductsService _service,
        //   IProductMapperService _productMapperService)
        //{
        //    var name = row["NAME"].ToString();
        //    var productsdto = GetProductsDTO(name);
        //    var code = GetProductCodeForPlainWasher(metadataValues, row);
        //    productsdto.partnumber = code;
        //    await _service.AddAsync(productsdto);


        //    var data = ProcessDataRowMetadataValues("MATERIAL", row, metadata, metadataValues, categoryWasher, subcategoryWasherPlain);
        //    var productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherPlain, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("THREAD TYPE", row, metadata, metadataValues, categoryWasher, subcategoryWasherPlain);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherPlain, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    //data = ProcessThreadPitch(row, metadata, metadataValues);
        //    //productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherPlain, groupIdPlainWasher, data.MetadataId, data.MetadataIdValue);
        //    //await _productMapperService.AddAsync(productMapperDto);

        //    //data = ProcessForm(row, metadata, metadataValues);
        //    //productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherPlain, groupIdPlainWasher, data.MetadataId, data.MetadataIdValue);
        //    //await _productMapperService.AddAsync(productMapperDto);

        //    //data = ProcessDriveType(row, metadata, metadataValues);
        //    //productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherPlain, groupIdPlainWasher, data.MetadataId, data.MetadataIdValue);
        //    //await _productMapperService.AddAsync(productMapperDto);

        //    //data = ProcessPropertyClass(row, metadata, metadataValues);
        //    //productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherPlain, groupIdPlainWasher, data.MetadataId, data.MetadataIdValue);
        //    //await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("SURFACE FINISH", row, metadata, metadataValues, categoryWasher, subcategoryWasherPlain);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherPlain, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("SIZE", row, metadata, metadataValues, categoryWasher, subcategoryWasherPlain);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherPlain, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("D1", row, metadata, metadataValues, categoryWasher, subcategoryWasherPlain);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherPlain, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("D2", row, metadata, metadataValues, categoryWasher, subcategoryWasherPlain);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherPlain, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    //data = ProcessK(row, metadata, metadataValues);
        //    //productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherPlain, groupIdPlainWasher, data.MetadataId, data.MetadataIdValue);
        //    //await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("S", row, metadata, metadataValues, categoryWasher, subcategoryWasherPlain);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherPlain, groupIdWasher, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //}

        public  async Task<List<string>> ProcessSOCKETHEADMainFunction(DataTable table, IEnumerable<productmetadatadto> metadata,
            IEnumerable<productmetadatavaluesdto> metadataValues,
            IProductsService _service,
            IProductMapperService _productMapperService,
            List<string> listMetadata)
        {
            var list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                var slNo = row["SL NO"].ToString();
                try
                {
                    //create products
                    if (row["NAME"] != null && row["NAME"].ToString() != "")
                    {
                        //await ProcessSOCKETHEAD(row, metadata, metadataValues, _service, _productMapperService);
                        var name = row["NAME"].ToString();
                        var productsdto = GetProductsDTO(name);
                        var code = GetProductCode(metadataValues, row, listMetadata);
                        productsdto.partnumber = code;
                        productsdto.productcategoryid = categoryidSocketHead;
                        productsdto.productsubcategoryid = subcategoryIdSocketHead;
                        await _service.AddAsync(productsdto);
                        

                        foreach (var met in listMetadata)
                        {
                            var data = ProcessDataRowMetadataValues(met, row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
                            var productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead,groupIdSocketHead, 
                                data.MetadataId, data.MetadataValueId, data.MetadataIdName, data.MetadataValueName);
                            await _productMapperService.AddAsync(productMapperDto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    list.Add(slNo);
                }

            }
            return list;
        }

        public  async Task<List<string>> ProcessDowelPinM6DMainFunction(DataTable table, IEnumerable<productmetadatadto> metadata,
           IEnumerable<productmetadatavaluesdto> metadataValues,
           IProductsService _service,
           IProductMapperService _productMapperService,
           List<string> listMetadata
            )
        {
            var list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                var slNo = row["SL NO"].ToString();
                try
                {
                    //create products
                    if (row["NAME"] != null && row["NAME"].ToString() != "")
                    {
                        var name = row["NAME"].ToString();
                        var productsdto = GetProductsDTO(name);
                        var code = GetProductCode(metadataValues, row, listMetadata);
                        productsdto.partnumber = code;
                        productsdto.productcategoryid = categoryPin;
                        productsdto.productsubcategoryid = subcategoryPinM6;
                        await _service.AddAsync(productsdto);
                        

                        foreach(var met in listMetadata)
                        {
                            var data = ProcessDataRowMetadataValues(met, row, metadata, metadataValues, categoryPin, subcategoryPinM6);
                            var productMapperDto = GetProductMapperDTO(productsdto, categoryPin, subcategoryPinM6, groupIPin, data.MetadataId, data.MetadataValueId, data.MetadataIdName, data.MetadataValueName);
                            await _productMapperService.AddAsync(productMapperDto);
                        }

                    }
                }
                catch (Exception ex)
                {
                    list.Add(slNo);
                }

            }
            return list;
        }

        public  async Task<List<string>> ProcessDowelPinH6DMainFunction(DataTable table, IEnumerable<productmetadatadto> metadata,
         IEnumerable<productmetadatavaluesdto> metadataValues,
         IProductsService _service,
         IProductMapperService _productMapperService,
         List<string> listMetadata
          )
        {
            var list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                var slNo = row["SL NO"].ToString();
                try
                {
                    //create products
                    if (row["NAME"] != null && row["NAME"].ToString() != "")
                    {
                        var name = row["NAME"].ToString();
                        var productsdto = GetProductsDTO(name);
                        var code = GetProductCode(metadataValues, row, listMetadata);
                        productsdto.partnumber = code;
                        productsdto.productcategoryid = categoryPin;
                        productsdto.productsubcategoryid = subcategoryPinH6;
                        await _service.AddAsync(productsdto);


                        foreach (var met in listMetadata)
                        {
                            var data = ProcessDataRowMetadataValues(met, row, metadata, metadataValues, categoryPin, subcategoryPinH6);
                            var productMapperDto = GetProductMapperDTO(productsdto, categoryPin, subcategoryPinH6, groupIPin, data.MetadataId, data.MetadataValueId, data.MetadataIdName, data.MetadataValueName);
                            await _productMapperService.AddAsync(productMapperDto);
                        }

                    }
                }
                catch (Exception ex)
                {
                    list.Add(slNo);
                }

            }
            return list;
        }

        public  async Task<List<string>> ProcessPlainWasherMainFunction(DataTable table, IEnumerable<productmetadatadto> metadata,
           IEnumerable<productmetadatavaluesdto> metadataValues,
           IProductsService _service,
           IProductMapperService _productMapperService,
            List<string> listMetadata)
        {
            var list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                var slNo = row["SL NO"].ToString();
                try
                {
                    if (row["NAME"] != null && row["NAME"].ToString() != "")
                    {
                        var name = row["NAME"].ToString();
                        var productsdto = GetProductsDTO(name);
                        var code = GetProductCode(metadataValues, row, listMetadata);
                        productsdto.partnumber = code;
                        productsdto.productcategoryid = categoryWasher;
                        productsdto.productsubcategoryid = subcategoryWasherPlain;
                        await _service.AddAsync(productsdto);
                        

                        foreach (var met in listMetadata)
                        {
                            var data = ProcessDataRowMetadataValues(met, row, metadata, metadataValues, categoryWasher, subcategoryWasherPlain);
                            var productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherPlain, groupIdWasher, data.MetadataId, data.MetadataValueId, data.MetadataIdName, data.MetadataValueName);
                            await _productMapperService.AddAsync(productMapperDto);
                        }

                    }
                }
                catch (Exception ex)
                {
                    list.Add(slNo);
                }

            }
            return list;
        }

        public  async Task<List<string>> ProcessSpringWasherMainFunction(DataTable table, IEnumerable<productmetadatadto> metadata,
          IEnumerable<productmetadatavaluesdto> metadataValues,
          IProductsService _service,
          IProductMapperService _productMapperService,
           List<string> listMetadata)
        {
            var list = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                var slNo = row["SL NO"].ToString();
                try
                {
                    //create products
                    if (row["NAME"] != null && row["NAME"].ToString() != "")
                    {
                        var name = row["NAME"].ToString();
                        var productsdto = GetProductsDTO(name);
                        var code = GetProductCode(metadataValues, row, listMetadata);
                        productsdto.partnumber = code;
                        productsdto.productcategoryid = categoryWasher;
                        productsdto.productsubcategoryid = subcategoryWasherSpring;
                        await _service.AddAsync(productsdto);
                        

                        foreach (var met in listMetadata)
                        {
                            var data = ProcessDataRowMetadataValues(met, row, metadata, metadataValues, categoryWasher, subcategoryWasherSpring);
                            var productMapperDto = GetProductMapperDTO(productsdto, categoryWasher, subcategoryWasherSpring, groupIdWasher, data.MetadataId, data.MetadataValueId, data.MetadataIdName, data.MetadataValueName);
                            await _productMapperService.AddAsync(productMapperDto);
                        }

                    }
                    //await ProcessSpringWasher(row, metadata, metadataValues, _service, _productMapperService);
                }
                catch (Exception ex)
                {
                    list.Add(slNo);
                }

            }
            return list;
        }

        //public  async Task ProcessSOCKETHEAD(DataRow row , 
        //    IEnumerable<productmetadatadto> metadata, 
        //    IEnumerable<productmetadatavaluesdto> metadataValues,
        //    IProductsService _service,
        //    IProductMapperService _productMapperService)
        //{
        //    var name = row["NAME"].ToString();
        //    var productsdto = GetProductsDTO(name);
        //    var code = GetProductCodeForSocketHeads(metadataValues, row);
        //    await _service.AddAsync(productsdto);
        //    productsdto.partnumber = code;

        //    var data = ProcessDataRowMetadataValues("MATERIAL", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    var productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("THREAD TYPE", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("THREAD PITCH", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("FORM", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("DRIVE TYPE", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("PROPERTY CLASS", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("SURFACE FINISH", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("SIZE", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("L", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("D2", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("K", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("S", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //}

        //public  async Task ProcessM6(DataRow row,
        //    IEnumerable<productmetadatadto> metadata,
        //    IEnumerable<productmetadatavaluesdto> metadataValues,
        //    IProductsService _service,
        //    IProductMapperService _productMapperService)
        //{
        //    var name = row["NAME"].ToString();
        //    var productsdto = GetProductsDTO(name);
        //    var code = GetProductCodeForSocketHeads(metadataValues, row);
        //    await _service.AddAsync(productsdto);
        //    productsdto.partnumber = code;

        //    var data = ProcessDataRowMetadataValues("MATERIAL", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    var productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIPin, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("THREAD TYPE", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIPin, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("THREAD PITCH", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIPin, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("FORM", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIPin, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("DRIVE TYPE", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIPin, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("PROPERTY CLASS", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIPin, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("SURFACE FINISH", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIPin, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("SIZE", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIPin, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("L", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIPin, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("D2", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIPin, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("K", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIPin, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //    data = ProcessDataRowMetadataValues("S", row, metadata, metadataValues, categoryidSocketHead, subcategoryIdSocketHead);
        //    productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIPin, data.MetadataId, data.MetadataIdValue);
        //    await _productMapperService.AddAsync(productMapperDto);

        //}

        //public  MetadataAndValue ProcessMaterial(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var material = row["MATERIAL"].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "MATERIAL".ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == material.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        //public  MetadataAndValue ProcessThreadType(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var threadType = row["THREAD TYPE"].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "THREAD TYPE".ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == threadType.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        //public  MetadataAndValue ProcessThreadPitch(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var threadPitch = row["THREAD PITCH"].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "THREAD PITCH".ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == threadPitch.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        //public  MetadataAndValue ProcessForm(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var FORM = row["FORM"].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "FORM".ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == FORM.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        //public  MetadataAndValue ProcessDriveType(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var driveType = row["DRIVE TYPE"].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "DRIVE TYPE".ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == driveType.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        //public  MetadataAndValue ProcessPropertyClass(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var property = row["PROPERTY CLASS"].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "PROPERTY CLASS".ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == property.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        //public  MetadataAndValue ProcessSurfaceFinish(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var surfaceFinish = row["SURFACE FINISH"].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "SURFACE FINISH".ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == surfaceFinish.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        //public  MetadataAndValue ProcessSize(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var SIZE = row["SIZE"].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "SIZE".ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == SIZE.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        //public  MetadataAndValue ProcessLength(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var length = row["L"].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "Length".ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == length.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        //public  MetadataAndValue ProcessD2(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var d2 = row["D2"].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "D2".ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == d2.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        //public  MetadataAndValue ProcessD1(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var d1 = row["D1"].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "D1".ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == d1.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        //public  MetadataAndValue ProcessK(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var K = row["K"].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "K".ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == K.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        //public  MetadataAndValue ProcessS(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var S = row["S"].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "S".ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == S.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        //public  MetadataAndValue ProcessD1Min(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        //{
        //    var key = "D1 MIN";
        //    var keyData = row[key].ToString();
        //    var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == key.ToLower());
        //    var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == keyData.ToLower());

        //    return new MetadataAndValue()
        //    {
        //        MetadataId = metadataSingle.id,
        //        MetadataIdValue = metvalue.id
        //    };
        //}

        public  MetadataAndValue ProcessDataRowMetadataValues(string key, DataRow row, 
            IEnumerable<productmetadatadto> metadata, 
            IEnumerable<productmetadatavaluesdto> metadatavalues,
            string category,
            string subcategory)
        {
            var keyData = row[key].ToString();
            var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == key.ToLower() && p.productcategoryid == category && p.productsubcategoryid == subcategory);
            var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == keyData.ToLower());

            return new MetadataAndValue()
            {
                MetadataId = metadataSingle.id,
                MetadataIdName = metadataSingle.name,
                MetadataValueId = metvalue.id,
                MetadataValueName = metvalue.name
            };
        }
    }
}

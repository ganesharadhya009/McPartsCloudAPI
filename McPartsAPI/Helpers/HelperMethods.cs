using Mcparts.Business.Dtos;
using Mcparts.DataAccess.Dtos;
using Mcparts.DataAccess.Models;
using System.Data;
using System.Xml.Linq;

namespace McPartsAPI.Helpers
{
    
    public class HelperMethods
    {
        public static string categoryidSocketHead = "b1404928-4100-4d11-be64-ab0d897e7953";
        public static string subcategoryIdSocketHead = "4fa08198-358f-4e1c-b64a-38239893ec7f";
        public static string groupIdSocketHead = "36f5679d-3f43-4d0e-a540-6fd27b17c8be";

        public static string GetProductCodeForSocketHeads(IEnumerable<productmetadatavaluesdto> metadataValues, DataRow row)
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

        public static productmapperdto GetProductMapperDTO(productsdto product, string categoryid, string subcategoryId, string productGroupId, string metadataId, string metadataValueId)
        {
            return new productmapperdto()
            {
                id = Guid.NewGuid().ToString(),
                productid = product.id,
                productcategoryid = categoryid,
                productsubcategoryid = subcategoryId,
                productgroupid = productGroupId,
                productmetadataid = metadataId,
                productmetadatavaluesid = metadataValueId
            };
        }

        public static productsdto GetProductsDTO(string productName)
        {
            return new productsdto()
            {
                id = Guid.NewGuid().ToString(),
                name = productName,
                unitmeasureid = "88184107-81be-452b-a28f-086426d6f225",
                lotsize = 25
            };
        }

        public static void ProcessSOCKETHEAD(DataRow row , IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadataValues)
        {
            var name = row["NAME"].ToString();
            var productsdto = GetProductsDTO(name);
            var code = HelperMethods.GetProductCodeForSocketHeads(metadataValues, row);
            productsdto.partnumber = code;

            var data = ProcessMaterial(row, metadata, metadataValues);
            var productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);

            data = ProcessThreadType(row, metadata, metadataValues);
            productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);

            data = ProcessThreadPitch(row, metadata, metadataValues);
            productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);

            data = ProcessForm(row, metadata, metadataValues);
            productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);

            data = ProcessDriveType(row, metadata, metadataValues);
            productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);

            data = ProcessPropertyClass(row, metadata, metadataValues);
            productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);

            data = ProcessSurfaceFinish(row, metadata, metadataValues);
            productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);

            data = ProcessSize(row, metadata, metadataValues);
            productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);

            data = ProcessLength(row, metadata, metadataValues);
            productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);

            data = ProcessD2(row, metadata, metadataValues);
            productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);

            data = ProcessK(row, metadata, metadataValues);
            productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);

            data = ProcessS(row, metadata, metadataValues);
            productMapperDto = GetProductMapperDTO(productsdto, categoryidSocketHead, subcategoryIdSocketHead, groupIdSocketHead, data.MetadataId, data.MetadataIdValue);

        }

        public static MetadataAndValue ProcessMaterial(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        {
            var material = row["MATERIAL"].ToString();
            var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "MATERIAL".ToLower());
            var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == material.ToLower());

            return new MetadataAndValue()
            {
                MetadataId = metadataSingle.id,
                MetadataIdValue = metvalue.id
            };
        }

        public static MetadataAndValue ProcessThreadType(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        {
            var threadType = row["THREAD TYPE"].ToString();
            var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "THREAD TYPE".ToLower());
            var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == threadType.ToLower());

            return new MetadataAndValue()
            {
                MetadataId = metadataSingle.id,
                MetadataIdValue = metvalue.id
            };
        }

        public static MetadataAndValue ProcessThreadPitch(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        {
            var threadPitch = row["THREAD PITCH"].ToString();
            var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "THREAD PITCH".ToLower());
            var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == threadPitch.ToLower());

            return new MetadataAndValue()
            {
                MetadataId = metadataSingle.id,
                MetadataIdValue = metvalue.id
            };
        }

        public static MetadataAndValue ProcessForm(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        {
            var FORM = row["FORM"].ToString();
            var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "FORM".ToLower());
            var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == FORM.ToLower());

            return new MetadataAndValue()
            {
                MetadataId = metadataSingle.id,
                MetadataIdValue = metvalue.id
            };
        }

        public static MetadataAndValue ProcessDriveType(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        {
            var driveType = row["DRIVE TYPE"].ToString();
            var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "DRIVE TYPE".ToLower());
            var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == driveType.ToLower());

            return new MetadataAndValue()
            {
                MetadataId = metadataSingle.id,
                MetadataIdValue = metvalue.id
            };
        }

        public static MetadataAndValue ProcessPropertyClass(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        {
            var property = row["PROPERTY CLASS"].ToString();
            var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "PROPERTY CLASS".ToLower());
            var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == property.ToLower());

            return new MetadataAndValue()
            {
                MetadataId = metadataSingle.id,
                MetadataIdValue = metvalue.id
            };
        }

        public static MetadataAndValue ProcessSurfaceFinish(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        {
            var surfaceFinish = row["SURFACE FINISH"].ToString();
            var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "SURFACE FINISH".ToLower());
            var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == surfaceFinish.ToLower());

            return new MetadataAndValue()
            {
                MetadataId = metadataSingle.id,
                MetadataIdValue = metvalue.id
            };
        }

        public static MetadataAndValue ProcessSize(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        {
            var SIZE = row["SIZE"].ToString();
            var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "SIZE".ToLower());
            var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == SIZE.ToLower());

            return new MetadataAndValue()
            {
                MetadataId = metadataSingle.id,
                MetadataIdValue = metvalue.id
            };
        }

        public static MetadataAndValue ProcessLength(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        {
            var length = row["L"].ToString();
            var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "Length".ToLower());
            var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == length.ToLower());

            return new MetadataAndValue()
            {
                MetadataId = metadataSingle.id,
                MetadataIdValue = metvalue.id
            };
        }

        public static MetadataAndValue ProcessD2(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        {
            var d2 = row["D2"].ToString();
            var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "D2".ToLower());
            var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == d2.ToLower());

            return new MetadataAndValue()
            {
                MetadataId = metadataSingle.id,
                MetadataIdValue = metvalue.id
            };
        }

        public static MetadataAndValue ProcessK(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        {
            var K = row["K"].ToString();
            var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "K".ToLower());
            var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == K.ToLower());

            return new MetadataAndValue()
            {
                MetadataId = metadataSingle.id,
                MetadataIdValue = metvalue.id
            };
        }

        public static MetadataAndValue ProcessS(DataRow row, IEnumerable<productmetadatadto> metadata, IEnumerable<productmetadatavaluesdto> metadatavalues)
        {
            var S = row["S"].ToString();
            var metadataSingle = metadata.FirstOrDefault(p => p.name.ToLower() == "S".ToLower());
            var metvalue = metadatavalues.FirstOrDefault(p => p.name.ToLower() == S.ToLower());

            return new MetadataAndValue()
            {
                MetadataId = metadataSingle.id,
                MetadataIdValue = metvalue.id
            };
        }
    }
}

using AutoMapper;
using Mcparts.Business.Dtos;
using Mcparts.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mcparts.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<productgroup, productgroupdto>().ReverseMap();
            CreateMap<productgroup, productgroupdto>();
            CreateMap<productgroupdto, productgroupdtoGet>().ReverseMap();
            CreateMap<productgroupdto, productgroupdtoGet>();

            CreateMap<productcategory, productcategorydto>().ReverseMap();
            CreateMap<productcategory, productcategorydto>();
            CreateMap<productcategorydto, productcategorydtoGet>().ReverseMap();
            CreateMap<productcategorydto, productcategorydtoGet>();

            CreateMap<productmetadata, productmetadatadto>().ReverseMap();
            CreateMap<productmetadata, productmetadatadto>();
            CreateMap<productmetadatadto, productmetadatadtoGet>().ReverseMap();
            CreateMap<productmetadatadto, productcategorydtoGet>();

            CreateMap<productmetadatavalues, productmetadatavaluesdto>().ReverseMap();
            CreateMap<productmetadatavalues, productmetadatavaluesdto>();
            CreateMap<productmetadatavaluesdto, productmetadatavaluesdtoGet>().ReverseMap();
            CreateMap<productmetadatavaluesdto, productmetadatavaluesdtoGet>();

            CreateMap<productsubcategory, productsubcategorydto>().ReverseMap();
            CreateMap<productsubcategory, productsubcategorydto>();
            CreateMap<productsubcategorydto, productsubcategorydtoGet>().ReverseMap();
            CreateMap<productsubcategorydto, productsubcategorydtoGet>();

            CreateMap<productsubcategorysubset, productsubcategorysubsetdto>().ReverseMap();
            CreateMap<productsubcategorysubset, productsubcategorysubsetdto>();
            CreateMap<productsubcategorysubsetdto, productsubcategorysubsetdtoGet>().ReverseMap();
            CreateMap<productsubcategorysubsetdto, productsubcategorysubsetdtoGet>();

            CreateMap<products, productsdto>().ReverseMap();
            CreateMap<products, productsdto>();
            CreateMap<productsdto, productsdtoGet>().ReverseMap();
            CreateMap<productsdto, productsdtoGet>();

            CreateMap<productmapper, productmapperdto>().ReverseMap();
            CreateMap<productmapper, productmapperdto>();
            CreateMap<productmapperdto, productmapperdtoGet>().ReverseMap();
            CreateMap<productmapperdto, productmapperdtoGet>();

            CreateMap<customer, customerdto>().ReverseMap();
            CreateMap<customer, customerdto>();
            CreateMap<customerdto, customerdtoGet>().ReverseMap();
            CreateMap<customerdto, customerdtoGet>();

            CreateMap<users, usersdto>().ReverseMap();
            CreateMap<users, usersdto>();
            CreateMap<usersdto, usersdtoGet>().ReverseMap();
            CreateMap<usersdto, usersdtoGet>();



        }
    }
}

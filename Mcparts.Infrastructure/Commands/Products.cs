using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.DataAccess.Commands
{
    public class Products
    {
        public static string GetAll = "select id,partnumber,name,description,additionaldescription,note from itemsviewall where isdeleted=@isdeleted";
        public static string GetById = "SELECT id, name, description FROM public.itemcategory where id=@id and isdeleted=@isdeleted";
        public static string Insert = "INSERT INTO itemcategory(id, name, description)VALUES(@id, @name, @description)";
        public static string Update = "UPDATE itemcategory set name=@name, description=@description where id=@id";
        public static string Delete = "UPDATE itemcategory set isdeleted=@isdeleted where id=@id";

        public static string GetSearchFilters = "select id,controltype, issearchable, ismultiselect, isiconsupported, category, categoryname from searchfilters";
        public static string GetSearcFilterData = "select id,name,tablename,iconpathsearch from searchheadervalues";
        public static string Search = "SELECT id,partnumber,name,description,additionaldescription,note FROM productsviewall";
    }
}

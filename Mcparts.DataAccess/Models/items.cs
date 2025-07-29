using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class items
{
    public string id { get; set; } = null!;

    public string? partnumber { get; set; }

    public string? name { get; set; }

    public string? description { get; set; }

    public bool? isdeleted { get; set; }

    public string? createdby { get; set; }

    public DateTime? createddate { get; set; }

    public string? updatedby { get; set; }

    public DateTime? updateddate { get; set; }

    public string? additionaldescription { get; set; }

    public string? note { get; set; }

    public string? itemcategoryid { get; set; }

    public string? itemsubcategoryid { get; set; }

    public string? itemgrouptypeid { get; set; }

    public string? itemsubgrouptypeid { get; set; }

    public string? itemtypeid { get; set; }

    public string? itemdrivetypeid { get; set; }

    public string? itemdimensiontypeid { get; set; }

    public string? itemheadformtypeid { get; set; }

    public string? itemmaterialtypeid { get; set; }

    public string? itempropertyclasstypeid { get; set; }

    public string? itemsurfacefinishtypeid { get; set; }

    public string? itemthreadtypeid { get; set; }

    public virtual itemcategory? itemcategory { get; set; }

    public virtual itemdimensiontype? itemdimensiontype { get; set; }

    public virtual itemdrivetype? itemdrivetype { get; set; }

    public virtual itemgrouptype? itemgrouptype { get; set; }

    public virtual itemheadformtype? itemheadformtype { get; set; }

    public virtual itemmaterialtype? itemmaterialtype { get; set; }

    public virtual ICollection<itemmetadata> itemmetadata { get; set; } = new List<itemmetadata>();

    public virtual itempropertyclasstype? itempropertyclasstype { get; set; }

    public virtual itemsubcategory? itemsubcategory { get; set; }

    public virtual itemsubgrouptype? itemsubgrouptype { get; set; }

    public virtual itemsurfacefinishtype? itemsurfacefinishtype { get; set; }

    public virtual itemthreadtype? itemthreadtype { get; set; }

    public virtual itemtype? itemtype { get; set; }
}

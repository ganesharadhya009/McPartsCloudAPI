using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text.Json;

namespace Mcparts.DataAccess.Models;

public partial class McpartsDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public McpartsDbContext(DbContextOptions<McpartsDbContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public virtual DbSet<auditlog> auditlog { get; set; }

    public virtual DbSet<company> company { get; set; }

    public virtual DbSet<customer> customer { get; set; }

    public virtual DbSet<customercategory> customercategory { get; set; }

    public virtual DbSet<customercontact> customercontact { get; set; }

    public virtual DbSet<customergroup> customergroup { get; set; }

    public virtual DbSet<deliveryorder> deliveryorder { get; set; }

    public virtual DbSet<filedocument> filedocument { get; set; }

    public virtual DbSet<fileimage> fileimage { get; set; }

    public virtual DbSet<gainers> gainers { get; set; }

    public virtual DbSet<getproductcategorydataallwithcount> getproductcategorydataallwithcount { get; set; }

    public virtual DbSet<getproductmetadatavalueall> getproductmetadatavalueall { get; set; }

    public virtual DbSet<getproductmetadatavaluebycategory> getproductmetadatavaluebycategory { get; set; }

    public virtual DbSet<getproductmetadatavaluebycategorysubcategory> getproductmetadatavaluebycategorysubcategory { get; set; }

    public virtual DbSet<getproductmetadatavaluebycategorysubcategorysubset> getproductmetadatavaluebycategorysubcategorysubset { get; set; }

    public virtual DbSet<goodsreceive> goodsreceive { get; set; }

    public virtual DbSet<inventorytransaction> inventorytransaction { get; set; }

    public virtual DbSet<itemcategory> itemcategory { get; set; }

    public virtual DbSet<itemdimensiontype> itemdimensiontype { get; set; }

    public virtual DbSet<itemdrivetype> itemdrivetype { get; set; }

    public virtual DbSet<itemgrouptype> itemgrouptype { get; set; }

    public virtual DbSet<itemheadformtype> itemheadformtype { get; set; }

    public virtual DbSet<itemmaterialtype> itemmaterialtype { get; set; }

    public virtual DbSet<itemmetadata> itemmetadata { get; set; }

    public virtual DbSet<itempropertyclasstype> itempropertyclasstype { get; set; }

    public virtual DbSet<items> items { get; set; }

    public virtual DbSet<itemsubcategory> itemsubcategory { get; set; }

    public virtual DbSet<itemsubgrouptype> itemsubgrouptype { get; set; }

    public virtual DbSet<itemsurfacefinishtype> itemsurfacefinishtype { get; set; }

    public virtual DbSet<itemthreadtype> itemthreadtype { get; set; }

    public virtual DbSet<itemtype> itemtype { get; set; }

    public virtual DbSet<loosers> loosers { get; set; }

    public virtual DbSet<negativeadjustment> negativeadjustment { get; set; }

    public virtual DbSet<numbersequence> numbersequence { get; set; }

    public virtual DbSet<positiveadjustment> positiveadjustment { get; set; }

    public virtual DbSet<productcategory> productcategory { get; set; }

    public virtual DbSet<productgroup> productgroup { get; set; }

    public virtual DbSet<productmapper> productmapper { get; set; }

    public virtual DbSet<productmetadata> productmetadata { get; set; }

    public virtual DbSet<productmetadatavalues> productmetadatavalues { get; set; }

    public virtual DbSet<products> products { get; set; }

    public virtual DbSet<productsubcategory> productsubcategory { get; set; }

    public virtual DbSet<productsubcategorysubset> productsubcategorysubset { get; set; }

    public virtual DbSet<purchaseorder> purchaseorder { get; set; }

    public virtual DbSet<purchaseorderitem> purchaseorderitem { get; set; }

    public virtual DbSet<purchasereturn> purchasereturn { get; set; }

    public virtual DbSet<roles> roles { get; set; }

    public virtual DbSet<salesorder> salesorder { get; set; }

    public virtual DbSet<salesorderitem> salesorderitem { get; set; }

    public virtual DbSet<salesreturn> salesreturn { get; set; }

    public virtual DbSet<scrapping> scrapping { get; set; }

    public virtual DbSet<stockcount> stockcount { get; set; }

    public virtual DbSet<tax> tax { get; set; }

    public virtual DbSet<todo> todo { get; set; }

    public virtual DbSet<todoitem> todoitem { get; set; }

    public virtual DbSet<transferin> transferin { get; set; }

    public virtual DbSet<transferout> transferout { get; set; }

    public virtual DbSet<unitmeasure> unitmeasure { get; set; }

    public virtual DbSet<users> users { get; set; }

    public virtual DbSet<userstatus> userstatus { get; set; }

    public virtual DbSet<usertype> usertype { get; set; }

    public virtual DbSet<vendor> vendor { get; set; }

    public virtual DbSet<vendorcategory> vendorcategory { get; set; }

    public virtual DbSet<vendorcontact> vendorcontact { get; set; }

    public virtual DbSet<vendorgroup> vendorgroup { get; set; }

    public virtual DbSet<warehouse> warehouse { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<auditlog>(entity =>
        {
            entity.HasKey(e => e.id).HasName("auditlog_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.action).HasColumnType("character varying");
            entity.Property(e => e.changes).HasColumnType("character varying");
            entity.Property(e => e.tablename).HasColumnType("character varying");
            entity.Property(e => e.userid).HasColumnType("character varying");
        });

        modelBuilder.Entity<company>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pk_company");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.city).HasMaxLength(255);
            entity.Property(e => e.country).HasMaxLength(255);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.currency).HasMaxLength(50);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.emailaddress).HasMaxLength(255);
            entity.Property(e => e.faxnumber).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.phonenumber).HasMaxLength(255);
            entity.Property(e => e.state).HasMaxLength(255);
            entity.Property(e => e.street).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
            entity.Property(e => e.website).HasMaxLength(255);
            entity.Property(e => e.zipcode).HasMaxLength(50);
        });

        modelBuilder.Entity<customer>(entity =>
        {
            entity.HasKey(e => e.id).HasName("customer_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.city).HasMaxLength(255);
            entity.Property(e => e.country).HasMaxLength(255);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.customercategoryid).HasMaxLength(50);
            entity.Property(e => e.customergroupid).HasMaxLength(50);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.emailaddress).HasMaxLength(255);
            entity.Property(e => e.facebook).HasMaxLength(255);
            entity.Property(e => e.faxnumber).HasMaxLength(255);
            entity.Property(e => e.instagram).HasMaxLength(255);
            entity.Property(e => e.linkedin).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.phonenumber).HasMaxLength(255);
            entity.Property(e => e.state).HasMaxLength(255);
            entity.Property(e => e.street).HasMaxLength(255);
            entity.Property(e => e.tiktok).HasMaxLength(255);
            entity.Property(e => e.twitterx).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
            entity.Property(e => e.website).HasMaxLength(255);
            entity.Property(e => e.whatsapp).HasMaxLength(255);
            entity.Property(e => e.zipcode).HasMaxLength(255);

            entity.HasOne(d => d.customercategory).WithMany(p => p.customer)
                .HasForeignKey(d => d.customercategoryid)
                .HasConstraintName("customer_customercategory_fk");

            entity.HasOne(d => d.customergroup).WithMany(p => p.customer)
                .HasForeignKey(d => d.customergroupid)
                .HasConstraintName("customer_customergroup_fk");
        });

        modelBuilder.Entity<customercategory>(entity =>
        {
            entity.HasKey(e => e.id).HasName("customercategory_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.isdeleted).HasColumnType("bit(1)");
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<customercontact>(entity =>
        {
            entity.HasKey(e => e.id).HasName("customercontact_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.customerid).HasMaxLength(50);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.emailaddress).HasMaxLength(255);
            entity.Property(e => e.jobtitle).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.phonenumber).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);

            entity.HasOne(d => d.customer).WithMany(p => p.customercontact)
                .HasForeignKey(d => d.customerid)
                .HasConstraintName("customercontact_customer_fk");
        });

        modelBuilder.Entity<customergroup>(entity =>
        {
            entity.HasKey(e => e.id).HasName("customergroup_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<deliveryorder>(entity =>
        {
            entity.HasKey(e => e.id).HasName("deliveryorder_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.salesorderid).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);

            entity.HasOne(d => d.salesorder).WithMany(p => p.deliveryorder)
                .HasForeignKey(d => d.salesorderid)
                .HasConstraintName("deliveryorder_salesorder_fk");
        });

        modelBuilder.Entity<filedocument>(entity =>
        {
            entity.HasKey(e => e.id).HasName("filedocument_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.extension).HasMaxLength(50);
            entity.Property(e => e.generatedname).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.originalname).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<fileimage>(entity =>
        {
            entity.HasKey(e => e.id).HasName("fileimage_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.extension).HasMaxLength(50);
            entity.Property(e => e.generatedname).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.originalname).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<gainers>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.apitimestamp).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ca_ex_dt).HasColumnType("character varying");
            entity.Property(e => e.ca_purpose).HasColumnType("character varying");
            entity.Property(e => e.legend).HasColumnType("character varying");
            entity.Property(e => e.market_type).HasColumnType("character varying");
            entity.Property(e => e.series).HasColumnType("character varying");
            entity.Property(e => e.srctimestamp).HasColumnType("timestamp without time zone");
            entity.Property(e => e.symbol).HasColumnType("character varying");
        });

        modelBuilder.Entity<getproductcategorydataallwithcount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("getproductcategorydataallwithcount");

            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpath).HasColumnType("character varying");
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.productcategoryid).HasColumnType("character varying");
        });

        modelBuilder.Entity<getproductmetadatavalueall>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("getproductmetadatavalueall");

            entity.Property(e => e.metadatavalueid).HasColumnType("character varying");
            entity.Property(e => e.metdataname).HasColumnType("character varying");
            entity.Property(e => e.name).HasColumnType("character varying");
        });

        modelBuilder.Entity<getproductmetadatavaluebycategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("getproductmetadatavaluebycategory");

            entity.Property(e => e.metadatavalueid).HasColumnType("character varying");
            entity.Property(e => e.metdataname).HasColumnType("character varying");
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.productcategoryid).HasColumnType("character varying");
        });

        modelBuilder.Entity<getproductmetadatavaluebycategorysubcategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("getproductmetadatavaluebycategorysubcategory");

            entity.Property(e => e.metadatavalueid).HasColumnType("character varying");
            entity.Property(e => e.metdataname).HasColumnType("character varying");
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.productcategoryid).HasColumnType("character varying");
            entity.Property(e => e.productsubcategoryid).HasColumnType("character varying");
        });

        modelBuilder.Entity<getproductmetadatavaluebycategorysubcategorysubset>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("getproductmetadatavaluebycategorysubcategorysubset");

            entity.Property(e => e.metadatavalueid).HasColumnType("character varying");
            entity.Property(e => e.metdataname).HasColumnType("character varying");
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.productcategoryid).HasColumnType("character varying");
            entity.Property(e => e.productsubcategoryid).HasColumnType("character varying");
            entity.Property(e => e.productsubcategorysubsetid).HasColumnType("character varying");
        });

        modelBuilder.Entity<goodsreceive>(entity =>
        {
            entity.HasKey(e => e.id).HasName("goodsreceive_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.purchaseorderid).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);

            entity.HasOne(d => d.purchaseorder).WithMany(p => p.goodsreceive)
                .HasForeignKey(d => d.purchaseorderid)
                .HasConstraintName("goodsreceive_purchaseorder_fk");
        });

        modelBuilder.Entity<inventorytransaction>(entity =>
        {
            entity.HasKey(e => e.id).HasName("inventorytransaction_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.modulecode).HasMaxLength(50);
            entity.Property(e => e.moduleid).HasMaxLength(50);
            entity.Property(e => e.modulename).HasMaxLength(255);
            entity.Property(e => e.modulenumber).HasColumnType("character varying");
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.productid).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
            entity.Property(e => e.warehousefromid).HasMaxLength(50);
            entity.Property(e => e.warehouseid).HasMaxLength(50);
            entity.Property(e => e.warehousetoid).HasMaxLength(50);

            entity.HasOne(d => d.product).WithMany(p => p.inventorytransaction)
                .HasForeignKey(d => d.productid)
                .HasConstraintName("inventorytransaction_product_fk");

            entity.HasOne(d => d.warehousefrom).WithMany(p => p.inventorytransactionwarehousefrom)
                .HasForeignKey(d => d.warehousefromid)
                .HasConstraintName("inventorytransaction_warehouse_fk_1");

            entity.HasOne(d => d.warehouse).WithMany(p => p.inventorytransactionwarehouse)
                .HasForeignKey(d => d.warehouseid)
                .HasConstraintName("inventorytransaction_warehouse_fk");

            entity.HasOne(d => d.warehouseto).WithMany(p => p.inventorytransactionwarehouseto)
                .HasForeignKey(d => d.warehousetoid)
                .HasConstraintName("inventorytransaction_warehouse_fk_2");
        });

        modelBuilder.Entity<itemcategory>(entity =>
        {
            entity.HasKey(e => e.id).HasName("itemcategory_pk");

            entity.HasIndex(e => e.id, "itemcategory_id_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpathsearch).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
        });

        modelBuilder.Entity<itemdimensiontype>(entity =>
        {
            entity.HasKey(e => e.id).HasName("itemdimensiontype_pk");

            entity.HasIndex(e => e.id, "itemdimensiontype_id_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpathsearch).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.value).HasColumnType("character varying");
        });

        modelBuilder.Entity<itemdrivetype>(entity =>
        {
            entity.HasKey(e => e.id).HasName("itemdrivetype_pk");

            entity.HasIndex(e => e.id, "itemdrivetype_id_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpathsearch).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
        });

        modelBuilder.Entity<itemgrouptype>(entity =>
        {
            entity.HasKey(e => e.id).HasName("itemgrouptype_pk");

            entity.HasIndex(e => e.id, "itemgrouptypey_id_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpathsearch).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.itemcategoryid).HasColumnType("character varying");
            entity.Property(e => e.itemsubcategoryid).HasColumnType("character varying");
            entity.Property(e => e.name).HasColumnType("character varying");

            entity.HasOne(d => d.itemcategory).WithMany(p => p.itemgrouptype)
                .HasForeignKey(d => d.itemcategoryid)
                .HasConstraintName("itemgrouptype_itemcategory_fk");

            entity.HasOne(d => d.itemsubcategory).WithMany(p => p.itemgrouptype)
                .HasForeignKey(d => d.itemsubcategoryid)
                .HasConstraintName("itemgrouptype_itemsubcategory_fk");
        });

        modelBuilder.Entity<itemheadformtype>(entity =>
        {
            entity.HasKey(e => e.id).HasName("itemheadformtype_pk");

            entity.HasIndex(e => e.id, "itemheadformtype_id_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpathsearch).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
        });

        modelBuilder.Entity<itemmaterialtype>(entity =>
        {
            entity.HasKey(e => e.id).HasName("itemmaterialtype_pk");

            entity.HasIndex(e => e.id, "itemmaterialtype_id_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpathsearch).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
        });

        modelBuilder.Entity<itemmetadata>(entity =>
        {
            entity.HasKey(e => e.id).HasName("itemproperties_pk");

            entity.HasIndex(e => e.itemid, "itemproperties_itemid_idx");

            entity.HasIndex(e => e.type, "itemproperties_type_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.itemid).HasColumnType("character varying");
            entity.Property(e => e.type).HasColumnType("character varying");
            entity.Property(e => e.value).HasColumnType("character varying");

            entity.HasOne(d => d.item).WithMany(p => p.itemmetadata)
                .HasForeignKey(d => d.itemid)
                .HasConstraintName("itemproperties_items_fk");
        });

        modelBuilder.Entity<itempropertyclasstype>(entity =>
        {
            entity.HasKey(e => e.id).HasName("itempropertyclasstype_pk");

            entity.HasIndex(e => e.id, "itempropertyclasstype_id_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpathsearch).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
        });

        modelBuilder.Entity<items>(entity =>
        {
            entity.HasKey(e => e.id).HasName("items_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.additionaldescription).HasColumnType("character varying");
            entity.Property(e => e.createdby).HasColumnType("character varying");
            entity.Property(e => e.createddate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.itemcategoryid).HasColumnType("character varying");
            entity.Property(e => e.itemdimensiontypeid).HasColumnType("character varying");
            entity.Property(e => e.itemdrivetypeid).HasColumnType("character varying");
            entity.Property(e => e.itemgrouptypeid).HasColumnType("character varying");
            entity.Property(e => e.itemheadformtypeid).HasColumnType("character varying");
            entity.Property(e => e.itemmaterialtypeid).HasColumnType("character varying");
            entity.Property(e => e.itempropertyclasstypeid).HasColumnType("character varying");
            entity.Property(e => e.itemsubcategoryid).HasColumnType("character varying");
            entity.Property(e => e.itemsubgrouptypeid).HasColumnType("character varying");
            entity.Property(e => e.itemsurfacefinishtypeid).HasColumnType("character varying");
            entity.Property(e => e.itemthreadtypeid).HasColumnType("character varying");
            entity.Property(e => e.itemtypeid).HasColumnType("character varying");
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.note).HasColumnType("character varying");
            entity.Property(e => e.partnumber).HasColumnType("character varying");
            entity.Property(e => e.updatedby).HasColumnType("character varying");
            entity.Property(e => e.updateddate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.itemcategory).WithMany(p => p.items)
                .HasForeignKey(d => d.itemcategoryid)
                .HasConstraintName("items_itemcategory_fk");

            entity.HasOne(d => d.itemdimensiontype).WithMany(p => p.items)
                .HasForeignKey(d => d.itemdimensiontypeid)
                .HasConstraintName("items_itemdimensiontype_fk");

            entity.HasOne(d => d.itemdrivetype).WithMany(p => p.items)
                .HasForeignKey(d => d.itemdrivetypeid)
                .HasConstraintName("items_itemdrivetype_fk");

            entity.HasOne(d => d.itemgrouptype).WithMany(p => p.items)
                .HasForeignKey(d => d.itemgrouptypeid)
                .HasConstraintName("items_itemgrouptype_fk");

            entity.HasOne(d => d.itemheadformtype).WithMany(p => p.items)
                .HasForeignKey(d => d.itemheadformtypeid)
                .HasConstraintName("items_itemheadformtype_fk");

            entity.HasOne(d => d.itemmaterialtype).WithMany(p => p.items)
                .HasForeignKey(d => d.itemmaterialtypeid)
                .HasConstraintName("items_itemmaterialtype_fk");

            entity.HasOne(d => d.itempropertyclasstype).WithMany(p => p.items)
                .HasForeignKey(d => d.itempropertyclasstypeid)
                .HasConstraintName("items_itempropertyclasstype_fk");

            entity.HasOne(d => d.itemsubcategory).WithMany(p => p.items)
                .HasForeignKey(d => d.itemsubcategoryid)
                .HasConstraintName("items_itemsubcategory_fk");

            entity.HasOne(d => d.itemsubgrouptype).WithMany(p => p.items)
                .HasForeignKey(d => d.itemsubgrouptypeid)
                .HasConstraintName("items_itemsubgrouptype_fk");

            entity.HasOne(d => d.itemsurfacefinishtype).WithMany(p => p.items)
                .HasForeignKey(d => d.itemsurfacefinishtypeid)
                .HasConstraintName("items_itemsurfacefinishtype_fk");

            entity.HasOne(d => d.itemthreadtype).WithMany(p => p.items)
                .HasForeignKey(d => d.itemthreadtypeid)
                .HasConstraintName("items_itemthreadtype_fk");

            entity.HasOne(d => d.itemtype).WithMany(p => p.items)
                .HasForeignKey(d => d.itemtypeid)
                .HasConstraintName("items_itemtype_fk");
        });

        modelBuilder.Entity<itemsubcategory>(entity =>
        {
            entity.HasKey(e => e.id).HasName("itemsubcategory_pk");

            entity.HasIndex(e => e.id, "itemsubcategory_id_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpathsearch).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.itemcaregoryid).HasColumnType("character varying");
            entity.Property(e => e.name).HasColumnType("character varying");

            entity.HasOne(d => d.itemcaregory).WithMany(p => p.itemsubcategory)
                .HasForeignKey(d => d.itemcaregoryid)
                .HasConstraintName("itemsubcategory_itemcategory_fk");
        });

        modelBuilder.Entity<itemsubgrouptype>(entity =>
        {
            entity.HasKey(e => e.id).HasName("itemgroupsubtype_pk");

            entity.HasIndex(e => e.id, "itemgroupsubtype_id_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpathsearch).HasColumnType("character varying");
            entity.Property(e => e.isdeleted)
                .HasDefaultValueSql("false")
                .HasColumnType("character varying");
            entity.Property(e => e.itemgrouptypeid).HasColumnType("character varying");
            entity.Property(e => e.name).HasColumnType("character varying");

            entity.HasOne(d => d.itemgrouptype).WithMany(p => p.itemsubgrouptype)
                .HasForeignKey(d => d.itemgrouptypeid)
                .HasConstraintName("itemgroupsubtype_itemgrouptype_fk");
        });

        modelBuilder.Entity<itemsurfacefinishtype>(entity =>
        {
            entity.HasKey(e => e.id).HasName("itemsurfacefinishtype_pk");

            entity.HasIndex(e => e.id, "itemsurfacefinishtype_id_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpathsearch).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
        });

        modelBuilder.Entity<itemthreadtype>(entity =>
        {
            entity.HasKey(e => e.id).HasName("itemthreadtype_pk");

            entity.HasIndex(e => e.id, "itemthreadtype_id_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpathsearch).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
        });

        modelBuilder.Entity<itemtype>(entity =>
        {
            entity.HasKey(e => e.id).HasName("itemtype_pk");

            entity.HasIndex(e => e.id, "itemtype_id_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpathsearch).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.itemcategoryid).HasColumnType("character varying");
            entity.Property(e => e.itemgroupsubtypeid).HasColumnType("character varying");
            entity.Property(e => e.itemgrouptypeid).HasColumnType("character varying");
            entity.Property(e => e.itemsubcategoryid).HasColumnType("character varying");
            entity.Property(e => e.name).HasColumnType("character varying");

            entity.HasOne(d => d.itemcategory).WithMany(p => p.itemtype)
                .HasForeignKey(d => d.itemcategoryid)
                .HasConstraintName("itemtype_itemcategory_fk");

            entity.HasOne(d => d.itemgroupsubtype).WithMany(p => p.itemtype)
                .HasForeignKey(d => d.itemgroupsubtypeid)
                .HasConstraintName("itemtype_itemgroupsubtype_fk");

            entity.HasOne(d => d.itemgrouptype).WithMany(p => p.itemtype)
                .HasForeignKey(d => d.itemgrouptypeid)
                .HasConstraintName("itemtype_itemgrouptype_fk");

            entity.HasOne(d => d.itemsubcategory).WithMany(p => p.itemtype)
                .HasForeignKey(d => d.itemsubcategoryid)
                .HasConstraintName("itemtype_itemsubcategory_fk");
        });

        modelBuilder.Entity<loosers>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.apitimestamp).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ca_ex_dt).HasColumnType("character varying");
            entity.Property(e => e.ca_purpose).HasColumnType("character varying");
            entity.Property(e => e.legend).HasColumnType("character varying");
            entity.Property(e => e.market_type).HasColumnType("character varying");
            entity.Property(e => e.series).HasColumnType("character varying");
            entity.Property(e => e.srctimestamp).HasColumnType("timestamp without time zone");
            entity.Property(e => e.symbol).HasColumnType("character varying");
        });

        modelBuilder.Entity<negativeadjustment>(entity =>
        {
            entity.HasKey(e => e.id).HasName("negativeadjustment_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.number).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<numbersequence>(entity =>
        {
            entity.HasKey(e => e.id).HasName("numbersequence_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.entityname).HasMaxLength(255);
            entity.Property(e => e.prefix).HasMaxLength(50);
            entity.Property(e => e.suffix).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<positiveadjustment>(entity =>
        {
            entity.HasKey(e => e.id).HasName("positiveadjustment_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.number).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<productcategory>(entity =>
        {
            entity.HasKey(e => e.id).HasName("productcategory_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.createdbyid).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpath).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.productgroupid).HasColumnType("character varying");
            entity.Property(e => e.updatedbyid).HasColumnType("character varying");

            entity.HasOne(d => d.productgroup).WithMany(p => p.productcategory)
                .HasForeignKey(d => d.productgroupid)
                .HasConstraintName("productcategory_productgroup_fk");
        });

        modelBuilder.Entity<productgroup>(entity =>
        {
            entity.HasKey(e => e.id).HasName("productgroup_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<productmapper>(entity =>
        {
            entity.HasKey(e => e.id).HasName("productmapper_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.createdbyid).HasColumnType("character varying");
            entity.Property(e => e.productcategoryid).HasColumnType("character varying");
            entity.Property(e => e.productgroupid).HasColumnType("character varying");
            entity.Property(e => e.productid).HasColumnType("character varying");
            entity.Property(e => e.productmetadataid).HasColumnType("character varying");
            entity.Property(e => e.productmetadataname).HasColumnType("character varying");
            entity.Property(e => e.productmetadatavaluesid).HasColumnType("character varying");
            entity.Property(e => e.productmetadatavaluesname).HasColumnType("character varying");
            entity.Property(e => e.productsubcategoryid).HasColumnType("character varying");
            entity.Property(e => e.productsubcategorysubsetid).HasColumnType("character varying");
            entity.Property(e => e.updatedbyid).HasColumnType("character varying");

            entity.HasOne(d => d.productcategory).WithMany(p => p.productmapper)
                .HasForeignKey(d => d.productcategoryid)
                .HasConstraintName("productmapper_productcategory_fk");

            entity.HasOne(d => d.productgroup).WithMany(p => p.productmapper)
                .HasForeignKey(d => d.productgroupid)
                .HasConstraintName("productmapper_productgroup_fk");

            entity.HasOne(d => d.product).WithMany(p => p.productmapper)
                .HasForeignKey(d => d.productid)
                .HasConstraintName("productmapper_products_fk");

            entity.HasOne(d => d.productmetadata).WithMany(p => p.productmapper)
                .HasForeignKey(d => d.productmetadataid)
                .HasConstraintName("productmapper_productmetdata_fk");

            entity.HasOne(d => d.productsubcategory).WithMany(p => p.productmapper)
                .HasForeignKey(d => d.productsubcategoryid)
                .HasConstraintName("productmapper_productsubcategory_fk");

            entity.HasOne(d => d.productsubcategorysubset).WithMany(p => p.productmapper)
                .HasForeignKey(d => d.productsubcategorysubsetid)
                .HasConstraintName("productmapper_productsubcategorysubset_fk");
        });

        modelBuilder.Entity<productmetadata>(entity =>
        {
            entity.HasKey(e => e.id).HasName("productmetdata_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.controltype).HasColumnType("character varying");
            entity.Property(e => e.createdbyid).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.isiconsupported).HasDefaultValue(false);
            entity.Property(e => e.ismultiselect).HasDefaultValue(false);
            entity.Property(e => e.issearchable).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.productcategoryid).HasColumnType("character varying");
            entity.Property(e => e.productsubcategoryid).HasColumnType("character varying");
            entity.Property(e => e.productsubcategoryidsubsetid).HasColumnType("character varying");
            entity.Property(e => e.updatedbyid).HasColumnType("character varying");

            entity.HasOne(d => d.productcategory).WithMany(p => p.productmetadata)
                .HasForeignKey(d => d.productcategoryid)
                .HasConstraintName("productmetadata_productcategory_fk");

            entity.HasOne(d => d.productsubcategory).WithMany(p => p.productmetadata)
                .HasForeignKey(d => d.productsubcategoryid)
                .HasConstraintName("productmetdata_productsubcategory_fk");

            entity.HasOne(d => d.productsubcategoryidsubset).WithMany(p => p.productmetadata)
                .HasForeignKey(d => d.productsubcategoryidsubsetid)
                .HasConstraintName("productmetadata_productsubcategorysubset_fk");
        });

        modelBuilder.Entity<productmetadatavalues>(entity =>
        {
            entity.HasKey(e => e.id).HasName("productmetdatavalues_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.createdbyid).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpath).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.partnumbercode).HasColumnType("character varying");
            entity.Property(e => e.productmetdataid).HasColumnType("character varying");
            entity.Property(e => e.updatedbyid).HasColumnType("character varying");

            entity.HasOne(d => d.productmetdata).WithMany(p => p.productmetadatavalues)
                .HasForeignKey(d => d.productmetdataid)
                .HasConstraintName("productmetdatavalues_productmetdata_fk");
        });

        modelBuilder.Entity<products>(entity =>
        {
            entity.HasKey(e => e.id).HasName("product_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.additionaldescription).HasColumnType("character varying");
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.note).HasColumnType("character varying");
            entity.Property(e => e.partnumber).HasMaxLength(50);
            entity.Property(e => e.productcategoryid).HasColumnType("character varying");
            entity.Property(e => e.productsubcategoryid).HasColumnType("character varying");
            entity.Property(e => e.productsubcategroysubsetid).HasColumnType("character varying");
            entity.Property(e => e.unitmeasureid).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);

            entity.HasOne(d => d.productcategory).WithMany(p => p.products)
                .HasForeignKey(d => d.productcategoryid)
                .HasConstraintName("products_productcategory_fk");

            entity.HasOne(d => d.productsubcategory).WithMany(p => p.products)
                .HasForeignKey(d => d.productsubcategoryid)
                .HasConstraintName("products_productsubcategory_fk");

            entity.HasOne(d => d.productsubcategroysubset).WithMany(p => p.products)
                .HasForeignKey(d => d.productsubcategroysubsetid)
                .HasConstraintName("products_productsubcategorysubset_fk");

            entity.HasOne(d => d.unitmeasure).WithMany(p => p.products)
                .HasForeignKey(d => d.unitmeasureid)
                .HasConstraintName("product_unitmeasure_fk");
        });

        modelBuilder.Entity<productsubcategory>(entity =>
        {
            entity.HasKey(e => e.id).HasName("productsubcategory_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.createdbyid).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpath).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.productcategoryid).HasColumnType("character varying");
            entity.Property(e => e.updatedbyid).HasColumnType("character varying");

            entity.HasOne(d => d.productcategory).WithMany(p => p.productsubcategory)
                .HasForeignKey(d => d.productcategoryid)
                .HasConstraintName("productsubcategory_productcategory_fk");
        });

        modelBuilder.Entity<productsubcategorysubset>(entity =>
        {
            entity.HasKey(e => e.id).HasName("productsubcategorysubset_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.createdbyid).HasColumnType("character varying");
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.iconpath).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.productsubcategoryid).HasColumnType("character varying");
            entity.Property(e => e.updatedbyid).HasColumnType("character varying");

            entity.HasOne(d => d.productsubcategory).WithMany(p => p.productsubcategorysubset)
                .HasForeignKey(d => d.productsubcategoryid)
                .HasConstraintName("productsubcategorysubset_productsubcategory_fk");
        });

        modelBuilder.Entity<purchaseorder>(entity =>
        {
            entity.HasKey(e => e.id).HasName("purchaseorder_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.taxid).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
            entity.Property(e => e.vendorid).HasMaxLength(50);

            entity.HasOne(d => d.tax).WithMany(p => p.purchaseorder)
                .HasForeignKey(d => d.taxid)
                .HasConstraintName("purchaseorder_tax_fk");

            entity.HasOne(d => d.vendor).WithMany(p => p.purchaseorder)
                .HasForeignKey(d => d.vendorid)
                .HasConstraintName("purchaseorder_vendor_fk");
        });

        modelBuilder.Entity<purchaseorderitem>(entity =>
        {
            entity.HasKey(e => e.id).HasName("purchaseorderitem_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.productid).HasMaxLength(50);
            entity.Property(e => e.purchaseorderid).HasMaxLength(50);
            entity.Property(e => e.summary).HasMaxLength(4000);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);

            entity.HasOne(d => d.product).WithMany(p => p.purchaseorderitem)
                .HasForeignKey(d => d.productid)
                .HasConstraintName("purchaseorderitem_product_fk");

            entity.HasOne(d => d.purchaseorder).WithMany(p => p.Inversepurchaseorder)
                .HasForeignKey(d => d.purchaseorderid)
                .HasConstraintName("purchaseorderitem_purchaseorderitem_fk");
        });

        modelBuilder.Entity<purchasereturn>(entity =>
        {
            entity.HasKey(e => e.id).HasName("purchasereturn_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.goodsreceiveid).HasMaxLength(50);
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);

            entity.HasOne(d => d.goodsreceive).WithMany(p => p.purchasereturn)
                .HasForeignKey(d => d.goodsreceiveid)
                .HasConstraintName("purchasereturn_goodsreceive_fk");
        });

        modelBuilder.Entity<roles>(entity =>
        {
            entity.HasKey(e => e.id).HasName("roles_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<salesorder>(entity =>
        {
            entity.HasKey(e => e.id).HasName("salesorder_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.customerid).HasMaxLength(50);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.taxid).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);

            entity.HasOne(d => d.customer).WithMany(p => p.salesorder)
                .HasForeignKey(d => d.customerid)
                .HasConstraintName("salesorder_customer_fk");

            entity.HasOne(d => d.tax).WithMany(p => p.salesorder)
                .HasForeignKey(d => d.taxid)
                .HasConstraintName("salesorder_tax_fk");
        });

        modelBuilder.Entity<salesorderitem>(entity =>
        {
            entity.HasKey(e => e.id).HasName("salesorderitem_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.productid).HasMaxLength(50);
            entity.Property(e => e.salesorderid).HasMaxLength(50);
            entity.Property(e => e.summary).HasMaxLength(4000);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);

            entity.HasOne(d => d.product).WithMany(p => p.salesorderitem)
                .HasForeignKey(d => d.productid)
                .HasConstraintName("salesorderitem_product_fk");

            entity.HasOne(d => d.salesorder).WithMany(p => p.salesorderitem)
                .HasForeignKey(d => d.salesorderid)
                .HasConstraintName("salesorderitem_salesorder_fk");
        });

        modelBuilder.Entity<salesreturn>(entity =>
        {
            entity.HasKey(e => e.id).HasName("salesreturn_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.deliveryorderid).HasMaxLength(50);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);

            entity.HasOne(d => d.deliveryorder).WithMany(p => p.salesreturn)
                .HasForeignKey(d => d.deliveryorderid)
                .HasConstraintName("salesreturn_deliveryorder_fk");
        });

        modelBuilder.Entity<scrapping>(entity =>
        {
            entity.HasKey(e => e.id).HasName("scrapping_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
            entity.Property(e => e.warehouseid).HasMaxLength(50);

            entity.HasOne(d => d.warehouse).WithMany(p => p.scrapping)
                .HasForeignKey(d => d.warehouseid)
                .HasConstraintName("scrapping_warehouse_fk");
        });

        modelBuilder.Entity<stockcount>(entity =>
        {
            entity.HasKey(e => e.id).HasName("stockcount_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
            entity.Property(e => e.warehouseid).HasMaxLength(50);

            entity.HasOne(d => d.warehouse).WithMany(p => p.stockcount)
                .HasForeignKey(d => d.warehouseid)
                .HasConstraintName("stockcount_warehouse_fk");
        });

        modelBuilder.Entity<tax>(entity =>
        {
            entity.HasKey(e => e.id).HasName("tax_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<todo>(entity =>
        {
            entity.HasKey(e => e.id).HasName("todo_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.isdeleted).HasColumnType("bit(1)");
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<todoitem>(entity =>
        {
            entity.HasKey(e => e.id).HasName("todoitem_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.isdeleted).HasColumnType("bit(1)");
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.todoid).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);

            entity.HasOne(d => d.todo).WithMany(p => p.todoitem)
                .HasForeignKey(d => d.todoid)
                .HasConstraintName("todoitem_todo_fk");
        });

        modelBuilder.Entity<transferin>(entity =>
        {
            entity.HasKey(e => e.id).HasName("transferin_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.isdeleted).HasColumnType("bit(1)");
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.transferoutid).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);

            entity.HasOne(d => d.transferout).WithMany(p => p.transferin)
                .HasForeignKey(d => d.transferoutid)
                .HasConstraintName("transferin_transferout_fk");
        });

        modelBuilder.Entity<transferout>(entity =>
        {
            entity.HasKey(e => e.id).HasName("transferout_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.isdeleted).HasColumnType("bit(1)");
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
            entity.Property(e => e.warehousefromid).HasMaxLength(50);
            entity.Property(e => e.warehousetoid).HasMaxLength(50);

            entity.HasOne(d => d.warehousefrom).WithMany(p => p.transferoutwarehousefrom)
                .HasForeignKey(d => d.warehousefromid)
                .HasConstraintName("transferout_warehouse_fk");

            entity.HasOne(d => d.warehouseto).WithMany(p => p.transferoutwarehouseto)
                .HasForeignKey(d => d.warehousetoid)
                .HasConstraintName("transferout_warehouse_fk_1");
        });

        modelBuilder.Entity<unitmeasure>(entity =>
        {
            entity.HasKey(e => e.id).HasName("unitmeasure_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<users>(entity =>
        {
            entity.HasKey(e => e.id).HasName("users_pk");

            entity.HasIndex(e => e.isdeleted, "users_isdeleted_idx");

            entity.HasIndex(e => e.usertype, "users_usertype_idx");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.address1).HasColumnType("character varying");
            entity.Property(e => e.address2).HasColumnType("character varying");
            entity.Property(e => e.area).HasColumnType("character varying");
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.district).HasColumnType("character varying");
            entity.Property(e => e.email).HasColumnType("character varying");
            entity.Property(e => e.firstname).HasColumnType("character varying");
            entity.Property(e => e.gender).HasColumnType("character varying");
            entity.Property(e => e.idproofname).HasColumnType("character varying");
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.lastname).HasColumnType("character varying");
            entity.Property(e => e.password).HasColumnType("character varying");
            entity.Property(e => e.photoname).HasColumnType("character varying");
            entity.Property(e => e.pincode).HasColumnType("character varying");
            entity.Property(e => e.primarycontactnumber).HasColumnType("character varying");
            entity.Property(e => e.propertyid).HasColumnType("character varying");
            entity.Property(e => e.referredby).HasColumnType("character varying");
            entity.Property(e => e.secondarycontactnumber).HasColumnType("character varying");
            entity.Property(e => e.street).HasColumnType("character varying");
            entity.Property(e => e.temporarypassword).HasColumnType("character varying");
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
            entity.Property(e => e.userstatusid).HasColumnType("character varying");
            entity.Property(e => e.usertype).HasColumnType("character varying");

            entity.HasOne(d => d.userstatus).WithMany(p => p.users)
                .HasForeignKey(d => d.userstatusid)
                .HasConstraintName("users_fk_4");

            entity.HasOne(d => d.usertypeNavigation).WithMany(p => p.users)
                .HasForeignKey(d => d.usertype)
                .HasConstraintName("users_fk");
        });

        modelBuilder.Entity<userstatus>(entity =>
        {
            entity.HasKey(e => e.id).HasName("userstatus_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<usertype>(entity =>
        {
            entity.HasKey(e => e.id).HasName("usertype_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.isdeleted).HasDefaultValue(false);
            entity.Property(e => e.name).HasColumnType("character varying");
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<vendor>(entity =>
        {
            entity.HasKey(e => e.id).HasName("vendor_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.city).HasMaxLength(255);
            entity.Property(e => e.country).HasMaxLength(255);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.emailaddress).HasMaxLength(255);
            entity.Property(e => e.facebook).HasMaxLength(255);
            entity.Property(e => e.faxnumber).HasMaxLength(255);
            entity.Property(e => e.instagram).HasMaxLength(255);
            entity.Property(e => e.linkedin).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.phonenumber).HasMaxLength(255);
            entity.Property(e => e.state).HasMaxLength(255);
            entity.Property(e => e.street).HasMaxLength(255);
            entity.Property(e => e.tiktok).HasMaxLength(255);
            entity.Property(e => e.twitterx).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
            entity.Property(e => e.vendorcategoryid).HasMaxLength(50);
            entity.Property(e => e.vendorgroupid).HasMaxLength(50);
            entity.Property(e => e.website).HasMaxLength(255);
            entity.Property(e => e.whatsapp).HasMaxLength(255);
            entity.Property(e => e.zipcode).HasMaxLength(255);

            entity.HasOne(d => d.vendorcategory).WithMany(p => p.vendor)
                .HasForeignKey(d => d.vendorcategoryid)
                .HasConstraintName("vendor_vendorcategory_fk");

            entity.HasOne(d => d.vendorgroup).WithMany(p => p.vendor)
                .HasForeignKey(d => d.vendorgroupid)
                .HasConstraintName("vendor_vendorgroup_fk");
        });

        modelBuilder.Entity<vendorcategory>(entity =>
        {
            entity.HasKey(e => e.id).HasName("vendorcategory_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<vendorcontact>(entity =>
        {
            entity.HasKey(e => e.id).HasName("vendorcontact_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.emailaddress).HasMaxLength(255);
            entity.Property(e => e.isdeleted).HasColumnType("bit(1)");
            entity.Property(e => e.jobtitle).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.number).HasMaxLength(50);
            entity.Property(e => e.phonenumber).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
            entity.Property(e => e.vendorid).HasMaxLength(50);

            entity.HasOne(d => d.vendor).WithMany(p => p.vendorcontact)
                .HasForeignKey(d => d.vendorid)
                .HasConstraintName("vendorcontact_vendor_fk");
        });

        modelBuilder.Entity<vendorgroup>(entity =>
        {
            entity.HasKey(e => e.id).HasName("vendorgroup_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.isdeleted).HasColumnType("bit(1)");
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        modelBuilder.Entity<warehouse>(entity =>
        {
            entity.HasKey(e => e.id).HasName("warehouse_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.description).HasMaxLength(4000);
            entity.Property(e => e.name).HasMaxLength(255);
            entity.Property(e => e.systemwarehouse).HasColumnType("bit(1)");
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        List<auditlog> auditLogs = new();
        try
        {
            //string userId = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            //Guid? user = userId != null ? Guid.Parse(userId) : null;
            // var test = ((System.Security.Claims.ClaimsIdentity)(_httpContextAccessor.HttpContext?.User?.Identity)).Claims;
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var claims = _httpContextAccessor.HttpContext?.User.Claims.ToList();
            userId = claims[0].Value;
            var userName = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);

            var entries = ChangeTracker.Entries()
                  .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);
            var currentUser = userId;//TODO put actual userid
            
            foreach (var entry in entries)
            {
                if (entry.Metadata.Name == $"Mcparts.DataAccess.Models.users"
                    )
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("createdbyid").CurrentValue = userId;
                        entry.Property("createdatutc").CurrentValue = DateTime.UtcNow;
                        entry.Property("updatedbyid").CurrentValue = userId;
                        entry.Property("updatedatutc").CurrentValue = DateTime.UtcNow;


                        auditLogs.Add(LogChanges(currentUser, entry, "INSERT"));
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entry.Property("updatedbyid").CurrentValue = userId;
                        entry.Property("updatedatutc").CurrentValue = DateTime.UtcNow;

                        var changes = GetModifiedProperties(entry);
                        if (changes.Any())
                        {
                            auditLogs.Add(LogChanges(currentUser, entry, "UPDATE", changes));
                        }
                    }
                    else if (entry.State == EntityState.Deleted)
                    {
                        auditLogs.Add(LogChanges(currentUser, entry, "DELETE"));
                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
        var result = await base.SaveChangesAsync(cancellationToken);

        if (auditLogs.Any())
        {
            await auditlog.AddRangeAsync(auditLogs);
            await base.SaveChangesAsync(cancellationToken);
        }

        return result;
    }

    private string SerializeObject(object obj)
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = false });
    }

    private auditlog LogChanges(string userId, EntityEntry entry, string action, object? changedData = null)
    {
        return new auditlog
        {
            id = Guid.NewGuid().ToString(),
            tablename = entry.Entity.GetType().Name,
            action = action,
            changes = changedData != null ? SerializeObject(changedData) : SerializeObject(entry.OriginalValues.Properties.ToDictionary(p => p.Name, p => entry.OriginalValues[p])),
            userid = userId,
            createdbyutc = DateTime.UtcNow
        };
    }

    private Dictionary<string, object> GetModifiedProperties(EntityEntry entry)
    {
        var changes = new Dictionary<string, object>();

        foreach (var property in entry.OriginalValues.Properties)
        {
            var original = entry.OriginalValues[property];
            var current = entry.CurrentValues[property];

            if (!object.Equals(original, current))
            {
                changes[property.Name] = new { OldValue = original, NewValue = current };
            }
        }

        return changes;
    }
}

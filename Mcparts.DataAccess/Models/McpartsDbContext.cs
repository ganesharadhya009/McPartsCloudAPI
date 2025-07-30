using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mcparts.DataAccess.Models;

public partial class McpartsDbContext : DbContext
{
    public McpartsDbContext(DbContextOptions<McpartsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<aspnetroleclaims> aspnetroleclaims { get; set; }

    public virtual DbSet<aspnetroles> aspnetroles { get; set; }

    public virtual DbSet<aspnetuserclaims> aspnetuserclaims { get; set; }

    public virtual DbSet<aspnetuserlogins> aspnetuserlogins { get; set; }

    public virtual DbSet<aspnetuserroles> aspnetuserroles { get; set; }

    public virtual DbSet<aspnetusers> aspnetusers { get; set; }

    public virtual DbSet<aspnetusertokens> aspnetusertokens { get; set; }

    public virtual DbSet<audit_log_entries> audit_log_entries { get; set; }

    public virtual DbSet<buckets> buckets { get; set; }

    public virtual DbSet<company> company { get; set; }

    public virtual DbSet<customer> customer { get; set; }

    public virtual DbSet<customercategory> customercategory { get; set; }

    public virtual DbSet<customercontact> customercontact { get; set; }

    public virtual DbSet<customergroup> customergroup { get; set; }

    public virtual DbSet<deliveryorder> deliveryorder { get; set; }

    public virtual DbSet<filedocument> filedocument { get; set; }

    public virtual DbSet<fileimage> fileimage { get; set; }

    public virtual DbSet<flow_state> flow_state { get; set; }

    public virtual DbSet<gainers> gainers { get; set; }

    public virtual DbSet<getproductcategorydataallwithcount> getproductcategorydataallwithcount { get; set; }

    public virtual DbSet<getproductmetadatavalueall> getproductmetadatavalueall { get; set; }

    public virtual DbSet<getproductmetadatavaluebycategory> getproductmetadatavaluebycategory { get; set; }

    public virtual DbSet<getproductmetadatavaluebycategorysubcategory> getproductmetadatavaluebycategorysubcategory { get; set; }

    public virtual DbSet<getproductmetadatavaluebycategorysubcategorysubset> getproductmetadatavaluebycategorysubcategorysubset { get; set; }

    public virtual DbSet<goodsreceive> goodsreceive { get; set; }

    public virtual DbSet<identities> identities { get; set; }

    public virtual DbSet<instances> instances { get; set; }

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

    public virtual DbSet<mfa_amr_claims> mfa_amr_claims { get; set; }

    public virtual DbSet<mfa_challenges> mfa_challenges { get; set; }

    public virtual DbSet<mfa_factors> mfa_factors { get; set; }

    public virtual DbSet<migrations> migrations { get; set; }

    public virtual DbSet<negativeadjustment> negativeadjustment { get; set; }

    public virtual DbSet<numbersequence> numbersequence { get; set; }

    public virtual DbSet<objects> objects { get; set; }

    public virtual DbSet<one_time_tokens> one_time_tokens { get; set; }

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

    public virtual DbSet<refresh_tokens> refresh_tokens { get; set; }

    public virtual DbSet<s3_multipart_uploads> s3_multipart_uploads { get; set; }

    public virtual DbSet<s3_multipart_uploads_parts> s3_multipart_uploads_parts { get; set; }

    public virtual DbSet<salesorder> salesorder { get; set; }

    public virtual DbSet<salesorderitem> salesorderitem { get; set; }

    public virtual DbSet<salesreturn> salesreturn { get; set; }

    public virtual DbSet<saml_providers> saml_providers { get; set; }

    public virtual DbSet<saml_relay_states> saml_relay_states { get; set; }

    public virtual DbSet<schema_migrations> schema_migrations { get; set; }

    public virtual DbSet<schema_migrations1> schema_migrations1 { get; set; }

    public virtual DbSet<scrapping> scrapping { get; set; }

    public virtual DbSet<sessions> sessions { get; set; }

    public virtual DbSet<sso_domains> sso_domains { get; set; }

    public virtual DbSet<sso_providers> sso_providers { get; set; }

    public virtual DbSet<stockcount> stockcount { get; set; }

    public virtual DbSet<subscription> subscription { get; set; }

    public virtual DbSet<tax> tax { get; set; }

    public virtual DbSet<todo> todo { get; set; }

    public virtual DbSet<todoitem> todoitem { get; set; }

    public virtual DbSet<token> token { get; set; }

    public virtual DbSet<transferin> transferin { get; set; }

    public virtual DbSet<transferout> transferout { get; set; }

    public virtual DbSet<unitmeasure> unitmeasure { get; set; }

    public virtual DbSet<users> users { get; set; }

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

        modelBuilder.Entity<aspnetroleclaims>(entity =>
        {
            entity.HasKey(e => e.id).HasName("aspnetroleclaims_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.claimtype).HasColumnType("character varying");
            entity.Property(e => e.claimvalue).HasColumnType("character varying");
            entity.Property(e => e.roleid).HasMaxLength(450);

            entity.HasOne(d => d.role).WithMany(p => p.aspnetroleclaims)
                .HasForeignKey(d => d.roleid)
                .HasConstraintName("aspnetroleclaims_aspnetroles_fk");
        });

        modelBuilder.Entity<aspnetroles>(entity =>
        {
            entity.HasKey(e => e.id).HasName("aspnetroles_pk");

            entity.Property(e => e.id).HasMaxLength(450);
            entity.Property(e => e.concurrencystamp).HasColumnType("character varying");
            entity.Property(e => e.name).HasMaxLength(256);
            entity.Property(e => e.normalizedname).HasMaxLength(256);
        });

        modelBuilder.Entity<aspnetuserclaims>(entity =>
        {
            entity.HasKey(e => e.id).HasName("aspnetuserclaims_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.claimtype).HasColumnType("character varying");
            entity.Property(e => e.claimvalue).HasColumnType("character varying");
            entity.Property(e => e.userid).HasMaxLength(450);

            entity.HasOne(d => d.user).WithMany(p => p.aspnetuserclaims)
                .HasForeignKey(d => d.userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aspnetuserclaims_aspnetusers_fk");
        });

        modelBuilder.Entity<aspnetuserlogins>(entity =>
        {
            entity.HasKey(e => new { e.loginprovider, e.providerkey }).HasName("aspnetuserlogins_pk");

            entity.Property(e => e.loginprovider).HasMaxLength(128);
            entity.Property(e => e.providerkey).HasMaxLength(128);
            entity.Property(e => e.providerdisplayname).HasColumnType("character varying");
            entity.Property(e => e.userid).HasColumnType("character varying");

            entity.HasOne(d => d.user).WithMany(p => p.aspnetuserlogins)
                .HasForeignKey(d => d.userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aspnetuserlogins_aspnetusers_fk");
        });

        modelBuilder.Entity<aspnetuserroles>(entity =>
        {
            entity.HasKey(e => e.id).HasName("aspnetuserroles_pk");

            entity.Property(e => e.id).HasColumnType("character varying");
            entity.Property(e => e.roleid).HasColumnType("character varying");
            entity.Property(e => e.userid).HasColumnType("character varying");

            entity.HasOne(d => d.role).WithMany(p => p.aspnetuserroles)
                .HasForeignKey(d => d.roleid)
                .HasConstraintName("aspnetuserroles_aspnetroles_fk");

            entity.HasOne(d => d.user).WithMany(p => p.aspnetuserroles)
                .HasForeignKey(d => d.userid)
                .HasConstraintName("aspnetuserroles_aspnetusers_fk");
        });

        modelBuilder.Entity<aspnetusers>(entity =>
        {
            entity.HasKey(e => e.id).HasName("aspnetusers_pk");

            entity.Property(e => e.id).HasMaxLength(450);
            entity.Property(e => e.companyname).HasColumnType("character varying");
            entity.Property(e => e.concurrencystamp).HasColumnType("character varying");
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.email).HasMaxLength(256);
            entity.Property(e => e.emailconfirmed).HasColumnType("bit(1)");
            entity.Property(e => e.firstname).HasMaxLength(255);
            entity.Property(e => e.lastname).HasMaxLength(255);
            entity.Property(e => e.normalizedemail).HasMaxLength(256);
            entity.Property(e => e.normalizedusername).HasMaxLength(256);
            entity.Property(e => e.passwordhash).HasColumnType("character varying");
            entity.Property(e => e.phonenumber).HasColumnType("character varying");
            entity.Property(e => e.profilepicturename).HasMaxLength(255);
            entity.Property(e => e.securitystamp).HasColumnType("character varying");
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
            entity.Property(e => e.username).HasMaxLength(256);
        });

        modelBuilder.Entity<aspnetusertokens>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => new { e.userid, e.loginprovider, e.name }, "aspnetusertokens_unique").IsUnique();

            entity.Property(e => e.loginprovider).HasMaxLength(128);
            entity.Property(e => e.name).HasMaxLength(128);
            entity.Property(e => e.userid).HasMaxLength(450);
            entity.Property(e => e.value).HasColumnType("character varying");

            entity.HasOne(d => d.user).WithMany()
                .HasForeignKey(d => d.userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aspnetusertokens_aspnetusers_fk");
        });

        modelBuilder.Entity<audit_log_entries>(entity =>
        {
            entity.HasKey(e => e.id).HasName("audit_log_entries_pkey");

            entity.ToTable("audit_log_entries", "auth", tb => tb.HasComment("Auth: Audit trail for user actions."));

            entity.HasIndex(e => e.instance_id, "audit_logs_instance_id_idx");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.ip_address)
                .HasMaxLength(64)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.payload).HasColumnType("json");
        });

        modelBuilder.Entity<buckets>(entity =>
        {
            entity.HasKey(e => e.id).HasName("buckets_pkey");

            entity.ToTable("buckets", "storage");

            entity.HasIndex(e => e.name, "bname").IsUnique();

            entity.Property(e => e._public)
                .HasDefaultValue(false)
                .HasColumnName("public");
            entity.Property(e => e.avif_autodetection).HasDefaultValue(false);
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.owner).HasComment("Field is deprecated, use owner_id instead");
            entity.Property(e => e.updated_at).HasDefaultValueSql("now()");
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

        modelBuilder.Entity<flow_state>(entity =>
        {
            entity.HasKey(e => e.id).HasName("flow_state_pkey");

            entity.ToTable("flow_state", "auth", tb => tb.HasComment("stores metadata for pkce logins"));

            entity.HasIndex(e => e.created_at, "flow_state_created_at_idx").IsDescending();

            entity.HasIndex(e => e.auth_code, "idx_auth_code");

            entity.HasIndex(e => new { e.user_id, e.authentication_method }, "idx_user_id_auth_method");

            entity.Property(e => e.id).ValueGeneratedNever();
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

        modelBuilder.Entity<identities>(entity =>
        {
            entity.HasKey(e => e.id).HasName("identities_pkey");

            entity.ToTable("identities", "auth", tb => tb.HasComment("Auth: Stores identities associated to a user."));

            entity.HasIndex(e => e.email, "identities_email_idx").HasOperators(new[] { "text_pattern_ops" });

            entity.HasIndex(e => new { e.provider_id, e.provider }, "identities_provider_id_provider_unique").IsUnique();

            entity.HasIndex(e => e.user_id, "identities_user_id_idx");

            entity.Property(e => e.id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.email)
                .HasComputedColumnSql("lower((identity_data ->> 'email'::text))", true)
                .HasComment("Auth: Email is a generated column that references the optional email property in the identity_data");
            entity.Property(e => e.identity_data).HasColumnType("jsonb");

            entity.HasOne(d => d.user).WithMany(p => p.identities)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("identities_user_id_fkey");
        });

        modelBuilder.Entity<instances>(entity =>
        {
            entity.HasKey(e => e.id).HasName("instances_pkey");

            entity.ToTable("instances", "auth", tb => tb.HasComment("Auth: Manages users across multiple sites."));

            entity.Property(e => e.id).ValueGeneratedNever();
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

        modelBuilder.Entity<mfa_amr_claims>(entity =>
        {
            entity.HasKey(e => e.id).HasName("amr_id_pk");

            entity.ToTable("mfa_amr_claims", "auth", tb => tb.HasComment("auth: stores authenticator method reference claims for multi factor authentication"));

            entity.HasIndex(e => new { e.session_id, e.authentication_method }, "mfa_amr_claims_session_id_authentication_method_pkey").IsUnique();

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.session).WithMany(p => p.mfa_amr_claims)
                .HasForeignKey(d => d.session_id)
                .HasConstraintName("mfa_amr_claims_session_id_fkey");
        });

        modelBuilder.Entity<mfa_challenges>(entity =>
        {
            entity.HasKey(e => e.id).HasName("mfa_challenges_pkey");

            entity.ToTable("mfa_challenges", "auth", tb => tb.HasComment("auth: stores metadata about challenge requests made"));

            entity.HasIndex(e => e.created_at, "mfa_challenge_created_at_idx").IsDescending();

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.web_authn_session_data).HasColumnType("jsonb");

            entity.HasOne(d => d.factor).WithMany(p => p.mfa_challenges)
                .HasForeignKey(d => d.factor_id)
                .HasConstraintName("mfa_challenges_auth_factor_id_fkey");
        });

        modelBuilder.Entity<mfa_factors>(entity =>
        {
            entity.HasKey(e => e.id).HasName("mfa_factors_pkey");

            entity.ToTable("mfa_factors", "auth", tb => tb.HasComment("auth: stores metadata about factors"));

            entity.HasIndex(e => new { e.user_id, e.created_at }, "factor_id_created_at_idx");

            entity.HasIndex(e => e.last_challenged_at, "mfa_factors_last_challenged_at_key").IsUnique();

            entity.HasIndex(e => new { e.friendly_name, e.user_id }, "mfa_factors_user_friendly_name_unique")
                .IsUnique()
                .HasFilter("(TRIM(BOTH FROM friendly_name) <> ''::text)");

            entity.HasIndex(e => e.user_id, "mfa_factors_user_id_idx");

            entity.HasIndex(e => new { e.user_id, e.phone }, "unique_phone_factor_per_user").IsUnique();

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.web_authn_credential).HasColumnType("jsonb");

            entity.HasOne(d => d.user).WithMany(p => p.mfa_factors)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("mfa_factors_user_id_fkey");
        });

        modelBuilder.Entity<migrations>(entity =>
        {
            entity.HasKey(e => e.id).HasName("migrations_pkey");

            entity.ToTable("migrations", "storage");

            entity.HasIndex(e => e.name, "migrations_name_key").IsUnique();

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.executed_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.hash).HasMaxLength(40);
            entity.Property(e => e.name).HasMaxLength(100);
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

        modelBuilder.Entity<objects>(entity =>
        {
            entity.HasKey(e => e.id).HasName("objects_pkey");

            entity.ToTable("objects", "storage");

            entity.HasIndex(e => new { e.bucket_id, e.name }, "bucketid_objname").IsUnique();

            entity.HasIndex(e => new { e.bucket_id, e.name }, "idx_objects_bucket_id_name").UseCollation(new[] { null, "C" });

            entity.HasIndex(e => e.name, "name_prefix_search").HasOperators(new[] { "text_pattern_ops" });

            entity.Property(e => e.id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.last_accessed_at).HasDefaultValueSql("now()");
            entity.Property(e => e.metadata).HasColumnType("jsonb");
            entity.Property(e => e.owner).HasComment("Field is deprecated, use owner_id instead");
            entity.Property(e => e.path_tokens).HasComputedColumnSql("string_to_array(name, '/'::text)", true);
            entity.Property(e => e.updated_at).HasDefaultValueSql("now()");
            entity.Property(e => e.user_metadata).HasColumnType("jsonb");

            entity.HasOne(d => d.bucket).WithMany(p => p.objects)
                .HasForeignKey(d => d.bucket_id)
                .HasConstraintName("objects_bucketId_fkey");
        });

        modelBuilder.Entity<one_time_tokens>(entity =>
        {
            entity.HasKey(e => e.id).HasName("one_time_tokens_pkey");

            entity.ToTable("one_time_tokens", "auth");

            entity.HasIndex(e => e.relates_to, "one_time_tokens_relates_to_hash_idx").HasMethod("hash");

            entity.HasIndex(e => e.token_hash, "one_time_tokens_token_hash_hash_idx").HasMethod("hash");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.user).WithMany(p => p.one_time_tokens)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("one_time_tokens_user_id_fkey");
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
            entity.Property(e => e.productmetadatavaluesid).HasColumnType("character varying");
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
            entity.Property(e => e.unitmeasureid).HasMaxLength(50);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);

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

        modelBuilder.Entity<refresh_tokens>(entity =>
        {
            entity.HasKey(e => e.id).HasName("refresh_tokens_pkey");

            entity.ToTable("refresh_tokens", "auth", tb => tb.HasComment("Auth: Store of tokens used to refresh JWT tokens once they expire."));

            entity.HasIndex(e => e.instance_id, "refresh_tokens_instance_id_idx");

            entity.HasIndex(e => new { e.instance_id, e.user_id }, "refresh_tokens_instance_id_user_id_idx");

            entity.HasIndex(e => e.parent, "refresh_tokens_parent_idx");

            entity.HasIndex(e => new { e.session_id, e.revoked }, "refresh_tokens_session_id_revoked_idx");

            entity.HasIndex(e => e.token, "refresh_tokens_token_unique").IsUnique();

            entity.HasIndex(e => e.updated_at, "refresh_tokens_updated_at_idx").IsDescending();

            entity.Property(e => e.parent).HasMaxLength(255);
            entity.Property(e => e.token).HasMaxLength(255);
            entity.Property(e => e.user_id).HasMaxLength(255);

            entity.HasOne(d => d.session).WithMany(p => p.refresh_tokens)
                .HasForeignKey(d => d.session_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("refresh_tokens_session_id_fkey");
        });

        modelBuilder.Entity<s3_multipart_uploads>(entity =>
        {
            entity.HasKey(e => e.id).HasName("s3_multipart_uploads_pkey");

            entity.ToTable("s3_multipart_uploads", "storage");

            entity.HasIndex(e => new { e.bucket_id, e.key, e.created_at }, "idx_multipart_uploads_list").UseCollation(new[] { null, "C", null });

            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.in_progress_size).HasDefaultValue(0L);
            entity.Property(e => e.key).UseCollation("C");
            entity.Property(e => e.user_metadata).HasColumnType("jsonb");

            entity.HasOne(d => d.bucket).WithMany(p => p.s3_multipart_uploads)
                .HasForeignKey(d => d.bucket_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("s3_multipart_uploads_bucket_id_fkey");
        });

        modelBuilder.Entity<s3_multipart_uploads_parts>(entity =>
        {
            entity.HasKey(e => e.id).HasName("s3_multipart_uploads_parts_pkey");

            entity.ToTable("s3_multipart_uploads_parts", "storage");

            entity.Property(e => e.id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.key).UseCollation("C");
            entity.Property(e => e.size).HasDefaultValue(0L);

            entity.HasOne(d => d.bucket).WithMany(p => p.s3_multipart_uploads_parts)
                .HasForeignKey(d => d.bucket_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("s3_multipart_uploads_parts_bucket_id_fkey");

            entity.HasOne(d => d.upload).WithMany(p => p.s3_multipart_uploads_parts)
                .HasForeignKey(d => d.upload_id)
                .HasConstraintName("s3_multipart_uploads_parts_upload_id_fkey");
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

        modelBuilder.Entity<saml_providers>(entity =>
        {
            entity.HasKey(e => e.id).HasName("saml_providers_pkey");

            entity.ToTable("saml_providers", "auth", tb => tb.HasComment("Auth: Manages SAML Identity Provider connections."));

            entity.HasIndex(e => e.entity_id, "saml_providers_entity_id_key").IsUnique();

            entity.HasIndex(e => e.sso_provider_id, "saml_providers_sso_provider_id_idx");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.attribute_mapping).HasColumnType("jsonb");

            entity.HasOne(d => d.sso_provider).WithMany(p => p.saml_providers)
                .HasForeignKey(d => d.sso_provider_id)
                .HasConstraintName("saml_providers_sso_provider_id_fkey");
        });

        modelBuilder.Entity<saml_relay_states>(entity =>
        {
            entity.HasKey(e => e.id).HasName("saml_relay_states_pkey");

            entity.ToTable("saml_relay_states", "auth", tb => tb.HasComment("Auth: Contains SAML Relay State information for each Service Provider initiated login."));

            entity.HasIndex(e => e.created_at, "saml_relay_states_created_at_idx").IsDescending();

            entity.HasIndex(e => e.for_email, "saml_relay_states_for_email_idx");

            entity.HasIndex(e => e.sso_provider_id, "saml_relay_states_sso_provider_id_idx");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.flow_state).WithMany(p => p.saml_relay_states)
                .HasForeignKey(d => d.flow_state_id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("saml_relay_states_flow_state_id_fkey");

            entity.HasOne(d => d.sso_provider).WithMany(p => p.saml_relay_states)
                .HasForeignKey(d => d.sso_provider_id)
                .HasConstraintName("saml_relay_states_sso_provider_id_fkey");
        });

        modelBuilder.Entity<schema_migrations>(entity =>
        {
            entity.HasKey(e => e.version).HasName("schema_migrations_pkey");

            entity.ToTable("schema_migrations", "auth", tb => tb.HasComment("Auth: Manages updates to the auth system."));

            entity.Property(e => e.version).HasMaxLength(255);
        });

        modelBuilder.Entity<schema_migrations1>(entity =>
        {
            entity.HasKey(e => e.version).HasName("schema_migrations_pkey");

            entity.ToTable("schema_migrations", "realtime");

            entity.Property(e => e.version).ValueGeneratedNever();
            entity.Property(e => e.inserted_at).HasColumnType("timestamp(0) without time zone");
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

        modelBuilder.Entity<sessions>(entity =>
        {
            entity.HasKey(e => e.id).HasName("sessions_pkey");

            entity.ToTable("sessions", "auth", tb => tb.HasComment("Auth: Stores session data associated to a user."));

            entity.HasIndex(e => e.not_after, "sessions_not_after_idx").IsDescending();

            entity.HasIndex(e => e.user_id, "sessions_user_id_idx");

            entity.HasIndex(e => new { e.user_id, e.created_at }, "user_id_created_at_idx");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.not_after).HasComment("Auth: Not after is a nullable column that contains a timestamp after which the session should be regarded as expired.");
            entity.Property(e => e.refreshed_at).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.user).WithMany(p => p.sessions)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("sessions_user_id_fkey");
        });

        modelBuilder.Entity<sso_domains>(entity =>
        {
            entity.HasKey(e => e.id).HasName("sso_domains_pkey");

            entity.ToTable("sso_domains", "auth", tb => tb.HasComment("Auth: Manages SSO email address domain mapping to an SSO Identity Provider."));

            entity.HasIndex(e => e.sso_provider_id, "sso_domains_sso_provider_id_idx");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.sso_provider).WithMany(p => p.sso_domains)
                .HasForeignKey(d => d.sso_provider_id)
                .HasConstraintName("sso_domains_sso_provider_id_fkey");
        });

        modelBuilder.Entity<sso_providers>(entity =>
        {
            entity.HasKey(e => e.id).HasName("sso_providers_pkey");

            entity.ToTable("sso_providers", "auth", tb => tb.HasComment("Auth: Manages SSO identity provider information; see saml_providers for SAML."));

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.resource_id).HasComment("Auth: Uniquely identifies a SSO provider according to a user-chosen resource ID (case insensitive), useful in infrastructure as code.");
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

        modelBuilder.Entity<subscription>(entity =>
        {
            entity.HasKey(e => e.id).HasName("pk_subscription");

            entity.ToTable("subscription", "realtime");

            entity.Property(e => e.id).UseIdentityAlwaysColumn();
            entity.Property(e => e.claims).HasColumnType("jsonb");
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("timezone('utc'::text, now())")
                .HasColumnType("timestamp without time zone");
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

        modelBuilder.Entity<token>(entity =>
        {
            entity.HasKey(e => e.id).HasName("token_pk");

            entity.Property(e => e.id).HasMaxLength(50);
            entity.Property(e => e.createdbyid).HasMaxLength(450);
            entity.Property(e => e.isdeleted).HasColumnType("bit(1)");
            entity.Property(e => e.refreshtoken).HasMaxLength(255);
            entity.Property(e => e.updatedbyid).HasMaxLength(450);
            entity.Property(e => e.userid).HasMaxLength(450);
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
            entity.HasKey(e => e.id).HasName("users_pkey");

            entity.ToTable("users", "auth", tb => tb.HasComment("Auth: Stores user login data within a secure schema."));

            entity.HasIndex(e => e.confirmation_token, "confirmation_token_idx")
                .IsUnique()
                .HasFilter("((confirmation_token)::text !~ '^[0-9 ]*$'::text)");

            entity.HasIndex(e => e.email_change_token_current, "email_change_token_current_idx")
                .IsUnique()
                .HasFilter("((email_change_token_current)::text !~ '^[0-9 ]*$'::text)");

            entity.HasIndex(e => e.email_change_token_new, "email_change_token_new_idx")
                .IsUnique()
                .HasFilter("((email_change_token_new)::text !~ '^[0-9 ]*$'::text)");

            entity.HasIndex(e => e.reauthentication_token, "reauthentication_token_idx")
                .IsUnique()
                .HasFilter("((reauthentication_token)::text !~ '^[0-9 ]*$'::text)");

            entity.HasIndex(e => e.recovery_token, "recovery_token_idx")
                .IsUnique()
                .HasFilter("((recovery_token)::text !~ '^[0-9 ]*$'::text)");

            entity.HasIndex(e => e.email, "users_email_partial_key")
                .IsUnique()
                .HasFilter("(is_sso_user = false)");

            entity.HasIndex(e => e.instance_id, "users_instance_id_idx");

            entity.HasIndex(e => e.is_anonymous, "users_is_anonymous_idx");

            entity.HasIndex(e => e.phone, "users_phone_key").IsUnique();

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.aud).HasMaxLength(255);
            entity.Property(e => e.confirmation_token).HasMaxLength(255);
            entity.Property(e => e.confirmed_at).HasComputedColumnSql("LEAST(email_confirmed_at, phone_confirmed_at)", true);
            entity.Property(e => e.email).HasMaxLength(255);
            entity.Property(e => e.email_change).HasMaxLength(255);
            entity.Property(e => e.email_change_confirm_status).HasDefaultValue((short)0);
            entity.Property(e => e.email_change_token_current)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.email_change_token_new).HasMaxLength(255);
            entity.Property(e => e.encrypted_password).HasMaxLength(255);
            entity.Property(e => e.is_anonymous).HasDefaultValue(false);
            entity.Property(e => e.is_sso_user)
                .HasDefaultValue(false)
                .HasComment("Auth: Set this column to true when the account comes from SSO. These accounts can have duplicate emails.");
            entity.Property(e => e.phone).HasDefaultValueSql("NULL::character varying");
            entity.Property(e => e.phone_change).HasDefaultValueSql("''::character varying");
            entity.Property(e => e.phone_change_token)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.raw_app_meta_data).HasColumnType("jsonb");
            entity.Property(e => e.raw_user_meta_data).HasColumnType("jsonb");
            entity.Property(e => e.reauthentication_token)
                .HasMaxLength(255)
                .HasDefaultValueSql("''::character varying");
            entity.Property(e => e.recovery_token).HasMaxLength(255);
            entity.Property(e => e.role).HasMaxLength(255);
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
        modelBuilder.HasSequence<int>("seq_schema_version", "graphql").IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

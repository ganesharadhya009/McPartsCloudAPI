using Mcparts.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record UserLoginDto
    {
        public string email { get; set; } = null!;

        public string? password { get; set; }
    }

    public record UserPasswordResetDto
    {
        public string email { get; set; } = null!;

        public string? newPassword { get; set; }

    }

    public record usersdtoGet : usersdtoBase
    {
        public string id { get; set; }
        public string? token { get; set; }
    }

    public record usersdto : usersdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record usersdtoBase : EntityDtoBase
    {

        public string? usertype { get; set; }

        public string? firstname { get; set; }

        public string? lastname { get; set; }

        public string? primarycontactnumber { get; set; }

        public string? secondarycontactnumber { get; set; }

        public string? address1 { get; set; }

        public string? address2 { get; set; }

        public string? street { get; set; }

        public string? district { get; set; }

        public string? pincode { get; set; }

        public string? email { get; set; }

        public string? userstatusid { get; set; }

        public string? password { get; set; }

        public string? propertyid { get; set; }

        public string? gender { get; set; }

        public byte[]? idproof { get; set; }

        public byte[]? photo { get; set; }

        public string? area { get; set; }

        public string? idproofname { get; set; }

        public string? photoname { get; set; }

        public string? referredby { get; set; }

        public string? temporarypassword { get; set; }

        public DateTime? registereddate { get; set; }

    }
}


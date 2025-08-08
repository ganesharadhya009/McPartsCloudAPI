﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McParts.Core.Domain
{
    public record PasswordEncrypt
    {
        public byte[]? EncryptedPassword { get; set; }
        public byte[]? Key { get; set; }
        public byte[]? IV { get; set; }
    }
}

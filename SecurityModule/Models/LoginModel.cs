﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Models
{
    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool isEmployee { get; set; } = false;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}

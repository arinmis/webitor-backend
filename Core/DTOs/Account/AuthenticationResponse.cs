﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.DTOs.Account
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string JWToken { get; set; }
        public List<string> Roles { get; set; }
    }
}
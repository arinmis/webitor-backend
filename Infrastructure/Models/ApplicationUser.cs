﻿using Core.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Core.Entities;

namespace Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }

        public ICollection<File> Files;
    }
}

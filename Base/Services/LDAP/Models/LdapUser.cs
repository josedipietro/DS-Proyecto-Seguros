using System;
using System.Collections.Generic;

namespace Base.Services.LDAP.Models
{
    public class LdapUser
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public string[] Roles { get; set; }
    }
}

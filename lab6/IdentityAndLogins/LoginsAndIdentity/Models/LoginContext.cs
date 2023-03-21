using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginsAndIdentity.Models
{
    public class LoginContext : DbContext
    {
        public LoginContext() : base("IdentityConn")
        {

        }
        public DbSet<Client> Clients {get; set;}
    }
}
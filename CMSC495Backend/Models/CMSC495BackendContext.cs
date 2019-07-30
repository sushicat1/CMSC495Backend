using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMSC495Backend.Models
{
    public class CMSC495BackendContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CMSC495BackendContext() : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<CMSC495Backend.Models.Users> Users { get; set; }
        public System.Data.Entity.DbSet<CMSC495Backend.Models.Deck> Decks { get; set; }
        public System.Data.Entity.DbSet<CMSC495Backend.Models.Card> Cards { get; set; }
    }
}

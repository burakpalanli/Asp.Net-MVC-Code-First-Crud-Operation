using CodeFirstCrud.Models.Entity;
using CodeFirstCrud.Models.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstCrud.Models.Context
{
    public class ProjectContext : DbContext
    {

        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server =servername; Database = CodeFirstCrudDB; UID = username; PWD = password; ";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

    }
}
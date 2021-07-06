using Microsoft.EntityFrameworkCore;
using RegistrationPrototype.DataAccess.Sql.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationPrototype.DataAccess.Sql.Repository
{
   public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options):base(options)
        { }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Login> Login { get; set; }

        public virtual DbSet<PersonelDetails> PersonelDetails { get; set; }

        // private override void OnModelBuilding()


    }
}

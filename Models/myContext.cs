using System;
using System.Data.Entity;
using System.Linq;

namespace SignalR.Models
{
    public class myContext : DbContext
    {
        public myContext()
            : base("name=myContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users{ get; set; }
        public virtual DbSet<Group> Groups { get; set; }
    }

    
}
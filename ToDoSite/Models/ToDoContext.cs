using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoSite.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext()
            : base("ToDoConnection")
        {

        }

        public DbSet<ToDoTask> Tasks { get; set; }
    }
}
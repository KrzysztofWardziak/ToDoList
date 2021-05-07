using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Model;

namespace ToDoList.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<ToDo> ToDoLists { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }
    }
}

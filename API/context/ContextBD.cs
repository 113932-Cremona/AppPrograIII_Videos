﻿using Clases.Models;
using Microsoft.EntityFrameworkCore;

namespace API.context
{
    public class ContextBD : DbContext
    {

        public ContextBD(DbContextOptions options) : base(options) { 
        
        }

        public DbSet<Usuario> Usuario { get; set; }

    }
}

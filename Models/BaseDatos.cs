using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class BaseDatos : DbContext
    {
        public BaseDatos(DbContextOptions opciones)
            : base(opciones)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}

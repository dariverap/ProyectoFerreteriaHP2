﻿using api_ferreteria.Entitys;
using Microsoft.EntityFrameworkCore;

namespace api_ferreteria
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        //configurando las tablas de la base de datos
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Documento> Documento { get; set; }
        public DbSet<FormaPago> FormaPago { get; set; }
    }
}

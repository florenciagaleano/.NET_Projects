using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Datos
{
    public class VuelosDBContext : DbContext
    {
        public VuelosDBContext()
            : base("KeyDB")
        {

        }

        public DbSet<Vuelo> Vuelos { get; set; }
    }
}
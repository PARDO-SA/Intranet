using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Intranet.Models.Clases;
using Intranet.Models.Clases.Consultas;

namespace Intranet.Models.Contexto
{
    public class CentralDBContexto:DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<ViewComisiones> ViewComisiones { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Intranet.Models.Login;

namespace Intranet.Models.Contexto
{
    public class SistemaDBContexto:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
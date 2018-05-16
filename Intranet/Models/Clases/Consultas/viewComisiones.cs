using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Intranet.Models.Clases.Consultas
{
    public class ViewComisiones
    {
        [DisplayFormat(DataFormatString = "{0:0##}")]
        public int Sucursal { get; set; }
        public string SucursalNombre { get; set;}
        [Key]
        public string Nombre { get; set; }
        public string Funcion { get; set; }
        [DisplayFormat(DataFormatString = "{0:##,###,##0}")]
        public decimal Cobrado { get; set; }
        [DisplayFormat(DataFormatString = "{0:##,###,##0}")]
        public decimal ComisionVen { get; set; }
        [DisplayFormat(DataFormatString = "{0:##,###,##0}")]
        public decimal ComisionSuc { get; set; }
        [DisplayFormat(DataFormatString = "{0:##,###,##0}")]
        public decimal ACobrar { get; set; }
        [DisplayFormat(DataFormatString = "{0:##,###,##0}")]
        public decimal RestaCobrar { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LaboratorioPWA.Models
{
    public class LocalCat
    {
        public int idcategoria { get; set; }
        public string nomCategoria { get; set; }
        public string imagenCat { get; set; }
        public string file { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
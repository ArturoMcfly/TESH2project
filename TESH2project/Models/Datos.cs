using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TESH2project.Models
{
    public class Datos//nombre de la tabla de la base de datos
    {
        public string Nombre//columna de basde de datos
        {
            get;set;//estructura lectura y escritura
        }
        public string Compania
        {
            get; set;
        }
        public int Empleados
        {
            get; set;
        }
    }
}
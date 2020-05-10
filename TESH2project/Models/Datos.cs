using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//Esta libreria contiene los atributos de entyt
using System.ComponentModel;
namespace TESH2project.Models
{
    public class Datos//nombre de la tabla de la base de datos
    {
        [Key, Required]//Llave primaria, con la coma se le pueden asignar diversos atributos
        public int Id { get; set; }
        [Required]
        public string Nombre//columna de basde de datos
        {
            get;set;//estructura lectura y escritura
        }
        [DisplayName("compañia")]
        public string Compania
        {
            get; set;
        }
        [Required]
        public int Empleados
        {
            get; set;
        }
    }
}
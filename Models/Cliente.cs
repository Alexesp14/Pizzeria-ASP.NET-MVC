using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS903_Espinosa_Jesus_Examen1P.Models
{
    public class Cliente
    {
        string nombre;
        string direccion;
        string telefono;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
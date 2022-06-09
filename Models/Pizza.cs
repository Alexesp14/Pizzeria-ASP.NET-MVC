using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS903_Espinosa_Jesus_Examen1P.Models
{
    public class Pizza
    {
        string tamaño;
        List<string> ingredientes;
        int cantidad;

        public string Tamaño { get => tamaño; set => tamaño = value; }
        public List<string> Ingredientes { get => ingredientes; set => ingredientes = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Subtotal()
        {
            var subtotal = 0;
            switch (Tamaño)
            {
                case "Chica":
                    subtotal += 40;
                    break;
                case "Mediana":
                    subtotal += 80;
                    break;
                case "Grande":
                    subtotal += 120;
                    break;
            }
            subtotal += (Ingredientes.Count * 10);
            subtotal *= Cantidad;
            return subtotal;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS903_Espinosa_Jesus_Examen1P.Models
{
    public class Pedido
    {
        Cliente cliente;
        List<Pizza> pizzas;
        DateTime fechaPedido;
        public Pedido()
        {
            cliente = new Cliente();
            pizzas = new List<Pizza>();
            fechaPedido = DateTime.Now;
        }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public List<Pizza> Pizzas { get => pizzas; set => pizzas = value; }
        public DateTime FechaPedido { get => fechaPedido; set => fechaPedido = value; }

        public double Total()
        {
            double total = 0;
            if(Pizzas.Count > 0)
            {
                foreach(var p in Pizzas)
                {
                    total += p.Subtotal();
                }
            }
            return total;
        }
    }
}
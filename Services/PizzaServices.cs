using IDGS903_Espinosa_Jesus_Examen1P.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace IDGS903_Espinosa_Jesus_Examen1P.Services
{
    public class PizzaServices
    {
        public List<Pedido> LeerArchivo()
        {
            List<Pedido> pedidos = new List<Pedido>();
            var dataFile = HttpContext.Current.Server.MapPath("~/App_Data/datos.txt");
            if (File.Exists(dataFile))
            {
                foreach(string json in File.ReadLines(dataFile))
                {
                    var pedido = JsonSerializer.Deserialize<Pedido>(json);
                    pedidos.Add(pedido);
                }
            }
            return pedidos;
        }
        public List<Pedido> LeerArchivoFiltro(int mes)
        {
            List<Pedido> pedidos = new List<Pedido>();
            var dataFile = HttpContext.Current.Server.MapPath("~/App_Data/datos.txt");
            if (File.Exists(dataFile))
            {
                foreach (string json in File.ReadLines(dataFile))
                {
                    var pedido = JsonSerializer.Deserialize<Pedido>(json);
                    if (pedido.FechaPedido.Month == mes)
                    {
                        pedidos.Add(pedido);
                    }
                }
            }
            return pedidos;
        }
        public List<Pedido> LeerArchivoFiltro(string dia)
        {
            List<Pedido> pedidos = new List<Pedido>();
            var dataFile = HttpContext.Current.Server.MapPath("~/App_Data/datos.txt");
            if (File.Exists(dataFile))
            {
                foreach (string json in File.ReadLines(dataFile))
                {
                    var pedido = JsonSerializer.Deserialize<Pedido>(json);
                    string dateDia = pedido.FechaPedido.ToString("dddd");
                    if (dia.Equals(dateDia))
                    {
                        pedidos.Add(pedido);
                    }
                }
            }
            return pedidos;
        }
        public Pedido DetallePedido(string p)
        {
            var pedido = JsonSerializer.Deserialize<Pedido>(p);
            return pedido;
        }
        public void GuardarArchivo(Pedido pedido)
        {
            var json = JsonSerializer.Serialize(pedido) + Environment.NewLine;
            var archivo = HttpContext.Current.Server.MapPath("~/App_Data/datos.txt");
            File.AppendAllText(@archivo, json);
        }
    }
}
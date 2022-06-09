using IDGS903_Espinosa_Jesus_Examen1P.Models;
using System.Web.Mvc;
using System.Text.Json;
using System.Web;
using IDGS903_Espinosa_Jesus_Examen1P.Services;
using System;
using System.Collections.Generic;

namespace IDGS903_Espinosa_Jesus_Examen1P.Controllers
{
    public class PedidoController : Controller
    {
        PizzaServices op = new PizzaServices();
        public ActionResult RegistrarDatos()
        {
            return View();
        }
        public ActionResult Generar()
        {
            Pedido p = null;
            return View(p);
        }
        [HttpPost]
        public ActionResult Generar(Pedido p, int op, string Tamaño, string[] listaIngredientes, int Cantidad)
        {
            switch (op)
            {
                case 1:
                    Session["p"] = p;
                    break;
                case 2:
                    List<string> Ingredientes = new List<string>(listaIngredientes);
                    Pizza pizza = new Pizza() { Tamaño = Tamaño, Ingredientes = Ingredientes, Cantidad = Cantidad };
                    p = new Pedido();
                    p = (Pedido)Session["p"];
                    p.Pizzas.Add(pizza);
                    break;
                case 3:
                    p = (Pedido)Session["p"];
                    this.op.GuardarArchivo(p);
                    return RedirectToAction("Ver");
            }
            return View(p);
        }
        public ActionResult Ver()
        {
            var model = op.LeerArchivo();
            return View(model);
        }
        [HttpPost]
        public ActionResult Ver(string filtro, string dia, int mes)
        {
            List<Pedido> model = new List<Pedido>();
            if (filtro == null)
            {
                model = op.LeerArchivo();
            }
            if(filtro == "Dia")
            {
                Session["Filter"] = true;
                model = op.LeerArchivoFiltro(dia);
            }
            if (filtro == "Mes")
            {
                Session["Filter"] = true;
                model = op.LeerArchivoFiltro(mes);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Detalle(string p)
        {
            var pedido = op.DetallePedido(p);
            return View(pedido);
        }
    }
}
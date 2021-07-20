using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PIE.Inventario.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PIE.Entities.Catalogo;
using PIE.Bussines.Inventario;

namespace PIE.Inventario.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetListaProductosBySucursal()
        {
            List<ProductoEntity> listaProductos;
            using (InventarioBusiness getProductos = new InventarioBusiness())
            {
                listaProductos = getProductos.GetProductosByIDSucursal();
            }
            return Json(new { data = listaProductos });
        }
    }
}

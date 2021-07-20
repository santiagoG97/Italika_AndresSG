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
        public IActionResult Index(bool TieneMensaje, string Mensaje)
        {
            ViewBag.TieneMensaje = TieneMensaje;
            ViewBag.Mensaje = Mensaje;
            TieneMensaje = false;
            Mensaje = "";
            return View();
        }
        public ActionResult GetListaProductosGeneral()
        {
            List<ProductoEntity> listaProductos;
            using (InventarioBusiness getProductos = new InventarioBusiness())
            {
                listaProductos = getProductos.GetListaProductosGeneral();
            }
            return Json(new { data = listaProductos });
        }
        public JsonResult EliminarProducto(int IdProducto)
        {
            using (InventarioBusiness setCompra = new InventarioBusiness())
            {
                setCompra.EliminarProducto(IdProducto);
            }
            return Json("'Success':'true'");
        }
        public ActionResult GetProductoById(int IdProducto)
        {
            ProductoEntity objProductos;
            using (InventarioBusiness getProductos = new InventarioBusiness())
            {
                objProductos = getProductos.GetProductoById(IdProducto);
            }
            return Json(new { data = objProductos });
        }
        public ActionResult GetListaTipoProducto()
        {
            List<TipoEntity> listaTipoProducto;
            using (InventarioBusiness getTipoProducto = new InventarioBusiness())
            {
                listaTipoProducto = getTipoProducto.GetListaTipoProducto();
            }
            return Json(new { data = listaTipoProducto });
        }
        public ActionResult obtenerListaModeloByIdTipo(int IdTipo)
        {
            List<ModeloEntity> listaTipoProducto;
            using (InventarioBusiness getTipoProducto = new InventarioBusiness())
            {
                listaTipoProducto = getTipoProducto.obtenerListaModeloByIdTipo(IdTipo);
            }
            return Json(new { data = listaTipoProducto });
        }
        public IActionResult ActualizaProducto(ProductoEntity Model)
        {
            string Mensaje = "";
            using (InventarioBusiness setProducto = new InventarioBusiness())
            {
                setProducto.ActualizaProducto(Model);
                Mensaje = "¡Operación exitosa!/¡Actualización realizada con éxito!/success";
            }
            return RedirectToAction("Index", "Home", new { TieneMensaje = true, Mensaje = Mensaje });
        }
    }
}

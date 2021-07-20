using System;
using System.Collections.Generic;
using System.Text;

namespace PIE.Data.StoredProcedures
{
    public class InventarioSP
    {
        public static string GetProductosGeneral = "[Catalogo].[spObtenerListaProductos]";
        public static string EliminaProducto = "[Inventario].[spEliminarProducto]";
        public static string ObtenerProductosById = "[Catalogo].[spObtenerProductosById]";
        public static string ObtenerTipoProducto = "[Catalogo].[spObtenerListaTipoProducto]";
        public static string ObtenerModeloProductoByIdTipo = "[Catalogo].[spObtenerModeloProductoByIdTipo]";
        public static string ActualizaProducto = "[Catalogo].[spActualizaProducto]";
    }
}

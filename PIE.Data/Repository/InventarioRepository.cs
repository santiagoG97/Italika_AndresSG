using System;
using System.Collections.Generic;
using System.Text;
using PIE.Entities.Catalogo;
using PIE.Data.StoredProcedures;
using System.Data;
using System.Data.SqlClient;

namespace PIE.Data.Repository
{
    public class InventarioRepository : IDisposable
    {
        public void Dispose() {
            GC.SuppressFinalize(this);
        }
        public List<ProductoEntity> GetProductosByIdSucursal(string DBCnn) {
            SqlDataReader DatosReader;
            using (ContextoDB DataObj = new ContextoDB(DBCnn)) {
                DatosReader = DataObj.EjecutaSP(InventarioSP.GetProductosGeneral);
                List<ProductoEntity> listaProductos = new List<ProductoEntity>();

                while (DatosReader.Read()) {
                    ProductoEntity objProductos = new ProductoEntity();
                    objProductos.Id = string.IsNullOrEmpty(DatosReader["Id"].ToString()) ? new long() : Convert.ToInt64(DatosReader["Id"].ToString());
                    objProductos.SKU = DatosReader["SKU"].ToString();
                    objProductos.Fert = DatosReader["Fert"].ToString();
                    objProductos.NumSerie = DatosReader["NumSerie"].ToString();
                    objProductos.objModelo = new ModeloEntity();
                    objProductos.objModelo.Descripcion = DatosReader["Modelo"].ToString();
                    objProductos.objModelo.objTipo = new TipoEntity();
                    objProductos.objModelo.objTipo.Descripcion = DatosReader["Tipo"].ToString();
                    listaProductos.Add(objProductos);
                }
                return listaProductos;
            }
        }
    }
}

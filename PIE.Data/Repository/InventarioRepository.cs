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
        public List<ProductoEntity> GetListaProductosGeneral(string DBCnn) {
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
        public void EliminaProducto(string DBCnn, int IdProducto)
        {
            SqlDataReader DatosReader;
            using (ContextoDB DataObj = new ContextoDB(DBCnn))
            {
                SqlParameter[] _Parametros = new SqlParameter[] {
                    new SqlParameter("IdProducto", SqlDbType.Int){ Value = IdProducto}
                };
                DatosReader = DataObj.EjecutaSP(InventarioSP.EliminaProducto, _Parametros);
            }
        }
        public ProductoEntity GetProductoById(string DBCnn, int IdProducto)
        {
            SqlDataReader DatosReader;
            ProductoEntity objProductos = new ProductoEntity();
            using (ContextoDB DataObj = new ContextoDB(DBCnn))
            {
                SqlParameter[] _Parametros = new SqlParameter[] {
                    new SqlParameter("IdProducto", SqlDbType.Int){ Value = IdProducto}
                };
                DatosReader = DataObj.EjecutaSP(InventarioSP.ObtenerProductosById, _Parametros);
                while (DatosReader.Read())
                {
                    objProductos.Id = string.IsNullOrEmpty(DatosReader["Id"].ToString()) ? new long() : Convert.ToInt64(DatosReader["Id"].ToString());
                    objProductos.SKU = DatosReader["SKU"].ToString();
                    objProductos.Fert = DatosReader["Fert"].ToString();
                    objProductos.NumSerie = DatosReader["NumSerie"].ToString();
                    objProductos.Fk_Modelo = string.IsNullOrEmpty(DatosReader["Fk_Modelo"].ToString()) ? new long() : Convert.ToInt64(DatosReader["Fk_Modelo"].ToString());
                    objProductos.objModelo = new ModeloEntity();
                    objProductos.objModelo.Fk_IdTipo = string.IsNullOrEmpty(DatosReader["Fk_IdTipo"].ToString()) ? new long() : Convert.ToInt64(DatosReader["Fk_IdTipo"].ToString());
                }
                return objProductos;
            }
        }
        public List<TipoEntity> GetListaTipoProducto(string DBCnn)
        {
            SqlDataReader DatosReader;
            using (ContextoDB DataObj = new ContextoDB(DBCnn))
            {
                DatosReader = DataObj.EjecutaSP(InventarioSP.ObtenerTipoProducto);
                List<TipoEntity> listaTipoProductos = new List<TipoEntity>();

                while (DatosReader.Read())
                {
                    TipoEntity objTipo = new TipoEntity();
                    objTipo.Id = string.IsNullOrEmpty(DatosReader["Id"].ToString()) ? new long() : Convert.ToInt64(DatosReader["Id"].ToString());
                    objTipo.Descripcion = DatosReader["Descripcion"].ToString();
                    listaTipoProductos.Add(objTipo);
                }
                return listaTipoProductos;
            }
        }
        public List<ModeloEntity> obtenerListaModeloByIdTipo(string DBCnn, int IdTipo)
        {
            SqlDataReader DatosReader;
            List<ModeloEntity> listaModeloProducto = new List<ModeloEntity>();
            using (ContextoDB DataObj = new ContextoDB(DBCnn))
            {
                SqlParameter[] _Parametros = new SqlParameter[] {
                    new SqlParameter("IdTipoProducto", SqlDbType.Int){ Value = IdTipo}
                };
                DatosReader = DataObj.EjecutaSP(InventarioSP.ObtenerModeloProductoByIdTipo, _Parametros);
                while (DatosReader.Read())
                {
                    ModeloEntity objTipo = new ModeloEntity();
                    objTipo.Id = string.IsNullOrEmpty(DatosReader["Id"].ToString()) ? new long() : Convert.ToInt64(DatosReader["Id"].ToString());
                    objTipo.Descripcion = DatosReader["Descripcion"].ToString();
                    listaModeloProducto.Add(objTipo);
                }
                return listaModeloProducto;
            }
        }
        public void ActualizaProducto(string DBCnn, ProductoEntity Model)
        {
            SqlDataReader DatosReader;
            using (ContextoDB DataObj = new ContextoDB(DBCnn))
            {
                SqlParameter[] _Parametros = new SqlParameter[] {
                    new SqlParameter("Id", SqlDbType.VarChar){ Value = Model.Id},
                    new SqlParameter("SKU", SqlDbType.VarChar){ Value = Model.SKU},
                    new SqlParameter("Fert", SqlDbType.VarChar){ Value = Model.Fert},
                    new SqlParameter("NumSerie", SqlDbType.VarChar){ Value = Model.NumSerie},
                    new SqlParameter("Fk_Modelo", SqlDbType.BigInt){ Value = Model.Fk_Modelo}
                };
                DatosReader = DataObj.EjecutaSP(InventarioSP.ActualizaProducto, _Parametros);
            }
        }
    }
}

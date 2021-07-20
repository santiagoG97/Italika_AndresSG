using System;
using System.Collections.Generic;
using System.Text;
using PIE.Entities.Catalogo;
using PIE.Bussines.Common;
using PIE.Data.Repository;

namespace PIE.Bussines.Inventario
{
    public class InventarioBusiness: IDisposable 
    {
        public void Dispose() {
            GC.SuppressFinalize(this);
        }
        public List<ProductoEntity> GetListaProductosGeneral() {
            using (InventarioRepository objDBD = new InventarioRepository()) {
                List<ProductoEntity> resutado = objDBD.GetListaProductosGeneral(DBSet.DBcnn);
                objDBD.Dispose();
                return resutado;
            }
        }
        public void EliminarProducto(int IdProducto)
        {
            using (InventarioRepository objDBD = new InventarioRepository())
            {
                objDBD.EliminaProducto(DBSet.DBcnn, IdProducto);
                objDBD.Dispose();
            }
        }
        public ProductoEntity GetProductoById(int IdProducto)
        {
            using (InventarioRepository objDBD = new InventarioRepository())
            {
                ProductoEntity resutado = objDBD.GetProductoById(DBSet.DBcnn, IdProducto);
                objDBD.Dispose();
                return resutado;
            }
        }
        public List<TipoEntity> GetListaTipoProducto()
        {
            using (InventarioRepository objDBD = new InventarioRepository())
            {
                List<TipoEntity> resutado = objDBD.GetListaTipoProducto(DBSet.DBcnn);
                objDBD.Dispose();
                return resutado;
            }
        }
        public List<ModeloEntity> obtenerListaModeloByIdTipo(int IdTipo)
        {
            using (InventarioRepository objDBD = new InventarioRepository())
            {
                List<ModeloEntity> resutado = objDBD.obtenerListaModeloByIdTipo(DBSet.DBcnn, IdTipo);
                objDBD.Dispose();
                return resutado;
            }
        }
        public void ActualizaProducto(ProductoEntity Model)
        {
            using (InventarioRepository objDBD = new InventarioRepository())
            {
                objDBD.ActualizaProducto(DBSet.DBcnn, Model);
                objDBD.Dispose();
            }
        }
    }
}

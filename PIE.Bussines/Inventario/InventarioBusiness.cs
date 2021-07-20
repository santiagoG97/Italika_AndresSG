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
        public List<ProductoEntity> GetProductosByIDSucursal() {
            using (InventarioRepository objDBD = new InventarioRepository()) {
                List<ProductoEntity> resutado = objDBD.GetProductosByIdSucursal(DBSet.DBcnn);
                objDBD.Dispose();
                return resutado;
            }
        }
       
    }
}

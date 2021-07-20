function cargarProductosTablaPrincipal() {
    $("#table_Products").dataTable().fnDestroy();
    $("#table_Products tbody").empty();
    $.ajax({
        type: "GET",
        url: "/Home/GetListaProductosBySucursal",
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            if (!$.isEmptyObject(data.data)) {
                var identChk = 0;
                $.each(data.data, function (key, entidad) {
                    var tr = '<tr>'
                        + '<td>' + entidad.sku + '</td>'
                        + '<td>' + entidad.fert + '</td>'
                        + '<td>' + entidad.numSerie + '</td>'
                        + '<td>' + entidad.objModelo.objTipo.descripcion + '</td>'
                        + '<td>' + entidad.objModelo.descripcion + '</td>'
                        + '<td><i class="fas fa-edit" onclick="abrirModal(' + entidad.id + ')" style="cursor: pointer;color:green;"></i>   <i class="fas fa-trash-alt" onclick="eliminarProducto(' + entidad.id + ')" style="cursor: pointer;color:red;"></i></td>'
                        + '</tr>';
                    $("#table_Products tbody").append(tr);
                    identChk += 1;
                });
                $("#table_Products").dataTable().api();
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            alert('Error!!' + xhr + ", " + textStatus + ", " + errorThrown);
        }
    });
}
function abrirModal(idProducto) {
    $('#dvEditarProducto').modal('show');
}
function eliminarProducto(idProducto) {
    swal({
        title: '¿Está seguro que desea eliminar este producto?',
        icon: 'warning',
        buttons: {
            cancel: "Cancelar",
            catch: {
                text: "OK",
                value: "Aceptar",
            }
        },
    }).then(function (value) {
        if (value == "Aceptar") {
            alert('Producto Eliminado con éxito');
        }
    }
    );
}




function cargarProductosTablaPrincipal() {
    $("#table_Products").dataTable().fnDestroy();
    $("#table_Products tbody").empty();
    $.ajax({
        type: "GET",
        url: "/Home/GetListaProductosGeneral",
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
                        + '<td><i class="fas fa-edit" onclick="abrirModalEditar(' + entidad.id + ')" style="cursor: pointer;color:green;"></i>   <i class="fas fa-trash-alt" onclick="eliminarProducto(' + entidad.id + ')" style="cursor: pointer;color:red;"></i></td>'
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
function abrirModalEditar(idProducto) {
    obtenerProductoById(idProducto);
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
            $.ajax({
                type: "POST",
                url: "/Home/EliminarProducto",
                data: { IdProducto: idProducto },
                content: "application/json; charset=utf-8",
                dataType: "json",
                success: function (info) {
                    swal("¡Operación realizada con éxito!", "Producto eliminado con éxito", "success")
                    cargarProductosTablaPrincipal()
                },
                error: function (xhr, textStatus, errorThrown) {
                    alert('Error!!');
                }
            });
        }
    });
}
function obtenerProductoById(idProducto) {
    $.ajax({
        type: "POST",
        url: "/Home/GetProductoById",
        data: { IdProducto: idProducto },
        content: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#txtIdProducto").val(data.data.id);
            $("#txtSku").val(data.data.sku);
            $("#txtFert").val(data.data.fert);
            $("#txtNumSerie").val(data.data.numSerie);
            obtenerListaTipoProductos(data.data.objModelo.fk_IdTipo,data.data.fk_Modelo);
        },
        error: function (xhr, textStatus, errorThrown) {
            alert('Error!!');
        }
    });
}
function obtenerListaTipoProductos(idTipo, idModelo) {
    $.ajax({
        type: "POST",
        url: "/Home/GetListaTipoProducto",
        content: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (!$.isEmptyObject(data.data)) {
                $("#ddlTipo").empty();
                $.each(data.data, function (key, entidad) {
                    var miSelect = document.getElementById("ddlTipo");
                    var miOption = document.createElement("option");
                    miOption.setAttribute("value", entidad.id);
                    miOption.setAttribute("label", entidad.descripcion);

                    if (entidad.id == idTipo) {
                        miOption.selected = true;
                    }
                    miSelect.appendChild(miOption);
                });
            }
            obtenerListaModeloByIdTipo(idTipo, idModelo);
        },
        error: function (xhr, textStatus, errorThrown) {
            alert('Error!!');
        }
    });
}
function obtenerListaModeloByIdTipo(idTipo, idModelo) {
    $.ajax({
        type: "POST",
        url: "/Home/obtenerListaModeloByIdTipo",
        data: { IdTipo: idTipo },
        content: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (!$.isEmptyObject(data.data)) {
                $("#ddlModelo").empty();
                $.each(data.data, function (key, entidad) {
                    var miSelect = document.getElementById("ddlModelo");
                    var miOption = document.createElement("option");
                    miOption.setAttribute("value", entidad.id);
                    miOption.setAttribute("label", entidad.descripcion);

                    if (entidad.id == idModelo) {
                        miOption.selected = true;
                    }
                    miSelect.appendChild(miOption);
                });
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            alert('Error!!');
        }
    });
}


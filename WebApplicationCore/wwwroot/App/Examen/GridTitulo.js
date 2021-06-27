"use strict";
var GridTitulo;
(function (GridTitulo) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea Eliminar Este Titulo?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Examen/GridTitulo?handler=Eliminar&id=" + id;
            }
        });
    }
    GridTitulo.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(GridTitulo || (GridTitulo = {}));
//# sourceMappingURL=GridTitulo.js.map
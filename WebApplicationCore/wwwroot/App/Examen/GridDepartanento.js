"use strict";
var GridDepartamento;
(function (GridDepartamento) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea Eliminar Este Departamento?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Examen/GridDepartamento?handler=Eliminar&id=" + id;
            }
        });
    }
    GridDepartamento.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(GridDepartamento || (GridDepartamento = {}));
//# sourceMappingURL=GridDepartanento.js.map
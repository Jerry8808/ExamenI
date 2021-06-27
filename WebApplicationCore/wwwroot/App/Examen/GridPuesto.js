"use strict";
var GridPuesto;
(function (GridPuesto) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea Eliminar Este Puesto?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Examen/GridPuesto?handler=Eliminar&id=" + id;
            }
        });
    }
    GridPuesto.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(GridPuesto || (GridPuesto = {}));
//# sourceMappingURL=GridPuesto.js.map
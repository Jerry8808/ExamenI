namespace GridTitulo {

    declare var MensajeApp;

    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        })
    }

    export function OnClickEliminar(id) {
        ComfirmAlert("Desea Eliminar Este Titulo?", "Eliminar", "warning", "#3085d6", "d33")
            .then(
                result => {
                    if (result.isConfirmed) {
                        window.location.href = "Examen/GridTitulo?handler=Eliminar&id=" + id;
                    }
                }
            );
    }

    $("#GridView").DataTable();
}
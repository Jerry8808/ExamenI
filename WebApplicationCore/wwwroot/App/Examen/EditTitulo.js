"use strict";
var EditTitulo;
(function (EditTitulo) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(EditTitulo || (EditTitulo = {}));
//# sourceMappingURL=EditTitulo.js.map
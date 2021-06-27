"use strict";
var EditDepartamento;
(function (EditDepartamento) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(EditDepartamento || (EditDepartamento = {}));
//# sourceMappingURL=EditDepartamento.js.map
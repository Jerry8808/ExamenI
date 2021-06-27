"use strict";
var EditPuesto;
(function (EditPuesto) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(EditPuesto || (EditPuesto = {}));
//# sourceMappingURL=EditPuesto.js.map
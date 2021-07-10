"use strict";
var VehiculoEdit;
(function (VehiculoEdit) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(VehiculoEdit || (VehiculoEdit = {}));
//# sourceMappingURL=Edit.js.map
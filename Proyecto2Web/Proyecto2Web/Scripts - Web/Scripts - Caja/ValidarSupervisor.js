// JavaScript source code

var valsup = angular.module("ValidarSupervisor", []);

valsup.controller('ValidarSupervisorController', function ($scope, $http) {
    $scope.idsupervisor;
    $scope.password;
    const url = "http://api-bd-tec2017-p2.azurewebsites.net/api/";
    $scope.eliminarprod = function () {
        if ($scope.idsupervisor != null &&
            $scope.password != null) {
            $http.get(url + "Personas/ValidSupervisor?id" + $scope.idsupervisor + "&&contrasena=" + scope.password)
                .then(function (response) {
                    if (response.data) {
                        var idF = window.localStorage.getItem("idfactura");
                        var idP = window.localStorage.getItem("idproducto");
                        var cant = window.localStorage.getItem("cantidadproducto");
                        $http.get(url + "Productos/BorrarProducto?idfactura" + idF + "&&idproducto=" + idP + "&&cantidad=" + cant)
                            .then(function (response) {
                                if (response.data) {
                                    //window.location = "http://proyecto2web.azurewebsites.net/Caja/addProductos.html";
                                    window.location = "http://localhost:61087/Caja/addProductos.html";
                                }
                                else {
                                    window.alert("Ocurrio un error al eliminar el producto");
                                }
                            });
                    }
                    else {
                        window.alert("Usuario o contraseña incorrecto");
                    }
                });


        }
        else {
            window.alert("Debe rellenar todos los campos");
        }
    }
});
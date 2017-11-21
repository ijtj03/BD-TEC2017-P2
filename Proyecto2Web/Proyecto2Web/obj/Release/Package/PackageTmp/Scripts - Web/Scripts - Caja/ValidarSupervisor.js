// JavaScript source code

var valsup = angular.module("ValidarSupervisor", []);

valsup.controller('ValidarSupervisorController', function ($scope, $http) {
    $scope.idsupervisor;
    $scope.password;
    const url = "http://api-bd-tec2017-p2.azurewebsites.net/api/";

    $http.get(url + "Personas/SucursalCajero?id=" + window.localStorage.getItem("idcajero"))
        .then(function (response) {
            $scope.infocajero = response.data;
            window.localStorage.setItem("infocajero", $scope.infocajero);
            
        });
    $scope.eliminarprod = function () {
        if ($scope.idsupervisor != null &&
            $scope.password != null) {
            $http.get(url + "Personas/ValidSupervisor?id=" + $scope.idsupervisor + "&&contrasena=" + $scope.password)
                .then(function (response) {
                    console.log(response.data);
                    if (response.data) {
                        var idF = window.localStorage.getItem("idfactura");
                        var idP = window.localStorage.getItem("idproducto");
                        
                        $http.get(url + "Productos/BorrarProducto?idfactura=" + idF + "&&idproducto=" + idP)
                            .then(function (response) {
                                if (response.data) {
                                    window.location = "http://proyecto2web.azurewebsites.net/Caja/addProductos.html";
                                    //window.location = "http://localhost:61087/Caja/addProductos.html";
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
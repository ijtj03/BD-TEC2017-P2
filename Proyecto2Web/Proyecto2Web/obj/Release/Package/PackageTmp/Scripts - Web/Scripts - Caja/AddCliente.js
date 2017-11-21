// JavaScript source code

var addfactura = angular.module("AddCliente", []);

addfactura.controller('AddClienteController', function ($scope, $http) {
    $scope.cedula;
    $scope.nombre;
    $scope.apellido1;
    $scope.apellido2;
    $scope.telefono;
    $scope.password;
    $scope.direccion;
    $scope.fecha;
    $scope.provincias;
    $scope.prov;
    $scope.cantones;
    $scope.cant;
    $scope.distritos;
    $scope.dis;

    const url = "http://api-bd-tec2017-p2.azurewebsites.net/api/";
    $http.get(url + "Direccion/GetAllProvincias")
        .then(function (response) {
            $scope.provincias = response.data;
        });
    $scope.getcantones = function (id) {
        $http.get(url + "Direccion/GetCantonesxProvincia?id=" + $scope.prov)
            .then(function (response) {
                $scope.cantones = response.data;
            });
    }
    $scope.getdistritos = function (id) {
        $http.get(url + "Direccion/GetDistritosxCanton?id=" + $scope.cant)
            .then(function (response) {
                $scope.distritos = response.data;
            });
    }
    $scope.addcliente = function (id) {
        if ($scope.cedula != null &&
            $scope.nombre != null &&
            $scope.apellido1 != null &&
            $scope.apellido2 != null &&
            $scope.telefono != null &&
            $scope.password != null &&
            $scope.direccion != null &&
            $scope.fecha != null) {
            var usuario = {
                IdCedula: $scope.cedula,
                Nombre: $scope.nombre,
                Apellido1: $scope.apellido1,
                Apellido2: $scope.apellido2,
                Telefono: $scope.telefono,
                Contrasena: $scope.password,
                Distrito: $scope.dis,
                Direccion: $scope.direccion,
                FechaNacimiento: document.getElementById("fech").value
            };
            console.log(usuario);
            $http.post(url+"Personas/CrearCliente", usuario)

                .then(function successCallback(response) {
                    if (response.data) {
                        window.location = "http://proyecto2web.azurewebsites.net/Caja/addFactura.html";
                        //window.location = "http://localhost:61087/Caja/addFactura.html";
                    }
                    else {
                        window.alert("Ha ocurrido un error");
                    }
                }, function errorCallback(response) {
                    window.alert("Usuario ya existente");
                    console.log(response);
                });
        }
        else {
            window.alert("Debe rellenar todos los campos");
        }
    }
});
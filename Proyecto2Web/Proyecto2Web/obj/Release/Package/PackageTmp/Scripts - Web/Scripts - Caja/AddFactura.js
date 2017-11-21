// JavaScript source code

var addfactura = angular.module("AddFactura", ['ui.router']);



addfactura.controller('AddFacturaController', function ($scope, $http, $state) {

    var r;
    const url = "http://api-bd-tec2017-p2.azurewebsites.net/api/";
    console.log("idcajero", window.localStorage.getItem("idcajero"));
    $http.get(url + "Personas/SucursalCajero?id=" + window.localStorage.getItem("idcajero"))
        .then(function (response) {
            $scope.infocajero = response.data;
            window.localStorage.setItem("infocajero", $scope.infocajero)
        });


    $scope.verificarcliente = function (id) {
        $http.get(url + "Personas/VerificarCliente?id=" + id)
            .then(function (response) {
                r = response.data;
                console.log($scope.check);
                if (r == true || $scope.check == true) {
                    window.alert("EL CLIENTE SE ENCUENTRE VERIFICADO");
                    window.localStorage.setItem("idcliente", id);

                } else {
                    window.alert("EL CLIENTE NO SE ENCUENTRA VERIFICADO");
                }
            });
    }



    $scope.registrar = function () {
        window.location = "http://proyecto2web.azurewebsites.net/Caja/registrarCliente.html";
        //window.location = "http://localhost:61087/Caja/registrarCliente.html";
    }



    $scope.goProducts = function () {
        // console.log(window.localStorage.getItem("idcliente"));
        //console.log(window.localStorage.getItem("idcajero"));
        
        if ($scope.check == true ) {
            var factura = {
                PeCedula: 999999999,
                CaCedula: window.localStorage.getItem("idcajero"),
            }

            console.log(factura);
            $http.post(url + "Productos/CrearFactura", factura)

                .then(function successCallback(response) {


                    console.log(response.data);
                    window.localStorage.setItem("idfactura", response.data)

                    window.location = "http://proyecto2web.azurewebsites.net/Caja/addProductos.html";
                    //window.location = "http://localhost:61087/Caja/addProductos.html";

                }, function errorCallback(response) {

                    console.log(response.data);

                });
        } else if (r) {
            var factura = {
                PeCedula: window.localStorage.getItem("idcliente"),
                CaCedula: window.localStorage.getItem("idcajero"),
            }

            console.log(factura);
            $http.post(url + "Productos/CrearFactura", factura)

                .then(function successCallback(response) {

                    console.log(response.data);
                    window.localStorage.setItem("idfactura", response.data)

                    window.location = "http://proyecto2web.azurewebsites.net/Caja/addProductos.html";
                    //window.location = "http://localhost:61087/Caja/addProductos.html";

                }, function errorCallback(response) {

                    console.log(response.data);

                });
        } else {
            window.alert("SE DEBE VERIFICAR EL CLIENTE");
        }


    };
});
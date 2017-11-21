// JavaScript source code

var addfactura = angular.module("AddFactura", ['ui.router']);

addfactura.config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {

   /* $urlRouterProvider.otherwise('/login');*/

    $stateProvider
        .state('productos', {
            url: '/addproductos',
            templateUrl: '/Caja/addProductos.html',
            location: true,
        })


}]);

addfactura.controller('AddFacturaController', function ($scope, $http, $state) {

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
                var r = response.data;
                console.log($scope.check);
                if (r == true) {
                    window.alert("EL CLIENTE SE ENCUENTRE VERIFICADO");
                    window.localStorage.setItem("idcliente", id);
                    
                } else {
                    window.alert("EL CLIENTE NO SE ENCUENTRA VERIFICADO"); 
                }
            });
    }

    

    $scope.registrar = function () {
        //window.location = "http://proyecto2web.azurewebsites.net/Caja/registrarCliente.html";
        window.location = "http://localhost:61087/Caja/registrarCliente.html";
    }

    

    $scope.goProducts = function () {
        console.log(window.localStorage.getItem("idcliente"));
        $http.get(url + "Personas/SucursalCajero?id=" + window.localStorage.getItem("idcajero"))
            .then(function (response) {
                var cajero = response.data;

                if ($scope.check == true) {
                    $http.post(url+"", usuario)

                        .then(function successCallback(response) {

                            console.log(response);

                            window.location = "http://localhost:64698/mywebsite/WebCliente/login.html";

                        }, function errorCallback(response) {

                            console.log(response);

                        });
                } else {

                }

            });
    };
});
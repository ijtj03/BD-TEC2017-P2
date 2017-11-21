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
        });


    $scope.goProducts = function (id, password, money) {
        
    };
});
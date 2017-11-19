

var agregarfactura = angular.module("AgregarFactura", ['ui.router']);

logincaja.config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {

    $urlRouterProvider.otherwise('/login');

    $stateProvider
        .state('factura', {
            url: '/addFactura',
            templateUrl: '/Caja/addFactura.html',
            location: true,
        })


}]);
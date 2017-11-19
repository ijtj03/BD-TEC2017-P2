// JavaScript source code

var logincaja = angular.module("LoginCaja", ['ui.router']);

logincaja.config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {

    $urlRouterProvider.otherwise('/login');

    $stateProvider
        .state('factura', {
           url: '/addFactura',
           templateUrl: '/Caja/addFactura.html',
           location: true,
        })
        

}]);

logincaja.controller('LoginCaja', function ($scope, $http, $state) {

    const url = "http://api-bd-tec2017-p2.azurewebsites.net/api/"



    $scope.log = function (id, password, money) {


        if (id != undefined && password != undefined && money != undefined) {
            
            $http.get("http://api-bd-tec2017-p2.azurewebsites.net/api/Personas/ValidCajero?id=" + id + "&contrasena=" + password + "&money=" + money)
                .then(function (response) {
                    var r = response.data;

                    if (r == true) {
                        $state.go('factura');
                    } else {
                        window.alert("Su username o password no coinciden con los esperados")
                    }
                });
        } else {
            window.alert("Rellene todos los campos para poder acceder");
        }
        
    };
});
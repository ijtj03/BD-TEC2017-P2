// JavaScript source code

var logincaja = angular.module("LoginCaja", ['ui.router','oc.lazyLoad']);

logincaja.config(['$stateProvider', '$urlRouterProvider', '$ocLazyLoadProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider, $ocLazyLoadProvider) {
 

}]);

logincaja.controller('LoginCajaController', function ($scope, $http, $state) {

    window.localStorage.clear();
    const url = "http://api-bd-tec2017-p2.azurewebsites.net/api/"



    $scope.log = function (id, password, money) {


        if (id != undefined && password != undefined && money != undefined) {
            
            $http.get("http://api-bd-tec2017-p2.azurewebsites.net/api/Personas/ValidCajero?id=" + id + "&contrasena=" + password + "&money=" + money)
                .then(function (response) {
                    var r = response.data;

                    if (r == true) {
                        window.localStorage.setItem("idcajero", id);
                        console.log("idcajero", window.localStorage.getItem("idcajero"));
                        window.location = "http://proyecto2web.azurewebsites.net/Caja/addFactura.html";
                        //window.location= "http://localhost:61087/Caja/addFactura.html";
                    } else {
                        window.alert("Su username o password no coinciden con los esperados")
                    }
                });
        } else {
            window.alert("Rellene todos los campos para poder acceder");
        }
        
    };
});
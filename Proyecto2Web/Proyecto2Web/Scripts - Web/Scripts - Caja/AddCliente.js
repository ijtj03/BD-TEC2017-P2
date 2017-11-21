// JavaScript source code

var addfactura = angular.module("AddCliente", []);

addfactura.controller('AddClienteController', function ($scope, $http) {
    window.localStorage.setItem("provincia", "");
    $scope.provincias;
    $scope.prov
    $scope.cantones;
    const url = "http://api-bd-tec2017-p2.azurewebsites.net/api/";
    $http.get(url + "Direccion/GetAllProvincias")
        .then(function (response) {
            $scope.provincias = response.data;
        });
    
    $scope.addcliente = function (id) {
        console.log($scope.prov);
    }
});
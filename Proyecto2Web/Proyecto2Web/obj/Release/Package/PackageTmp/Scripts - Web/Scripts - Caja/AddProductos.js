var addproductos = angular.module("AddProductos",[]);


addproductos.controller("AddProductosController", function ($scope, $http) {

    const url = "http://api-bd-tec2017-p2.azurewebsites.net/api/";

    console.log(window.localStorage.getItem("idfactura"));

    console.log("idcajero", window.localStorage.getItem("idcajero"));
    $http.get(url + "Personas/SucursalCajero?id=" + window.localStorage.getItem("idcajero"))
        .then(function (response) {
            $scope.infocajero = response.data;
            window.localStorage.setItem("infocajero", $scope.infocajero)
        });


    


    $scope.AgregarProducto = function (idproducto,cantidad) {

        $http.get(url + "Productos/AgregarProducto?idfactura=" + window.localStorage.getItem("idfactura") + "&idproducto=" + idproducto + "&cantidad=" + cantidad)
            .then(function (response) {
                r = response.data;
                console.log(response.data);

                if (r == true) {
                    window.alert("SE AGREGO CORRECTAMENTE");
                } else {
                    window.alert("ERROR AL AGREGAR PRODUCTO, NO SE ENCUENTRA DISPONIBLE");
                }

            });

    }






});
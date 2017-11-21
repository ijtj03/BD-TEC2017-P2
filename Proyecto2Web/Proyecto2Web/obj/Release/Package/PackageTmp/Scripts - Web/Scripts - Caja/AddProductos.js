var addproductos = angular.module("AddProductos",[]);


addproductos.controller("AddProductosController", function ($scope, $http) {

    const url = "http://api-bd-tec2017-p2.azurewebsites.net/api/";
    $scope.productos;
    $scope.total = 0;
    console.log("idfactura",window.localStorage.getItem("idfactura"));

    console.log("idcajero", window.localStorage.getItem("idcajero"));
    $http.get(url + "Personas/SucursalCajero?id=" + window.localStorage.getItem("idcajero"))
        .then(function (response) {
            $scope.infocajero = response.data;
            window.localStorage.setItem("infocajero", $scope.infocajero);
            $http.get(url + "Productos/ProductosxFactura?idfactura=" + window.localStorage.getItem("idfactura") + "&sucursal=" + $scope.infocajero.Sucursal)
                .then(function (response) {
                    $scope.productos = response.data;
                    
                });
        });


    


    


    $scope.AgregarProducto = function (idproducto,cantidad) {

        $http.get(url + "Productos/AgregarProducto?idfactura=" + window.localStorage.getItem("idfactura") + "&idproducto=" + idproducto + "&cantidad=" + cantidad)
            .then(function (response) {
                r = response.data;
                console.log(response.data);

                if (r == true) {
                    window.alert("SE AGREGO CORRECTAMENTE");
                    $http.get(url + "Personas/SucursalCajero?id=" + window.localStorage.getItem("idcajero"))
                        .then(function (response) {
                            $scope.infocajero = response.data;
                            console.log($scope.infocajero.Sucursal);
                            window.localStorage.setItem("infocajero", $scope.infocajero)
                            $http.get(url + "Productos/ProductosxFactura?idfactura=" + window.localStorage.getItem("idfactura") + "&sucursal=" + $scope.infocajero.Sucursal)
                                .then(function (response) {
                                    $scope.productos = response.data;

                                    $scope.idproducto = null;
                                    $scope.cantidad = null;
                                });
                        });
                    
                } else {
                    window.alert("ERROR AL AGREGAR PRODUCTO, NO SE ENCUENTRA DISPONIBLE");
                }

            });

    }

    $scope.Total = function () {

        
        angular.forEach($scope.productos, function (value, key) {
            console.log(value);
            $scope.total = $scope.total + (value.Cantidad * value.Precio);
        });

        


    }

    $scope.BorrarProducto = function (idproducto) {
     
        window.localStorage.setItem("idproducto", idproducto);
    
        window.location = "http://proyecto2web.azurewebsites.net/Caja/eliminarProductoFact.html";
        //window.location = "http://localhost:61087/Caja/eliminarProductoFact.html";
    }

    $scope.TerminarFactura = function () {

       

        window.location = "http://proyecto2web.azurewebsites.net/Caja/addFactura.html";
        //window.location = "http://localhost:61087/Caja/addFactura.html";
    }

    


});
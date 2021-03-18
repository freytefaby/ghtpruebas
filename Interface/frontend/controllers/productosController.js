angular.module("app")
.controller("productos",['$scope','$http','$window',function($scope,$http,$window){
   var token = localStorage.getItem('token');
   $scope.productos = [];
   $scope.listarProductos = function(){
    console.log(token);
    Swal.fire("Cargando datos...")
    Swal.showLoading()
       $http.get('https://localhost:44392/Producto/get',{
           headers:{
               'Authorization':'Bearer '+token
           }
       })
       .then(function success(ok){
            Swal.close();
            console.log(ok.data.data)
            $scope.productos = ok.data.data;

       },function error(error){
            Swal.close();
            console.log(error)
       })
   }

   $scope.crearProducto = function(){
    Swal.showLoading();
    $http.post('https://localhost:44392/producto/crear',{
        codigo : $scope.codigo,
        nombre : $scope.producto,
        valor : $scope.valor,
        cantidad : $scope.cantidad
    },{
        headers:{
            'Authorization':'Bearer '+token
        }
    }).then(function success(ok){
        console.log(ok);
        Swal.close();
        $scope.productos.push({
            codigo:$scope.codigo,
            nombre:$scope.producto,
            valor:$scope.valor,
            cantidad:$scope.cantidad
        });

        $scope.codigo = "";
        $scope.producto = "";
        $scope.valor = 0;
        $scope.cantidad = 0;
        var modal_element = angular.element('#register');
        modal_element.modal('hide');
    },function error(error){
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Error, no se pudo insertar los datos.'
          })
        console.log(error)
    })
   }

   $scope.listarProductos();

}])
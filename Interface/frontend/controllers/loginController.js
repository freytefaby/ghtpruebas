angular.module("app")
.controller("auth",['$scope','$http','$window',function($scope,$http,$window){


  $scope.login = function(){
    Swal.showLoading()
      $http.post('https://localhost:44392/auth/login',{
        usuario:$scope.usuario,
        password:$scope.password
  
      }).then(function success(e){
  
        console.log(e.data.data)
        localStorage.setItem("usuario",JSON.stringify(e.data.data.usuario));
        localStorage.setItem("token",e.data.data.token);
        Swal.close();
        $window.location.href = "#!/productos";
      },function error(er){
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Credenciales invalidas, vuelta a intentarlo'
        })
      })
   
  }

}])


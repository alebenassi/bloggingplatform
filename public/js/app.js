// Creación del módulo
var ngApp = angular.module('ngApp', ['ngRoute', 'ngSanitize']);
    
    // Configuración de las rutas
    ngApp.config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'Views/list.html',
                controller: 'listController'                
            })            
            .when('/new-entry', {
                templateUrl: 'Views/new-entry.html',
                controller: 'newController'                
            })  
            .when('/edit-entry/:id', {
                templateUrl: 'Views/edit-entry.html',
                controller: 'editController',                
            })                      
            .when('/delete-entry/:id', {
                templateUrl: 'Views/delete-entry.html',
                controller: 'deleteController',                
            })                      
            .otherwise({
                redirectTo: '/'
            });
    });   

    ngApp.controller('mainController', function ($scope, $route, $http, $rootScope) {
        

    });

    ngApp.controller('listController',function ($scope, $route, $http, $routeParams, $rootScope) {                       
        $http.get('http://localhost:8088/api/blogs')
           .then(function (result) {
               $scope.blogs = result.data;               
           }, function (err) {
               alert("Error");
           });
                   
    });    

    ngApp.controller('newController', function ($scope, $route, $http, $routeParams, $rootScope) {
           $scope.msgAlertM = '';
           $scope.createEntry = function(){
               $scope.showLoader = true;
               $scope.newBlog.IdUser = 1;
               $scope.newBlog.IsDraft = 0;                             
               $http.post('http://localhost:8088/api/blogs', $scope.newBlog)
            .then(function (result) {                
                if (result.data.response) {                    
                    $scope.newBlog = {};                    
                }                
                $scope.showLoader = false;
                $scope.msgAlertM = result.data.message;
            }, function (err) {
                $scope.showLoader = false;
                alert("Error, try again");
            });
           }           
    });    

    ngApp.controller('editController', function ($scope, $route, $http, $routeParams, $rootScope) {
           $scope.msgAlertM = '';
           var idBlog = $routeParams.id;           
           $http.get('http://localhost:8088/api/blogs/' + idBlog)
           .then(function (result) {               
               if (result.data) {
                   $scope.editBlog = result.data;               
                } else {
                    window.location = '#';
                }
           }, function (err) {
               alert("Error");
           });
           $scope.editEntry = function(){
               $scope.showLoader = true;
               $scope.editBlog.IdBlog = idBlog;
               $scope.editBlog.IdUser = 1;
               $scope.editBlog.IsDraft = 0;                             
               $http.put('http://localhost:8088/api/blogs/' + idBlog, $scope.editBlog)
            .then(function (result) {                                
                $scope.showLoader = false;
                $scope.msgAlertM = result.data.message;
            }, function (err) {
                $scope.showLoader = false;
                alert("Error, try again");
            });
           }           
    });    

    ngApp.controller('deleteController', function ($scope, $route, $http, $routeParams, $rootScope) {
           $scope.msgAlertM = '';
           $scope.entryDeleted = false;
           var idBlog = $routeParams.id;           
           $http.get('http://localhost:8088/api/blogs/' + idBlog)
           .then(function (result) {               
               if (!result.data) {                   
                    window.location = '#';
                }
           }, function (err) {
               alert("Error");
           });
           $scope.back = function(){
               window.location = '#';
           }
           $scope.deleteEntry = function(){
               $scope.showLoader = true;               
               $http.delete('http://localhost:8088/api/blogs/' + idBlog)               
            .then(function (result) {                                
                if (result.data.response) {                    
                    $scope.entryDeleted = true;                    
                }            
                $scope.showLoader = false;
                $scope.msgAlertM = result.data.message;
            }, function (err) {
                $scope.showLoader = false;
                alert("Error, try again");
            });
           }           
    });    

    
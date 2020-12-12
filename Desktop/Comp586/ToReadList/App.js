//var App = angular.module('App', ['ngRoute', 'ui.bootstrap']); //, 'chart.js']);

//App.controller('ListController', ListController);


//var configFunction = function ($routeProvider, $httpProvider) {
//    $routeProvider.
//        when('/list', {
//            templateUrl: 'Views/ToRead/Index.html',
//            controller: ListController
//        })
//        .otherwise({
//            redirectTo: function () {
//                return '/list';
//            }
//        });
//}
//configFunction.$inject = ['$routeProvider', '$httpProvider'];

//App.config(configFunction);

var routerApp = angular.module('plunker', 'routerApp', ['ui.router']);

routerApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {

    $urlRouterProvider.otherwise('/ToRead');

    $stateProvider

        // HOME STATES AND NESTED VIEWS ========================================
        .state('ToRead', {
            url: '/ToRead',
            templateUrl: '~/ToRead/Index.cshtml',
            resolve: {
                test: function () {
                    alert("Triggered main state");
                    return true;
                }
        })
});

app.controller('MainController', function ($scope) {
    $scope.name = 'World';
});

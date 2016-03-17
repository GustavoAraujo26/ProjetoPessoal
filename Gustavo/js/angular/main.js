angular.module('gustavo', ['ngRoute', 'ngAnimate', 'ui.bootstrap']).config(function ($routeProvider, $locationProvider) {

    $locationProvider.html5Mode(true);

    $routeProvider.when('/', {
        templateUrl: 'partials/home/home.html',
        controller: 'HomeController'
    });

    $routeProvider.when('/competencia', {
        templateUrl: 'partials/competencia/competencia.html',
        controller: 'HomeController'
    });

    $routeProvider.when('/experiencia', {
        templateUrl: 'partials/experiencia/experiencia.html',
        controller: 'HomeController'
    });

    $routeProvider.when('/formacao', {
        templateUrl: 'partials/formacao/formacao.html',
        controller: 'HomeController'
    });

    $routeProvider.when('/sobremim', {
        templateUrl: 'partials/sobre_mim/sobre-mim.html',
        controller: 'HomeController'
    });

    $routeProvider.when('/portfolio', {
        templateUrl: 'partials/portfolio/portfolio.html',
        controller: 'HomeController'
    });

    $routeProvider.when('/contato', {
        templateUrl: 'partials/contato/contato.html',
        controller: 'HomeController'
    });

    $routeProvider.otherwise({ redirectTo: '/' });
});
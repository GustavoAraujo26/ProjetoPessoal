angular.module('cotacao', ['ngRoute', 'servicoProduto', 'servicoFornecedor', 'servicoRepresentante', 'servicoCotacao', 'ngAnimate', 'ui.bootstrap']).config(function ($routeProvider, $locationProvider) {

        $locationProvider.html5Mode(true);

        $routeProvider.when('/', {
            templateUrl: 'partials/home/home.html',
            controller: 'HomeController'
        });

        //Rotas do produto
        $routeProvider.when('/produto', {
            templateUrl: 'partials/produto/home.html',
            controller: 'ProdutoController'
        });
        
        $routeProvider.when('/produto/detalhes/:produtoId', {
            templateUrl: 'partials/produto/detalhes.html',
            controller: 'ProdutoController'
        });

        $routeProvider.when('/produto/novo', {
            templateUrl: 'partials/produto/formulario.html',
            controller: 'ProdutoController'
        });

        $routeProvider.when('/produto/edit/:produtoId', {
            templateUrl: 'partials/produto/formulario.html',
            controller: 'ProdutoController'
        });

        $routeProvider.when('/produto/pesquisa', {
            templateUrl: 'partials/produto/pesquisa.html',
            controller: 'ProdutoController'
        });

        //Rotas do produto
        $routeProvider.when('/fornecedor', {
            templateUrl: 'partials/fornecedor/home.html',
            controller: 'FornecedorController'
        });

        $routeProvider.when('/fornecedor/detalhes/:fornecedorId', {
            templateUrl: 'partials/fornecedor/detalhes.html',
            controller: 'FornecedorController'
        });

        $routeProvider.when('/fornecedor/novo', {
            templateUrl: 'partials/fornecedor/formulario.html',
            controller: 'FornecedorController'
        });

        $routeProvider.when('/fornecedor/edit/:fornecedorId', {
            templateUrl: 'partials/fornecedor/formulario.html',
            controller: 'FornecedorController'
        });

        $routeProvider.when('/fornecedor/pesquisa', {
            templateUrl: 'partials/fornecedor/pesquisa.html',
            controller: 'FornecedorController'
        });

        //Rotas do representante
        $routeProvider.when('/representante', {
            templateUrl: 'partials/representante/home.html',
            controller: 'RepresentanteController'
        });

        $routeProvider.when('/representante/detalhes/:representanteId', {
            templateUrl: 'partials/representante/detalhes.html',
            controller: 'RepresentanteController'
        });

        $routeProvider.when('/representante/novo', {
            templateUrl: 'partials/representante/formulario.html',
            controller: 'RepresentanteController'
        });

        $routeProvider.when('/representante/edit/:representanteId', {
            templateUrl: 'partials/representante/formulario.html',
            controller: 'RepresentanteController'
        });

        $routeProvider.when('/representante/pesquisa', {
            templateUrl: 'partials/representante/pesquisa.html',
            controller: 'RepresentanteController'
        });

        //Rotas da cotação
        $routeProvider.when('/cotacao', {
            templateUrl: 'partials/cotacao/home.html',
            controller: 'CotacaoController'
        });

        $routeProvider.when('/cotacao/oferta/detalhes/:cotacaoId', {
            templateUrl: 'partials/cotacao/detalhes.html',
            controller: 'CotacaoController'
        });

        $routeProvider.when('/cotacao/oferta/novo', {
            templateUrl: 'partials/cotacao/formulario.html',
            controller: 'CotacaoController'
        });

        $routeProvider.when('/cotacao/oferta/pesquisa', {
            templateUrl: 'partials/cotacao/pesquisa.html',
            controller: 'CotacaoController'
        });

        $routeProvider.otherwise({ redirectTo: '/' });
    })
    .filter('startFrom', function() {
        return function(data, start) {
            if (!data || !data.length) { return; }
            start = +start;//parse to int
            return data.slice(start);
        }
    })
    .run(function ($rootScope) {
        $rootScope.$on("$routeChangeSuccess", function (event, currentRoute, previousRoute) {
            window.scrollTo(0, 0);
        });
    });
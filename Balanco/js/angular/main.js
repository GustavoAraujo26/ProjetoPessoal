angular.module('balanco',['ngRoute',
                          'servicoProdutor',
                          'servicoFazenda',
                          'servicoPosse',
                          'servicoLeite',
                          'servicoDespesa',
                          'servicoReceita',
                          'servicoCompraGado',
                          'servicoVendaGado',
                          'ngAnimate',
                          'ui.bootstrap']).config(function ($routeProvider, $locationProvider) {

        $locationProvider.html5Mode(true);

        $routeProvider.when('/', {
            templateUrl: 'partials/home/home.html',
            controller: 'HomeController'
        });
        
        //Rotas do Produtor Rural
        $routeProvider.when('/produtor', {
            templateUrl: 'partials/produtor/home.html',
            controller: 'ProdutorRuralController'
        });

        $routeProvider.when('/produtor/detalhes/:produtorId', {
            templateUrl: 'partials/produtor/detalhes.html',
            controller: 'ProdutorRuralController'
        });

        $routeProvider.when('/produtor/novo', {
            templateUrl: 'partials/produtor/formulario.html',
            controller: 'ProdutorRuralController'
        });

        $routeProvider.when('/produtor/edit/:produtorId', {
            templateUrl: 'partials/produtor/formulario.html',
            controller: 'ProdutorRuralController'
        });

        $routeProvider.when('/produtor/pesquisa', {
            templateUrl: 'partials/produtor/pesquisa.html',
            controller: 'ProdutorRuralController'
        });
        
        //Rotas da Fazenda
        $routeProvider.when('/fazenda', {
            templateUrl: 'partials/fazenda/home.html',
            controller: 'FazendaController'
        });

        $routeProvider.when('/fazenda/detalhes/:fazendaId', {
            templateUrl: 'partials/fazenda/detalhes.html',
            controller: 'FazendaController'
        });

        $routeProvider.when('/fazenda/novo', {
            templateUrl: 'partials/fazenda/formulario.html',
            controller: 'FazendaController'
        });

        $routeProvider.when('/fazenda/edit/:fazendaId', {
            templateUrl: 'partials/fazenda/formulario.html',
            controller: 'FazendaController'
        });

        $routeProvider.when('/fazenda/pesquisa', {
            templateUrl: 'partials/fazenda/pesquisa.html',
            controller: 'FazendaController'
        });

        //Rotas da Posse
        $routeProvider.when('/posse', {
            templateUrl: 'partials/posse/home.html',
            controller: 'PosseController'
        });

        $routeProvider.when('/posse/detalhes/:posseId', {
            templateUrl: 'partials/posse/detalhes.html',
            controller: 'PosseController'
        });

        $routeProvider.when('/posse/novo', {
            templateUrl: 'partials/posse/formulario.html',
            controller: 'PosseController'
        });

        $routeProvider.when('/posse/edit/:posseId', {
            templateUrl: 'partials/posse/formulario.html',
            controller: 'PosseController'
        });

        $routeProvider.when('/posse/pesquisa', {
            templateUrl: 'partials/posse/pesquisa.html',
            controller: 'PosseController'
        });

        //Rotas do Leite
        $routeProvider.when('/leite', {
            templateUrl: 'partials/leite/home.html',
            controller: 'LeiteController'
        });

        $routeProvider.when('/leite/detalhes/:vendaleiteId', {
            templateUrl: 'partials/leite/detalhes.html',
            controller: 'LeiteController'
        });

        $routeProvider.when('/leite/novo', {
            templateUrl: 'partials/leite/formulario.html',
            controller: 'LeiteController'
        });

        $routeProvider.when('/leite/edit/:vendaleiteId', {
            templateUrl: 'partials/leite/formulario.html',
            controller: 'LeiteController'
        });

        $routeProvider.when('/leite/pesquisa', {
            templateUrl: 'partials/leite/pesquisa.html',
            controller: 'LeiteController'
        });

        //Rotas da despesa
        $routeProvider.when('/despesa', {
            templateUrl: 'partials/despesa/home.html',
            controller: 'DespesaController'
        });

        $routeProvider.when('/despesa/detalhes/:despesageralId', {
            templateUrl: 'partials/despesa/detalhes.html',
            controller: 'DespesaController'
        });

        $routeProvider.when('/despesa/novo', {
            templateUrl: 'partials/despesa/formulario.html',
            controller: 'DespesaController'
        });

        $routeProvider.when('/despesa/edit/:despesageralId', {
            templateUrl: 'partials/despesa/formulario.html',
            controller: 'DespesaController'
        });

        $routeProvider.when('/despesa/pesquisa', {
            templateUrl: 'partials/despesa/pesquisa.html',
            controller: 'DespesaController'
        });

        //Rotas da despesa
        $routeProvider.when('/receita', {
            templateUrl: 'partials/receita/home.html',
            controller: 'ReceitaController'
        });

        $routeProvider.when('/receita/detalhes/:receitageralId', {
            templateUrl: 'partials/receita/detalhes.html',
            controller: 'ReceitaController'
        });

        $routeProvider.when('/receita/novo', {
            templateUrl: 'partials/receita/formulario.html',
            controller: 'ReceitaController'
        });

        $routeProvider.when('/receita/edit/:receitageralId', {
            templateUrl: 'partials/receita/formulario.html',
            controller: 'ReceitaController'
        });

        $routeProvider.when('/receita/pesquisa', {
            templateUrl: 'partials/receita/pesquisa.html',
            controller: 'ReceitaController'
        });

        //Rotas da compra de gado
        $routeProvider.when('/compragado', {
            templateUrl: 'partials/compra_gado/home.html',
            controller: 'CompraGadoController'
        });

        $routeProvider.when('/compragado/detalhes/:compragadoId', {
            templateUrl: 'partials/compra_gado/detalhes.html',
            controller: 'CompraGadoController'
        });

        $routeProvider.when('/compragado/novo', {
            templateUrl: 'partials/compra_gado/formulario.html',
            controller: 'CompraGadoController'
        });

        $routeProvider.when('/compragado/edit/:compragadoId', {
            templateUrl: 'partials/compra_gado/formulario.html',
            controller: 'CompraGadoController'
        });

        $routeProvider.when('/compragado/pesquisa', {
            templateUrl: 'partials/compra_gado/pesquisa.html',
            controller: 'CompraGadoController'
        });

        //Rotas da venda de gado
        $routeProvider.when('/vendagado', {
            templateUrl: 'partials/venda_gado/home.html',
            controller: 'VendaGadoController'
        });

        $routeProvider.when('/vendagado/detalhes/:vendagadoId', {
            templateUrl: 'partials/venda_gado/detalhes.html',
            controller: 'VendaGadoController'
        });

        $routeProvider.when('/vendagado/novo', {
            templateUrl: 'partials/venda_gado/formulario.html',
            controller: 'VendaGadoController'
        });

        $routeProvider.when('/vendagado/edit/:vendagadoId', {
            templateUrl: 'partials/venda_gado/formulario.html',
            controller: 'VendaGadoController'
        });

        $routeProvider.when('/vendagado/pesquisa', {
            templateUrl: 'partials/venda_gado/pesquisa.html',
            controller: 'VendaGadoController'
        });

        //Rota do balanço fiscal
        $routeProvider.when('/balanco', {
            templateUrl: 'partials/balanco/balanco.html',
            controller: 'BalancoController'
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
angular.module('servicoCotacao', ['ngResource'])
    .factory('recursoCotacao', function($resource) {
        return $resource('http://api.gustavodearaujo.com/v1/public/cotacao/:cotacaoId', null, {
            'update': {
                method: 'PUT'
            }
        });
    })
    .factory('menorPreco', function($resource) {
        return $resource('http://api.gustavodearaujo.com/v1/public/cotacao/menorpreco', null, null);
    })
    .factory('ofertaPorRepresentanteEPreco', function ($resource) {
        return $resource('http://api.gustavodearaujo.com/v1/public/cotacao/representante/:representanteId/menorpreco', null, null);
    })
    .factory('ofertaPorProdutoEPreco', function($resource) {
        return $resource('http://api.gustavodearaujo.com/v1/public/cotacao/produto/:produtoId/menorpreco', null, null);
    });
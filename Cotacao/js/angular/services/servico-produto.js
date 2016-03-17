angular.module('servicoProduto', ['ngResource'])
    .factory('recursoProduto', function($resource) {
        return $resource('http://api.gustavodearaujo.com/v1/public/produto/:produtoId', null, {
            'update': {
                method: 'PUT'
            }
        });
    });
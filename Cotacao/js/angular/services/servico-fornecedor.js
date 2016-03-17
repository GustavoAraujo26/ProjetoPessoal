angular.module('servicoFornecedor', ['ngResource'])
    .factory('recursoFornecedor', function($resource) {
        return $resource('http://api.gustavodearaujo.com/v1/public/fornecedor/:fornecedorId', null, {
            'update': {
                method: 'PUT'
            }
        });
    });
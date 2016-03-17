angular.module('servicoCompraGado', ['ngResource'])
    .factory('recursoCompraGado', function($resource) {

        return $resource('http://api.gustavodearaujo.com/v1/public/compragado/:compragadoId', null, {
            'update': {
                method: 'PUT'
            }
        });
    })
    .factory('balancoCompraGado', function($resource) {
        return $resource('http://api.gustavodearaujo.com/v1/public/compragado/balanco/:produtorId/:ano', null, null);
    });
angular.module('servicoVendaGado', ['ngResource'])
    .factory('recursoVendaGado', function ($resource) {

        return $resource('http://api.gustavodearaujo.com/v1/public/vendagado/:vendagadoId', null, {
            'update': {
                method: 'PUT'
            }
        });
    })
    .factory('balancoVendaGado', function ($resource) {
        return $resource('http://api.gustavodearaujo.com/v1/public/vendagado/balanco/:produtorId/:ano', null, null);
    });
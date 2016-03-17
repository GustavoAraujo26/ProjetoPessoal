angular.module('servicoFazenda', ['ngResource'])
    .factory('recursoFazenda', function ($resource) {

        return $resource('http://api.gustavodearaujo.com/v1/public/fazenda/:fazendaId', null, {
            'update': {
                method: 'PUT'
            }
        });
    });
angular.module('servicoPosse', ['ngResource'])
    .factory('recursoPosse', function ($resource) {

        return $resource('http://api.gustavodearaujo.com/v1/public/posse/:posseId', null, {
            'update': {
                method: 'PUT'
            }
        });
    })
    .factory('balancoPosse', function ($resource) {
        return $resource('http://api.gustavodearaujo.com/v1/public/posse/balanco/:produtorId/:ano', null, null);
    });
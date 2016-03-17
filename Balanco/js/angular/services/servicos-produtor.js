angular.module('servicoProdutor', ['ngResource'])
    .factory('recursoProdutor', function($resource) {

        return $resource('http://api.gustavodearaujo.com/v1/public/produtor/:produtorId', null, {
            'update': {
                method: 'PUT'
            }
        });
    });
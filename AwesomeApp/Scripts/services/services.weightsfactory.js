angular.module(APPNAME)
    .factory('weightsDataFactory', ['$http', function ($http) {

        var urlBase = '/api/weightexercises';
        var dataFactory = {};

        dataFactory.getWeightExercises = function () {
            return $http.get(urlBase);
        };

        dataFactory.getWeightExercise = function (id) {
            return $http.get(urlBase + '/' + id);
        };

        dataFactory.insertWeightExercise = function (exercise) {
            return $http.post(urlBase, exercise);
        };

        dataFactory.updateWeightExercise = function (exercise) {
            return $http.put(urlBase + '/' + exercise.ID, exercise);
        };

        dataFactory.deleteWeightExercise = function (id) {
            return $http.delete(urlBase + '/' + id);
        };

        return dataFactory;
    }]);
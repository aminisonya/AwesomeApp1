angular.module(APPNAME)
    .factory('weightExercisesDataFactory', ['$http', function ($http) {

        var urlBase = '/api/weightexercises';
        var dataFactory = {};

        dataFactory.getWeightExercises = function () {
            return $http.get(urlBase)
            .then(onCompletion)
            .catch(onFailure);
        };

        dataFactory.getWeightExercise = function (id) {
            return $http.get(urlBase + '/' + id)
            .then(onCompletion)
            .catch(onFailure);
        };

        dataFactory.insertWeightExercise = function (exercise) {
            return $http.post(urlBase, exercise)
            .then(onCompletion)
            .catch(onFailure);
        };

        dataFactory.updateWeightExercise = function (exercise) {
            return $http.put(urlBase + '/' + exercise.ID, exercise)
            .then(onCompletion)
            .catch(onFailure);
        };

        dataFactory.deleteWeightExercise = function (id) {
            return $http.delete(urlBase + '/' + id)
            .then(onCompletion)
            .catch(onFailure);
        };

        return dataFactory;
    }]);
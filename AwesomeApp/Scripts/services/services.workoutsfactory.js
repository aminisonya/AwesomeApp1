angular.module(APPNAME)
    .factory('workoutsDataFactory', ['$http', function ($http) {

        var urlBase = '/api/workouts';
        var dataFactory = {};

        dataFactory.getWorkouts = function () {
            return $http.get(urlBase);
        };

        dataFactory.getWorkout = function (id) {
            return $http.get(urlBase + '/' + id);
        };

        dataFactory.insertWorkout = function (workout) {
            return $http.post(urlBase, workout);
        };

        dataFactory.updateWorkout = function (workout) {
            return $http.put(urlBase + '/' + workout.ID, workout);
        };

        dataFactory.deleteWorkout = function (id) {
            return $http.delete(urlBase + '/' + id);
        };

        return dataFactory;
    }]);



//example dataservice factory

//angular
//    .module(APPNAME)
//    .factory('dataservice', dataservice);

//dataservice.$inject = ['$http', 'logger'];

//function dataservice($http, logger) {
//    return {
//        getStuff: getStuff
//    };

//    function getStuff() {
//        return $http.get('/api/stuff')
//            .then(onCompletion)
//            .catch(onFailure);

//        function onCompletion(response) {
//            return response.data.results;
//        }

//        function onFailure(error) {
//            logger.error('XHR Failed' + error.data);
//        }
//    }
//}
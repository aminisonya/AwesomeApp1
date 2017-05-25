awesomeapp.services.workouts = awesomeapp.services.workouts || {};

awesomeapp.services.workouts.create = function (workoutData, onSuccess, onError) {
    var url = "/api/workouts";

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
		, data: workoutData
		, dataType: "JSON"
		, success: onSuccess
		, error: onError
		, type: "POST"
    };
    $.ajax(url, settings);
}

awesomeapp.services.workouts.update = function (id, workoutData, onSuccess, onError) {
    var url = "/api/workouts/" + id;

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
		, data: workoutData
		, dataType: "JSON"
		, success: onSuccess
		, error: onError
		, type: "PUT"
    };
    $.ajax(url, settings);
}
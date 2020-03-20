app.factory("MechanicsService", [
    "$http", "serverUrl",
    function ($http, serverUrl) {
        var mechanicsService = {};

        mechanicsService.registerMechanic = function (model) {
            return $http.post(serverUrl + "Mechanics/RegisterMechanic", model);
        };

        mechanicsService.signInMechanic = function (model) {
            return $http.post(serverUrl + "Mechanics/SignInMechanic", model);
        };

        mechanicsService.getAll = function () {
            return $http.post(serverUrl + "Mechanics/GetAll", null);
        };
        mechanicsService.getInspections = function (id) {
            return $http.post(serverUrl + "Mechanics/GetInspections", { id: id });
        };
        mechanicsService.getAllList = function () {
            return $http.post(serverUrl + "Mechanics/GetAllList", null);
        };

        mechanicsService.delete = function (id) {
            return $http.post(serverUrl + "Mechanics/Delete", {id: id});
        };

        mechanicsService.update = function (model) {
            return $http.post(serverUrl + "Mechanics/Update", model)
        }
        mechanicsService.getById = function (id) {
            return $http.post(serverUrl + "Mechanics/GetById", {id: id})
        }
        mechanicsService.getAverage = function (id) {
            return $http.post(serverUrl + "Mechanics/GetAverage", { id: id })
        }
        return mechanicsService;
    }
]);
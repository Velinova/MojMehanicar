app.factory("InspectionsService", [
    "$http", "serverUrl",
    function ($http, serverUrl) {
        var inspectionsService = {};

        inspectionsService.addInspection = function (model) {
            return $http.post(serverUrl + "TechnicalInspections/Add", { model: model });
        };
        inspectionsService.getPending = function (id) {
            return $http.post(serverUrl + "TechnicalInspections/GetPendingInspections", { id:id});
        };
        inspectionsService.getInProgress = function (id) {
            return $http.post(serverUrl + "TechnicalInspections/GetInProgressInspections", { id: id });
        };
        inspectionsService.getDone = function (id) {
            return $http.post(serverUrl + "TechnicalInspections/GetDoneInspections", { id: id });
        };
        inspectionsService.delete = function (id) {
            return $http.post(serverUrl + "TechnicalInspections/Delete", { id: id });
        };
        inspectionsService.getById = function (id) {
            return $http.post(serverUrl + "TechnicalInspections/GetById", { id: id })
        }
        inspectionsService.update = function (model) {
            return $http.post(serverUrl + "TechnicalInspections/Update", { model: model })
        }
        inspectionsService.getAll = function () {
            return $http.post(serverUrl + "TechnicalInspections/GetAll", null);
        };

        return inspectionsService;
    }
]);
app.factory("VehiclesService", [
    "$http", "serverUrl",
    function ($http, serverUrl) {
        var vehiclesService = {};

        vehiclesService.addVehicle = function (model) {
            return $http.post(serverUrl + "Vehicles/Create", { model: model });
        };
        vehiclesService.delete = function (id) {
            return $http.post(serverUrl + "Vehicles/Delete", { id: id });
        };
        vehiclesService.update = function (model) {
            return $http.post(serverUrl + "Vehicles/Update", { model: model });
        };
        vehiclesService.getById = function (id) {
            return $http.post(serverUrl + "Vehicles/GetById", { id: id })
        }
        vehiclesService.getAll = function () {
            return $http.post(serverUrl + "Vehicles/GetAll", null);
        };
        //usersService.registerUser = function (model) {
        //    return $http.post(serverUrl + "Users/RegisterUser", model);
        //};

        //usersService.signInUser = function (model) {
        //    return $http.post(serverUrl + "Users/SignInUser", model);
        //};

        //usersService.getAllAdmins = function () {
        //    return $http.post(serverUrl + "Users/GetAllAdmins", null);
        //};

        //usersService.getAllUsers = function () {
        //    return $http.post(serverUrl + "Users/GetAllUsers", null);
        //};

        

        

        
        
        //usersService.changeRole = function (id) {
        //    return $http.post(serverUrl + "Users/ChangeRole", { id: id })
        //}

        return vehiclesService;
    }
]);
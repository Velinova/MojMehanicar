app.directive("users", [
    function () {
        var users = {
            restrict: 'E',
            templateUrl: 'app/users/users.html',
            controller: "UsersController"
        }
        return users;
    }
])
app.directive("mechanics", [
    function () {
        var mechanics = {
            restrict: 'E',
            templateUrl: 'app/mechanics/mechanics.html',
            controller: "MechanicsController"
        }
        return mechanics;
    }
])
app.directive("vehicles", [
    function () {
        var vehicles = {
            restrict: 'E',
            templateUrl: 'app/vehicles/vehicles.html',
            controller: "VehiclesController"
        }
        return vehicles;
    }
])
app.directive("inspections", [
    function () {
        var inspections = {
            restrict: 'E',
            templateUrl: 'app/inspections/inspections.html',
            controller: "InspectionsController"
        }
        return inspections;
    }
])

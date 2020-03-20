app.directive("myvehicles", [
    function () {
        var myvehicles = {
            restrict: 'E',
            templateUrl: 'app/myprofile/myvehicles.html',
            controller: "MyVehiclesController"
        }
        return myvehicles;
    }
])
app.directive("listmechanics", [
    function () {
        var listmechanics = {
            restrict: 'E',
            templateUrl: 'app/myprofile/list-mechanics.html',
            controller: "ListMechanicsController"
        }
        return listmechanics;
    }
])
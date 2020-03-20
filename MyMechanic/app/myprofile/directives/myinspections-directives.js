app.directive("myinspections", [
    function () {
        var myinspections = {
            restrict: 'E',
            templateUrl: 'app/myprofile/myinspections.html',
            controller: "MyInspectionsController"
        }
        return myinspections;
    }
])
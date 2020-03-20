app.directive("mechanicinspections", [
    function () {
        var mechanicinspections = {
            restrict: 'E',
            templateUrl: 'app/mymechanicprofile/mechanicinspections.html',
            controller: "MechanicInspectionsController"
        }
        return mechanicinspections;
    }
])
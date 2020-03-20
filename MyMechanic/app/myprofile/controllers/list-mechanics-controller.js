app.controller("ListMechanicsController", [
    "$scope", "$uibModal", "MechanicsService", "$cookies",
    function ($scope, $uibModal, MechanicsService, $cookies) {
        $scope.list = [];
        $scope.searchCriteria = "";
        $scope.searchText = "";
        $scope.ascdes = true;
        MechanicsService.getAllList().then(
            function (response) {
                $scope.list = response.data;
            },
            function (response) {
                alert(response.data);
            }
        );
        // dynamic order by
        $scope.dynamicOrderBy = function (criteria, flag) {
            if (criteria == "rating" && flag == true) {
                $scope.searchCriteria = "AverageRating";
                $scope.ascdes = true;
            }
            if (criteria == "rating" && flag == false) {
                $scope.searchCriteria = "AverageRating";
                $scope.ascdes = false;
            }
            if (criteria == "inspectionCount" && flag == false) {
                $scope.searchCriteria = "InspectionsCount";
                $scope.ascdes = false;
            }
            if (criteria == "inspectionCount" && flag == true) {
                $scope.searchCriteria = "InspectionsCount";
                $scope.ascdes = true;
            }
        };
        //clear search
        $scope.clear = function () {
            $scope.searchText = "";
        }
    }
]);
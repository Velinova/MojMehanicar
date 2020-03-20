app.controller("MechanicInspectionsController", [
    "$scope", "UsersService", "MechanicsService", "$cookies", "$uibModal", "$window", "VehiclesService", "InspectionsService",
    function ($scope, UsersService, MechanicsService, $cookies, $uibModal, $window, VehiclesService, InspectionsService) {
        $scope.filterIndex = '';
        $scope.myInspections = [];
        $scope.userId = $cookies.get('userId');
        function fetchData() {
            MechanicsService.getInspections($scope.userId).then(
                function (response) {
                    $scope.myInspections = response.data;

                    for (var i = 0; i < $scope.myInspections.length; i++) {
                        switch ($scope.myInspections[i].Status) {
                            case -1:
                                $scope.myInspections[i].statusString = 'pending';
                                break;
                            case 0:
                                $scope.myInspections[i].statusString = 'in-progress';
                                break;
                            case 1:
                                $scope.myInspections[i].statusString = 'done';
                                break;
                        }
                    }
                },
                function (response) {
                    alert(response.data);
                }
            );
        }
        //filter vehicles function
        $scope.filter = function (index) {
            $scope.filterIndex = index;
        }


        //changeStatus function
        $scope.changeStatus = function (inspection, status) {
            var modalInstance = $uibModal.open(
                {
                    controller: "ChangeStatusController",
                    templateUrl: "app/inspections/change-status.html",
                    backdrop: false,
                    resolve: {
                        service: function () {
                            return InspectionsService.update;
                        },
                        params: function () {
                            return inspection;
                        },
                        status: function () {
                            return status;
                        }
                    }
                }
            );

            modalInstance.result.then(function (result) {
                fetchData();
            });
        }
        fetchData();
        }

]);
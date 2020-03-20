app.controller("VehiclesController", [
    "$scope", "$uibModal", "VehiclesService",
    function ($scope, $uibModal, VehiclesService) {
        $scope.vehicles = [];
        function fetchData() {
            VehiclesService.getAll().then(
                function (response) {
                    $scope.vehicles = response.data;
                },
                function (response) {
                    alert(response.data);
                }
            );
        }
        $scope.summonDeleteDialog = function (vehicleId) {
            
            var modalInstance = $uibModal.open(
                {
                    controller: "DeleteModalController",
                    templateUrl: "app/common/delete-modal/delete-modal.html",
                    backdrop: false,
                    resolve: {
                        service: function () {
                            return VehiclesService.delete;
                        },
                        params: function () {
                            return vehicleId;
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
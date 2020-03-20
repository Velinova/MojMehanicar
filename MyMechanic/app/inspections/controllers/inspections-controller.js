app.controller("InspectionsController", [
    "$scope", "$uibModal", "InspectionsService",
    function ($scope, $uibModal, InspectionsService) {
        $scope.inspections = [];
        function fetchData() {
            InspectionsService.getAll().then(
                function (response) {
                    $scope.inspections = response.data;
                },
                function (response) {
                    alert(response.data);
                }
            );
        }
        $scope.summonDeleteDialog = function (inspectionId) {

            var modalInstance = $uibModal.open(
                {
                    controller: "DeleteModalController",
                    templateUrl: "app/common/delete-modal/delete-modal.html",
                    backdrop: false,
                    resolve: {
                        service: function () {
                            return InspectionsService.delete;
                        },
                        params: function () {
                            return inspectionId;
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
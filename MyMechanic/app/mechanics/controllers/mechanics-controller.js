app.controller("MechanicsController", [
    "$scope", "$uibModal", "MechanicsService","$cookies",
    function ($scope, $uibModal, MechanicsService, $cookies) {
        $scope.mechanics = [];
        $scope.cookieId = $cookies.get('userId');
        fetchData();

        $scope.summonDeleteDialog = function (userId) {
            if (userId === $scope.cookieId)
                return;

            var modalInstance = $uibModal.open(
                {
                    controller: "DeleteModalController",
                    templateUrl: "app/common/delete-modal/delete-modal.html",
                    backdrop:false,
                    resolve: {
                        service: function () {
                            return MechanicsService.delete;
                        },
                        params: function () {
                            return userId;
                        }
                    }
                }
            );

            modalInstance.result.then(function (result) {
                fetchData();
            });
        }

        


        function fetchData() {
           MechanicsService.getAll().then(
                // success
                function (response) {
                    $scope.mechanics = response.data;
                },
                // error
                function (response) {
                    alert(response.data);
                }
            );
        }
    }
]);
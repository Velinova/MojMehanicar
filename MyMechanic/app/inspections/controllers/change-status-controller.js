app.controller("ChangeStatusController", [
    "$scope", "$uibModalInstance", "service", "params","status",
    function ($scope, $uibModalInstance, service, params, status) {
        $scope.status = status;
        $scope.model = params;
        $scope.model.Status = $scope.status;
        $scope.submit = function (form) {
            service($scope.model).then(
                function (response) {
                    $uibModalInstance.close(response.data);
                },
                function (response) {
                    console.log(response);
                    alert(response.data);
                });
        }

        $scope.cancel = function () {
            $uibModalInstance.dismiss(false);
        }
    }
]);
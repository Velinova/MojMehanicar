app.controller("ChangeRoleModalController", [
    "$scope", "$uibModalInstance","UsersService", "user",
    function ($scope, $uibModalInstance, UsersService, user) {
        $scope.submit = function () {
            UsersService.changeRole(user).then(
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
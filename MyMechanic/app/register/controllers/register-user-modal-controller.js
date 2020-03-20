app.controller("RegisterUserModalController", [
    "$scope", "$uibModalInstance", "SignInRegisterService","$rootScope","$state",
    function ($scope, $uibModalInstance, SignInRegisterService, $rootScope, $state) {
        $scope.registerModel = {
            UserName: "",
            Email: "",
            Password: "",
            ConfirmedPassword: "",
            Name: "",
            Surname: "",
            City: "",
            Country: "",
            Address: "",
            PostalCode: ""
        }
        //watch password and confirmed password for mistakes
        $scope.$watchGroup(['model.Password', 'model.ConfirmedPassword'], function (newValues) {
            if ($scope.submitted) {
                if (newValues[0] === newValues[1]) {
                    $scope.passwordsMatch = true;
                } else {
                    $scope.passwordsMatch = false;
                }
            }
        })
        //register user function
        $scope.registerUser = function (form) {
            $scope.submitted = true;

            if (form.$invalid || $scope.passwordsMatch == false) {
                return;
            }

            SignInRegisterService.registerUser($scope.registerModel).then(
                function (response) {
                    $uibModalInstance.dismiss(true);
                    SignInRegisterService.signIn({ Email: $scope.registerModel.Email, Password: $scope.registerModel.Password });
                    $rootScope.$broadcast('cookie-data', { Id: response.data });
                    $state.go("welcome");
                },
                function () {
                    $scope.hasError = true;
                });
        }

        $scope.cancel = function () {
            $uibModalInstance.dismiss(false);
        }
    }
]);
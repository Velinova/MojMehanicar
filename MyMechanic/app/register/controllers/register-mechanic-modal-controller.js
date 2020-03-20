app.controller("RegisterMechanicModalController", [
    "$scope", "$uibModalInstance", "SignInRegisterService", "$rootScope", "$state",
    function ($scope, $uibModalInstance, SignInRegisterService, $rootScope, $state) {
        $scope.model = {
            Holder: "",
            CardNumber: "",
            ExpirationDate: "",
            CVC: ""
        };
        $scope.registerModel = {
            UserName: "",
            Email: "",
            Password: "",
            ConfirmedPassword: "",
            CompanyName: "",
            City: "",
            Country: "",
            Address: "",
            PostalCode: ""
        }
        $scope.submitted = false;
        $scope.showSubscriptionForm = false;
        $scope.passwordsMatch = true;
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
        //open subcription form
        $scope.openSubscriptionForm = function () {
            $scope.showSubscriptionForm = true;
        }
        //pay subcription
        $scope.paySubscription = function (form) {
            $scope.submitted = true;

            if (form.$invalid) {
                return;
            }

            $scope.registerMechanic(form);
            $scope.cancel();
           

        }
        //register mechanic function
        $scope.registerMechanic = function (form) {
            $scope.submitted = true;

            if (form.$invalid || $scope.passwordsMatch == false) {
                return;
            }

            SignInRegisterService.registerMechanic($scope.registerModel).then(
                function (response) {
                    $scope.showSubscriptionForm = false;
                    $scope.cancel();
                    SignInRegisterService.signInMechanic({ Email: $scope.registerModel.Email, Password: $scope.registerModel.Password });
                    $rootScope.$broadcast('cookie-data2', { Id: response.data });
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
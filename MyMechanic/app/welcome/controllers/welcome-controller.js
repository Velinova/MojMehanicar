app.controller("WelcomeController", [
    "$scope", "$state", "SignInRegisterService", "$rootScope", "$uibModal","$cookies", 
    function ($scope, $state, SignInRegisterService, $rootScope, $uibModal, $cookies) {
        //form is not submitted
        $scope.submitted = false;
        $scope.isMechanic = false;
        //model
        $scope.model = {
            Email: "",
            Password: ""
        };

        //signin function
        $scope.signIn = function (form) {
            $scope.submitted = true;

            if (form.$invalid) {
                return;
            }

            if ($scope.isMechanic == false) {
                SignInRegisterService.signIn($scope.signInModel).then(
                    function (response) {
                        $rootScope.$broadcast('cookie-data', { Id: response.data });
                    },
                    function () {
                    });
            }
            else {
                SignInRegisterService.signInMechanic($scope.signInModel).then(
                    function (response) {
                        $rootScope.$broadcast('cookie-data2', { Id: response.data });
                    },
                    function () {
                    });
            }
        }
        //open register user dialog
        $scope.summonRegisterUserDialog = function () {
            var modalInstance = $uibModal.open(
                {
                    controller: "RegisterUserModalController",
                    templateUrl: "app/register/register-user-modal.html"
                }
            );

            modalInstance.result.then(
                function (response) {
                    //do nothing
                });
        }

        //open register mechanic dialog
        $scope.summonRegisterMechanicDialog = function () {
            var modalInstance = $uibModal.open(
                {
                    controller: "RegisterMechanicModalController",
                    templateUrl: "app/register/register-mechanic-modal.html"
                }
            );

            modalInstance.result.then(
                function (response) {
                    //do nothing
                });
        }



        //form is not submitted
        $scope.submitted = false;
        $scope.passwordsMatch = true;

        //model
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
        };

        $scope.$watchGroup(['model.Password', 'model.ConfirmedPassword'], function (newValues) {
            if ($scope.submitted) {
                if (newValues[0] === newValues[1]) {
                    $scope.passwordsMatch = true;
                } else {
                    $scope.passwordsMatch = false;
                }
            }
        })

        //register function
        $scope.register = function (form) {
            $scope.submitted = true;

            if (form.$invalid || $scope.passwordsMatch == false) {
                return;
            }

            SignInRegisterService.register($scope.registerModel).then(
                function (response) {
                    SignInRegisterService.signIn({ Email: $scope.registerModel.Email, Password: $scope.registerModel.Password });
                    $rootScope.$broadcast('cookie-data', { Id: response.data });
                    $state.go("home");
                },
                function () {
                    $scope.hasError = true;
                });
        }

    }


]);
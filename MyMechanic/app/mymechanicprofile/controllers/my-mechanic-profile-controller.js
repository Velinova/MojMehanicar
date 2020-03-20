app.controller("MyMechanicProfileController", [
    "$scope", "$uibModal", "MechanicsService", "UsersService", "$cookies", "$window",
    function ($scope, $uibModal, MechanicsService, UsersService, $cookies, $window) {
        $scope.activeTab = 1;
        $scope.activeItem = 3;
        $scope.id = $cookies.get('userId');
        $scope.mechanic = {};
        $scope.mechanicAverage = 0;
        $scope.newPassword = null;
        $scope.oldPassword = null;
        $scope.infoSubmitted = false;
        $scope.accountSubmitted = false;
        $scope.oldPasswordInvalid = false;
        function getUser() {
                MechanicsService.getById($scope.id).then(
                    function (response) {
                        $scope.mechanic = response.data;
                        $scope.mechanic.Id = $scope.id;
                    },
                    function (response) {
                        alert(response.data);
                    }
            );
            MechanicsService.getAverage($scope.id).then(
                function (response) {
                    $scope.mechanicAverage = response.data;
                },
                function (response) {
                    alert(response.data);
                }
            );

        }

        getUser();
        //change activetab function
        $scope.changeActiveTab = function (index) {
            $scope.activeTab = index;
        }
        //change activeitem function
        $scope.changeActiveItem = function (index) {
            $scope.activeItem = index;
        }
        //update personal info
        $scope.updatePersonlInfo = function (form) {
            $scope.infoSubmitted == true;
            if (form.$invalid) {
                return;
            }
                MechanicsService.update($scope.mechanic).then(
                    function (response) {
                        alert("Personal info updated");
                        $window.location.reload();
                    },
                    function (response) {
                        alert(response.data);
                    }
                );
        }
        //update account info
        $scope.updateAccountInfo = function (form) {
            $scope.accountSubmitted = true;
            if ($scope.oldPassword == $scope.mechanic.Password) {
                $scope.oldPasswordInvalid = false;
            }
            else {
                $scope.oldPasswordInvalid = true;
            }
            if (form.$invalid || $scope.oldPasswordInvalid) {
                return;
            }
                $scope.mechanic.Password = $scope.newPassword;
                MechanicsService.update($scope.mechanic).then(
                    function (response) {
                        alert("Personal info updated");
                        getUser();
                        $rootScope.$broadcast('cookie-data2', { Id: $scope.user.Id });
                        $window.location.reload();
                    },
                    function (response) {
                        getUser();
                        alert(response.data);
                    }
                );
            
        }
    }
]);     
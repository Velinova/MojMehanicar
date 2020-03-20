app.controller("EditVehicleModalController", [
    "$scope", "$uibModalInstance", "VehiclesService", "$cookies", "UsersService","vehicleId",
    function ($scope, $uibModalInstance, VehiclesService, $cookies, UsersService, vehicleId) {
        $scope.types = [{ key: 1, value: "Car" }, { key: 3, value: "Bus" }, { key: 3, value: "Train" }, { key: 4, value: "Motorcycle" }, { key: 5, value: "Bike" }, { key: 6, value: "Van" }];
        $scope.model = {
            Type: null,
            Model: "",
            License: ""
        };
        VehiclesService.getById(vehicleId).then(
            function (response) {
                $scope.model = response.data;
            }, 
            function (response) {
                alert(response.data);
            }
        );
        $scope.submitted = false;
        
        //edit vehicle function
        $scope.submit = function (form) {
            $scope.typeEmpty = false;
            $scope.submitted = true;
            if ($scope.model.Type == null) {
                $scope.typeEmpty = true;
            }
            if (form.$invalid || $scope.typeEmpty) {
                return;
            }

            VehiclesService.update($scope.model)
                .then(
                    function (response) {
                        $uibModalInstance.close(true);
                    },
                    function (response) {
                        alert(response.data);
                    }
                );
        }
        //close modal function 
        $scope.cancel = function () {

            $uibModalInstance.close(false);
        }
    }
]);
app.controller("MyInspectionsController", [
    "$scope", "UsersService", "MechanicsService", "$cookies", "$uibModal", "$window", "VehiclesService", "InspectionsService",
    function ($scope, UsersService, MechanicsService, $cookies, $uibModal, $window, VehiclesService, InspectionsService) {
        $scope.mechanics = [];
        $scope.vehicles = [];
        $scope.submitted = false;
        $scope.show = false;
        $scope.showId = null;
        $scope.rate = 0;

        $scope.pendingInspections = [];
        $scope.inProgressInspections = [];
        $scope.doneInspections = [];
        $scope.userId = $cookies.get('userId');
        $scope.model = {
            Mechanic: null,
            Vehicle: null,
            User: null,
            UserNote: null
        }
        $scope.updatemodel = {
            Id: null,
            Mechanic: null,
            Vehicle: null,
            User: null,
            UserNote: null,
            MechanicNote: null,
            Status: null,
            Rating: null
        };
        MechanicsService.getAll().then(
            function (response) {
                $scope.mechanics = response.data;
            },
            function (response) {
                alert(response.data);
            }
        );
        UsersService.getVehicles($scope.userId).then(
            function (response) {
                $scope.vehicles = response.data;
            },
            function (response) {
                alert(response.data);
            }
        );
        UsersService.getById($scope.userId).then(
            function (response) {
                $scope.model.User = response.data;
            },
            function (response) {
                alert(response.data);
            }
        );

        function fetchData() {
            //get inspection by status
            InspectionsService.getPending($scope.userId).then(
                function (response) {
                    $scope.pendingInspections = response.data;
                },
                function (response) {
                    alrt(response.data);
                }
            );
            InspectionsService.getInProgress($scope.userId).then(
                function (response) {
                    $scope.inProgressInspections = response.data;
                },
                function (response) {
                    alrt(response.data);
                }
            );
            InspectionsService.getDone($scope.userId).then(
                function (response) {
                    $scope.doneInspections = response.data;
                },
                function (response) {
                    alrt(response.data);
                }
            );
            UsersService.getById($scope.userId).then(
                function (response) {
                    $scope.model.User = response.data;
                },
                function (response) {
                    alert(response.data);
                }
            );

        }

        //function add inspection
        $scope.addInspection = function (form) {
            $scope.submitted = true;
            if (form.$invalid) {
                return;
            }
            //else add
            
            InspectionsService.addInspection($scope.model).then(
                function (response) {
                    fetchData();
                    $scope.model = {
                        Mechanic: null,
                        Vehicle: null,
                        UserNote: null
                    }
                    $scope.submitted = false;
                },
                function (response) {
                    alert(response.data);
                }
            );

        }
        
        // delete inspection
        $scope.deleteInspection = function (inspectionId) {

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
        //change show
        $scope.changeShow = function (id) {
            $scope.show = true;
            $scope.showId = id;
        }
        //submit rating
        $scope.submitRating = function () {
            
            InspectionsService.getById($scope.showId).then(
                function (response) {
                    console.log(response.data);
                    $scope.updatemodel.Id = $scope.showId;
                    $scope.updatemodel.Mechanic = response.data.Mechanic;
                    $scope.updatemodel.Vehicle = response.data.Vehicle;
                    $scope.updatemodel.User = response.data.User;
                    $scope.updatemodel.UserNote = response.data.UserNote;
                    $scope.updatemodel.MechanicNote = response.data.MechanicNote;
                    $scope.updatemodel.Status = response.data.Status;
                    
                    InspectionsService.update($scope.updatemodel).then(
                        function (response) {
                            $scope.show = false;
                            $scope.showId = false;
                            $scope.updatemodel.Rating = 0;
                            fetchData();
                        },
                        function (response) {
                            alert(response.data);
                        }
                    );
                },
                function (response) {
                    alert(response.data);
                }
            );
            
        }
        fetchData();
    }
]);
app.controller("AdminPanelController", [
    "$scope", "$stateParams", 
    function ($scope, $stateParams) {
        $scope.activeTab = Number($stateParams.id);

        $scope.tabs = [{ Header: "Users", Index: 0 }, { Header: "Mechanics", Index: 1 },
            { Header: "Vehicles", Index: 2 }, { Header: "Inspections", Index: 3 }];
        

    }
]);
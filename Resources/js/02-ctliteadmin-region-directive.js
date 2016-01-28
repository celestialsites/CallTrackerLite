var $nwsc = $nwsc || {};

$nwsc.regionAddEditDirective = function (ModulePath) {
    return {
        scope: {
            editRegion: '=?',
            title: '@',
            saveRegion: '&saveRegion',
            refreshRegions: '&'
        },
        restrict: 'E',
        templateUrl: ModulePath + 'Resources/js/templates/region-addedit.html',
        controller: ['$scope', function ($scope) {
            if (typeof $scope.editRegion === 'undefined') {
                $scope.editRegion = new $nwsc.city();

            }
            $scope.showAddEdit = function () {
                $(".modal").hide();
                $("#mdlAddEditCity-" + $scope.editRegion.CityId).modal();
            };
        }],
        link: function (scope, elem, attrs) {
            scope.Name = attrs['name'];

            scope.saveButton = function (e, form) {
                e.preventDefault();
                scope.invalidSubmitAttempt = false;
                if (form.$invalid) {
                    scope.invalidSubmitAttempt = true;
                    return;
                }

                // Call our passed in save DPCode function
                if (angular.isFunction(scope.saveRegion)) {
                    var saveFnExp = scope.saveRegion();
                    saveFnExp(scope.editRegion);
                }

                // Hide the modal, reset the scope, reset the form validation
                $("#mdlAddEditCity-" + scope.editRegion.CityId).modal('hide');
                if (scope.editRegion.CityId === 0)
                    scope.editRegion = new $nwsc.city();
                form.$setPristine();
            }

            scope.cancelButton = function () {
                $("#mdlAddEditCity-" + scope.editRegion.CityId).modal('hide');
                $("#mdlAddEditCity-" + scope.editRegion.CityId).on('hidden.bs.modal', function () {
                    if (angular.isFunction(scope.refreshRegions)) {
                        var refFnExp = scope.refreshRegions();
                        refFnExp();
                    }
                })
            }
        }
    }
};

$nwsc.city = function () {
    this.CityId = 0;
    this.CityName = '';
    this.RegionName = '';
    this.UtilityType = '';
};
var $nwsc = $nwsc || {};

$nwsc.dpcodeAddEditDirective = function (ModulePath) {
    return {
        scope: {
            editEntity: '=?',
            title: '@',
            saveFunction: '&saveFunction',
            refreshDpcodes: '&'
        },
        restrict: 'E',
        templateUrl: ModulePath + 'Resources/js/templates/dpcode-addedit.html',
        controller: ['$scope', function ($scope) {
            if (typeof $scope.editEntity === 'undefined') {
                $scope.editEntity = new $nwsc.DPCode();

            }
            $scope.showAddEdit = function () {
                $(".modal").hide();
                $("#mdlAddEditDpcode-" + $scope.editEntity.DispatchCodeId).modal();
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
                if (angular.isFunction(scope.saveFunction)) {
                    var saveFnExp = scope.saveFunction();
                    saveFnExp(scope.editEntity);
                }

                // Hide the modal, reset the scope, reset the form validation
                $("#mdlAddEditDpcode-" + scope.editEntity.DispatchCodeId).modal('hide');
                if (scope.editEntity.DispatchCodeId === 0)
                    scope.editEntity = new $nwsc.DPCode();
                form.$setPristine();
            }

            scope.cancelButton = function () {
                $("#mdlAddEditDpcode-" + scope.editEntity.DispatchCodeId).modal('hide');
                $("#mdlAddEditDpcode-" + scope.editEntity.DispatchCodeId).on('hidden.bs.modal', function () {
                    if (angular.isFunction(scope.refreshDpcodes)) {
                        var refFnExp = scope.refreshDpcodes();
                        refFnExp();
                    }
                })
            }
        }
    }
};

$nwsc.DPCode = function () {
    this.DispatchCodeId = 0;
    this.DispatchCodeName = '';
};
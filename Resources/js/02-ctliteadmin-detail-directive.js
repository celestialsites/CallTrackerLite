var $nwsc = $nwsc || {};

$nwsc.ctdetailAddEditDirective = function (ModulePath) {

    return {
        scope: {
            editDetails: '=?',
            title: '@',
            editCall: '=',
            dispatcherList: '=',
            dispatchcodeList: '=',
            saveFunction: '&saveFunction',
            refreshCalldetails: '&'
        },
        restrict: 'E',
        templateUrl: ModulePath + 'Resources/js/templates/calldetail-addedit.html',
        controller: ['$scope', function ($scope) {
            if (typeof $scope.editDetails === 'undefined') {
                $scope.editDetails = new $nwsc.CTCallDetails();
                $scope.editDetails.CallId = $scope.editCall.CallId;
            }
            $scope.chkBoxDispatchFlag = '1';
            if ($scope.editCall.DispatchFlag === 0) {
                $scope.chkBoxDispatchFlag = '0';
            }
            $scope.showAddEdit = function () {
                $(".modal").hide();
                $("#mdlAddEditCalldetails-" + $scope.editDetails.CallDetailId).modal();
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
                scope.editCall.DispatchFlag = scope.chkBoxDispatchFlag


                // Call our passed in save CTCall function
                if (angular.isFunction(scope.saveFunction)) {
                    var saveFnExp = scope.saveFunction();
                    saveFnExp(scope.editDetails, scope.editCall);
                }

                // Hide the modal, reset the scope, reset the form validation
                $("#mdlAddEditCalldetails-" + scope.editDetails.CallDetailId).modal('hide');
                $("#mdlAddEditCalldetails-" + scope.editDetails.CallDetailId).on('hidden.bs.modal', function () {
                    if (angular.isFunction(scope.refreshCalldetails)) {
                        var refFnExp = scope.refreshCalldetails();
                        refFnExp(scope.editCall);
                    }
                })
                if (scope.editDetails.CallDetailId === 0) {
                    scope.editDetails = new $nwsc.CTCallDetails();
                }
                form.$setPristine();
            }

            scope.cancelButton = function () {
                $("#mdlAddEditCalldetails-" + scope.editDetails.CallDetailId).modal('hide');
                $("#mdlAddEditCalldetails-" + scope.editDetails.CallDetailId).on('hidden.bs.modal', function () {
                    if (angular.isFunction(scope.refreshCalldetails)) {
                        var refFnExp = scope.refreshCalldetails();
                        refFnExp(scope.editCall);
                    }
                })
            }
        }
    }
};

$nwsc.CTCallDetails = function () {
    this.CallDetailId = 0;
    this.CallId = 0;
    this.DispatchCode = '';
    this.DispatchCodeId = 0;
    this.DispatchTime = '';
    this.Comments = '';
    this.Dispatcher = '';
    this.DispatcherId = 0;
};

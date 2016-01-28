var $nwsc = $nwsc || {};

$nwsc.mainController = function mainController($http, $log, AppServiceFramework) {
    // Set vm to the scope of this controller
    var vm = this;

    // Set API base url
    var serviceRoot = AppServiceFramework.getServiceRoot('CTLiteAdmin');

    vm.EditMode = true;
    vm.dispatchers = [];
    vm.regions = [];
    vm.citys = [];
    vm.EditIndex = -1;
    vm.ctcalls = [];
    vm.callid = -1;

    //vm.show = 'default';

    //Get Dispatchers

    vm.getAllDispatchers = function () {
        $http.get(serviceRoot + 'dispatcher/dpList')
            .success(function (response) {
                vm.dispatchers = response;
            })
            .error(function (data) {
                $log.error('Failure to return dispatcher', data);
            });
    }

    vm.createUpdateDispatcher = function (dispatcher) {
        // make a copy of the dispatcher to not change directive scope
        var dispatcherCp = angular.copy(dispatcher);
        var sMethod = "dispatcher/dpnew";
        if (dispatcherCp.DispatcherId > 0) { sMethod = "dispatcher/dpupdate"; }

        $http.post(serviceRoot + sMethod, dispatcherCp)
            .success(function (response) {
                if (sMethod === "dispatcher/dpnew") {
                    var id = parseInt(response);
                    if (id > 0) {
                        dispatcherCp.DispatcherId = id;
                        vm.dispatchers.push(dispatcherCp);
                    }
                } else {
                    if (vm.EditIndex >= 0)
                        vm.dispatchers[vm.EditIndex] = dispatcherCp;

                }
            })
            .error(function (errorPayload) {
                $log.error('failure saving dispatcher', errorPayload);
            });
    }

    vm.deleteDispatcher = function (dispatcher, idx) {
        if (confirm('Are you sure to delete "' + dispatcher.DispatcherName + '"?')) {
            $http.post(serviceRoot + 'dispatcher/dpdelete', angular.toJson(dispatcher))
                .success(function (response) {
                    vm.dispatchers.splice(idx, 1);
                })
                .error(function (errorPayload) {
                    $log.error('failure deleting dispatcher', errorPayload);
                });
        }
    }


    vm.getAllDPCodes = function () {
        $http.get(serviceRoot + 'dpcode/dpcodeList')
            .success(function (response) {
                vm.dpcodes = response;
            })
            .error(function (data) {
                $log.error('Failure to return Dispatch code', data);
            });
    }

    vm.createUpdateDPCode = function (dpcode) {
        // make a copy of the dispatcher to not change directive scope
        var dpcodeCp = angular.copy(dpcode);
        var sMethod = "dpcode/dpcodenew";
        if (dpcodeCp.DispatchCodeId > 0) { sMethod = "dpcode/dpcodeupdate"; }

        $http.post(serviceRoot + sMethod, dpcodeCp)
            .success(function (response) {
                if (sMethod === "dpcode/dpcodenew") {
                    var id = parseInt(response);
                    if (id > 0) {
                        dpcodeCp.DispatchCodeId = id;
                        vm.dpcodes.push(dpcodeCp);
                    }
                } else {
                    if (vm.EditIndex >= 0)
                        vm.dpcodes[vm.EditIndex] = dpcodeCp;

                }
            })
            .error(function (errorPayload) {
                $log.error('failure saving dispatch code', errorPayload);
            });
    }

    vm.deleteDPCode = function (dpcode, idx) {
        if (confirm('Are you sure to delete "' + dpcode.DispatchCodeName + '"?')) {
            $http.post(serviceRoot + 'dpcode/dpcodedelete', angular.toJson(dpcode))
                .success(function (response) {
                    vm.dpcodes.splice(idx, 1);
                })
                .error(function (errorPayload) {
                    $log.error('failure deleting dispatch code', errorPayload);
                });
        }
    }



    vm.getAllCitys = function () {
        $http.get(serviceRoot + 'region/cityList')
            .success(function (response) {
                vm.citys = response;
            })
            .error(function (data) {
                $log.error('Failure to return Citys', data);
            });
    }


    vm.createUpdateCity = function (city) {
        // make a copy of the dispatcher to not change directive scope
        var cityCp = angular.copy(city);
        var sMethod = "region/citynew";
        if (cityCp.CityId > 0) { sMethod = "region/cityupdate"; }

        $http.post(serviceRoot + sMethod, cityCp)
            .success(function (response) {
                if (sMethod === "region/citynew") {
                    var id = parseInt(response);
                    if (id > 0) {
                        cityCp.CityId = id;
                        vm.citys.push(cityCp)
                        //vm.getAllCitys();
                        vm.show = 'regions';
                    }
                } else {
                    if (vm.EditIndex >= 0)
                        vm.getAllCitys();
                    //     vm.citys[vm.EditIndex] = cityCp;
                    vm.show = 'regions';


                }
            })
            .error(function (errorPayload) {
                $log.error('failure saving City', errorPayload);
            });
    }

    vm.deleteCity = function (city, idx) {
        if (confirm('Are you sure to delete "' + city.CityName + '"?')) {
            $http.post(serviceRoot + 'region/citydelete', angular.toJson(city))
                .success(function (response) {
                    vm.citys.splice(idx, 1);
                })
                .error(function (errorPayload) {
                    $log.error('failure deleting city code', errorPayload);
                });
        }
    }


    // Get calls
    vm.getAllOpenCalls = function () {
        $http.get(serviceRoot + 'ctcall/ctOpenCallList')
            .success(function (response) {
                vm.opencalls = response;
            })
            .error(function (data) {
                $log.error('Failure to return Open Calls', data);
            });
    }

    vm.deleteCtOpencall = function (call, idx) {
        if (confirm('Are you sure to delete Call Name=  "' + call.CallerName + '"?')) {
            $http.post(serviceRoot + 'ctcall/ctCallDelete', angular.toJson(call))
                .success(function (response) {
                    vm.opencalls.splice(idx, 1);
                })
                .error(function (errorPayload) {
                    $log.error('failure deleting Open call', errorPayload);
                });
        }
    }


    // Get calls
    vm.getAllCalls = function () {
        $http.get(serviceRoot + 'ctcall/ctCallList')
            .success(function (response) {
                vm.calls = response;
            })
            .error(function (data) {
                $log.error('Failure to return Calls', data);
            });
    }

    //vm.getCall = function (call) {
    //    $http.get(serviceRoot + 'ctcall/ctGetCall', angular.toJson(call))
    //        .success(function (response) {
    //            vm.ctcalls = response;
    //        })
    //        .error(function (data) {
    //            $log.error('Failure to return a Call', data);
    //        });
    //}

    vm.createUpdateCall = function (call) {
        // make a copy of the dispatcher to not change directive scope
        var ctCallCP = angular.copy(call);
        var sMethod = "ctcall/ctCallNew";
        if (ctCallCP.CallId > 0) { sMethod = "ctcall/ctCallUpdate"; }

        $http.post(serviceRoot + sMethod, ctCallCP)
            .success(function (response) {
                //vm.getAllCalls();
                if (sMethod === "ctcall/ctCallNew") {
                    var id = parseInt(response);
                    if (id > 0) {
                        ctCallCP.CallId = id;
                        vm.calls.push(ctCallCP);
                        //vm.getAllCalls();
                    }
                } else {
                    if (vm.EditIndex >= 0)
                        vm.calls[vm.EditIndex] = ctCallCP ;
                }
            })
            .error(function (errorPayload) {
                $log.error('failure saving Calls', errorPayload);
            });
        
    }

    vm.deleteCtcall = function (call, idx) {
        if (confirm('Are you sure to delete Call Name=  "' + call.CallerName + '"?')) {
            $http.post(serviceRoot + 'ctcall/ctCallDelete', angular.toJson(call))
                .success(function (response) {
                    vm.calls.splice(idx, 1);
                })
                .error(function (errorPayload) {
                    $log.error('failure deleting call', errorPayload);
                });
        }
    }


    vm.getAllCallDetails = function (call) {
            $http.get(serviceRoot + 'ctcalldetail/ctCallDetailList?t=' + call.CallId)
            .success(function (response) {
                vm.calldetails = response;
            })
            .error(function (data) {
                $log.error('Failure to return Detail Calls', data);
            });
        
    }


    vm.createUpdateDetail = function (detail, call) {
        // make a copy of the dispatcher to not change directive scope
        var ctCallCP = angular.copy(call);
        var ctCallDetailCP = angular.copy(detail);
        var sMethod = "ctcalldetail/ctCallDetailNew";
        if (ctCallDetailCP.CallDetailId > 0) { sMethod = "ctcalldetail/ctCallDetailUpdate"; }


        //ctCallCP.DispatchFlag = 1;
        $http.post(serviceRoot + "ctcall/ctCallUpdate", ctCallCP)
            .success(function (response) {
                //vm.getAllCalls();
            })
            .error(function (errorPayload) {
                $log.error('failure updating Dispatch Flag on Calls', errorPayload);
            });

        $http.post(serviceRoot + sMethod, ctCallDetailCP)
            .success(function (response) {
                if (sMethod === "ctcalldetail/ctCallDetailNew") {
                    var id = parseInt(response);
                    if (id > 0) {
                        ctCallDetailCP.CallDetailId = id;
                        vm.calldetails.push(ctCallDetailCP);
                    }
                } else {
                    if (vm.EditIndex >= 0)
                        vm.calldetails[vm.EditIndex] = ctCallDetailCP;
                }
            })
            .error(function (errorPayload) {
                $log.error('failure saving Details', errorPayload);
            });


    }


    vm.deleteCtcalldetails = function (detail, idx) {
        if (confirm('Are you sure to delete Call Detail for Dispatcher =  "' + detail.Dispatcher + '"?')) {
            $http.post(serviceRoot + 'ctcalldetail/ctCallDetailDelete', angular.toJson(detail))
                .success(function (response) {
                    vm.calldetails.splice(idx, 1);
                })
                .error(function (errorPayload) {
                    $log.error('failure deleting call Details', errorPayload);
                });
        }
    }


    //vm.addCalls = function () {
    //    vm.show = 'new';
    //    $http.get(serviceRoot + 'home/GetRegions')
    //       .success(function (response) {
    //           vm.regions = response;
    //       })
    //       .error(function (data) {
    //           console.log(data);
    //       });

    //}

    vm.todayCalls = function () {
        vm.getAllCalls();
        vm.getAllCitys();
        vm.show = 'calls';
    }

    vm.openCalls = function () {
        vm.getAllOpenCalls();
        vm.getAllCitys();
        vm.show = 'opencalls';
        vm.predicate = 'CallId';
        vm.reverse = true;
    }

    vm.reviewCallDetails = function (call, idx) {
        //vm.getCall(call)
        //        vm.EditIndex = idx;
        //vm.callid = vm.calls[idx].CallId;
        //vm.callid = call.CallId;
        vm.ctcalls = angular.copy(call);
        vm.getAllCallDetails(call);
        vm.getAllDispatchers();
        vm.getAllDPCodes();
        vm.show = 'details'
    }

    vm.adminDispatchers = function () {
        vm.getAllDispatchers();
        vm.show = 'dispatch';
    }

    vm.adminDPCodes = function () {
        vm.show = 'dpcode';
        vm.getAllDPCodes();
    }

    vm.adminCitys = function () {
        vm.getAllCitys();
        vm.show = 'regions';
    }

    vm.cancel = function () {
        vm.show = 'default';
    }

    vm.init = function (editable) {
        vm.EditMode = editable;
        vm.show = 'default';
    }

    vm.order = function (predicate) {
        vm.reverse = (vm.predicate === predicate) ? !vm.reverse : false;
        vm.predicate = predicate;
    };



}
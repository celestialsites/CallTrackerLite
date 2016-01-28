Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports DotNetNuke.Web.Api
Imports DotNetNuke.Security
Imports NWSC.Modules.CTLiteAdmin.Components
Imports NWSC.Modules.CTLiteAdmin.Components.Common
Imports NWSC.Modules.CTLiteAdmin.MyEntities



Namespace Services.Controllers
    <SupportedModulesAttribute(Constants.DESKTOPMODULE_NAME)>
    <DnnModuleAuthorizeAttribute(AccessLevel:=SecurityAccessLevel.View)>
    Public Class homeController
        Inherits DnnApiController

        'Private _cityRepository As CityRepository
        'Private _dispatcherRepository As DispatcherRepository
        'Private _dpcodeRepository As DPCodeRepository
        'Private _itemRepository As ItemRepository

        'Public Sub New()
        '    _cityRepository = New CityRepository()
        '    _dispatcherRepository = New DispatcherRepository()
        '    _dpcodeRepository = New DPCodeRepository()
        '    _itemRepository = New ItemRepository()

        'End Sub

#Region "Test"


        ''' <summary>
        ''' API that returns Hello world
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ActionName("Test")>
        <AllowAnonymous>
        Public Function HelloWorld() As HttpResponseMessage
            Return Request.CreateResponse(HttpStatusCode.OK, "Hello DNN Angular World!")
        End Function
#End Region

        '#Region "Dispatcher API"

        '        ''' <summary>
        '        ''' API that returns an Dispatcher List
        '        ''' </summary>
        '        ''' <returns></returns>
        '        <HttpPost, HttpGet>
        '        <ValidateAntiForgeryTokenAttribute>
        '        <ActionName("dpList")>
        '        Public Function GetAllDispatchers() As HttpResponseMessage

        '            Try
        '                Dim dispatcherList = _dispatcherRepository.GetDispatchers(ActiveModule.ModuleID)
        '                Return Request.CreateResponse(HttpStatusCode.OK, dispatcherList.ToList())
        '            Catch ex As Exception
        '                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
        '            End Try

        '        End Function

        '        ''' <summary>
        '        ''' API that creates a new Dispatchers
        '        ''' </summary>
        '        ''' <returns></returns>
        '        <HttpPost, HttpGet>
        '        <ValidateAntiForgeryToken>
        '        <ActionName("dpnew")>
        '        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        '        Public Function AddDispatcher(t As RequestDispatcher) As HttpResponseMessage
        '            Try
        '                Dim newDispatcher As New Dispatcher()
        '                newDispatcher.ModuleId = ActiveModule.ModuleID
        '                newDispatcher.CreatedByUserId = UserInfo.UserID
        '                newDispatcher.CreatedOnDate = DateTime.Now
        '                newDispatcher.LastModifiedByUserId = UserInfo.UserID
        '                newDispatcher.LastModifiedOnDate = DateTime.Now
        '                newDispatcher.CellPhone = t.CellPhone
        '                newDispatcher.HomePhone = t.HomePhone
        '                newDispatcher.AltPhone = t.AltPhone
        '                newDispatcher.DispatcherName = t.DispatcherName
        '                newDispatcher.DispatcherType = t.DispatcherType
        '                Dim dispatcherid As Integer = _dispatcherRepository.AddDispatcher(newDispatcher)
        '                Return Request.CreateResponse(HttpStatusCode.OK, dispatcherid)
        '            Catch ex As Exception
        '                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
        '            End Try
        '        End Function

        '        ''' <summary>
        '        ''' API that deletes a Dispatcher 
        '        ''' </summary>
        '        ''' <returns></returns>
        '        <HttpPost, HttpGet>
        '        <ValidateAntiForgeryTokenAttribute>
        '        <ActionName("dpdelete")>
        '        Public Function DeleteDispatcher(delit As Dispatcher) As HttpResponseMessage

        '            Try
        '                _dispatcherRepository.DeleteDispatcher(delit)
        '                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
        '            Catch ex As Exception
        '                Return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message)
        '            End Try

        '        End Function

        '        ''' <summary>
        '        ''' API that updates a Dispatcher
        '        ''' </summary>
        '        ''' <returns></returns>
        '        <HttpPost>
        '        <ValidateAntiForgeryToken>
        '        <ActionName("dpupdate")>
        '        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        '        Public Function UpdateDispatcher(t As Dispatcher) As HttpResponseMessage
        '            Try
        '                t.LastModifiedByUserId = UserInfo.UserID
        '                t.LastModifiedOnDate = DateTime.Now
        '                _dispatcherRepository.UpdateDispatcher(t)
        '                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
        '            Catch ex As Exception
        '                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
        '            End Try
        '        End Function
        '#End Region

        '#Region "Dispatch Code API"

        '        ''' <summary>
        '        ''' API that returns a Dispatch Code List
        '        ''' </summary>
        '        ''' <returns></returns>
        '        <HttpPost, HttpGet>
        '        <ValidateAntiForgeryTokenAttribute>
        '        <ActionName("dpcodeList")>
        '        Public Function GetAllDPCodes() As HttpResponseMessage

        '            Try
        '                Dim dpCodeList = _dpcodeRepository.GetDPCodes(ActiveModule.ModuleID)
        '                Return Request.CreateResponse(HttpStatusCode.OK, dpCodeList.ToList())
        '            Catch ex As Exception
        '                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
        '            End Try

        '        End Function

        '        ''' <summary>
        '        ''' API that creates a new Dispatch Code
        '        ''' </summary>
        '        ''' <returns></returns>
        '        <HttpPost, HttpGet>
        '        <ValidateAntiForgeryToken>
        '        <ActionName("dpcodenew")>
        '        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        '        Public Function AddDPCode(t As RequestDPCode) As HttpResponseMessage
        '            Try
        '                Dim newDPCode As New DPCode()
        '                newDPCode.ModuleId = ActiveModule.ModuleID
        '                newDPCode.CreatedByUserId = UserInfo.UserID
        '                newDPCode.CreatedOnDate = DateTime.Now
        '                newDPCode.LastModifiedByUserId = UserInfo.UserID
        '                newDPCode.LastModifiedOnDate = DateTime.Now
        '                newDPCode.DispatchCodeName = t.DispatchCodeName
        '                Dim dpcodeid As Integer = _dpcodeRepository.AddDPCode(newDPCode)
        '                Return Request.CreateResponse(HttpStatusCode.OK, dpcodeid)
        '            Catch ex As Exception
        '                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
        '            End Try
        '        End Function

        '        ''' <summary>
        '        ''' API that deletes a Dispatch Code
        '        ''' </summary>
        '        ''' <returns></returns>
        '        <HttpPost, HttpGet>
        '        <ValidateAntiForgeryTokenAttribute>
        '        <ActionName("dpcodedelete")>
        '        Public Function DeleteDispatchCode(delit As DPCode) As HttpResponseMessage

        '            Try
        '                _dpcodeRepository.DeleteDPCode(delit)
        '                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
        '            Catch ex As Exception
        '                Return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message)
        '            End Try

        '        End Function

        '        ''' <summary>
        '        ''' API that updates a Dispatch Code
        '        ''' </summary>
        '        ''' <returns></returns>
        '        <HttpPost>
        '        <ValidateAntiForgeryToken>
        '        <ActionName("dpcodeupdate")>
        '        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        '        Public Function UpdateDispatchCode(t As DPCode) As HttpResponseMessage
        '            Try
        '                t.LastModifiedByUserId = UserInfo.UserID
        '                t.LastModifiedOnDate = DateTime.Now
        '                _dpcodeRepository.UpdateDPCode(t)
        '                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
        '            Catch ex As Exception
        '                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
        '            End Try
        '        End Function

        '#End Region

        '#Region "City/Region API"


        '        ''' <summary>
        '        ''' API that returns an City/Region List
        '        ''' </summary>
        '        ''' <returns></returns>
        '        <HttpPost, HttpGet>
        '        <ValidateAntiForgeryTokenAttribute>
        '        <ActionName("cityList")>
        '        Public Function GetAllCitys() As HttpResponseMessage

        '            Try
        '                Dim cityList = _cityRepository.GetCitys(ActiveModule.ModuleID)
        '                Return Request.CreateResponse(HttpStatusCode.OK, cityList.ToList())
        '            Catch ex As Exception
        '                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
        '            End Try

        '        End Function
        '        ''' <summary>
        '        ''' API that creates a new City/Region
        '        ''' </summary>
        '        ''' <returns></returns>
        '        <HttpPost, HttpGet>
        '        <ValidateAntiForgeryToken>
        '        <ActionName("citynew")>
        '        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        '        Public Function Addcity(t As RequestCity) As HttpResponseMessage
        '            Try
        '                Dim newcity As New City()
        '                newcity.ModuleId = ActiveModule.ModuleID
        '                newcity.CreatedByUserId = UserInfo.UserID
        '                newcity.CreatedOnDate = DateTime.Now
        '                newcity.LastModifiedByUserId = UserInfo.UserID
        '                newcity.LastModifiedOnDate = DateTime.Now
        '                newcity.CityName = t.CityName
        '                newcity.RegionName = t.RegionName
        '                newcity.UtilityType = t.UtilityType
        '                Dim cityid As Integer = _cityRepository.AddCity(newcity)
        '                Return Request.CreateResponse(HttpStatusCode.OK, cityid)
        '            Catch ex As Exception
        '                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
        '            End Try
        '        End Function

        '        ''' <summary>
        '        ''' API that Updates a city/region
        '        ''' </summary>
        '        ''' <returns></returns>
        '        <HttpPost>
        '        <ValidateAntiForgeryToken>
        '        <ActionName("cityupdate")>
        '        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        '        Public Function UpdateCityCode(t As City) As HttpResponseMessage
        '            Try
        '                t.LastModifiedByUserId = UserInfo.UserID
        '                t.LastModifiedOnDate = DateTime.Now
        '                _cityRepository.UpdateCity(t)
        '                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
        '            Catch ex As Exception
        '                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
        '            End Try
        '        End Function

        '        ''' <summary>
        '        ''' API that Deletes a City/Region
        '        ''' </summary>
        '        ''' <returns></returns>
        '        <HttpPost, HttpGet>
        '        <ValidateAntiForgeryTokenAttribute>
        '        <ActionName("citydelete")>
        '        Public Function DeleteCityCode(delit As City) As HttpResponseMessage

        '            Try
        '                _cityRepository.DeleteCity(delit)
        '                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
        '            Catch ex As Exception
        '                Return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message)
        '            End Try

        '        End Function
        '#End Region


    End Class


    'Public Class RequestDispatcher
    '    Private _dispatcherId As Integer
    '    Private _dispatcherName As String
    '    Private _dispatcherType As String
    '    Private _cellPhone As Int64
    '    Private _homePhone As Int64
    '    Private _altPhone As Int64
    '    Private _createdByUserId As Integer
    '    Private _lastModifiedByUserId As Integer
    '    Private _createdOnDate As DateTime
    '    Private _lastModifiedOnDate As DateTime
    '    Private _moduleId As Integer

    '    Public Property DispatcherId() As Integer
    '        Get
    '            Return _dispatcherId
    '        End Get
    '        Set(ByVal value As Integer)
    '            _dispatcherId = value
    '        End Set
    '    End Property


    '    Public Property DispatcherName() As String
    '        Get
    '            Return _dispatcherName
    '        End Get
    '        Set(ByVal value As String)
    '            _dispatcherName = value
    '        End Set
    '    End Property
    '    Public Property DispatcherType() As String
    '        Get
    '            Return _dispatcherType
    '        End Get
    '        Set(ByVal value As String)
    '            _dispatcherType = value
    '        End Set
    '    End Property

    '    Public Property CellPhone() As Int64
    '        Get
    '            Return _cellPhone
    '        End Get
    '        Set(ByVal value As Int64)
    '            _cellPhone = value
    '        End Set
    '    End Property

    '    Public Property HomePhone() As Int64
    '        Get
    '            Return _homePhone
    '        End Get
    '        Set(ByVal value As Int64)
    '            _homePhone = value
    '        End Set
    '    End Property
    '    Public Property AltPhone() As Int64
    '        Get
    '            Return _altPhone
    '        End Get
    '        Set(ByVal value As Int64)
    '            _altPhone = value
    '        End Set
    '    End Property

    '    Public Overloads Property CreatedByUserId() As Integer
    '        Get
    '            Return _createdByUserId
    '        End Get
    '        Set(ByVal value As Integer)
    '            _createdByUserId = value
    '        End Set
    '    End Property

    '    Public Overloads Property LastModifiedByUserId() As Integer
    '        Get
    '            Return _lastModifiedByUserId
    '        End Get
    '        Set(ByVal value As Integer)
    '            _lastModifiedByUserId = value
    '        End Set
    '    End Property

    '    Public Overloads Property CreatedOnDate() As DateTime
    '        Get
    '            Return _createdOnDate
    '        End Get
    '        Set(ByVal value As DateTime)
    '            _createdOnDate = value
    '        End Set
    '    End Property
    '    Public Overloads Property LastModifiedOnDate() As DateTime
    '        Get
    '            Return _lastModifiedOnDate
    '        End Get
    '        Set(ByVal value As DateTime)
    '            _lastModifiedOnDate = value
    '        End Set
    '    End Property

    '    Public Overloads Property ModuleId() As Integer
    '        Get
    '            Return _moduleId
    '        End Get
    '        Set(ByVal value As Integer)
    '            _moduleId = value
    '        End Set
    '    End Property





    'End Class

    'Public Class RequestDPCode
    '    Private _dispatchcodeId As Integer
    '    Private _dispatchCodeName As String
    '    Private _createdByUserId As Integer
    '    Private _lastModifiedByUserId As Integer
    '    Private _createdOnDate As DateTime
    '    Private _lastModifiedOnDate As DateTime
    '    Private _moduleId As Integer

    '    Public Property DispatchCodeId() As Integer
    '        Get
    '            Return _dispatchcodeId
    '        End Get
    '        Set(ByVal value As Integer)
    '            _dispatchcodeId = value
    '        End Set
    '    End Property


    '    Public Property DispatchCodeName() As String
    '        Get
    '            Return _dispatchCodeName
    '        End Get
    '        Set(ByVal value As String)
    '            _dispatchCodeName = value
    '        End Set
    '    End Property

    '    Public Overloads Property CreatedByUserId() As Integer
    '        Get
    '            Return _createdByUserId
    '        End Get
    '        Set(ByVal value As Integer)
    '            _createdByUserId = value
    '        End Set
    '    End Property

    '    Public Overloads Property LastModifiedByUserId() As Integer
    '        Get
    '            Return _lastModifiedByUserId
    '        End Get
    '        Set(ByVal value As Integer)
    '            _lastModifiedByUserId = value
    '        End Set
    '    End Property

    '    Public Overloads Property CreatedOnDate() As DateTime
    '        Get
    '            Return _createdOnDate
    '        End Get
    '        Set(ByVal value As DateTime)
    '            _createdOnDate = value
    '        End Set
    '    End Property
    '    Public Overloads Property LastModifiedOnDate() As DateTime
    '        Get
    '            Return _lastModifiedOnDate
    '        End Get
    '        Set(ByVal value As DateTime)
    '            _lastModifiedOnDate = value
    '        End Set
    '    End Property

    '    Public Overloads Property ModuleId() As Integer
    '        Get
    '            Return _moduleId
    '        End Get
    '        Set(ByVal value As Integer)
    '            _moduleId = value
    '        End Set
    '    End Property

    'End Class

    'Public Class RequestCity

    '    Private _cityId As Integer
    '    Private _cityName As String
    '    Private _regionName As String
    '    Private _utilityType As String
    '    Private _createdByUserId As Integer
    '    Private _lastModifiedByUserId As Integer
    '    Private _createdOnDate As DateTime
    '    Private _lastModifiedOnDate As DateTime
    '    Private _moduleId As Integer

    '    Public Property CityId() As Integer
    '        Get
    '            Return _cityId
    '        End Get
    '        Set(ByVal value As Integer)
    '            _cityId = value
    '        End Set
    '    End Property


    '    Public Property CityName() As String
    '        Get
    '            Return _cityName
    '        End Get
    '        Set(ByVal value As String)
    '            _cityName = value
    '        End Set
    '    End Property

    '    Public Property RegionName() As String
    '        Get
    '            Return _regionName
    '        End Get
    '        Set(ByVal value As String)
    '            _regionName = value
    '        End Set
    '    End Property

    '    Public Overloads Property UtilityType() As String
    '        Get
    '            Return _utilityType
    '        End Get
    '        Set(ByVal value As String)
    '            _utilityType = value
    '        End Set
    '    End Property

    '    Public Overloads Property CreatedByUserId() As Integer
    '        Get
    '            Return _createdByUserId
    '        End Get
    '        Set(ByVal value As Integer)
    '            _createdByUserId = value
    '        End Set
    '    End Property

    '    Public Overloads Property LastModifiedByUserId() As Integer
    '        Get
    '            Return _lastModifiedByUserId
    '        End Get
    '        Set(ByVal value As Integer)
    '            _lastModifiedByUserId = value
    '        End Set
    '    End Property

    '    Public Overloads Property CreatedOnDate() As DateTime

    '        Get
    '            Return _createdOnDate
    '        End Get
    '        Set(ByVal value As DateTime)
    '            _createdOnDate = value
    '        End Set
    '    End Property
    '    Public Overloads Property LastModifiedOnDate() As DateTime
    '        Get
    '            Return _lastModifiedOnDate
    '        End Get
    '        Set(ByVal value As DateTime)
    '            _lastModifiedOnDate = value
    '        End Set
    '    End Property

    '    Public Overloads Property ModuleId() As Integer
    '        Get
    '            Return _moduleId
    '        End Get
    '        Set(ByVal value As Integer)
    '            _moduleId = value
    '        End Set
    '    End Property



    'End Class







End Namespace

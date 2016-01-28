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
    Public Class ctcallController
        Inherits DnnApiController

        Private _ctcallRepository As CTCallRepository
        Private _cityRepository As CityRepository

        Public Sub New()
            _ctcallRepository = New CTCallRepository()
            _cityRepository = New CityRepository()

        End Sub

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

#Region "CTCall API"

        ''' <summary>
        ''' API that returns an CTCall List
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryTokenAttribute>
        <ActionName("ctCallList")>
        Public Function GetAllCTCalls() As HttpResponseMessage

            Try
                Dim ctcallList = _ctcallRepository.GetCTCalls(ActiveModule.ModuleID)
                Return Request.CreateResponse(HttpStatusCode.OK, ctcallList.ToList())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' API that deletes a CTCall 
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryTokenAttribute>
        <ActionName("ctOpenCallList")>
        Public Function getOpenCTCall() As HttpResponseMessage

            Try
                Dim ctopencallList = _ctcallRepository.GetOpenCTCalls(ActiveModule.ModuleID, UserInfo.UserID)
                Return Request.CreateResponse(HttpStatusCode.OK, ctopencallList.ToList())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try

        End Function


        ''' <summary>
        ''' API that creates a new CTCalls
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryToken>
        <ActionName("ctCallNew")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.View)>
        Public Function AddCTCall(t As RequestCTCall) As HttpResponseMessage
            Try
                Dim newCity As New City()
                newCity = _cityRepository.GetCity(t.CityId, ActiveModule.ModuleID)

                Dim newCTCall As New CTCall()
                newCTCall.ModuleId = ActiveModule.ModuleID
                newCTCall.CreatedByUserId = UserInfo.UserID
                newCTCall.CreatedOnDate = DateTime.Now
                newCTCall.LastModifiedByUserId = UserInfo.UserID
                newCTCall.CSR = UserInfo.Username
                newCTCall.LastModifiedOnDate = DateTime.Now
                newCTCall.CallDate = DateTime.Now
                newCTCall.CallerName = t.CallerName
                newCTCall.CallerAddress = t.CallerAddress
                newCTCall.CallerCity = newCity.CityName
                newCTCall.Region = newCity.RegionName
                newCTCall.UtilityType = newCity.UtilityType
                newCTCall.CallBackNumber = t.CallBackNumber
                newCTCall.CrossStreet = t.CrossStreet
                newCTCall.Comments = t.Comments
                newCTCall.CallType = t.CallType
                newCTCall.DispatchFlag = 0
                newCTCall.CityId = t.CityId
                Dim CTCallid As Integer = _ctcallRepository.AddCTCall(newCTCall)
                Return Request.CreateResponse(HttpStatusCode.OK, CTCallid)
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' API that deletes a CTCall 
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryTokenAttribute>
        <ActionName("ctCallDelete")>
        Public Function DeleteCTCall(delit As CTCall) As HttpResponseMessage

            Try
                _ctcallRepository.DeleteCTCall(delit)
                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' API that updates a CTCall
        ''' </summary>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        <ActionName("ctCallUpdate")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.View)>
        Public Function UpdateCTCall(t As CTCall) As HttpResponseMessage
            Try
                Dim newCity As New City()
                newCity = _cityRepository.GetCity(t.CityId, ActiveModule.ModuleID)
                t.CallerCity = newCity.CityName
                t.Region = newCity.RegionName
                t.UtilityType = newCity.UtilityType
                t.LastModifiedByUserId = UserInfo.UserID
                t.CSR = UserInfo.Username
                t.LastModifiedOnDate = DateTime.Now
                _ctcallRepository.UpdateCTCall(t)
                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
#End Region

    End Class


    Public Class RequestCTCall
        Private _callid As Integer
        Private _calldate As DateTime
        Private _callername As String
        Private _calleraddress As String
        Private _callercity As String
        Private _cityid As Integer
        Private _region As String
        Private _utilitytype As String
        Private _callbacknumber As Integer
        Private _crossstreet As String
        Private _comments As String
        Private _calltype As String
        Private _dispatchflag As Integer
        Private _createdByUserId As Integer
        Private _lastModifiedByUserId As Integer
        Private _csr As String
        Private _createdOnDate As DateTime
        Private _lastModifiedOnDate As DateTime
        Private _moduleId As Integer

        Public Property CallId() As Integer

            Get
                Return _callid
            End Get
            Set(ByVal value As Integer)
                _callid = value
            End Set
        End Property
        Public Property CallDate() As DateTime
            Get
                Return _calldate
            End Get
            Set(ByVal value As DateTime)
                _calldate = value
            End Set
        End Property
        Public Property CallerName() As String
            Get
                Return _callername
            End Get
            Set(ByVal value As String)
                _callername = value
            End Set
        End Property
        Public Property CallerAddress() As String
            Get
                Return _calleraddress
            End Get
            Set(ByVal value As String)
                _calleraddress = value
            End Set
        End Property
        Public Property CallerCity() As String
            Get
                Return _callercity
            End Get
            Set(ByVal value As String)
                _callercity = value
            End Set
        End Property
        Public Property CityId() As Integer

            Get
                Return _cityid
            End Get
            Set(ByVal value As Integer)
                _cityid = value
            End Set
        End Property

        Public Property Region() As String
            Get
                Return _region
            End Get
            Set(ByVal value As String)
                _region = value
            End Set
        End Property
        Public Property UtilityType() As String
            Get
                Return _utilitytype
            End Get
            Set(ByVal value As String)
                _utilitytype = value
            End Set
        End Property
        Public Property CallBackNumber() As Integer
            Get
                Return _callbacknumber
            End Get
            Set(ByVal value As Integer)
                _callbacknumber = value
            End Set
        End Property
        Public Property CrossStreet() As String
            Get
                Return _crossstreet
            End Get
            Set(ByVal value As String)
                _crossstreet = value
            End Set
        End Property
        Public Property Comments() As String
            Get
                Return _comments
            End Get
            Set(ByVal value As String)
                _comments = value
            End Set
        End Property
        Public Property CallType() As String
            Get
                Return _calltype
            End Get
            Set(ByVal value As String)
                _calltype = value
            End Set
        End Property

        Public Property DispatchFlag() As Integer

            Get
                Return _dispatchflag
            End Get
            Set(ByVal value As Integer)
                _dispatchflag = value
            End Set
        End Property

        Public Overloads Property CreatedByUserId() As Integer
            Get
                Return _createdByUserId
            End Get
            Set(ByVal value As Integer)
                _createdByUserId = value
            End Set
        End Property

        Public Overloads Property LastModifiedByUserId() As Integer
            Get
                Return _lastModifiedByUserId
            End Get
            Set(ByVal value As Integer)
                _lastModifiedByUserId = value
            End Set
        End Property
        Public Property CSR() As String
            Get
                Return _csr
            End Get
            Set(ByVal value As String)
                _csr = value
            End Set
        End Property

        Public Overloads Property CreatedOnDate() As DateTime
            Get
                Return _createdOnDate
            End Get
            Set(ByVal value As DateTime)
                _createdOnDate = value
            End Set
        End Property
        Public Overloads Property LastModifiedOnDate() As DateTime
            Get
                Return _lastModifiedOnDate
            End Get
            Set(ByVal value As DateTime)
                _lastModifiedOnDate = value
            End Set
        End Property

        Public Overloads Property ModuleId() As Integer
            Get
                Return _moduleId
            End Get
            Set(ByVal value As Integer)
                _moduleId = value
            End Set
        End Property




    End Class







End Namespace



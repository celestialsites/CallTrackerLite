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
    Public Class CTCallDetailController
        Inherits DnnApiController

        Private _CTCallDetailRepository As CTCallDetailRepository
        Private _dispatcherRepository As DispatcherRepository
        Private _dpcodeRepository As DPCodeRepository
        Private _ctCallRepository As CTCallRepository


        Public Sub New()
            _CTCallDetailRepository = New CTCallDetailRepository()
            _dispatcherRepository = New DispatcherRepository()
            _dpcodeRepository = New DPCodeRepository()
            _ctCallRepository = New CTCallRepository

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

#Region "CTCallDetail API"

        ''' <summary>
        ''' API that returns an CTCallDetail List
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryTokenAttribute>
        <ActionName("ctCallDetailList")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.View)>
        Public Function GetAllCTCallDetails(t As Integer) As HttpResponseMessage

            Try
                Dim CTCallDetailList = _CTCallDetailRepository.GetCTCallidDetails(t, ActiveModule.ModuleID)
                Return Request.CreateResponse(HttpStatusCode.OK, CTCallDetailList.ToList())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' API that creates a new CTCallDetails
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryToken>
        <ActionName("ctCallDetailNew")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.View)>
        Public Function AddCTCallDetail(t As RequestCTCallDetail) As HttpResponseMessage
            Try
                Dim newDispatcher As New Dispatcher()
                newDispatcher = _dispatcherRepository.GetDispatcher(t.DispatcherId, ActiveModule.ModuleID)
                Dim newdpcode As New DPCode()
                newdpcode = _dpcodeRepository.GetDPCode(t.DispatchCodeId, ActiveModule.ModuleID)

                Dim newCTCallDetail As New CTCallDetail()
                newCTCallDetail.ModuleId = ActiveModule.ModuleID
                newCTCallDetail.CreatedByUserId = UserInfo.UserID
                newCTCallDetail.CreatedOnDate = DateTime.Now
                newCTCallDetail.LastModifiedByUserId = UserInfo.UserID
                newCTCallDetail.LastModifiedOnDate = DateTime.Now
                newCTCallDetail.DispatchTime = DateTime.Now
                newCTCallDetail.CallId = t.CallId
                newCTCallDetail.DispatchCodeId = t.DispatchCodeId
                newCTCallDetail.DispatchCode = newdpcode.DispatchCodeName
                newCTCallDetail.Dispatcher = newDispatcher.DispatcherName
                newCTCallDetail.DispatcherId = t.DispatcherId
                newCTCallDetail.DispatcherPhone = newDispatcher.CellPhone
                newCTCallDetail.Comments = t.Comments
                Dim CTCallDetailid As Integer = _CTCallDetailRepository.AddCTCallDetail(newCTCallDetail)
                Return Request.CreateResponse(HttpStatusCode.OK, CTCallDetailid)
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' API that deletes a CTCallDetail 
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryTokenAttribute>
        <ActionName("CTCallDetailDelete")>
        Public Function DeleteCTCallDetail(delit As CTCallDetail) As HttpResponseMessage

            Try
                _CTCallDetailRepository.DeleteCTCallDetail(delit)
                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' API that updates a CTCallDetail
        ''' </summary>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        <ActionName("CTCallDetailUpdate")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.View)>
        Public Function UpdateCTCallDetail(t As CTCallDetail) As HttpResponseMessage
            Try
                Dim newDispatcher As New Dispatcher()
                newDispatcher = _dispatcherRepository.GetDispatcher(t.DispatcherId, ActiveModule.ModuleID)
                Dim newdpcode As New DPCode()
                newdpcode = _dpcodeRepository.GetDPCode(t.DispatchCodeId, ActiveModule.ModuleID)

                t.DispatchCode = newdpcode.DispatchCodeName
                t.Dispatcher = newDispatcher.DispatcherName
                t.LastModifiedByUserId = UserInfo.UserID
                t.LastModifiedOnDate = DateTime.Now
                t.DispatcherPhone = newDispatcher.CellPhone
                _CTCallDetailRepository.UpdateCTCallDetail(t)
                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function
#End Region

    End Class


    Public Class RequestCTCallDetail
        Private _calldetailid As Integer
        Private _callid As Integer
        Private _dispatchcode As String
        Private _dispatchcodeId As Integer
        Private _dispatchtime As DateTime
        Private _comments As String
        Private _dispatcher As String
        Private _dispatcherid As Integer
        Private _dispatcherphone As Int64
        Private _createdByUserId As Integer
        Private _lastModifiedByUserId As Integer
        Private _csr As String
        Private _createdOnDate As DateTime
        Private _lastModifiedOnDate As DateTime
        Private _moduleId As Integer

        Public Sub New()
            CallDetailId = -1
        End Sub
        Public Property CallDetailId() As Integer
            Get
                Return _calldetailid
            End Get
            Set(ByVal value As Integer)
                _calldetailid = value
            End Set
        End Property
        Public Property CallId() As Integer
            Get
                Return _callid
            End Get
            Set(ByVal value As Integer)
                _callid = value
            End Set
        End Property
        Public Property DispatchTime() As DateTime
            Get
                Return _dispatchtime
            End Get
            Set(ByVal value As DateTime)
                _dispatchtime = value
            End Set
        End Property
        Public Property DispatchCode() As String
            Get
                Return _dispatchcode
            End Get
            Set(ByVal value As String)
                _dispatchcode = value
            End Set
        End Property
        Public Property DispatchCodeId() As Integer
            Get
                Return _dispatchcodeId
            End Get
            Set(ByVal value As Integer)
                _dispatchcodeId = value
            End Set
        End Property
        Public Property Dispatcher() As String
            Get
                Return _dispatcher
            End Get
            Set(ByVal value As String)
                _dispatcher = value
            End Set
        End Property
        Public Property DispatcherId() As Integer
            Get
                Return _dispatcherid
            End Get
            Set(ByVal value As Integer)
                _dispatcherid = value
            End Set
        End Property
        Public Property DispatcherPhone() As Int64

            Get
                Return _dispatcherphone
            End Get
            Set(ByVal value As Int64)
                _dispatcherphone = value
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




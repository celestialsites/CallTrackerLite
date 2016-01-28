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
    Public Class dpcodeController
        Inherits DnnApiController

        Private _dpcodeRepository As DPCodeRepository

        Public Sub New()
            _dpcodeRepository = New DPCodeRepository()

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


#Region "Dispatch Code API"

        ''' <summary>
        ''' API that returns a Dispatch Code List
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryTokenAttribute>
        <ActionName("dpcodeList")>
        Public Function GetAllDPCodes() As HttpResponseMessage

            Try
                Dim dpCodeList = _dpcodeRepository.GetDPCodes(ActiveModule.ModuleID)
                Return Request.CreateResponse(HttpStatusCode.OK, dpCodeList.ToList())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' API that creates a new Dispatch Code
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryToken>
        <ActionName("dpcodenew")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        Public Function AddDPCode(t As RequestDPCode) As HttpResponseMessage
            Try
                Dim newDPCode As New DPCode()
                newDPCode.ModuleId = ActiveModule.ModuleID
                newDPCode.CreatedByUserId = UserInfo.UserID
                newDPCode.CreatedOnDate = DateTime.Now
                newDPCode.LastModifiedByUserId = UserInfo.UserID
                newDPCode.LastModifiedOnDate = DateTime.Now
                newDPCode.DispatchCodeName = t.DispatchCodeName
                Dim dpcodeid As Integer = _dpcodeRepository.AddDPCode(newDPCode)
                Return Request.CreateResponse(HttpStatusCode.OK, dpcodeid)
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' API that deletes a Dispatch Code
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryTokenAttribute>
        <ActionName("dpcodedelete")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        Public Function DeleteDispatchCode(delit As DPCode) As HttpResponseMessage

            Try
                _dpcodeRepository.DeleteDPCode(delit)
                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' API that updates a Dispatch Code
        ''' </summary>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        <ActionName("dpcodeupdate")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        Public Function UpdateDispatchCode(t As DPCode) As HttpResponseMessage
            Try
                t.LastModifiedByUserId = UserInfo.UserID
                t.LastModifiedOnDate = DateTime.Now
                _dpcodeRepository.UpdateDPCode(t)
                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

#End Region

    End Class


    Public Class RequestDPCode
        Private _dispatchcodeId As Integer
        Private _dispatchCodeName As String
        Private _createdByUserId As Integer
        Private _lastModifiedByUserId As Integer
        Private _createdOnDate As DateTime
        Private _lastModifiedOnDate As DateTime
        Private _moduleId As Integer

        Public Property DispatchCodeId() As Integer
            Get
                Return _dispatchcodeId
            End Get
            Set(ByVal value As Integer)
                _dispatchcodeId = value
            End Set
        End Property


        Public Property DispatchCodeName() As String
            Get
                Return _dispatchCodeName
            End Get
            Set(ByVal value As String)
                _dispatchCodeName = value
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

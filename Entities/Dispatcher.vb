' Copyright (c) 2015  NWSC.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 

Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.ComponentModel.DataAnnotations
Imports System.Web.Caching
Imports System

Namespace MyEntities

    'setup the primary key for table
    'configure caching using PetaPoco
    'scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    <TableName("CTLiteAdmin_Dispatchers")>
    <PrimaryKey("DispatcherId", AutoIncrement:=True)>
    <Cacheable("Dispatchers", CacheItemPriority.Default, 20)>
    <Scope("ModuleId")>
    Public Class Dispatcher
        Implements IDispatcherModel

        Private _dispatcherId As Integer
        Private _dispatcherName As String
        Private _dispatcherType As String
        Private _cellPhone As Int64
        Private _homePhone As Int64
        Private _altPhone As Int64
        Private _createdByUserId As Integer
        Private _lastModifiedByUserId As Integer
        Private _createdOnDate As DateTime
        Private _lastModifiedOnDate As DateTime
        Private _moduleId As Integer

        Public Property DispatcherId() As Integer Implements IDispatcherModel.DispatcherId
            Get
                Return _dispatcherId
            End Get
            Set(ByVal value As Integer)
                _dispatcherId = value
            End Set
        End Property


        Public Property DispatcherName() As String Implements IDispatcherModel.DispatcherName
            Get
                Return _dispatcherName
            End Get
            Set(ByVal value As String)
                _dispatcherName = value
            End Set
        End Property
        Public Property DispatcherType() As String Implements IDispatcherModel.DispatcherType
            Get
                Return _dispatcherType
            End Get
            Set(ByVal value As String)
                _dispatcherType = value
            End Set
        End Property

        Public Property CellPhone() As Int64 Implements IDispatcherModel.CellPhone
            Get
                Return _cellPhone
            End Get
            Set(ByVal value As Int64)
                _cellPhone = value
            End Set
        End Property

        Public Property HomePhone() As Int64 Implements IDispatcherModel.HomePhone
            Get
                Return _homePhone
            End Get
            Set(ByVal value As Int64)
                _homePhone = value
            End Set
        End Property
        Public Property AltPhone() As Int64 Implements IDispatcherModel.AltPhone
            Get
                Return _altPhone
            End Get
            Set(ByVal value As Int64)
                _altPhone = value
            End Set
        End Property

        Public Overloads Property CreatedByUserId() As Integer Implements IDispatcherModel.CreatedByUserId
            Get
                Return _createdByUserId
            End Get
            Set(ByVal value As Integer)
                _createdByUserId = value
            End Set
        End Property

        Public Overloads Property LastModifiedByUserId() As Integer Implements IDispatcherModel.LastModifiedByUserId
            Get
                Return _lastModifiedByUserId
            End Get
            Set(ByVal value As Integer)
                _lastModifiedByUserId = value
            End Set
        End Property

        Public Overloads Property CreatedOnDate() As DateTime Implements IDispatcherModel.CreatedOnDate
            Get
                Return _createdOnDate
            End Get
            Set(ByVal value As DateTime)
                _createdOnDate = value
            End Set
        End Property
        Public Overloads Property LastModifiedOnDate() As DateTime Implements IDispatcherModel.LastModifiedOnDate
            Get
                Return _lastModifiedOnDate
            End Get
            Set(ByVal value As DateTime)
                _lastModifiedOnDate = value
            End Set
        End Property

        Public Overloads Property ModuleId() As Integer Implements IDispatcherModel.ModuleId
            Get
                Return _moduleId
            End Get
            Set(ByVal value As Integer)
                _moduleId = value
            End Set
        End Property


    End Class






End Namespace
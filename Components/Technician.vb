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

Namespace Components


    'setup the primary key for table
    'configure caching using PetaPoco
    'scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    <TableName("CTLiteAdmin_Technicians")>
    <PrimaryKey("TechnicianId", AutoIncrement:=True)>
    <Cacheable("Technicians", CacheItemPriority.Default, 20)>
    <Scope("ModuleId")>
    Public Class Technician

        Private _technicianId As Integer
        Private _technicianName As String
        Private _technicianType As String
        Private _cellphone As Integer
        Private _homephone As Integer
        Private _altphone As Integer
        Private _createdByUserId As Integer
        Private _lastModifiedByUserId As Integer
        Private _createdOnDate As DateTime
        Private _lastModifiedOnDate As DateTime
        Private _moduleId As Integer

        Public Property TechnicianId() As Integer
            Get
                Return _technicianId
            End Get
            Set(ByVal value As Integer)
                _technicianId = value
            End Set
        End Property


        Public Property TechnicianName() As String
            Get
                Return _technicianName
            End Get
            Set(ByVal value As String)
                _technicianName = value
            End Set
        End Property

        Public Property TechnicianType() As String
            Get
                Return _technicianType
            End Get
            Set(ByVal value As String)
                _technicianType = value
            End Set
        End Property

        Public Property CellPhone() As Integer
            Get
                Return _cellphone
            End Get
            Set(ByVal value As Integer)
                _cellphone = value
            End Set
        End Property

        Public Property HomePhone() As Integer
            Get
                Return _homephone
            End Get
            Set(ByVal value As Integer)
                _homephone = value
            End Set
        End Property

        Public Property AltPhone() As Integer
            Get
                Return _altphone
            End Get
            Set(ByVal value As Integer)
                _altphone = value
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






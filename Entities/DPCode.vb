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
    <TableName("CTLiteAdmin_DPCodes")>
    <PrimaryKey("DispatchCodeId", AutoIncrement:=True)>
    <Cacheable("DPCodes", CacheItemPriority.Default, 20)>
    <Scope("ModuleId")>
    Public Class DPCode
        Implements IDPCodeModel


        Private _dispatchCodeId As Integer
        Private _dispatchCodeName As String
        Private _createdByUserId As Integer
        Private _lastModifiedByUserId As Integer
        Private _createdOnDate As DateTime
        Private _lastModifiedOnDate As DateTime
        Private _moduleId As Integer

        Public Property DispatchCodeId() As Integer Implements IDPCodeModel.DispatchCodeId
            Get
                Return _dispatchCodeId
            End Get
            Set(ByVal value As Integer)
                _dispatchCodeId = value
            End Set
        End Property


        Public Property DispatchCodeName() As String Implements IDPCodeModel.DispatchCodeName
            Get
                Return _dispatchCodeName
            End Get
            Set(ByVal value As String)
                _dispatchCodeName = value
            End Set
        End Property


        Public Overloads Property CreatedByUserId() As Integer Implements IDPCodeModel.CreatedByUserId
            Get
                Return _createdByUserId
            End Get
            Set(ByVal value As Integer)
                _createdByUserId = value
            End Set
        End Property

        Public Overloads Property LastModifiedByUserId() As Integer Implements IDPCodeModel.LastModifiedByUserId
            Get
                Return _lastModifiedByUserId
            End Get
            Set(ByVal value As Integer)
                _lastModifiedByUserId = value
            End Set
        End Property

        Public Overloads Property CreatedOnDate() As DateTime Implements IDPCodeModel.CreatedOnDate

            Get
                Return _createdOnDate
            End Get
            Set(ByVal value As DateTime)
                _createdOnDate = value
            End Set
        End Property
        Public Overloads Property LastModifiedOnDate() As DateTime Implements IDPCodeModel.LastModifiedOnDate

            Get
                Return _lastModifiedOnDate
            End Get
            Set(ByVal value As DateTime)
                _lastModifiedOnDate = value
            End Set
        End Property

        Public Overloads Property ModuleId() As Integer Implements IDPCodeModel.ModuleId
            Get
                Return _moduleId
            End Get
            Set(ByVal value As Integer)
                _moduleId = value
            End Set
        End Property

    End Class





End Namespace
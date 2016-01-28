' Copyright (c) 2015  NWSC.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 

Imports System.Collections.Generic
Imports DotNetNuke.Collections
Imports DotNetNuke.Data
Imports NWSC.Modules.CTLiteAdmin.MyEntities


Namespace Components

    Public Class CTCallDetailRepository
        Implements ICTCallDetailRepository

        Public Sub ClearCache(moduleid As Integer)
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of CTCallDetail)()
                Try
                    ' Setup fictitious Call to delete (just to clear the scope cache)
                    Dim t = New CTCallDetail() With {
                        .CallId = -1,
                        .ModuleId = moduleid
                    }
                    DeleteCTCallDetail(t)
                Catch
                    ' ignore
                End Try
            End Using
        End Sub

        Public Sub DeleteCTCallDetail(t As CTCallDetail) Implements ICTCallDetailRepository.DeleteCTCallDetail
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of CTCallDetail)()
                rep.Delete(DirectCast(t, CTCallDetail))
            End Using


        End Sub

        Public Sub UpdateCTCallDetail(t As ICTCallDetailModel) Implements ICTCallDetailRepository.UpdateCTCallDetail
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of CTCallDetail)()
                rep.Update(DirectCast(t, CTCallDetail))
            End Using
        End Sub

        Public Function AddCTCallDetail(t As CTCallDetail) As Integer Implements ICTCallDetailRepository.AddCTCallDetail
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of CTCallDetail)()
                rep.Insert(DirectCast(t, CTCallDetail))
                Return t.CallDetailId
            End Using
        End Function


        Public Function GetCTCallDetail(callid As Integer, moduleId As Integer) As ICTCallDetailModel Implements ICTCallDetailRepository.GetCTCallDetail
            Dim t As CTCallDetail

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of CTCallDetail)()
                t = rep.GetById(callid, moduleId)
            End Using
            Return t
        End Function


        Public Function GetCTCallDetails(moduleId As Integer) As IEnumerable(Of CTCallDetail) Implements ICTCallDetailRepository.GetCTCallDetails
            Dim t As IEnumerable(Of CTCallDetail)

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of CTCallDetail) = ctx.GetRepository(Of CTCallDetail)()
                t = rep.Get(moduleId)
            End Using
            Return t
        End Function

        Public Function GetCTCallidDetails(callid As Integer, moduleId As Integer) As IEnumerable(Of CTCallDetail) Implements ICTCallDetailRepository.GetCTCallidDetails

            Dim t = GetCTCallDetails(moduleId).Where(Function(c) c.CallId.Equals(callid))
            Return t

        End Function

        Public Function GetCTCallDetails(searchTerm As String,
                                   moduleId As Integer,
                                   pageIndex As Integer,
                                   pageSize As Integer) As IPagedList(Of CTCallDetail) Implements ICTCallDetailRepository.GetCTCallDetails

            Dim calls = GetCTCallDetails(moduleId).Where(Function(c) c.CallId.Equals(searchTerm))
            Return New PagedList(Of CTCallDetail)(calls, pageIndex, pageSize)
        End Function

    End Class

End Namespace


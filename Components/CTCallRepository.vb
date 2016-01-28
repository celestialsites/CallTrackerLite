' Copyright (c) 2015  NWSC.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 


'Imports System.Net
'Imports System.Net.Http
'Imports System.Web.Http
'Imports DotNetNuke.Web.Api
'Imports DotNetNuke.Security


Imports System.Collections.Generic
Imports DotNetNuke.Collections
Imports DotNetNuke.Data
Imports NWSC.Modules.CTLiteAdmin.MyEntities


Namespace Components

    Public Class CTCallRepository
        Implements ICTCallRepository

        Public Sub ClearCache(moduleid As Integer)
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of CTCall)()
                Try
                    ' Setup fictitious Call to delete (just to clear the scope cache)
                    Dim t = New CTCall() With {
                        .CallId = -1,
                        .ModuleId = moduleid
                    }
                    DeleteCTCall(t)
                Catch
                    ' ignore
                End Try
            End Using
        End Sub

        Public Sub DeleteCTCall(t As CTCall) Implements ICTCallRepository.DeleteCTCall
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of CTCall)()
                rep.Delete(DirectCast(t, CTCall))
            End Using


        End Sub

        Public Sub UpdateCTCall(t As ICTCallModel) Implements ICTCallRepository.UpdateCTCall
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of CTCall)()
                rep.Update(DirectCast(t, CTCall))
            End Using
        End Sub

        Public Function AddCTCall(t As CTCall) As Integer Implements ICTCallRepository.AddCTCall
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of CTCall)()
                rep.Insert(DirectCast(t, CTCall))
                Return t.CallId
            End Using
        End Function


        Public Function GetCTCall(callid As Integer, moduleId As Integer) As ICTCallModel Implements ICTCallRepository.GetCTCall
            Dim t As CTCall

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of CTCall)()
                t = rep.GetById(callid, moduleId)
            End Using
            Return t
        End Function


        Public Function GetCTCalls(moduleId As Integer) As IEnumerable(Of CTCall) Implements ICTCallRepository.GetCTCalls
            Dim t As IEnumerable(Of CTCall)

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of CTCall) = ctx.GetRepository(Of CTCall)()
                t = rep.Get(moduleId)
            End Using
            Return t
        End Function

        Public Function GetOpenCTCalls(moduleId As Integer, userid As Integer) As IEnumerable(Of CTCall) Implements ICTCallRepository.GetOpenCTCalls

            'Dim ctx = GetCTCalls(moduleId).Where(Function(c) c.DispatchFlag.Equals(0) And c.LastModifiedByUserId.Equals(userid))
            Dim ctx = GetCTCalls(moduleId).Where(Function(c) c.DispatchFlag.Equals(0))
            Return ctx

        End Function

        Public Function GetCTCalls(searchTerm As String,
                                   moduleId As Integer,
                                   pageIndex As Integer,
                                   pageSize As Integer) As IPagedList(Of CTCall) Implements ICTCallRepository.GetCTCalls

            Dim calls = GetCTCalls(moduleId).Where(Function(c) c.CallerCity.Contains(searchTerm) OrElse c.Region.Contains(searchTerm))
            Return New PagedList(Of CTCall)(calls, pageIndex, pageSize)
        End Function

    End Class

End Namespace
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

    Public Class DispatcherRepository
        Implements IDispatcherRepository

        Public Sub ClearCache(moduleid As Integer)
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of Dispatcher)()
                Try
                    'Setup fictitious Call to delete (just to clear the scope cache)
                    Dim t = New Dispatcher() With {
                        .DispatcherId = -1,
                        .ModuleId = moduleid
                    }
                    DeleteDispatcher(t)
                Catch
                    'ignore
                End Try
            End Using
        End Sub

        Public Sub DeleteDispatcher(t As Dispatcher) Implements IDispatcherRepository.DeleteDispatcher
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of Dispatcher)()
                rep.Delete(DirectCast(t, Dispatcher))
            End Using

        End Sub


        'Public Sub DeleteItem(t As IItemModel)
        '    Using ctx As IDataContext = DataContext.Instance()
        '        Dim rep = ctx.GetRepository(Of Item)()
        '        rep.Delete(DirectCast(t, Item))
        '    End Using
        'End Sub


        Public Sub UpdateDispatcher(t As IDispatcherModel) Implements IDispatcherRepository.UpdateDispatcher
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of Dispatcher)()
                rep.Update(DirectCast(t, Dispatcher))
            End Using
        End Sub

        Public Function AddDispatcher(t As Dispatcher) As Integer Implements IDispatcherRepository.AddDispatcher
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of Dispatcher)()
                rep.Insert(DirectCast(t, Dispatcher))
                Return t.DispatcherId
            End Using
        End Function


        Public Function GetDispatcher(Dispatcherid As Integer, moduleId As Integer) As IDispatcherModel Implements IDispatcherRepository.GetDispatcher
            Dim t As Dispatcher
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of Dispatcher)()
                t = rep.GetById(Dispatcherid, moduleId)
            End Using
            Return t
        End Function


        Public Function GetDispatchers(moduleId As Integer) As IEnumerable(Of Dispatcher) Implements IDispatcherRepository.GetDispatchers

            Dim t As IEnumerable(Of Dispatcher)

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of Dispatcher) = ctx.GetRepository(Of Dispatcher)()
                t = rep.Get(moduleId)
            End Using
            Return t
        End Function

        Public Function GetDispatchers(searchTerm As String,
                                   moduleId As Integer,
                                   pageIndex As Integer,
                                   pageSize As Integer) As IPagedList(Of Dispatcher) Implements IDispatcherRepository.GetDispatchers

            Dim calls = GetDispatchers(moduleId).Where(Function(c) c.DispatcherName.Contains(searchTerm))
            Return New PagedList(Of Dispatcher)(calls, pageIndex, pageSize)
        End Function

    End Class

End Namespace
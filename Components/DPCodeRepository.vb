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

    Public Class DPCodeRepository
        Implements IDPCodeRepository

        Public Sub ClearCache(moduleid As Integer)
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of DPCode)()
                Try
                    ' Setup fictitious Call to delete (just to clear the scope cache)
                    Dim t = New DPCode() With {
                        .DispatchCodeId = -1,
                        .ModuleId = moduleid
                    }
                    DeleteDPCode(t)
                Catch
                    ' ignore
                End Try
            End Using
        End Sub

        Public Sub DeleteDPCode(t As DPCode) Implements IDPCodeRepository.DeleteDPCode
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of DPCode)()
                rep.Delete(DirectCast(t, DPCode))
            End Using

        End Sub

        Public Sub UpdateDPCode(t As IDPCodeModel) Implements IDPCodeRepository.UpdateDPCode
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of DPCode)()
                rep.Update(DirectCast(t, DPCode))
            End Using
        End Sub

        Public Function AddDPCode(t As DPCode) As Integer Implements IDPCodeRepository.AddDPCode
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of DPCode)()
                rep.Insert(DirectCast(t, DPCode))
                Return t.DispatchCodeId
            End Using
        End Function


        Public Function GetDPCode(DPCodeid As Integer, moduleId As Integer) As IDPCodeModel Implements IDPCodeRepository.GetDPCode
            Dim t As DPCode

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of DPCode)()
                t = rep.GetById(DPCodeid, moduleId)
            End Using
            Return t
        End Function

        Public Function GetDPCodes(moduleId As Integer) As IEnumerable(Of DPCode) Implements IDPCodeRepository.GetDPCodes
            Dim t As IEnumerable(Of DPCode)

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of DPCode) = ctx.GetRepository(Of DPCode)()
                t = rep.Get(moduleId)
            End Using
            Return t
        End Function

        Public Function GetDPCodes(searchTerm As String,
                                   moduleId As Integer,
                                   pageIndex As Integer,
                                   pageSize As Integer) As IPagedList(Of DPCode) Implements IDPCodeRepository.GetDPCodes

            Dim calls = GetDPCodes(moduleId).Where(Function(c) c.DispatchCodeName.Contains(searchTerm))
            Return New PagedList(Of DPCode)(calls, pageIndex, pageSize)
        End Function

    End Class

End Namespace
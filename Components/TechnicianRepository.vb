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
Imports DotNetNuke.Data




Namespace Components

    Public Class TechnicianRepository

        Public Sub CreateTechnician(ByVal t As Technician)
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of Technician) = ctx.GetRepository(Of Technician)()
                rep.Insert(t)
            End Using
        End Sub

        Public Sub DeleteTechnician(ByVal t As Integer, ByVal moduleId As Integer)
            Dim _Technician As Technician = GetTechnician(t, moduleId)
            DeleteTechnician(_Technician)
        End Sub

        Public Sub DeleteTechnician(ByVal t As Technician)
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of Technician) = ctx.GetRepository(Of Technician)()
                rep.Delete(t)
            End Using
        End Sub

        Public Function GetTechnicians(ByVal moduleId As Integer) As IEnumerable(Of Technician)
            Dim t As IEnumerable(Of Technician)

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of Technician) = ctx.GetRepository(Of Technician)()
                t = rep.Get(moduleId)
            End Using
            Return t
        End Function

        Public Function GetTechnician(ByVal Techid As Integer, ByVal moduleId As Integer) As Technician
            Dim t As Technician

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of Technician) = ctx.GetRepository(Of Technician)()
                t = rep.GetById(Of Int32, Int32)(Techid, moduleId)
            End Using
            Return t
        End Function

        Public Sub UpdateTechnician(ByVal t As Technician)
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of Technician) = ctx.GetRepository(Of Technician)()
                rep.Update(t)
            End Using
        End Sub

    End Class

End Namespace
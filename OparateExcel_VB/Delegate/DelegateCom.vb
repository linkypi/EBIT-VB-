Imports MsExcel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Excel

Public Class DelegateCom
    Public Delegate Sub ThreadFinishEvent()
    Public Delegate Sub ConvertFinishEvent()
    Public Delegate Sub GenerateFinishEvent(ByVal id As Integer)
    Public Delegate Sub ExcetionCloseEvent(ByRef exapp As MsExcel.Application)
    Public Delegate Sub ConvertThreadProgressEvent()
    Public Delegate Sub GeneratorProgressEvent()
    Public Delegate Sub ConvertProgressEvent(ByVal value As Integer)

    Public Delegate Sub FinishedOneFileEvent()
End Class

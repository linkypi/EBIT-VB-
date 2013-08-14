Imports System.IO
Imports System.Collections.Generic
Imports System.Threading
Imports OparateExcel_VB.DelegateCom
Imports MsExcel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop.Excel

Public Class ExcelGenerator

    Private oExcApp As MsExcel.Application
    Private oExcBook As MsExcel.Workbook
    Private worksheet1 As MsExcel.Worksheet

    Private fmodel As FileModel
    Private totalPage As Integer '每个工作簿的工作表总数
    Private lines As Integer  '总行数
    Private curLines As Integer '当前页的行数
    Private excelArg As ExcelArgument

    Public Event OnGenerateFinished As GenerateFinishEvent
    Public Event OnConvertProgress As GeneratorProgressEvent

    '生成器的标志
    Private Identity As Integer

    Public Sub New(ByVal arg As ExcelArgument)
        excelArg = arg
        Identity = arg.ID
        fmodel = excelArg.FileModels(arg.FileIndex)

        ''分页
        If excelArg.SeparatePage Then
            lines = CType(fmodel.ListStr.Length / excelArg.PageAttr.Cols, Integer)
            totalPage = Math.Ceiling(lines / excelArg.PageAttr.Rows)
        End If
    End Sub

    '''<summary>
    ''' 生成Excel
    '''<param name="fileName">文件名</param>
    '''<param name="direName">文件路径</param>
    '''</summary>
    Public Sub GenerateExcel()
        Try

            oExcApp = New MsExcel.ApplicationClass()
            '//读取文本内容到Excel 表格
            oExcApp.Visible = False
            oExcApp.DisplayAlerts = False '//不提示警告信息
            '//新建一个Excel 文档
            oExcBook = oExcApp.Workbooks.Add(True)

            '不对工作表自动进行重算
            'worksheet1.EnableCalculation = False
            ''启动写入线程
            If fmodel.ListStr IsNot Nothing Then
                WriteThread()
                'Dim thread_write As Thread = New Thread(New ThreadStart(AddressOf WriteThread))
                'thread_write.Priority = ThreadPriority.Normal
                'thread_write.IsBackground = True
                'thread_write.Start()
            End If
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    '''  更新进度
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdatePro()
        RaiseEvent OnConvertProgress()
    End Sub

    ''' <summary>
    ''' 生成结束
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Finish()
        Try
            oExcApp.ActiveWorkbook.Close()
            oExcApp.Quit()

            System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcApp)
            System.GC.Collect()
            RaiseEvent OnGenerateFinished(Identity)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub WriteThread()
        Dim index As Integer = 0
        Try
            If excelArg.SeparatePage Then
                For i As Integer = 1 To totalPage
                    WirteMultiPages(i, index)
                Next
            Else
                WriteSinglePage()
            End If
            Finish()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' 单页写入
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub WriteSinglePage()
        Try
            worksheet1 = oExcBook.Worksheets("sheet1")
            worksheet1.Activate()
            Dim str_list As String()
            Dim row As Integer = 1

            For Each str As String In fmodel.ListStr
                str_list = str.Split(excelArg.SeparateChars)
                Dim writeStr(0, str_list.Count() - 1) As String
                For i As Integer = 0 To str_list.Count() - 1
                    If excelArg.RemoveSpace Then ''去除空格
                        writeStr(0, i) = str_list(i).Trim()
                    Else
                        writeStr(0, i) = str_list(i)
                    End If
                    Thread.Sleep(5)
                Next
                RaiseEvent OnConvertProgress() '更新生成进度
                worksheet1.Range("A" + row.ToString(), Tool.Chr(str_list.Count()) + row.ToString()).Value = writeStr
                row += 1
                'Thread.Sleep(2)
            Next
            worksheet1.SaveAs(excelArg.SavePath + "\" + fmodel.Name.Substring(0, fmodel.Name.IndexOf(".")) + ".xls")
            '设置单元格右对齐
            worksheet1.Cells().HorizontalAlignment = MsExcel.XlHAlign.xlHAlignRight
        Catch ex As Exception
            Throw ex
        End Try
      
    End Sub

    ''' <summary>
    ''' 写入数据（分页）
    ''' </summary>
    ''' <param name="curPage"></param>
    ''' <param name="index"></param>
    ''' <remarks></remarks>
    Private Sub WirteMultiPages(ByVal curPage As Integer, ByRef index As Integer)
        Try
            ''若行数大于指定行数则起新的工作表sheet
            If totalPage > 1 Then
                If curPage = totalPage Then
                    curLines = lines Mod excelArg.PageAttr.Rows
                Else
                    curLines = excelArg.PageAttr.Rows
                End If
                If worksheet1 Is Nothing Then
                    worksheet1 = oExcBook.Worksheets("sheet" + curPage.ToString())
                Else
                    worksheet1 = oExcBook.Worksheets.Add(After:=oExcBook.Worksheets("sheet" + (curPage - 1).ToString()))
                End If
            Else
                curLines = lines
                worksheet1 = oExcBook.Worksheets("sheet" + curPage.ToString())
            End If

            Dim endRange As String = Tool.Chr(excelArg.PageAttr.Cols) + (curLines + 1).ToString()
            SetExcelArg(worksheet1, endRange)

            ''写入数据    一次写入
            Dim write_strList(curLines - 1, excelArg.PageAttr.Cols - 1) As String

            For m As Integer = 0 To curLines - 1
                For j As Integer = 0 To excelArg.PageAttr.Cols - 1
                    If excelArg.RemoveSpace Then ''去除空格
                        write_strList(m, j) = fmodel.ListStr(index).Trim()
                    Else
                        write_strList(m, j) = fmodel.ListStr(index)
                    End If

                    RaiseEvent OnConvertProgress() '更新生成进度
                    index += 1
                    Thread.Sleep(2)
                Next
            Next
            worksheet1.Range("A2", endRange).Value = write_strList

            ''分10次写入
            'Dim etime As Integer = Math.Ceiling(curLines / 10)
            'Dim write_strList(etime - 1, excelArg.PageAttr.Cols - 1) As String
            'Dim current As Integer
            'Dim endStr As String = Tool.Chr(excelArg.PageAttr.Cols)
            'Dim flag As Boolean = False
            'For m As Integer = 0 To 9
            '    current = etime * m + 1
            '    'write_strList = Nothing
            '    For k As Integer = 0 To etime - 1  ''每次写入etime行数据
            '        For j As Integer = 0 To excelArg.PageAttr.Cols - 1
            '            If excelArg.RemoveSpace Then ''去除空格
            '                write_strList(k, j) = fmodel.ListStr(index).Trim()
            '            Else
            '                write_strList(k, j) = fmodel.ListStr(index)
            '            End If
            '            If index >= fmodel.ListStr.Count() - 1 Then
            '                flag = True
            '                Exit For
            '            End If
            '            RaiseEvent OnConvertProgress() '更新生成进度
            '            index += 1
            '            Thread.Sleep(2)

            '        Next
            '        If flag Then
            '            For y As Integer = k To etime - 1
            '                For c As Integer = 0 To excelArg.PageAttr.Cols - 1
            '                    write_strList(y, c) = ""
            '                Next
            '            Next
            '            Exit For
            '        End If
            '    Next
            '    worksheet1.Range("A" + (current + 1).ToString(), endStr + (etime + current).ToString()).Value = write_strList
            '    If flag Then
            '        Exit For
            '    End If
            'Next


            worksheet1.SaveAs(excelArg.SavePath + "\" + fmodel.Name.Substring(0, fmodel.Name.IndexOf(".")) + ".xls")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ''' <summary>
    ''' 设置Excel参数
    ''' </summary>
    ''' <param name="worksheet"></param>
    ''' <param name="endRange"></param>
    ''' <remarks></remarks>
    Private Sub SetExcelArg(ByRef worksheet As MsExcel.Worksheet, ByVal endRange As String)
        Try
            worksheet.Activate()

            '设置列名对齐方式和字体
            Dim rangCaption As Range = worksheet.Range("A1", Tool.Chr(excelArg.PageAttr.Cols) + "1")
            rangCaption.HorizontalAlignment = MsExcel.XlHAlign.xlHAlignCenter
            rangCaption.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Blue)
            rangCaption.Font.Size = 10
            rangCaption.Font.Bold = True
            '设置每列的列名和数据类型
            Dim clIndex As Integer = 1
            Dim str_rang As String
            For Each ca As ColumnAttribute In excelArg.PageAttr.ColumnAttrList
                worksheet.Cells(1, clIndex) = ca.Name
                str_rang = Tool.Chr(clIndex)
                Dim rangeData As MsExcel.Range = worksheet.Range(str_rang + "2", str_rang + (curLines + 1).ToString())
                rangeData.NumberFormatLocal = ca.DataType
                clIndex += 1
            Next

            '设置单元格右对齐
            Dim range As MsExcel.Range = worksheet.Range("A2", endRange)
            range.HorizontalAlignment = MsExcel.XlHAlign.xlHAlignRight
        Catch ex As Exception
            Throw ex
        End Try
    
    End Sub
End Class

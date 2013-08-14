Imports System.IO
Imports System.Collections.Generic
Imports System.Threading
Imports OparateExcel_VB.DelegateCom

Public Class ExcelConverter

    Private Shared fileCount As Integer
    Private Shared listID As List(Of Integer)

    Private Shared currentID As Integer = 1
    Private Shared savePath As String
    Private Shared streamReader As StreamReader
    Private Shared total As Integer '待写入的数组总量
    Private Shared current As Integer '当前转换量
    Private Shared excelArg As ExcelArgument

    Public Shared Event ConvFinishedEvent As ConvertFinishEvent
    Public Shared Event UpdateConvertProgress As ConvertProgressEvent
    Public Shared Event OnFinishedOneFile As FinishedOneFileEvent
    Private Shared mrEvent As ManualResetEvent

    Public Shared Sub InitAllCount(ByVal arg As ExcelArgument)
        current = 0
        excelArg = arg
        mrEvent = New ManualResetEvent(True)
        excelArg.FileModels = New List(Of FileModel)
        listID = New List(Of Integer)

        fileCount = excelArg.FileInfos.Count

        '记录所有文件实体
        total = 0 ''必须
        Dim a_str As String
        Dim str_list As String()
        Dim model As FileModel
        Dim index As Integer = 1

        If excelArg.Separator = "tab" Then
            excelArg.SeparateChars = vbTab.ToCharArray()
        ElseIf excelArg.Separator = "" Then
            excelArg.SeparateChars = " ".ToCharArray()
        Else
            excelArg.SeparateChars = excelArg.Separator.ToCharArray()
        End If

        ''获取文件总量
        For Each fi As FileInfo In excelArg.FileInfos
            streamReader = New StreamReader(fi.DirectoryName + "\" + fi.Name)
            a_str = streamReader.ReadToEnd() ''无视回车换行
            If excelArg.SeparatePage Then
                str_list = a_str.Split(excelArg.SeparateChars)
            Else
                str_list = Split(a_str, vbCrLf, -1, vbBinaryCompare) '换行符为\r\n
                If str_list.Count() = 1 Then
                    str_list = Split(a_str, vbLf, -1, vbBinaryCompare) '换行符为\n
                End If
            End If

            total += str_list.Length
            model = New FileModel(fi.Name, str_list)
            excelArg.FileModels.Add(model)
            index += 1
            Thread.Sleep(1)
        Next
        streamReader.Close()
    End Sub


    ''' <summary>
    ''' 开始转换
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StartConvert()

        Dim thread1 As Thread = New Thread(New ThreadStart(AddressOf Convert))
        thread1.IsBackground = True
        thread1.Priority = ThreadPriority.Normal
        thread1.Start()

        'Dim thread1 As Thread = New Thread(New ThreadStart(AddressOf GenerateThread1))
        'thread1.IsBackground = True
        'thread1.Priority = ThreadPriority.Normal
        'thread1.Start()

        'Dim thread2 As Thread = New Thread(New ThreadStart(AddressOf GenerateThread2))
        'thread2.IsBackground = True
        'thread2.Priority = ThreadPriority.Normal
        'thread2.Start()
    End Sub

    'Private Shared Sub GenerateThread1()
    '    Dim eg2 As ExcelGenerator

    '    While listID.Count > 0

    '        SyncLock listID
    '            eg2 = New ExcelGenerator(currentID, excelArg.FileInfos(currentID - 1))
    '            listID.Remove(currentID)
    '        End SyncLock
    '        AddHandler eg2.OnGenerateFinished, AddressOf RemoveID
    '        AddHandler eg2.OnConvertProgress, AddressOf UpdateProgress
    '        eg2.GenerateExcel()
    '        currentID += 1
    '    End While

    'End Sub

    'Private Shared Sub GenerateThread2()
    '    Dim eg2 As ExcelGenerator

    '    While listID.Count > 0

    '        SyncLock listID
    '            eg2 = New ExcelGenerator(currentID, excelArg.FileInfos(currentID - 1))
    '            listID.Remove(currentID)
    '        End SyncLock
    '        AddHandler eg2.OnGenerateFinished, AddressOf RemoveID
    '        AddHandler eg2.OnConvertProgress, AddressOf UpdateProgress
    '        eg2.GenerateExcel()
    '        currentID += 1
    '    End While

    'End Sub

    ''' <summary>
    ''' 更新转换进度
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub UpdateProgress()
        current += 1
        RaiseEvent UpdateConvertProgress(CType(100 * (current / total), Integer))
    End Sub

    Private Shared Sub Generate(ByVal obj As Object)
        Dim index As Integer = CType(obj, Integer)
        If index < fileCount + 1 Then
            listID.Add(index)
            excelArg.ID = index
            excelArg.FileIndex = index - 1
            Dim eg2 As ExcelGenerator = New ExcelGenerator(excelArg)
            AddHandler eg2.OnGenerateFinished, AddressOf RemoveID
            AddHandler eg2.OnConvertProgress, AddressOf UpdateProgress
            eg2.GenerateExcel()
            index += 1
        End If
    End Sub

    Private Shared Sub TimeOut()

    End Sub

    ''' <summary>
    ''' 转换  转换缓冲区为2个
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Sub Convert()
        Dim index As Integer = 1
        Dim ev As New AutoResetEvent(False)

        ThreadPool.RegisterWaitForSingleObject(ev, New WaitOrTimerCallback(AddressOf TimeOut), Nothing, 3000, False)

        For i As Integer = 0 To fileCount - 1
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Generate), index)
        Next
        'Do While mrEvent.WaitOne()
        '    mrEvent.Reset()
        '    If listID.Count = 0 AndAlso index < fileCount + 1 Then

        '        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Generate), index)
        '        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Generate), index)
        '        'Generate(index)
        '        'Generate(index)
        '        'Generate(index)
        '    End If

        '    If index >= fileCount Then
        '        If listID.Count = 0 Then
        '            RaiseEvent ConvFinishedEvent()
        '        End If
        '    End If
        'Loop
    End Sub

    ' <summary>
    ' 生成Excel后将指定的生成器移除
    ' </summary>
    ' <param name="id"></param>
    Private Shared Sub RemoveID(ByVal id As Integer)

        SyncLock listID
            listID.Remove(id)
        End SyncLock

        If listID.Count = 0 Then
            'mrEvent.Set()
        End If

        'If listID.Count = 0 Then
        '    RaiseEvent ConvFinishedEvent()
        'End If
        RaiseEvent OnFinishedOneFile()

    End Sub
End Class

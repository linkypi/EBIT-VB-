Imports Microsoft.Office.Interop
Imports System.IO
Imports Microsoft.Win32
Imports System.Diagnostics
Imports System.Threading

Public Class FrmConvert

#Region "属性"

    Private beginTime As DateTime
    Private totalFile As Integer '文件总数
    Private fileCount_hasFinished As Integer '已完成的文件数量
    Private sourceFiles As List(Of String) '源文件列表
    Private excelArg As ExcelArgument 'Excel参数

    ''代理
    Private Delegate Sub ShowTimesEvent()
    Private Delegate Sub ActiveEvent()
    Private Delegate Sub UpdateProgressEvent(ByVal val As Integer)
    Private Delegate Sub UpdateFileCountEvent()
    Private Delegate Sub FlashEvent(ByVal sender As Object)
    Private UpdateProgressDel As UpdateProgressEvent
    Private ShowTimesDel As ShowTimesEvent
    Private UpdateFileCountDel As UpdateFileCountEvent
    Private FlashDel As FlashEvent
    Private ActiveDel As ActiveEvent


#End Region

#Region "事件"

    ''' <summary>
    ''' 打开
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtFilePath.Text = FolderBrowserDialog1.SelectedPath
        End If
        LoadFile(FolderBrowserDialog1.SelectedPath)

    End Sub

    ''' <summary>
    ''' 浏览
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txtSavePath.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    ''' <summary>
    ''' 转换
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvert.Click
        Convert()
    End Sub

    ''' <summary>
    ''' 窗体加载事件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            chkTab.Checked = True
            txtSeparator.Enabled = False
            chkRmSpace.Checked = True
            ' btnConvert.Enabled = False
            excelArg = New ExcelArgument()

            ShowTimesDel = New ShowTimesEvent(AddressOf ShowSpanTimes)
            UpdateProgressDel = New UpdateProgressEvent(AddressOf ShowProgress)
            UpdateFileCountDel = New UpdateFileCountEvent(AddressOf UpdateFileCount)
            FlashDel = New FlashEvent(AddressOf Flash)
            ActiveDel = New ActiveEvent(AddressOf ActiveControls)

            AddHandler ExcelConverter.ConvFinishedEvent, AddressOf ConvertFinished
            AddHandler ExcelConverter.UpdateConvertProgress, AddressOf UpdateProcess
            AddHandler ExcelConverter.OnFinishedOneFile, AddressOf FinishedOneFile
            '获取系统桌面路径
            Dim folders As RegistryKey = OpenRegistryPath(Registry.CurrentUser, "\software\microsoft\windows\currentversion\explorer\shell folders")
            txtSavePath.Text = folders.GetValue("Desktop").ToString() + "\Data"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 移除ListBox中的文件
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 移除RToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 移除RToolStripMenuItem.Click
        Dim files As List(Of String) = New List(Of String)

        ''获取所有选中的文件名
        For i As Integer = 0 To ListBox1.SelectedItems.Count - 1
            files.Add(ListBox1.SelectedItems(i))
        Next

        ''移除选中的文件名
        For Each f As String In files
            ListBox1.Items.Remove(f)
            For Each fi As FileInfo In excelArg.FileInfos
                If fi.Name = f Then
                    excelArg.FileInfos.Remove(fi)
                    totalFile -= 1
                    Exit For
                End If
            Next
        Next
        Label4.Text = "共 " + totalFile.ToString() + " 个文件"
    End Sub

    Private Sub txtFilePath_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFilePath.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadFile(txtFilePath.Text.Trim())
        End If
    End Sub

#End Region

#Region "私有方法"

    ''' <summary>
    ''' 加载文件
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadFile(ByVal path As String)
        Try
            ''加载文件夹
            Dim di As DirectoryInfo = New DirectoryInfo(path)
            excelArg.FileInfos = di.GetFiles("*.unl").ToList()
            If excelArg.FileInfos.Count = 0 Then
                excelArg.FileInfos = di.GetFiles("*.txt").ToList()
            End If
        Catch ex As Exception
            Try ''加载文件夹失败则加载单个文件
                Dim fi As FileInfo = New FileInfo(path)
                Dim ext As String = System.IO.Path.GetExtension(path)

                If ext = ".txt" Or ext = ".unl" Then
                    excelArg.FileInfos.Clear()
                    excelArg.FileInfos.Add(fi)
                Else
                    Me.BeginInvoke(FlashDel, New Object() {txtFilePath})
                    Return
                End If

            Catch exc As Exception
                Me.BeginInvoke(FlashDel, New Object() {txtFilePath})
                Return
            End Try
        End Try

        If excelArg.FileInfos Is Nothing Then
            Return
        End If
        If excelArg.FileInfos.Count > 0 Then
            btnConvert.Enabled = True
            btnConvert.Focus()
        End If

        ProgressBar1.Value = 0
        ListBox1.Items.Clear()
        ''加载文件列表
        sourceFiles = New List(Of String)
        Dim index As Integer = 0
        For Each fi As FileInfo In excelArg.FileInfos
            sourceFiles.Add(fi.Name)
            ListBox1.Items.Add(fi.Name)
            index += 1
        Next
        totalFile = excelArg.FileInfos.Count

        Label4.Text = "共 " + totalFile.ToString() + " 个文件"
    End Sub

    ''' <summary>
    ''' 显示消耗时间
    ''' </summary>
    ''' <param name="str"></param>
    ''' <remarks></remarks>
    Private Sub ShowSpanTimes()
        Dim endTime As DateTime = DateTime.Now
        Dim span As Integer = (endTime.Hour - beginTime.Hour) * 3600 + (endTime.Minute - beginTime.Minute) * 60 + endTime.Second - beginTime.Second
        Dim spantime As String = CType(span / 3600, Integer).ToString() + ":" + FormatTimeString(CType(span / 60, Integer).ToString()) + ":" + FormatTimeString((span Mod 60).ToString())

        LabSpanTime.Text = spantime
    End Sub

    ''' <summary>
    ''' 显示进度
    ''' </summary>
    ''' <param name="val"></param>
    ''' <remarks></remarks>
    Private Sub ShowProgress(ByVal val As Integer)
        Me.ProgressBar1.Value = val
    End Sub

    ''' <summary>
    ''' 转换结束
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConvertFinished()
        Me.BeginInvoke(ShowTimesDel)
        Me.BeginInvoke(ActiveDel)

        ClearExcelProcesses()
        MessageBox.Show("转换完成！")
    End Sub

    ''' <summary>
    ''' 激活控件
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActiveControls()
        ListBox1.ContextMenuStrip = ContextMenuStrip1
        grbArg.Enabled = True
        btnConvert.Enabled = True
    End Sub

    ''' <summary>
    ''' 清楚所有未关闭的Excel进程
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearExcelProcesses()
        Dim pross As Process() = Process.GetProcessesByName("EXCEL")
        For Each p As Process In pross
            p.Kill()
        Next
    End Sub

    Private Function FormatTimeString(ByVal str As String) As String
        If str.Length < 2 Then
            str = "0" & str
        End If
        Return str
    End Function

    ''' <summary>
    ''' 更新进度
    ''' </summary>
    ''' <param name="val"></param>
    ''' <remarks></remarks>
    Private Sub UpdateProcess(ByVal val As Integer)
        Me.BeginInvoke(UpdateProgressDel, New Object() {val})
    End Sub

    ''' <summary>
    ''' 参数验证
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ValidateArg() As Boolean
        '检测文件的有效性
        Dim filestr As String = txtFilePath.Text
        If String.IsNullOrEmpty(filestr) Then
            Me.BeginInvoke(FlashDel, New Object() {txtFilePath})
            Return False
        End If
        filestr = filestr.Substring(0, filestr.LastIndexOf("\"))
        If Directory.Exists(filestr) = False Then
            Me.BeginInvoke(FlashDel, New Object() {txtFilePath})
            Return False
        End If

        ''检测保存路径的有效性   若保存文件的文件夹不存在则创建
        excelArg.SavePath = txtSavePath.Text.Trim()
        Try
            If Directory.Exists(excelArg.SavePath) = False Then
                Directory.CreateDirectory(excelArg.SavePath)
            End If
        Catch ex As Exception
            Me.BeginInvoke(FlashDel, New Object() {txtSavePath})
            Return False
        End Try

        ''判断是否选择了分隔符
        Dim flag As Boolean = False
        For Each ct As Control In grbSeparate.Controls
            If ct.Name <> txtSeparator.Name Then
                Dim c As CheckBox = CType(ct, CheckBox)
                If c.Checked Then
                    flag = True
                    If chkOther.Name = c.Name Then ''若自定义分隔符为空
                        If chkOther.Checked And (String.IsNullOrEmpty(txtSeparator.Text) = True Or txtSeparator.Text.Trim().Length > 1) Then
                            Me.BeginInvoke(FlashDel, New Object() {txtSeparator})
                            Return False
                        End If
                        excelArg.Separator = txtSeparator.Text.Trim()
                    Else
                        excelArg.Separator = c.Tag
                    End If
                    Exit For
                End If
            End If
        Next
        If flag = False Then  '若未选择分隔符则提示
            Me.BeginInvoke(FlashDel, New Object() {grbSeparate})
            Return False
        End If

        ''若文件为空
        If excelArg.FileInfos.Count = 0 Then
            Me.BeginInvoke(FlashDel, New Object() {ListBox1})
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' 转换
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Convert()
        Try
            If ValidateArg() = False Then
                Return
            End If
            ListBox1.ContextMenuStrip = Nothing
            grbArg.Enabled = False
            btnConvert.Enabled = False

            excelArg.RemoveSpace = chkRmSpace.Checked
            LabSpanTime.Text = String.Empty
            LabHasFinished.Text = String.Empty
            Me.ProgressBar1.Value = 0
            fileCount_hasFinished = 0

            beginTime = DateTime.Now
            ExcelConverter.InitAllCount(excelArg)
            ExcelConverter.StartConvert()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 播放动画
    ''' </summary>
    ''' <param name="sender">控件名</param>
    ''' <remarks></remarks>
    Private Sub Flash(ByVal sender As Object)
        Dim control As Control = CType(sender, Control)
        Dim bcolor As Color = control.BackColor
        For i As Integer = 1 To 2
            control.BackColor = Color.Pink
            control.Update()
            Thread.Sleep(100)
            control.BackColor = bcolor
            control.Update()
            Thread.Sleep(100)
        Next
    End Sub

    ''' <summary>
    ''' 获取Excel参数
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetExcelArg()

        excelArg.SeparatePage = chkSeparate.Checked
        excelArg.RemoveSpace = chkRmSpace.Checked

        ''获取分隔符
        For Each ct As Control In grbSeparate.Controls
            If ct.Name = txtSeparator.Name AndAlso txtSeparator.Enabled Then
                excelArg.Separator = txtSeparator.Text.Trim()
                Exit For
            End If

            Dim c As CheckBox = CType(ct, CheckBox)
            If c.Checked Then
                excelArg.Separator = c.Tag
            End If
        Next

    End Sub

    ''' <summary>
    ''' 已成功转换一个文件
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FinishedOneFile()
        fileCount_hasFinished += 1
        BeginInvoke(UpdateFileCountDel, New Object() {})
    End Sub

    ''' <summary>
    ''' 更新已完成的文件数量
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateFileCount()
        LabHasFinished.Text = "已完成 " + fileCount_hasFinished.ToString() + " 个文件"
    End Sub

    ''' <summary>
    ''' 根据注册表获取系统桌面路径
    ''' </summary>
    ''' <param name="root"></param>
    ''' <param name="s"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function OpenRegistryPath(ByVal root As RegistryKey, ByVal s As String) As RegistryKey
        s = s.Remove(0, 1) & "/"

        While s.IndexOf("/") <> -1
            root = root.OpenSubKey(s.Substring(0, s.IndexOf("/")))
            s = s.Remove(0, s.IndexOf("/") + 1)
        End While
        Return root
    End Function

#End Region

#Region "CheckBox操作"

    ''' <summary>
    ''' 选择分页
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSeparate.CheckedChanged
        If chkSeparate.Checked Then
            Dim frmpage As FrmPaging = New FrmPaging

            If frmpage.ShowDialog() = DialogResult.OK Then
                excelArg.PageAttr = CType(frmpage.Tag, PageAttribute)
                excelArg.SeparatePage = True
            Else
                chkSeparate.Checked = False
            End If
        End If
    End Sub

    ''' <summary>
    ''' 分隔符参数选择
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkTab_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTab.CheckedChanged, chkSemicolon.CheckedChanged, chkComma.CheckedChanged
        SetCheck(sender)
    End Sub

    ''' <summary>
    ''' 选择分隔符
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    Private Sub SetCheck(ByVal sender As Object)
        Dim cb As CheckBox = CType(sender, CheckBox)

        If cb.Checked Then
            grbSeparate.Controls.Remove(txtSeparator)

            For Each ct As Control In grbSeparate.Controls
                Dim c As CheckBox = CType(ct, CheckBox)
                If c IsNot cb Then
                    c.Checked = False
                End If
            Next
            grbSeparate.Controls.Add(txtSeparator)
        End If

        If cb.Checked = False AndAlso cb.Tag.ToString() = "" Then
            chkRmSpace.Enabled = True
        End If
    End Sub

    '''' <summary>
    '''' 去除文本中的空格
    '''' </summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks></remarks>
    'Private Sub chkRmSpace_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRmSpace.CheckedChanged
    '    If chkRmSpace.Checked Then
    '        chkSpace.Enabled = False
    '    Else
    '        chkSpace.Enabled = True
    '    End If
    'End Sub

    ''' <summary>
    ''' 空格
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkSpace_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSpace.CheckedChanged
        'chkRmSpace.Enabled = False
        SetCheck(sender)
    End Sub

    ''' <summary>
    ''' 其他
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkOther_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOther.CheckedChanged

        txtSeparator.Enabled = chkOther.Checked
        If chkOther.Checked Then
            txtSeparator.BackColor = Color.White
        Else
            txtSeparator.BackColor = grbSeparate.BackColor
            txtSeparator.Text = String.Empty
        End If
        SetCheck(sender)
    End Sub
#End Region

End Class

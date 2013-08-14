<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConvert
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConvert))
        Me.btnOpen = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.txtFilePath = New System.Windows.Forms.TextBox
        Me.btnConvert = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSavePath = New System.Windows.Forms.TextBox
        Me.btnScan = New System.Windows.Forms.Button
        Me.LabSpanTime = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.移除RToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label4 = New System.Windows.Forms.Label
        Me.LabHasFinished = New System.Windows.Forms.Label
        Me.grbArg = New System.Windows.Forms.GroupBox
        Me.grbSeparate = New System.Windows.Forms.GroupBox
        Me.chkOther = New System.Windows.Forms.CheckBox
        Me.chkSpace = New System.Windows.Forms.CheckBox
        Me.txtSeparator = New System.Windows.Forms.TextBox
        Me.chkComma = New System.Windows.Forms.CheckBox
        Me.chkSemicolon = New System.Windows.Forms.CheckBox
        Me.chkTab = New System.Windows.Forms.CheckBox
        Me.chkRmSpace = New System.Windows.Forms.CheckBox
        Me.chkSeparate = New System.Windows.Forms.CheckBox
        Me.ContextMenuStrip1.SuspendLayout()
        Me.grbArg.SuspendLayout()
        Me.grbSeparate.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(329, 5)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 0
        Me.btnOpen.Text = "打开"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "文件："
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "文本文件|*.txt;*.unl"
        Me.OpenFileDialog1.FilterIndex = 0
        Me.OpenFileDialog1.Multiselect = True
        '
        'txtFilePath
        '
        Me.txtFilePath.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtFilePath.Location = New System.Drawing.Point(75, 8)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(238, 21)
        Me.txtFilePath.TabIndex = 2
        '
        'btnConvert
        '
        Me.btnConvert.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnConvert.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConvert.Location = New System.Drawing.Point(429, 5)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(77, 60)
        Me.btnConvert.TabIndex = 0
        Me.btnConvert.Text = "转换"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "保存位置："
        '
        'txtSavePath
        '
        Me.txtSavePath.Location = New System.Drawing.Point(75, 44)
        Me.txtSavePath.Name = "txtSavePath"
        Me.txtSavePath.Size = New System.Drawing.Size(238, 21)
        Me.txtSavePath.TabIndex = 2
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(329, 42)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(75, 23)
        Me.btnScan.TabIndex = 0
        Me.btnScan.Text = "浏览···"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'LabSpanTime
        '
        Me.LabSpanTime.AutoSize = True
        Me.LabSpanTime.Location = New System.Drawing.Point(235, 345)
        Me.LabSpanTime.Name = "LabSpanTime"
        Me.LabSpanTime.Size = New System.Drawing.Size(0, 12)
        Me.LabSpanTime.TabIndex = 3
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 326)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(493, 14)
        Me.ProgressBar1.TabIndex = 4
        '
        'ListBox1
        '
        Me.ListBox1.ColumnWidth = 100
        Me.ListBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(13, 179)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBox1.Size = New System.Drawing.Size(493, 148)
        Me.ListBox1.TabIndex = 6
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.移除RToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(117, 26)
        '
        '移除RToolStripMenuItem
        '
        Me.移除RToolStripMenuItem.Name = "移除RToolStripMenuItem"
        Me.移除RToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.移除RToolStripMenuItem.Text = "移除(&R)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 345)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 12)
        Me.Label4.TabIndex = 3
        '
        'LabHasFinished
        '
        Me.LabHasFinished.AutoSize = True
        Me.LabHasFinished.Location = New System.Drawing.Point(414, 345)
        Me.LabHasFinished.Name = "LabHasFinished"
        Me.LabHasFinished.Size = New System.Drawing.Size(0, 12)
        Me.LabHasFinished.TabIndex = 3
        '
        'grbArg
        '
        Me.grbArg.Controls.Add(Me.grbSeparate)
        Me.grbArg.Controls.Add(Me.chkRmSpace)
        Me.grbArg.Controls.Add(Me.chkSeparate)
        Me.grbArg.Location = New System.Drawing.Point(15, 73)
        Me.grbArg.Name = "grbArg"
        Me.grbArg.Size = New System.Drawing.Size(491, 100)
        Me.grbArg.TabIndex = 7
        Me.grbArg.TabStop = False
        Me.grbArg.Text = "参数设置"
        '
        'grbSeparate
        '
        Me.grbSeparate.Controls.Add(Me.chkOther)
        Me.grbSeparate.Controls.Add(Me.chkSpace)
        Me.grbSeparate.Controls.Add(Me.txtSeparator)
        Me.grbSeparate.Controls.Add(Me.chkComma)
        Me.grbSeparate.Controls.Add(Me.chkSemicolon)
        Me.grbSeparate.Controls.Add(Me.chkTab)
        Me.grbSeparate.Location = New System.Drawing.Point(185, 16)
        Me.grbSeparate.Name = "grbSeparate"
        Me.grbSeparate.Size = New System.Drawing.Size(300, 73)
        Me.grbSeparate.TabIndex = 8
        Me.grbSeparate.TabStop = False
        Me.grbSeparate.Text = "分隔符"
        '
        'chkOther
        '
        Me.chkOther.AutoSize = True
        Me.chkOther.Location = New System.Drawing.Point(110, 45)
        Me.chkOther.Name = "chkOther"
        Me.chkOther.Size = New System.Drawing.Size(72, 16)
        Me.chkOther.TabIndex = 15
        Me.chkOther.Tag = "other"
        Me.chkOther.Text = "其他(&O):"
        Me.chkOther.UseVisualStyleBackColor = True
        '
        'chkSpace
        '
        Me.chkSpace.AutoSize = True
        Me.chkSpace.Location = New System.Drawing.Point(22, 45)
        Me.chkSpace.Name = "chkSpace"
        Me.chkSpace.Size = New System.Drawing.Size(66, 16)
        Me.chkSpace.TabIndex = 15
        Me.chkSpace.Tag = ""
        Me.chkSpace.Text = "空格(&S)"
        Me.chkSpace.UseVisualStyleBackColor = True
        '
        'txtSeparator
        '
        Me.txtSeparator.BackColor = System.Drawing.SystemColors.Control
        Me.txtSeparator.Font = New System.Drawing.Font("宋体", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtSeparator.ForeColor = System.Drawing.Color.DimGray
        Me.txtSeparator.Location = New System.Drawing.Point(190, 43)
        Me.txtSeparator.Name = "txtSeparator"
        Me.txtSeparator.Size = New System.Drawing.Size(66, 23)
        Me.txtSeparator.TabIndex = 1
        '
        'chkComma
        '
        Me.chkComma.AutoSize = True
        Me.chkComma.Location = New System.Drawing.Point(190, 21)
        Me.chkComma.Name = "chkComma"
        Me.chkComma.Size = New System.Drawing.Size(66, 16)
        Me.chkComma.TabIndex = 14
        Me.chkComma.Tag = ","
        Me.chkComma.Text = "逗号(&C)"
        Me.chkComma.UseVisualStyleBackColor = True
        '
        'chkSemicolon
        '
        Me.chkSemicolon.AutoSize = True
        Me.chkSemicolon.Location = New System.Drawing.Point(110, 23)
        Me.chkSemicolon.Name = "chkSemicolon"
        Me.chkSemicolon.Size = New System.Drawing.Size(66, 16)
        Me.chkSemicolon.TabIndex = 13
        Me.chkSemicolon.Tag = ";"
        Me.chkSemicolon.Text = "分号(&M)"
        Me.chkSemicolon.UseVisualStyleBackColor = True
        '
        'chkTab
        '
        Me.chkTab.AutoSize = True
        Me.chkTab.Location = New System.Drawing.Point(22, 23)
        Me.chkTab.Name = "chkTab"
        Me.chkTab.Size = New System.Drawing.Size(72, 16)
        Me.chkTab.TabIndex = 12
        Me.chkTab.Tag = "tab"
        Me.chkTab.Text = "Tab键(&T)"
        Me.chkTab.UseVisualStyleBackColor = True
        '
        'chkRmSpace
        '
        Me.chkRmSpace.AutoSize = True
        Me.chkRmSpace.Location = New System.Drawing.Point(38, 65)
        Me.chkRmSpace.Name = "chkRmSpace"
        Me.chkRmSpace.Size = New System.Drawing.Size(120, 16)
        Me.chkRmSpace.TabIndex = 12
        Me.chkRmSpace.Text = "去除文本中的空格"
        Me.chkRmSpace.UseVisualStyleBackColor = True
        '
        'chkSeparate
        '
        Me.chkSeparate.AutoSize = True
        Me.chkSeparate.Location = New System.Drawing.Point(38, 31)
        Me.chkSeparate.Name = "chkSeparate"
        Me.chkSeparate.Size = New System.Drawing.Size(48, 16)
        Me.chkSeparate.TabIndex = 12
        Me.chkSeparate.Text = "分页"
        Me.chkSeparate.UseVisualStyleBackColor = True
        '
        'FrmConvert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 359)
        Me.Controls.Add(Me.grbArg)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LabHasFinished)
        Me.Controls.Add(Me.LabSpanTime)
        Me.Controls.Add(Me.txtSavePath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFilePath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.btnScan)
        Me.Controls.Add(Me.btnOpen)
        Me.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmConvert"
        Me.Opacity = 0.95
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Excel转换器"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.grbArg.ResumeLayout(False)
        Me.grbArg.PerformLayout()
        Me.grbSeparate.ResumeLayout(False)
        Me.grbSeparate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents btnConvert As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSavePath As System.Windows.Forms.TextBox
    Friend WithEvents btnScan As System.Windows.Forms.Button
    Friend WithEvents LabSpanTime As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LabHasFinished As System.Windows.Forms.Label
    Friend WithEvents grbArg As System.Windows.Forms.GroupBox
    Friend WithEvents txtSeparator As System.Windows.Forms.TextBox
    Friend WithEvents chkRmSpace As System.Windows.Forms.CheckBox
    Friend WithEvents chkSeparate As System.Windows.Forms.CheckBox
    Friend WithEvents grbSeparate As System.Windows.Forms.GroupBox
    Friend WithEvents chkOther As System.Windows.Forms.CheckBox
    Friend WithEvents chkSpace As System.Windows.Forms.CheckBox
    Friend WithEvents chkComma As System.Windows.Forms.CheckBox
    Friend WithEvents chkSemicolon As System.Windows.Forms.CheckBox
    Friend WithEvents chkTab As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 移除RToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

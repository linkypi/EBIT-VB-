<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPaging
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPaging))
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.NudRowCount = New System.Windows.Forms.NumericUpDown
        Me.NudColumeCount = New System.Windows.Forms.NumericUpDown
        Me.列1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.列2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.列3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me._flex = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        CType(Me.NudRowCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudColumeCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._flex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 17)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "每页的行数:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(244, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 17)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "每行的列数:"
        '
        'NudRowCount
        '
        Me.NudRowCount.Location = New System.Drawing.Point(91, 11)
        Me.NudRowCount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NudRowCount.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NudRowCount.Name = "NudRowCount"
        Me.NudRowCount.Size = New System.Drawing.Size(49, 23)
        Me.NudRowCount.TabIndex = 10
        '
        'NudColumeCount
        '
        Me.NudColumeCount.Location = New System.Drawing.Point(321, 11)
        Me.NudColumeCount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NudColumeCount.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NudColumeCount.Name = "NudColumeCount"
        Me.NudColumeCount.Size = New System.Drawing.Size(49, 23)
        Me.NudColumeCount.TabIndex = 11
        '
        '列1
        '
        Me.列1.HeaderText = "列1"
        Me.列1.Name = "列1"
        Me.列1.ReadOnly = True
        '
        '列2
        '
        Me.列2.HeaderText = "列2"
        Me.列2.Name = "列2"
        Me.列2.ReadOnly = True
        '
        '列3
        '
        Me.列3.HeaderText = "列3"
        Me.列3.Name = "列3"
        Me.列3.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "设置列的名称及数据类型:"
        '
        '_flex
        '
        Me._flex.ColumnInfo = "10,1,0,50,100,100,Columns:"
        Me._flex.Location = New System.Drawing.Point(17, 68)
        Me._flex.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me._flex.Name = "_flex"
        Me._flex.Rows.DefaultSize = 20
        Me._flex.Size = New System.Drawing.Size(361, 91)
        Me._flex.StyleInfo = resources.GetString("_flex.StyleInfo")
        Me._flex.TabIndex = 13
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(295, 168)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "取消(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(182, 168)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 14
        Me.btnOK.Tag = ""
        Me.btnOK.Text = "确定(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'FrmPaging
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 196)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me._flex)
        Me.Controls.Add(Me.NudColumeCount)
        Me.Controls.Add(Me.NudRowCount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPaging"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "分页设置"
        CType(Me.NudRowCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudColumeCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._flex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents NudRowCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudColumeCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents 列1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 列2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 列3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents _flex As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class

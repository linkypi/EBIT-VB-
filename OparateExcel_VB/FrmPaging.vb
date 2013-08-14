Imports C1.Win.C1FlexGrid

Public Class FrmPaging

    Private columns As Integer
    Private rows As Integer
    Dim dic_dt As Dictionary(Of String, String)

    Private Sub FrmPaging_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NudColumeCount.Value = 5
        NudRowCount.Value = 200

        dic_dt = New Dictionary(Of String, String)
        dic_dt.Add("常规", "G/通用格式")
        dic_dt.Add("数值", "0.000_ ")
        dic_dt.Add("RMB", "￥#,##0.000") '
        dic_dt.Add("美元", "$#,##0.000")
        dic_dt.Add("百分比", "0.000%")
        dic_dt.Add("分数", "# ?/?")
        dic_dt.Add("科学计数", "0.00E+00")
        dic_dt.Add("文本", "@")

        dic_dt.Add("邮政编码", "000000")
        dic_dt.Add("中文小写数字", "[DBNum1]G/通用格式")
        dic_dt.Add("中文大写数字", "[DBNum2]G/通用格式")
        dic_dt.Add("人民币大写", "[DBNum2][$RMB]G/通用格式")
        dic_dt.Add("日期", "yy/mm/dd")
    End Sub

    Private Sub SetCellType(ByVal cols As Integer)
        columns = cols
        _flex.Cols.Count = cols + 1
        _flex.Rows.Count = 3
        _flex(1, 0) = "列名"
        _flex(2, 0) = "数据类型"

        Dim cs As CellStyle = _flex.Styles.Add("dataType")
        cs.DataType = GetType(String)
        cs.ComboList = "|常规|文本|日期|数值|RMB|美元|百分比|分数|科学计数|中文小写数字|中文大写数字|人民币大写|"
        cs.ForeColor = Color.Green
        cs.Font = New Font(Font, FontStyle.Bold)

        cs = _flex.Styles.Add("ColumnName")
        cs.DataType = GetType(String)
        cs.ForeColor = Color.DarkGoldenrod


        Dim rg As CellRange = _flex.GetCellRange(2, 1, 2, cols)
        rg.Style = _flex.Styles("dataType")

        rg = _flex.GetCellRange(1, 1, 1, cols)
        rg.Style = _flex.Styles("ColumnName")

        _flex.Cols(0).Caption = ""
        For i As Integer = 1 To cols
            _flex.Cols(i).Caption = "列" + i.ToString()
            _flex(2, i) = "文本"
            _flex(1, i) = _flex.Cols(i).Caption
            _flex.Cols(i).TextAlign = Web.UI.WebControls.TextAlign.Right
        Next
    End Sub

    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudColumeCount.ValueChanged
        If NudColumeCount.Value > 0 Then
            SetCellType(CType(NudColumeCount.Value, Integer))
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        For i As Integer = 1 To columns
            If String.IsNullOrEmpty(_flex(1, i)) Then
                MessageBox.Show("列" & i.ToString() & "缺少列名！")
                Return
            End If
        Next

        Dim pa As PageAttribute = New PageAttribute()
        pa.Cols = CType(NudColumeCount.Value, Integer)
        pa.Rows = CType(NudRowCount.Value, Integer)

        pa.ColumnAttrList = New List(Of ColumnAttribute)
        Dim ca As ColumnAttribute
        For i As Integer = 1 To CType(NudColumeCount.Value, Integer)
            ca = New ColumnAttribute(_flex(1, i).ToString(), dic_dt(_flex(2, i).ToString()))
            pa.ColumnAttrList.Add(ca)
        Next

        Me.Tag = pa

        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class
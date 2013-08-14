Public Class ColumnAttribute
    Private _name As String
    Private _datatype As String

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="name">列名</param>
    ''' <param name="dt">数据类型</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal name As String, ByVal dt As String)
        _name = name
        _datatype = dt
    End Sub

    ''' <summary>
    ''' 列名
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    ''' <summary>
    ''' 数据类型
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataType() As String
        Get
            Return _datatype
        End Get
        Set(ByVal value As String)
            _datatype = value
        End Set
    End Property
End Class

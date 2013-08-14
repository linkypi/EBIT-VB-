Public Class PageAttribute
    Private _cols As Integer
    Private _rows As Integer
    Private _calist As List(Of ColumnAttribute)

    ''' <summary>
    ''' 每行的列数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Cols() As Integer
        Get
            Return _cols
        End Get

        Set(ByVal value As Integer)
            _cols = value
        End Set
    End Property

    ''' <summary>
    ''' 每页的行数
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Rows() As Integer
        Get
            Return _rows
        End Get

        Set(ByVal value As Integer)
            _rows = value
        End Set
    End Property

    ''' <summary>
    ''' 列的属性集合
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ColumnAttrList() As List(Of ColumnAttribute)
        Get
            Return _calist
        End Get

        Set(ByVal value As List(Of ColumnAttribute))
            _calist = value
        End Set
    End Property
End Class

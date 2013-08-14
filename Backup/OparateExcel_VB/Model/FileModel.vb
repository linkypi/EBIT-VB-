Public Class FileModel

    Private _name As String
    Private _strlist As String()

    Public Sub New(ByVal name As String, ByVal strlist As String())
        _name = name
        _strlist = strlist
    End Sub


    ''' <summary>
    ''' 文件名
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
    ''' 文件字符数组
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ListStr() As String()
        Get
            Return _strlist
        End Get

        Set(ByVal value As String())
            _strlist = value
        End Set
    End Property
End Class

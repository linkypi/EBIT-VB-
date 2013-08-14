Imports System.IO

Public Class ExcelArgument
    Private _pageattr As PageAttribute
    Private _removespace As Boolean
    Private _separatePage As Boolean
    Private _separator As String
    Private _savepath As String
    Private _fileinfos As List(Of FileInfo)
    Private _fileModels As List(Of FileModel)
    Private _id As Integer
    Private _fielIndex As Integer
    Private _chars As Char()
    Private _sleeptimes As Integer


    ''' <summary>
    ''' ID
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    ''' <summary>
    ''' 线程睡眠时间
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SleepTimes() As Integer
        Get
            Return _sleeptimes
        End Get
        Set(ByVal value As Integer)
            _sleeptimes = value
        End Set
    End Property

    ''' <summary>
    ''' 转为Char后的分隔符
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SeparateChars() As Char()
        Get
            Return _chars
        End Get
        Set(ByVal value As Char())
            _chars = value
        End Set
    End Property

    ''' <summary>
    ''' 文件索引
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FileIndex() As Integer
        Get
            Return _fielIndex
        End Get
        Set(ByVal value As Integer)
            _fielIndex = value
        End Set
    End Property

    ''' <summary>
    ''' 页面属性
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PageAttr() As PageAttribute
        Get
            Return _pageattr
        End Get
        Set(ByVal value As PageAttribute)
            _pageattr = value
        End Set
    End Property

    ''' <summary>
    ''' 是否移除空格
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RemoveSpace() As Boolean
        Get
            Return _removespace
        End Get
        Set(ByVal value As Boolean)
            _removespace = value
        End Set
    End Property

    ''' <summary>
    ''' 是否分页
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SeparatePage() As Boolean
        Get
            Return _separatePage
        End Get
        Set(ByVal value As Boolean)
            _separatePage = value
        End Set
    End Property

    ''' <summary>
    ''' 分隔符
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Separator() As String
        Get
            Return _separator
        End Get
        Set(ByVal value As String)
            _separator = value
        End Set
    End Property

    ''' <summary>
    ''' 保存路径
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SavePath() As String
        Get
            Return _savepath
        End Get

        Set(ByVal value As String)
            _savepath = value
        End Set
    End Property


    Public Property FileInfos() As List(Of FileInfo)
        Get
            If _fileinfos Is Nothing Then
                _fileinfos = New List(Of FileInfo)
            End If
            Return _fileinfos
        End Get

        Set(ByVal value As List(Of FileInfo))
            _fileinfos = value
        End Set
    End Property


    Public Property FileModels() As List(Of FileModel)
        Get
            If _fileModels Is Nothing Then
                _fileModels = New List(Of FileModel)
            End If
            Return _fileModels
        End Get

        Set(ByVal value As List(Of FileModel))
            _fileModels = value
        End Set
    End Property


End Class

Public Class Todo
    'プロパティ
    Private _item As String
    Public Property Item() As String
        Get
            Return _item
        End Get
        Set(ByVal value As String)
            _item = value
        End Set
    End Property

    Private _done As Boolean
    Public Property Done() As Boolean
        Get
            Return _done
        End Get
        Set(ByVal value As Boolean)
            _done = value
        End Set
    End Property
End Class

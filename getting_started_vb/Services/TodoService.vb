Imports getting_started_vb
Imports NLog

Public Class TodoService : Implements ITodoService
    Private ReadOnly _repository As ITodoRepository
    Private ReadOnly _logger As ILogger

    'コンストラクタ
    Sub New()
        Me.New(New TodoRepository(), LogManager.GetCurrentClassLogger)
    End Sub

    'コンストラクタのオーバーロード
    Sub New(ByVal repository As ITodoRepository, ByVal logger As ILogger)
        _repository = repository
        _logger = logger
    End Sub

    ''' <summary>
    ''' Todoリストの取得
    ''' </summary>
    ''' <returns>Todoリスト</returns>
    Public Function GetTodoList() As IEnumerable(Of Todo) Implements ITodoService.GetTodoList
        Dim list = _repository.GetTodoList()
        'Log出力
        _logger.Debug($"取得件数 : {list.Count}")
        Return list
    End Function
End Class

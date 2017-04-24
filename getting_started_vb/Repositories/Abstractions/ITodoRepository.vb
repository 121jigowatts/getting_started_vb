'インターフェイスの定義
Public Interface ITodoRepository
    Function GetTodoList() As IEnumerable(Of Todo)
End Interface

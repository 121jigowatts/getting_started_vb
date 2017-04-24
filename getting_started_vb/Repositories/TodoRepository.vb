Imports getting_started_vb
'インターフェイスの実装
Public Class TodoRepository : Implements ITodoRepository

    Public Function GetTodoList() As IEnumerable(Of Todo) Implements ITodoRepository.GetTodoList
        '初期化子
        Dim list As New List(Of Todo) From {
                New Todo() With {.Item = "Task001", .Done = False},
                New Todo() With {.Item = "Task002", .Done = False},
                New Todo() With {.Item = "Task003", .Done = True},
                New Todo() With {.Item = "Task004", .Done = True},
                New Todo() With {.Item = "Task005", .Done = False},
                New Todo() With {.Item = "Task006", .Done = True}
            }
        Return list
    End Function
End Class

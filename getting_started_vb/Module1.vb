Module Module1

    Sub Main()
        Dim service As New TodoService
        'リスト(ジェネリックコレクション))
        Dim todoList As List(Of Todo) = service.GetTodoList
        'LINQ
        Dim query = todoList.Where(Function(f) f.Done = True)
        'For Each文
        For Each item In query
            Console.WriteLine($"完了済み: {item.Item}")
        Next
        Console.ReadKey(True)
    End Sub
End Module

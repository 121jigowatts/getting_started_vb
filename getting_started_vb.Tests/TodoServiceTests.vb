Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports NLog

<TestClass()>
Public Class TodoServiceTests

    Private testContextInstance As TestContext

    '''<summary>
    '''現在のテストの実行についての情報および機能を
    '''提供するテスト コンテキストを取得または設定します。
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = value
        End Set
    End Property

#Region "追加のテスト属性"
    '
    ' テストを作成する際には、次の追加属性を使用できます:
    '
    ' クラス内で最初のテストを実行する前に、ClassInitialize を使用してコードを実行してください
    ' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    ' End Sub
    '
    ' クラス内のテストをすべて実行したら、ClassCleanup を使用してコードを実行してください
    ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
    ' End Sub
    '
    ' 各テストを実行する前に、TestInitialize を使用してコードを実行してください
    ' <TestInitialize()> Public Sub MyTestInitialize()
    ' End Sub
    '
    ' 各テストを実行した後に、TestCleanup を使用してコードを実行してください
    ' <TestCleanup()> Public Sub MyTestCleanup()
    ' End Sub
    '
#End Region

    <TestMethod()>
    Public Sub GetTodoList_Normal()
        Dim list = New List(Of Todo) From {
                New Todo() With {.Item = "Task001", .Done = False},
                New Todo() With {.Item = "Task002", .Done = False},
                New Todo() With {.Item = "Task003", .Done = True}
            }

        'モック
        Dim repositoryMock = New Mock(Of ITodoRepository)
        repositoryMock.Setup(Function(r) r.GetTodoList()).Returns(list)
        Dim loggerMock = New Mock(Of ILogger)
        Dim _service = New TodoService(repositoryMock.Object, loggerMock.Object)

        Dim expected = 3
        Dim todoList = _service.GetTodoList
        Dim actual = todoList.Count

        '単体テスト
        Assert.AreEqual(expected, actual)
    End Sub

End Class

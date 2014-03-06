' An instance of the SortWrapper class is created for  
' each item and added to the ArrayList for sorting. 
Public Class ListViewColumnSorter
    Friend sortItem As ListViewItem
    Friend sortColumn As Integer

    ' A SortWrapper requires the item and the index of the clicked column. 
    Public Sub New(ByVal Item As ListViewItem, ByVal iColumn As Integer)
        sortItem = Item
        sortColumn = iColumn
    End Sub

    ' Text property for getting the text of an item. 
    Public ReadOnly Property [Text]() As String
        Get
            Return sortItem.SubItems(sortColumn).Text
        End Get
    End Property

    ' Implementation of the IComparer  
    ' interface for sorting ArrayList items. 
    Public Class SortComparer
        Implements IComparer
        Private ascending As Boolean


        ' Constructor requires the sort order; 
        ' true if ascending, otherwise descending. 
        Public Sub New(ByVal asc As Boolean)
            Me.ascending = asc
        End Sub


        ' Implementation of the IComparer:Compare  
        ' method for comparing two objects. 
        Public Function [Compare](ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Dim xItem As ListViewColumnSorter = CType(x, ListViewColumnSorter)
            Dim yItem As ListViewColumnSorter = CType(y, ListViewColumnSorter)

            Dim xText As String = xItem.sortItem.SubItems(xItem.sortColumn).Text
            Dim yText As String = yItem.sortItem.SubItems(yItem.sortColumn).Text
            Return xText.CompareTo(yText) * IIf(Me.ascending, 1, -1)
        End Function
    End Class
End Class
Imports System.Drawing.Text
Imports System.Security.Cryptography

Public Class Form1

  Dim id As Integer

  Public Sub New()
    InitializeComponent()
    id = 0
    lstvData.FullRowSelect = True
  End Sub

  Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    Dim x As MyItem
    'i++   -->   i = i + 1
    Dim description As String = txtDescription.Text
    id = id + 1
    Dim Price As Random = New Random()

    x = New MyItem(id, description, Math.Round(Price.NextDouble() * 1000, 2))
    lstItems.Items.Add(x.ToString())

    'ListView -- ListViewItems -- SubItems

    For i = 1 To 100
      Dim row As ListViewItem = New ListViewItem(x.Id)
      row.SubItems.Add(x.Description)
      row.SubItems.Add(x.Price)
      lstvData.Items.Add(row)
      x.Id = x.Id + 1
      x.Price = Math.Round(Price.NextDouble() * 1000, 2)

    Next
    UpdateLabel()
    UpdateTotal()
  End Sub

  Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
    If lstvData.SelectedItems.Count = 0 Then
      Return
    End If
    For Each item As ListViewItem In lstvData.SelectedItems
      lstvData.Items.Remove(item)
    Next
    UpdateLabel()
    UpdateTotal()
  End Sub

  Sub UpdateLabel()
    lblCount.Text = lstvData.Items.Count
  End Sub
  Sub UpdateTotal()
    Dim Total As Decimal = 0
    For Each item As ListViewItem In lstvData.Items
      Total = Total + Decimal.Parse(item.SubItems(2).Text)
    Next
    LblTotal.Text = Total
  End Sub
End Class

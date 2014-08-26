Public Class Main

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click

        Misc.ReportGen()
        Form2.ShowDialog()
    End Sub

    Private Sub AdaugaProdusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdaugaProdusToolStripMenuItem.Click

        Dim frm As New Form4
        If ListView1.Items.Count <= 27 Then
            frm.ShowDialog()
        End If
    End Sub

    Private Sub StergeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StergeToolStripMenuItem1.Click

        For Each lvItem As ListViewItem In ListView1.SelectedItems
            lvItem.Remove()
        Next
        For i As Integer = 0 To ListView1.Items.Count - 1
            ListView1.Items(i).Text = i + 1
        Next
        Misc.Calculate()
    End Sub

    Private Sub ModificaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificaToolStripMenuItem.Click

        Dim frm As New Form4
        frm.Text = "Modifica produs"
        If ListView1.SelectedItems.Count = 1 Then
            frm.ShowDialog()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        ListView1.Items.Clear()
        TextBox15.Clear()
        TextBox22.Text = "0,00"
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click

        Form3.ShowDialog()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = "Aviz de Insotire a Marfii v" & Application.ProductVersion
        Misc.Settings(False)
        Misc.Update()
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click

        Form5.ShowDialog()
    End Sub
End Class

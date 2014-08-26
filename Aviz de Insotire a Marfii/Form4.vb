Public Class Form4

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me.Text = "Modifica produs" Then
            TextBox1.Text = Main.ListView1.Items(Main.ListView1.SelectedItems(0).Index).SubItems.Item(1).Text
            TextBox2.Text = Main.ListView1.Items(Main.ListView1.SelectedItems(0).Index).SubItems.Item(2).Text
            NumericUpDown2.Text = Main.ListView1.Items(Main.ListView1.SelectedItems(0).Index).SubItems.Item(3).Text
            NumericUpDown1.Text = Main.ListView1.Items(Main.ListView1.SelectedItems(0).Index).SubItems.Item(4).Text
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        If Me.Text = "Modifica produs" Then
            Main.ListView1.Items(Main.ListView1.SelectedItems(0).Index).SubItems.Item(1).Text = TextBox1.Text
            Main.ListView1.Items(Main.ListView1.SelectedItems(0).Index).SubItems.Item(2).Text = TextBox2.Text
            Main.ListView1.Items(Main.ListView1.SelectedItems(0).Index).SubItems.Item(3).Text = NumericUpDown2.Text
            Main.ListView1.Items(Main.ListView1.SelectedItems(0).Index).SubItems.Item(4).Text = NumericUpDown1.Text
            Main.ListView1.Items(Main.ListView1.SelectedItems(0).Index).SubItems.Item(5).Text = Format(Math.Round(NumericUpDown2.Text * NumericUpDown1.Text, 2), "0.00")
        Else
            Main.ListView1.Items.Add(Main.ListView1.Items.Count + 1)
            Main.ListView1.Items(Main.ListView1.Items.Count - 1).SubItems.Add(TextBox1.Text)
            Main.ListView1.Items(Main.ListView1.Items.Count - 1).SubItems.Add(TextBox2.Text)
            Main.ListView1.Items(Main.ListView1.Items.Count - 1).SubItems.Add(NumericUpDown2.Text)
            Main.ListView1.Items(Main.ListView1.Items.Count - 1).SubItems.Add(NumericUpDown1.Text)
            Main.ListView1.Items(Main.ListView1.Items.Count - 1).SubItems.Add(Format(Math.Round(NumericUpDown2.Text * NumericUpDown1.Text, 2), "0.00"))
        End If
        Misc.Calculate()
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Me.Close()
    End Sub
End Class
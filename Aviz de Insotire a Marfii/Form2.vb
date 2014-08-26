Imports System.IO
Imports Microsoft.Reporting.WinForms

Public Class Form2

    Sub New()

        InitializeComponent()
        Me.Width = Screen.PrimaryScreen.Bounds.Width - 50
        Me.Height = Screen.PrimaryScreen.Bounds.Height - 75
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ToolStripComboBox1.SelectedIndex = 5
        ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.RefreshReport()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        ReportViewer1.PrintDialog()
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged

        If ToolStripComboBox1.SelectedItem = "Latimea paginii" Then
            ReportViewer1.ZoomMode = ZoomMode.PageWidth
            ReportViewer1.RefreshReport()
        ElseIf ToolStripComboBox1.SelectedItem = "Toata pagina" Then
            ReportViewer1.ZoomMode = ZoomMode.FullPage
            ReportViewer1.RefreshReport()
        Else
            ReportViewer1.ZoomMode = ZoomMode.Percent
            ReportViewer1.ZoomPercent = ToolStripComboBox1.SelectedItem.ToString.Replace("%", "")
            ReportViewer1.RefreshReport()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        SaveFileDialog1.InitialDirectory = Application.StartupPath & "\Avize"
        SaveFileDialog1.FileName = "Aviz nr. " & Main.TextBox15.Text
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim warningArray As Warning()
            Dim strArray As String()
            Dim buffer As Byte() = ReportViewer1.LocalReport.Render("PDF", Nothing, "", "", ".pdf", strArray, warningArray)
            Dim stream As New FileStream(SaveFileDialog1.FileName, FileMode.Create)
            stream.Write(buffer, 0, buffer.Length)
            stream.Close()
        End If
    End Sub
End Class
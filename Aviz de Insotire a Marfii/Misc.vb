Imports System.IO
Imports System.Xml
Imports Microsoft.Reporting.WinForms

Public Class Misc

    Public Shared Sub Calculate()

        Dim t1 As Double = 0
        For i As Integer = 0 To Main.ListView1.Items.Count - 1
            t1 += Double.Parse(Main.ListView1.Items(i).SubItems.Item(5).Text)
        Next
        Main.TextBox22.Text = Format(Math.Round(t1, 2), "0.00")
    End Sub

    Public Shared Sub Update()

        Main.TextBox1.Text = Form3.TextBox1.Text
        Main.TextBox2.Text = Form3.TextBox2.Text
        Main.TextBox3.Text = Form3.TextBox3.Text
        Main.TextBox4.Text = Form3.TextBox4.Text
        Main.TextBox5.Text = Form3.TextBox5.Text
        Main.TextBox6.Text = Form3.ComboBox1.Text
        Main.TextBox7.Text = Form3.TextBox6.Text
        Main.TextBox8.Text = Form3.TextBox7.Text
        Main.TextBox20.Text = Form3.TextBox14.Text
        Main.TextBox9.Text = Form3.TextBox13.Text
        Main.TextBox10.Text = Form3.TextBox12.Text
        Main.TextBox11.Text = Form3.TextBox10.Text
        Main.TextBox12.Text = Form3.ComboBox2.Text
        Main.TextBox13.Text = Form3.TextBox9.Text
        Main.TextBox14.Text = Form3.TextBox8.Text
        Main.TextBox21.Text = Form3.TextBox17.Text
        Main.TextBox16.Text = Form3.TextBox16.Text
        Main.TextBox17.Text = Form3.TextBox15.Text
        Main.TextBox18.Text = Form3.TextBox11.Text
    End Sub

    Public Shared Sub ReportGen()

        Dim table As DataTable = Form2.DataSet1.DataTable1
        table.Rows.Clear()
        For i As Integer = 0 To Main.ListView1.Items.Count - 1
            table.Rows.Add(New Object(0 - 1) {})
            table.Rows.Item(i).Item("DataColumn1") = Main.ListView1.Items(i).SubItems(0).Text
            table.Rows.Item(i).Item("DataColumn2") = Main.ListView1.Items(i).SubItems(1).Text
            table.Rows.Item(i).Item("DataColumn3") = Main.ListView1.Items(i).SubItems(2).Text
            table.Rows.Item(i).Item("DataColumn4") = Main.ListView1.Items(i).SubItems(3).Text
            table.Rows.Item(i).Item("DataColumn5") = Main.ListView1.Items(i).SubItems(4).Text
            table.Rows.Item(i).Item("DataColumn6") = Main.ListView1.Items(i).SubItems(5).Text
        Next i

        Dim params As ReportParameter() = New ReportParameter(23) {}
        params(0) = New ReportParameter("furnizor_denumire", Main.TextBox1.Text)
        params(1) = New ReportParameter("furnizor_RC", Main.TextBox2.Text)
        params(2) = New ReportParameter("furnizor_CF", Main.TextBox3.Text)
        params(3) = New ReportParameter("furnizor_capital", Main.TextBox4.Text)
        params(4) = New ReportParameter("furnizor_sediu", Main.TextBox5.Text)
        params(5) = New ReportParameter("furnizor_judet", Main.TextBox6.Text)
        params(6) = New ReportParameter("furnizor_cont", Main.TextBox7.Text)
        params(7) = New ReportParameter("furnizor_banca", Main.TextBox8.Text)
        params(8) = New ReportParameter("client_denumire", Main.TextBox20.Text)
        params(9) = New ReportParameter("client_RC", Main.TextBox9.Text)
        params(10) = New ReportParameter("client_CF", Main.TextBox10.Text)
        params(11) = New ReportParameter("client_sediu", Main.TextBox11.Text)
        params(12) = New ReportParameter("client_judet", Main.TextBox12.Text)
        params(13) = New ReportParameter("client_cont", Main.TextBox13.Text)
        params(14) = New ReportParameter("client_banca", Main.TextBox14.Text)
        If Form3.CheckBox2.Checked = True Then
            params(15) = New ReportParameter("aviz_numar", Main.TextBox15.Text)
        Else
            params(15) = New ReportParameter("aviz_numar", "")
        End If
        If Form3.CheckBox3.Checked = True Then
            params(16) = New ReportParameter("aviz_data", Main.DateTimePicker1.Value.ToString("dd MMMM yyyy"))
        Else
            params(16) = New ReportParameter("aviz_data", "")
        End If
        If Form3.CheckBox4.Checked = True Then
            params(17) = New ReportParameter("aviz_data2", Main.DateTimePicker1.Value.ToString("dd MMMM yyyy"))
        Else
            params(17) = New ReportParameter("aviz_data2", "")
        End If
        params(18) = New ReportParameter("delegat_nume", Main.TextBox21.Text)
        params(19) = New ReportParameter("delegat_BI_CI", Main.TextBox16.Text)
        params(20) = New ReportParameter("delegat_BI_CI_eliberat", Main.TextBox17.Text)
        params(21) = New ReportParameter("delegat_transport", Main.TextBox18.Text)
        params(22) = New ReportParameter("aviz_copyright", "Comenzi program facturare => E-mail: laurentiufd@yahoo.com")
        params(23) = New ReportParameter("total_plata", Main.TextBox22.Text)
        Form2.ReportViewer1.LocalReport.SetParameters(params)
    End Sub

    Public Shared Sub Settings(ByVal save As Boolean)

        If save = True Then
            Dim Writer As XmlTextWriter
            Writer = New XmlTextWriter(Application.StartupPath & "\Settings.xml", Nothing)
            Writer.WriteStartDocument()
            Writer.WriteStartElement("Settings")
            Writer.WriteStartElement("Firma")
            Writer.WriteStartElement("Nume")
            Writer.WriteString(Form3.TextBox1.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("RC")
            Writer.WriteString(Form3.TextBox2.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("CF")
            Writer.WriteString(Form3.TextBox3.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("Capital")
            Writer.WriteString(Form3.TextBox4.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("Sediu")
            Writer.WriteString(Form3.TextBox5.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("Judet")
            Writer.WriteString(Form3.ComboBox1.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("Cont")
            Writer.WriteString(Form3.TextBox6.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("Banca")
            Writer.WriteString(Form3.TextBox7.Text)
            Writer.WriteEndElement()
            Writer.WriteEndElement()
            Writer.WriteStartElement("Client")
            Writer.WriteStartElement("Nume")
            Writer.WriteString(Form3.TextBox14.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("RC")
            Writer.WriteString(Form3.TextBox13.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("CF")
            Writer.WriteString(Form3.TextBox12.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("Sediu")
            Writer.WriteString(Form3.TextBox10.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("Judet")
            Writer.WriteString(Form3.ComboBox2.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("Cont")
            Writer.WriteString(Form3.TextBox9.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("Banca")
            Writer.WriteString(Form3.TextBox8.Text)
            Writer.WriteEndElement()
            Writer.WriteEndElement()
            Writer.WriteStartElement("Delegat")
            Writer.WriteStartElement("Nume")
            Writer.WriteString(Form3.TextBox17.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("BICI")
            Writer.WriteString(Form3.TextBox16.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("Eliberat")
            Writer.WriteString(Form3.TextBox15.Text)
            Writer.WriteEndElement()
            Writer.WriteStartElement("Transport")
            Writer.WriteString(Form3.TextBox11.Text)
            Writer.WriteEndElement()
            Writer.WriteEndElement()
            Writer.WriteStartElement("Settings")
            Writer.WriteStartElement("PNumar")
            Writer.WriteString(System.Convert.ToBoolean(Form3.CheckBox2.CheckState))
            Writer.WriteEndElement()
            Writer.WriteStartElement("PDataEiberare")
            Writer.WriteString(System.Convert.ToBoolean(Form3.CheckBox3.CheckState))
            Writer.WriteEndElement()
            Writer.WriteStartElement("PDataExpeditie")
            Writer.WriteString(System.Convert.ToBoolean(Form3.CheckBox4.CheckState))
            Writer.WriteEndElement()
            Writer.WriteEndElement()
            Writer.WriteEndElement()
            Writer.WriteEndDocument()
            Writer.Close()
        Else
            Try
                Dim Node As XmlNode
                Dim NList As XmlNodeList
                Dim Doc As XmlDocument = New XmlDocument()
                Doc.Load(Application.StartupPath & "\Settings.xml")
                NList = Doc.SelectNodes("/Settings/Firma")
                For Each Node In NList
                    Form3.TextBox1.Text = Node.ChildNodes.Item(0).InnerText
                    Form3.TextBox2.Text = Node.ChildNodes.Item(1).InnerText
                    Form3.TextBox3.Text = Node.ChildNodes.Item(2).InnerText
                    Form3.TextBox4.Text = Node.ChildNodes.Item(3).InnerText
                    Form3.TextBox5.Text = Node.ChildNodes.Item(4).InnerText
                    Form3.ComboBox1.Text = Node.ChildNodes.Item(5).InnerText
                    Form3.TextBox6.Text = Node.ChildNodes.Item(6).InnerText
                    Form3.TextBox7.Text = Node.ChildNodes.Item(7).InnerText
                Next
                NList = Doc.SelectNodes("/Settings/Client")
                For Each Node In NList
                    Form3.TextBox14.Text = Node.ChildNodes.Item(0).InnerText
                    Form3.TextBox13.Text = Node.ChildNodes.Item(1).InnerText
                    Form3.TextBox12.Text = Node.ChildNodes.Item(2).InnerText
                    Form3.TextBox10.Text = Node.ChildNodes.Item(3).InnerText
                    Form3.ComboBox2.Text = Node.ChildNodes.Item(4).InnerText
                    Form3.TextBox9.Text = Node.ChildNodes.Item(5).InnerText
                    Form3.TextBox8.Text = Node.ChildNodes.Item(6).InnerText
                Next
                NList = Doc.SelectNodes("/Settings/Delegat")
                For Each Node In NList
                    Form3.TextBox17.Text = Node.ChildNodes.Item(0).InnerText
                    Form3.TextBox16.Text = Node.ChildNodes.Item(1).InnerText
                    Form3.TextBox15.Text = Node.ChildNodes.Item(2).InnerText
                    Form3.TextBox11.Text = Node.ChildNodes.Item(3).InnerText
                Next
                NList = Doc.SelectNodes("/Settings/Settings")
                For Each Node In NList
                    Form3.CheckBox2.Checked = Node.ChildNodes.Item(0).InnerText
                    Form3.CheckBox3.Checked = Node.ChildNodes.Item(1).InnerText
                    Form3.CheckBox4.Checked = Node.ChildNodes.Item(2).InnerText
                Next
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
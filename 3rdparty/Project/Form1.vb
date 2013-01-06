Public Class Form1
    Dim snd_string As String
    Dim last_snd_string As String
    Dim data_arr(4) As String
    Dim data_add(3) As String
    Dim snd_c As Integer
    Dim s As String
    Dim s_buf As String
    Dim chksumnow As Boolean
    Dim chksumbyte_saved As Boolean
    Dim chksumbyte As String
    Dim sbuf_max As Integer
    Dim chart_name As String

    Private Sub Form1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        com1.Close()
        End

    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a() As String
        Dim x As String


        a = IO.Ports.SerialPort.GetPortNames()
        For Each x In a
            ComboBox1.Items.Add(x)
        Next

        ComboBox1.Sorted = True
        ComboBox1.SelectedIndex = 0

       

        sensors_arr.SelectedIndex = 0

        


        ' 

        '   grid.RowCount = grid.RowCount + 1
        ''   grid.Rows(grid.RowCount - 1).Cells(0).Value = "2"



    End Sub
   
    Private Sub com1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles com1.DataReceived
        TextBox1.Invoke(New myDelegate(AddressOf DataReceived), New Object() {})
        '  MessageBox.Show(com1.ReadExisting())
        '   UPdateTextBox()
     
    End Sub
    Public Delegate Sub myDelegate()

    Public Sub DataReceived()
        On Error Resume Next
        sbuf_max = 20
        If Len(s_buf) > sbuf_max Then s_buf = ""

        total_bytes.Text = Val(total_bytes.Text) + 1
        ' Dim data As String
        Dim row_id, strp, endp As Integer

        '  Dim strpos1, strpos2 As Integer
        ' Dim chk_sum_chr As String

        '   Try

        s = com1.ReadLine
        If s <> "" Then
            If trace.Checked = True Then

                TextBox1.AppendText(s)
            End If


            '  strpos1 = InStr(s, ".")
            '  strpos2 = InStr(s, ",")
            '  If strpos1 > 0 And strpos2 > 0 Then
            '     TextBox1.AppendText(vbNewLine & "RV: " & Mid(s, strpos1 + 1, (strpos1 - strpos2 + 1)))

            '   Else
            strp = InStr(s, ":") + 1
            endp = InStr(s, ";")

            If strp > 0 And endp > 0 And (endp - strp) > 0 And Len(s) >= (endp + 1) Then
                s_buf = Mid(s, strp, endp - strp)
                chksumbyte = 0
                chksumbyte = Mid(s, endp + 1, 1)

                If check_sum(s_buf) = Asc(chksumbyte) Then
                    TextBox1.AppendText(vbNewLine & "Recv:" & s_buf & vbNewLine)


                    If IsNumeric(Mid(s_buf, 1, 1)) Then
                        '----- update grid -------'
                        data_add = Split(s_buf, "%")

                        '   data_add(0) = Rnd()

                        row_id = get_row_by_text(data_add(0))
                        If row_id = -1 Then
                            grid.RowCount = grid.RowCount + 1
                            grid.Rows(grid.RowCount - 1).Cells(0).Value = data_add(0)
                            row_id = grid.RowCount - 1

                        End If


                        data_arr = Split(data_add(1), "-")
                        grid.Rows(row_id).Cells(1).Value = data_arr(0)
                        grid.Rows(row_id).Cells(2).Value = data_arr(1)
                        grid.Rows(row_id).Cells(3).Value = Date.Now()


                        '------- end grid update ----------'


                        '------- chart update -------------'
                        chart_name = sensors_arr.SelectedItem & " - " & grid.Rows(row_id).Cells(0).Value

                        If Chart1.Series.IndexOf(chart_name) = -1 Then
                            Chart1.Series.Add(chart_name)
                            Chart1.Series(chart_name).ChartType = DataVisualization.Charting.SeriesChartType.Line
                            '   Chart1.Series(chart_name).MarkerBorderWidth = 10
                        End If

                        Chart1.Series(chart_name).Points.AddXY(TimeOfDay.Hour & ":" & TimeOfDay.Minute & ":" & TimeOfDay.Second, grid.Rows(row_id).Cells(sensors_arr.SelectedIndex + 1).Value)
                        '---------------------------------'

                        rf_num.Text = Val(rf_num.Text) + 1
                        rf_success.Text = Val(rf_success.Text) + 1

                    End If
                Else
                    TextBox1.AppendText(vbNewLine & "WRNG:" & s_buf & "(" & check_sum(s_buf) & " | " & Asc(chksumbyte) & ")" & vbNewLine)
                    rf_num.Text = Val(rf_num.Text) + 1
                End If




                If Val(rf_num.Text) >= 10 Then
                    rf_signal.Text = Int((Val(rf_success.Text) / 10) * 100)

                    If Val(rf_signal.Text) < 25 Then
                        rf_signal.ForeColor = Color.Red
                    ElseIf Val(rf_signal.Text) < 70 Then
                        rf_signal.ForeColor = Color.DarkGoldenrod

                    Else
                        rf_signal.ForeColor = Color.Green
                    End If


                    rf_signal.Text &= "%"
                    rf_num.Text = "0"
                    rf_success.Text = "0"

                End If
            End If
        End If

        '    TextBox1.AppendText(Chr(s))
        '     End If
        ' End If
        ' End If
        '  End If


        ' Catch
        '   MessageBox.Show(Err.Description)

        ' End Try
    End Sub
    Function get_row_by_text(ByVal txt As String) As Integer
        Dim row_id As Integer
        row_id = -1
        For i = 0 To grid.RowCount - 1
            If grid.Rows(i).Cells(0).Value = txt Then
                row_id = i
                Exit For

            End If

        Next
        Return row_id
    End Function
    Function check_sum(ByVal s As String)
        Dim x As Integer
        x = 0
        For i = 1 To Len(s)
            x = x + Asc(Mid(s, i, 1))
            If (x > 100) Then x = x Mod 100
            ' TextBox1.AppendText("|" & Mid(s, i, 1) & " : " & Asc(Mid(s, i, 1)) & "|")
        Next
        Return x
    End Function
  
    

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            com1.PortName = ComboBox1.SelectedItem
            com1.Open()

            TextBox1.AppendText(vbNewLine & "---  " & ComboBox1.SelectedItem & " Opened , Waiting Nodes Signal  ----" & vbNewLine & vbNewLine)

            Button2.Enabled = False
            Button3.Enabled = True
        Catch
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        com1.Close()
        TextBox1.AppendText(vbNewLine & "---  " & ComboBox1.SelectedItem & " Closed ... ----" & vbNewLine)
        Button2.Enabled = True
        Button3.Enabled = False


    End Sub

   

    Private Sub sensors_arr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sensors_arr.SelectedIndexChanged
        Chart1.Series.Clear()

    End Sub

    
End Class

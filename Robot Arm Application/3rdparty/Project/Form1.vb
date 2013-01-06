Public Class Form1
    Dim last_tx As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a() As String
        Dim x As String
        a = IO.Ports.SerialPort.GetPortNames()
        For Each x In a
            ComboBox1.Items.Add(x)
        Next

        ComboBox1.Sorted = True
        ComboBox1.SelectedIndex = 0

      
        m1.Text = 90
        m2.Text = 45
        m3.Text = 0
        m4.Text = 0

    End Sub
   
    Private Sub com1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles com1.DataReceived
        TextBox1.Invoke(New myDelegate(AddressOf UPdateTextBox), New Object() {})
        '  MessageBox.Show(com1.ReadExisting())
    End Sub
    Public Delegate Sub myDelegate()

    Public Sub UPdateTextBox()

        With TextBox1

            .AppendText(com1.ReadExisting)

        End With

    End Sub
    Function check_sum(ByVal s As String)
        Dim x As Integer
        x = 0
        For i = 1 To Len(s)
            x = x + Asc(Mid(s, i, 1))
            If (x > 100) Then x = x Mod 100
        Next
        Return x
    End Function
    Sub com_send(ByVal text As String)
        Dim checksum_value As Integer
        Dim checksum_chr As String
        If com1.IsOpen Then


            checksum_value = check_sum(text)
            checksum_chr = Chr(checksum_value)

            '  MessageBox.Show(checksum_value)
            com1.Write("|||." & text & "," & checksum_chr)

            TextBox1.AppendText(vbNewLine & "Send : " & text)
            TextBox2.Text = ""
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        last_tx = TextBox2.Text
        com_send(TextBox2.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        com1.PortName = ComboBox1.SelectedItem
        Try
            com1.Open()
            com1.DtrEnable = True

            TextBox1.Text = TextBox1.Text & vbNewLine & "---  " & ComboBox1.SelectedItem & " Opened ... ----"
            Button2.Enabled = False
            Button3.Enabled = True
            Button1.Enabled = True
            Button4.Enabled = True
        Catch
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        com1.Close()
        TextBox1.Text = TextBox1.Text & vbNewLine & "---  " & ComboBox1.SelectedItem & " Closed ... ----"
        Button2.Enabled = True
        Button3.Enabled = False
        Button1.Enabled = False
        Button4.Enabled = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        last_tx = "XX-" & m1.Text & "-" & m2.Text & "-" & m3.Text & "-" & m4.Text
        com_send(last_tx)
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll, TrackBar2.Scroll, TrackBar3.Scroll, TrackBar4.Scroll
        m1.Text = TrackBar1.Value
        m2.Text = TrackBar2.Value
        m3.Text = TrackBar3.Value
        m4.Text = TrackBar4.Value

        picCanvas.Invalidate()
    End Sub
    Private Sub m3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m1.TextChanged, m2.TextChanged, m3.TextChanged, m4.TextChanged
        Try
            TrackBar1.Value = Val(m1.Text)
            TrackBar2.Value = Val(m2.Text)
            TrackBar3.Value = Val(m3.Text)
            TrackBar4.Value = Val(m4.Text)

            picCanvas.Invalidate()
        Catch
            m1.Text = TrackBar1.Value
            m2.Text = TrackBar2.Value
            m3.Text = TrackBar3.Value
            m4.Text = TrackBar4.Value
        End Try

    End Sub

    Private Sub picCanvas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picCanvas.Paint
        Const ARM_LENGTH_1 As Integer = 40
        Const ARM_LENGTH_2 As Integer = 40
        Const ARM_LENGTH_3 As Integer = 40

        e.Graphics.Clear(Me.BackColor)

        Dim cx As Double = picCanvas.ClientSize.Width / 2
        Dim cy As Double = picCanvas.ClientSize.Height / 2

        ' Make sure we start from scratch.
        e.Graphics.ResetTransform()

        ' For each stage in the arm, draw and then *prepend* the
        ' new transformation to represent the next arm in the sequence.

        ' Translate to center of form.
        e.Graphics.TranslateTransform(cx, cy)

        ' Draw the shoulder centered at the origin.
        e.Graphics.DrawEllipse(Pens.Red, -4, -4, 9, 9)

        ' Rotate at the shoulder.
        ' (Negative to make the angle increase counter-clockwise).
        e.Graphics.RotateTransform(-TrackBar1.Value, Drawing2D.MatrixOrder.Prepend)

        ' Draw the first arm.
        e.Graphics.DrawRectangle(Pens.Blue, 0, -1, ARM_LENGTH_1, 3)

        ' Translate to the end of the first arm.
        e.Graphics.TranslateTransform(ARM_LENGTH_1, 0, Drawing2D.MatrixOrder.Prepend)

        ' Draw the elbow.
        e.Graphics.DrawEllipse(Pens.Red, -4, -4, 9, 9)

        ' Rotate at the elbow.
        e.Graphics.RotateTransform(TrackBar2.Value - 90, Drawing2D.MatrixOrder.Prepend)

        ' Draw the second arm.
        e.Graphics.DrawRectangle(Pens.Blue, 0, -1, ARM_LENGTH_2, 3)

        ' Translate to the end of the second arm.
        e.Graphics.TranslateTransform(ARM_LENGTH_2, 0, Drawing2D.MatrixOrder.Prepend)

        ' Draw the wrist.
        e.Graphics.DrawEllipse(Pens.Red, -4, -4, 9, 9)

        ' Rotate at the wrist.
        e.Graphics.RotateTransform(TrackBar3.Value - 90, Drawing2D.MatrixOrder.Prepend)

        ' Draw the third arm.
        e.Graphics.DrawRectangle(Pens.Blue, 0, -1, ARM_LENGTH_3, 3)
    End Sub

    Private Sub picCanvas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCanvas.Click

    End Sub

   

   
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If last_tx <> "" Then
            com_send(last_tx)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class

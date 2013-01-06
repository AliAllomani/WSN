<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.com1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.total_bytes = New System.Windows.Forms.TextBox()
        Me.trace = New System.Windows.Forms.CheckBox()
        Me.rf_success = New System.Windows.Forms.TextBox()
        Me.rf_num = New System.Windows.Forms.TextBox()
        Me.rf_signal = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.sensors_arr = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gcar_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gs1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gs2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.last_update = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'com1
        '
        Me.com1.BaudRate = 1200
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(11, 19)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(261, 130)
        Me.TextBox1.TabIndex = 0
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(28, 16)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(91, 21)
        Me.ComboBox1.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(125, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(58, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Open"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(196, 16)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(59, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Close"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(261, 44)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Connection"
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gcar_id, Me.gs1, Me.gs2, Me.last_update})
        Me.grid.Location = New System.Drawing.Point(12, 62)
        Me.grid.Name = "grid"
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid.Size = New System.Drawing.Size(507, 142)
        Me.grid.TabIndex = 27
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Controls.Add(Me.total_bytes)
        Me.GroupBox3.Controls.Add(Me.trace)
        Me.GroupBox3.Controls.Add(Me.rf_success)
        Me.GroupBox3.Controls.Add(Me.rf_num)
        Me.GroupBox3.Location = New System.Drawing.Point(525, 21)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(276, 183)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Debug"
        '
        'total_bytes
        '
        Me.total_bytes.Location = New System.Drawing.Point(93, 155)
        Me.total_bytes.Name = "total_bytes"
        Me.total_bytes.Size = New System.Drawing.Size(68, 20)
        Me.total_bytes.TabIndex = 36
        '
        'trace
        '
        Me.trace.AutoSize = True
        Me.trace.Location = New System.Drawing.Point(11, 155)
        Me.trace.Name = "trace"
        Me.trace.Size = New System.Drawing.Size(53, 17)
        Me.trace.TabIndex = 37
        Me.trace.Text = "Trace"
        Me.trace.UseVisualStyleBackColor = True
        '
        'rf_success
        '
        Me.rf_success.Location = New System.Drawing.Point(201, 155)
        Me.rf_success.Name = "rf_success"
        Me.rf_success.Size = New System.Drawing.Size(31, 20)
        Me.rf_success.TabIndex = 31
        Me.rf_success.Text = "0"
        '
        'rf_num
        '
        Me.rf_num.Location = New System.Drawing.Point(164, 155)
        Me.rf_num.Name = "rf_num"
        Me.rf_num.Size = New System.Drawing.Size(31, 20)
        Me.rf_num.TabIndex = 30
        Me.rf_num.Text = "0"
        '
        'rf_signal
        '
        Me.rf_signal.AutoSize = True
        Me.rf_signal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rf_signal.ForeColor = System.Drawing.Color.Navy
        Me.rf_signal.Location = New System.Drawing.Point(38, 14)
        Me.rf_signal.Name = "rf_signal"
        Me.rf_signal.Size = New System.Drawing.Size(30, 19)
        Me.rf_signal.TabIndex = 32
        Me.rf_signal.Text = "---"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rf_signal)
        Me.GroupBox6.Location = New System.Drawing.Point(404, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(115, 44)
        Me.GroupBox6.TabIndex = 33
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Signal"
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.SystemColors.Control
        Me.Chart1.BorderlineColor = System.Drawing.Color.Silver
        Me.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        Me.Chart1.BorderSkin.BorderColor = System.Drawing.Color.Gainsboro
        ChartArea1.BorderColor = System.Drawing.Color.Gainsboro
        ChartArea1.Name = "ChartArea1"
        ChartArea1.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.ItemColumnSeparatorColor = System.Drawing.Color.Silver
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(6, 46)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(769, 197)
        Me.Chart1.TabIndex = 34
        Me.Chart1.Text = "Chart1"
        '
        'sensors_arr
        '
        Me.sensors_arr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sensors_arr.FormattingEnabled = True
        Me.sensors_arr.Items.AddRange(New Object() {"Temperature", "Light"})
        Me.sensors_arr.Location = New System.Drawing.Point(25, 19)
        Me.sensors_arr.Name = "sensors_arr"
        Me.sensors_arr.Size = New System.Drawing.Size(121, 21)
        Me.sensors_arr.TabIndex = 35
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.sensors_arr)
        Me.GroupBox1.Controls.Add(Me.Chart1)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 220)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(781, 253)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Chart"
        '
        'gcar_id
        '
        Me.gcar_id.HeaderText = "Node ID"
        Me.gcar_id.Name = "gcar_id"
        Me.gcar_id.ReadOnly = True
        Me.gcar_id.Width = 75
        '
        'gs1
        '
        Me.gs1.HeaderText = "Temperature"
        Me.gs1.Name = "gs1"
        Me.gs1.ReadOnly = True
        Me.gs1.Width = 80
        '
        'gs2
        '
        Me.gs2.HeaderText = "Light"
        Me.gs2.Name = "gs2"
        Me.gs2.ReadOnly = True
        Me.gs2.Width = 60
        '
        'last_update
        '
        Me.last_update.HeaderText = "Last Update"
        Me.last_update.Name = "last_update"
        Me.last_update.Width = 200
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 475)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "Form1"
        Me.Text = "WSN Project (O6U 2010)"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Public WithEvents TextBox1 As System.Windows.Forms.TextBox
    Public WithEvents com1 As System.IO.Ports.SerialPort
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rf_num As System.Windows.Forms.TextBox
    Friend WithEvents rf_success As System.Windows.Forms.TextBox
    Friend WithEvents rf_signal As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents total_bytes As System.Windows.Forms.TextBox
    Friend WithEvents trace As System.Windows.Forms.CheckBox
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents sensors_arr As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gcar_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gs1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gs2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents last_update As System.Windows.Forms.DataGridViewTextBoxColumn

End Class

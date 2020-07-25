<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogForm
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
        Me.listLog = New System.Windows.Forms.ListBox()
        Me.Button_Close = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'listLog
        '
        Me.listLog.FormattingEnabled = True
        Me.listLog.Location = New System.Drawing.Point(59, 12)
        Me.listLog.Name = "listLog"
        Me.listLog.Size = New System.Drawing.Size(304, 199)
        Me.listLog.TabIndex = 1
        '
        'Button_Close
        '
        Me.Button_Close.Location = New System.Drawing.Point(172, 231)
        Me.Button_Close.Name = "Button_Close"
        Me.Button_Close.Size = New System.Drawing.Size(75, 23)
        Me.Button_Close.TabIndex = 2
        Me.Button_Close.Text = "Close"
        Me.Button_Close.UseVisualStyleBackColor = True
        '
        'LogForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 266)
        Me.Controls.Add(Me.Button_Close)
        Me.Controls.Add(Me.listLog)
        Me.Name = "LogForm"
        Me.Text = "LogForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents listLog As ListBox
    Friend WithEvents Button_Close As Button
End Class

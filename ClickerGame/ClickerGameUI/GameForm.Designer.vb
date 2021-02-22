<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameForm
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
        Me.ButtonClick = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelAmountMoney = New System.Windows.Forms.Label()
        Me.LabelBuilding2DPT = New System.Windows.Forms.Label()
        Me.LabelBuilding2Cost = New System.Windows.Forms.Label()
        Me.ButtonBuilding2 = New System.Windows.Forms.Button()
        Me.LabelBuilding1DPT = New System.Windows.Forms.Label()
        Me.LabelBuilding1Cost = New System.Windows.Forms.Label()
        Me.ButtonBuilding1 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonClick
        '
        Me.ButtonClick.Location = New System.Drawing.Point(449, 125)
        Me.ButtonClick.Name = "ButtonClick"
        Me.ButtonClick.Size = New System.Drawing.Size(68, 37)
        Me.ButtonClick.TabIndex = 0
        Me.ButtonClick.Text = "Click"
        Me.ButtonClick.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonBuilding1)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelBuilding1Cost)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelBuilding1DPT)
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonBuilding2)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelBuilding2Cost)
        Me.FlowLayoutPanel1.Controls.Add(Me.LabelBuilding2DPT)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(2, 6)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(254, 515)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'LabelAmountMoney
        '
        Me.LabelAmountMoney.AutoSize = True
        Me.LabelAmountMoney.Location = New System.Drawing.Point(446, 14)
        Me.LabelAmountMoney.Name = "LabelAmountMoney"
        Me.LabelAmountMoney.Size = New System.Drawing.Size(13, 13)
        Me.LabelAmountMoney.TabIndex = 2
        Me.LabelAmountMoney.Text = "$"
        '
        'LabelBuilding2DPT
        '
        Me.LabelBuilding2DPT.AutoSize = True
        Me.LabelBuilding2DPT.Location = New System.Drawing.Point(161, 29)
        Me.LabelBuilding2DPT.Name = "LabelBuilding2DPT"
        Me.LabelBuilding2DPT.Size = New System.Drawing.Size(72, 13)
        Me.LabelBuilding2DPT.TabIndex = 5
        Me.LabelBuilding2DPT.Text = "Building2DPT"
        '
        'LabelBuilding2Cost
        '
        Me.LabelBuilding2Cost.AutoSize = True
        Me.LabelBuilding2Cost.Location = New System.Drawing.Point(84, 29)
        Me.LabelBuilding2Cost.Name = "LabelBuilding2Cost"
        Me.LabelBuilding2Cost.Size = New System.Drawing.Size(71, 13)
        Me.LabelBuilding2Cost.TabIndex = 7
        Me.LabelBuilding2Cost.Text = "Building2Cost"
        '
        'ButtonBuilding2
        '
        Me.ButtonBuilding2.Location = New System.Drawing.Point(3, 32)
        Me.ButtonBuilding2.Name = "ButtonBuilding2"
        Me.ButtonBuilding2.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuilding2.TabIndex = 4
        Me.ButtonBuilding2.Text = "Building2"
        Me.ButtonBuilding2.UseVisualStyleBackColor = True
        '
        'LabelBuilding1DPT
        '
        Me.LabelBuilding1DPT.AutoSize = True
        Me.LabelBuilding1DPT.Location = New System.Drawing.Point(161, 0)
        Me.LabelBuilding1DPT.Name = "LabelBuilding1DPT"
        Me.LabelBuilding1DPT.Size = New System.Drawing.Size(72, 13)
        Me.LabelBuilding1DPT.TabIndex = 3
        Me.LabelBuilding1DPT.Text = "Building1DPT"
        '
        'LabelBuilding1Cost
        '
        Me.LabelBuilding1Cost.AutoSize = True
        Me.LabelBuilding1Cost.Location = New System.Drawing.Point(84, 0)
        Me.LabelBuilding1Cost.Name = "LabelBuilding1Cost"
        Me.LabelBuilding1Cost.Size = New System.Drawing.Size(71, 13)
        Me.LabelBuilding1Cost.TabIndex = 6
        Me.LabelBuilding1Cost.Text = "Building1Cost"
        '
        'ButtonBuilding1
        '
        Me.ButtonBuilding1.Location = New System.Drawing.Point(3, 3)
        Me.ButtonBuilding1.Name = "ButtonBuilding1"
        Me.ButtonBuilding1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBuilding1.TabIndex = 0
        Me.ButtonBuilding1.Text = "Building1"
        Me.ButtonBuilding1.UseVisualStyleBackColor = True
        '
        'GameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 524)
        Me.Controls.Add(Me.LabelAmountMoney)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.ButtonClick)
        Me.Name = "GameForm"
        Me.Text = "ClickerGame"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonClick As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents LabelAmountMoney As Label
    Friend WithEvents ButtonBuilding1 As Button
    Friend WithEvents LabelBuilding1Cost As Label
    Friend WithEvents LabelBuilding1DPT As Label
    Friend WithEvents ButtonBuilding2 As Button
    Friend WithEvents LabelBuilding2Cost As Label
    Friend WithEvents LabelBuilding2DPT As Label
End Class

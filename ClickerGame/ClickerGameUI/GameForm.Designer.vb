<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GameForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ButtonClick = New System.Windows.Forms.Button()
        Me.LayoutPanelBuildings = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelAmountMoney = New System.Windows.Forms.Label()
        Me.ButtonSaveGame = New System.Windows.Forms.Button()
        Me.ButtonLoadGame = New System.Windows.Forms.Button()
        Me.LayoutPanelUpgrades = New System.Windows.Forms.FlowLayoutPanel()
        Me.LabelBuildings = New System.Windows.Forms.Label()
        Me.LabelUpgrades = New System.Windows.Forms.Label()
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
        'LayoutPanelBuildings
        '
        Me.LayoutPanelBuildings.Location = New System.Drawing.Point(2, 34)
        Me.LayoutPanelBuildings.Name = "LayoutPanelBuildings"
        Me.LayoutPanelBuildings.Size = New System.Drawing.Size(254, 487)
        Me.LayoutPanelBuildings.TabIndex = 1
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
        'ButtonSaveGame
        '
        Me.ButtonSaveGame.Location = New System.Drawing.Point(312, 462)
        Me.ButtonSaveGame.Name = "ButtonSaveGame"
        Me.ButtonSaveGame.Size = New System.Drawing.Size(68, 37)
        Me.ButtonSaveGame.TabIndex = 3
        Me.ButtonSaveGame.Text = "Save Game"
        Me.ButtonSaveGame.UseVisualStyleBackColor = True
        '
        'ButtonLoadGame
        '
        Me.ButtonLoadGame.Location = New System.Drawing.Point(554, 462)
        Me.ButtonLoadGame.Name = "ButtonLoadGame"
        Me.ButtonLoadGame.Size = New System.Drawing.Size(68, 37)
        Me.ButtonLoadGame.TabIndex = 4
        Me.ButtonLoadGame.Text = "Load Game"
        Me.ButtonLoadGame.UseVisualStyleBackColor = True
        '
        'LayoutPanelUpgrades
        '
        Me.LayoutPanelUpgrades.Location = New System.Drawing.Point(730, 34)
        Me.LayoutPanelUpgrades.Name = "LayoutPanelUpgrades"
        Me.LayoutPanelUpgrades.Size = New System.Drawing.Size(254, 487)
        Me.LayoutPanelUpgrades.TabIndex = 5
        '
        'LabelBuildings
        '
        Me.LabelBuildings.AutoSize = True
        Me.LabelBuildings.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBuildings.Location = New System.Drawing.Point(48, 6)
        Me.LabelBuildings.Name = "LabelBuildings"
        Me.LabelBuildings.Size = New System.Drawing.Size(96, 24)
        Me.LabelBuildings.TabIndex = 6
        Me.LabelBuildings.Text = "Buildings"
        '
        'LabelUpgrades
        '
        Me.LabelUpgrades.AutoSize = True
        Me.LabelUpgrades.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUpgrades.Location = New System.Drawing.Point(836, 6)
        Me.LabelUpgrades.Name = "LabelUpgrades"
        Me.LabelUpgrades.Size = New System.Drawing.Size(100, 24)
        Me.LabelUpgrades.TabIndex = 7
        Me.LabelUpgrades.Text = "Upgrades"
        '
        'GameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 524)
        Me.Controls.Add(Me.LabelUpgrades)
        Me.Controls.Add(Me.LabelBuildings)
        Me.Controls.Add(Me.LayoutPanelUpgrades)
        Me.Controls.Add(Me.ButtonLoadGame)
        Me.Controls.Add(Me.ButtonSaveGame)
        Me.Controls.Add(Me.LabelAmountMoney)
        Me.Controls.Add(Me.LayoutPanelBuildings)
        Me.Controls.Add(Me.ButtonClick)
        Me.Name = "GameForm"
        Me.Text = "ClickerGame"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonClick As Button
    Friend WithEvents LayoutPanelBuildings As FlowLayoutPanel
    Friend WithEvents LabelAmountMoney As Label
    Friend WithEvents ButtonSaveGame As Button
    Friend WithEvents ButtonLoadGame As Button
    Friend WithEvents LayoutPanelUpgrades As FlowLayoutPanel
    Friend WithEvents LabelBuildings As Label
    Friend WithEvents LabelUpgrades As Label
End Class

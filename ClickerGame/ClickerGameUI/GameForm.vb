Imports ClickerGameLogic

Public Class GameForm
    Private Const COST_TAG = "Cost"
    Private Const DPT_TAG = "DPT"

    Private _refreshTime As Integer
    ''' <summary>
    ''' Use to keep track of which building events are being created
    ''' </summary>
    Private _currentBuildingIndex As Integer = 0
    Private _buildingNames As New List(Of String)
    Private _currentUpgradeIndex As Integer = 0
    Private _upgradeNames As New List(Of String)


    'DO NOT USE A CONSTRUCTOR, or UI breaks
    'Sub New()
    'End Sub

    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _refreshTime = 100

            GenerateBuildings()
            StartGame()

            RunAndAwait(AddressOf RefreshUI, _refreshTime)
        Catch ex As Exception
            DisplayError(ex)
        End Try

    End Sub

    Private Sub ButtonClick_Click(sender As Object, e As EventArgs) Handles ButtonClick.Click
        Try
            EventClickButton()
        Catch ex As Exception
            DisplayError(ex)
        End Try
    End Sub

    Private Function ButtonBuilding_Click(sender As Object, e As EventArgs) As Boolean
        Try
            Dim currentBuilding As MyButton = DirectCast(sender, MyButton)
            EventClickBuilding(currentBuilding.ID)
        Catch ex As Exception
            DisplayError(ex)
        End Try

        'handler function requires return
        Return True
    End Function

    Public Sub RefreshUI()
        LabelAmountMoney.Text = GetCurrentDollars().ToString("C")

        'Gets list of controls
        'Dim controlsList As IEnumerator = Me.Controls.GetEnumerator()
        'Todo: add Loggign from Encryption tool here
        For Each control In LayoutPanelBuildings.Controls
            Select Case control.GetType
                Case GetType(MyLabel)
                    If control.Type = COST_TAG Then
                        control.Text = GetBuildingCost(control.ID).ToString("C")
                    ElseIf control.Type = DPT_TAG Then
                        control.Text = GetBuildingDPT(control.ID).ToString("C") & "/tick"
                    Else
                        Throw New Exception("Proper control tag is missing from the label")
                    End If
                Case Else
                    Continue For
            End Select
        Next

    End Sub

    ''' <summary>
    ''' Dynamically creates buildings and adds the appropriate UI elements to the UI
    ''' </summary>
    Public Sub GenerateBuildings()
        Dim xLoc As Integer = 3
        Dim yLoc As Integer = 3
        _currentBuildingIndex = 0

        _buildingNames = ReturnBuildingNames()

        If _buildingNames.Count < 1 Then
            Throw New Exception("There are no buildings to create")
        End If

        For Each buildingName In _buildingNames

            Dim newUpgradeButton As New MyButton
            With newUpgradeButton
                .Name = "button" & buildingName
                .Text = buildingName
                .Size = New Size(75, 23)
                '.Location = New Point(xLoc, yLoc)
                .ID = _currentBuildingIndex
            End With

            AddHandler newUpgradeButton.Click, AddressOf ButtonBuilding_Click
            'AddHandler newUpgradeButton.Click, Function(sender, e) ButtonBuilding_Click(_currentBuildingIndex)

            Dim newBuildingCostLabel As New MyLabel
            With newBuildingCostLabel
                .Name = "labelCost" & buildingName
                .Text = ""
                .Size = New Size(71, 13)
                '.Location = New Point(xLoc + 81, yLoc - 3) 'next column
                .Type = COST_TAG
                .ID = _currentBuildingIndex
            End With

            Dim newBuildingDPTLabel As New MyLabel
            With newBuildingDPTLabel
                .Name = "labelDPT" & buildingName
                .Text = ""
                .Size = New Size(71, 13)
                '.Location = New Point(xLoc + 158, yLoc - 3) 'next column
                .Type = DPT_TAG
                .ID = _currentBuildingIndex
            End With

            'next row
            yLoc += 29

            With LayoutPanelBuildings.Controls
                .Add(newUpgradeButton)
                .Add(newBuildingCostLabel)
                .Add(newBuildingDPTLabel)
            End With

            _currentBuildingIndex += 1
        Next
    End Sub

    ''' <summary>
    ''' Dynamically creates upgrades and adds the appropriate UI elements to the UI
    ''' </summary>
    Public Sub GenerateUpgrades()
        Dim xLoc As Integer = 3
        Dim yLoc As Integer = 3
        _currentUpgradeIndex = 0

        _upgradeNames = ReturnUpgradeNames()

        'todo: pull back upgrade fields too
        For Each upgradeName In _upgradeNames

            Dim newUpgradeButton As New MyButton
            With newUpgradeButton
                .Name = "button" & upgradeName
                .Text = upgradeName
                .Size = New Size(75, 23)
                '.Location = New Point(xLoc, yLoc)
                .ID = _currentUpgradeIndex
            End With

            AddHandler newUpgradeButton.Click, AddressOf ButtonBuilding_Click
            'AddHandler newUpgradeButton.Click, Function(sender, e) ButtonBuilding_Click(_currentBuildingIndex)

            Dim newUpgradeCostLabel As New MyLabel
            With newUpgradeCostLabel
                .Name = "labelCost" & upgradeName
                .Text = ""
                .Size = New Size(71, 13)
                '.Location = New Point(xLoc + 81, yLoc - 3) 'next column
                .Type = COST_TAG
                .ID = _currentUpgradeIndex
            End With

            'next row
            yLoc += 29

            With LayoutPanelUpgrades.Controls
                .Add(newUpgradeButton)
                .Add(newUpgradeCostLabel)
            End With

            _currentUpgradeIndex += 1
        Next
    End Sub

    ''' <summary>
    ''' Put a try-catch for this at every game entry point to catch errors across all files
    ''' </summary>
    ''' <param name="e"></param>
    Sub DisplayError(e As Exception)
        MsgBox(e.Message)
        Me.Close()
    End Sub

    Private Sub ButtonSaveGame_Click(sender As Object, e As EventArgs) Handles ButtonSaveGame.Click
        SaveGame()
    End Sub

    Private Sub ButtonLoadGame_Click(sender As Object, e As EventArgs) Handles ButtonLoadGame.Click
        LoadGame()
    End Sub
End Class

#Region "Custom Form Classes"
Public Class MyButton
    Inherits Button

    Public Property ID As Integer
End Class
Public Class MyLabel
    Inherits Label

    Public Property ID As Integer
    Public Property Type As String
End Class
#End Region
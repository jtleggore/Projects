Imports ClickerGameLogic

Public Class GameForm

    Private refreshTime As Integer
    'Use to keep track of which building events are beign created
    Private currentBuildingNumber As Integer = 0

    Private buildingNames As New List(Of String)
    'DO NOT USE A CONSTRUCTOR, or UI breaks
    'Sub New()
    'End Sub

    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshTime = 100

        GenerateBuildings()
        StartGame()
        RunAndAwait(AddressOf RefreshUI, refreshTime)
    End Sub

    Private Sub ButtonClick_Click(sender As Object, e As EventArgs) Handles ButtonClick.Click
        EventClickButton()
    End Sub

    Private Sub ButtonBuilding_Click(sender As Object, e As EventArgs)
        'Number = index + 1
        EventClickBuilding(currentBuildingNumber - 1)
    End Sub

    Public Sub RefreshUI()
        LabelAmountMoney.Text = GetCurrentDollars().ToString("C")

        Me.Controls.GetEnumerator()


        LabelBuilding1DPT.Text = GetBuildingDPT(0).ToString("C") & "/tick"
        LabelBuilding1Cost.Text = GetBuildingCost(0).ToString("C")
        LabelBuilding2DPT.Text = GetBuildingDPT(1).ToString("C") & "/tick"
        LabelBuilding2Cost.Text = GetBuildingCost(1).ToString("C")
    End Sub

    ''' <summary>
    ''' Dynamically creates buildings and adds the appropriate UI elements to the UI
    ''' </summary>
    Public Sub GenerateBuildings()
        buildingNames = ReturnBuildingNames()
        For Each buildingName In buildingNames
            Dim newBuildingButton As New Button
            With newBuildingButton
                .Name = "button" & buildingName
                .Text = buildingName
                '.Size =
                '.Location =
            End With

            currentBuildingNumber += 1
            AddHandler newBuildingButton.Click, AddressOf ButtonBuilding_Click

            Dim newBuildingCostLabel As New Label
            With newBuildingCostLabel
                .Name = "labelCost" & buildingName
                .Text = ""
                '.Size =
                '.Location =
            End With

            Dim newBuildingDPTLabel As New Label
            With newBuildingDPTLabel
                .Name = "labelDPT" & buildingName
                .Text = ""
                '.Size =
                '.Location =
            End With

            With Me.Controls
                .Add(newBuildingButton)
                .Add(newBuildingCostLabel)
                .Add(newBuildingDPTLabel)
            End With
            'Todo: create a list of buuildings, list of costlabels, and list of DPT labels to be able to use them 
            'by Index number in the RefreshUI
        Next
    End Sub

End Class
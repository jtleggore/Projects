Imports ClickerGameLogic

Public Class Form1

    Private refreshTime As Integer
    Private moneySymbol As Char

    'DO NOT USE A CONSTRUCTOR, or UI breaks
    'Sub New()
    'End Sub

    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshTime = 100
        moneySymbol = "$"

        StartGame()
        RunAndAwait(AddressOf RefreshUI, refreshTime)
    End Sub

    Private Sub ButtonClick_Click(sender As Object, e As EventArgs) Handles ButtonClick.Click
        EventClickButton()
    End Sub

    Private Sub ButtonBuilding1_Click(sender As Object, e As EventArgs) Handles ButtonBuilding1.Click
        EventClickBuilding(0)
    End Sub

    Private Sub ButtonBuilding2_Click(sender As Object, e As EventArgs) Handles ButtonBuilding2.Click
        EventClickBuilding(1)
    End Sub

    Public Sub RefreshUI()
        LabelAmountMoney.Text = moneySymbol & GetCurrentDollars()
        LabelBuilding1DPT.Text = moneySymbol & GetBuildingDPT(0) & "/tick"
        LabelBuilding1Cost.Text = moneySymbol & GetBuildingCost(0)
        LabelBuilding2DPT.Text = moneySymbol & GetBuildingDPT(1) & "/tick"
        LabelBuilding2Cost.Text = moneySymbol & GetBuildingCost(1)
    End Sub

End Class
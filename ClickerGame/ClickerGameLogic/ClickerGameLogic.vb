Imports ClickerGameFramework

Public Module ClickerGameLogic

    Private DECIMAL_PRECISION As Integer = 2

    Private buildingTick As Integer
    Private buildingList As New List(Of Building)
    'Private building1
    'Private building2

    Sub New()
        buildingTick = 1000
        MainOperator.setCurrentDPC(0.01)

        buildingList.Add(New Building("building1", 0.01, 0.25, 1.05))
        buildingList.Add(New Building("building2", 0.05, 1))
        buildingList.Add(New Building("building3", 0.25, 5.5))
    End Sub

    'Returns Building names to the UI for purpose of dynamically building the buttons
    Public Function ReturnBuildingNames() As List(Of String)
        Dim nameList As New List(Of String)

        For Each building In buildingList
            nameList.Add(building.getName)
        Next

        Return nameList
    End Function

    Public Sub StartGame()
        'Call RunAndAwait for each building that exists
        For Each building In buildingList
            RunAndAwait(AddressOf building.addDPTToMainOperator, buildingTick)
        Next
    End Sub

    Public Sub EventClickButton()
        MainOperator.doClick(MainOperator.getCurrentDPC)
    End Sub

    Public Sub EventClickBuilding(buildingNumber As Integer)
        Dim currentCost As Single = buildingList(buildingNumber).getCurrentCost

        If currentCost <= MainOperator.getCurrentDollars Then
            MainOperator.addToCurrentDollars(-1 * currentCost)
            buildingList(buildingNumber).addToQuantity(1)
            buildingList(buildingNumber).updateCost()
        End If
    End Sub

#Region "Wrapper Functions"
    Public Function GetCurrentDollars() As Single
        Return Math.Round(MainOperator.getCurrentDollars, DECIMAL_PRECISION)
    End Function

    Public Function GetBuildingDPT(buildingNumber As Integer) As Single
        Return Math.Round(buildingList(buildingNumber).getCurrentDPT, DECIMAL_PRECISION)
    End Function

    Public Function GetBuildingCost(buildingNumber As Integer) As Single
        Return Math.Round(buildingList(buildingNumber).getCurrentCost, DECIMAL_PRECISION)
    End Function

#End Region
End Module

Public Module Runner
    ''' <summary>
    ''' Runs a method repeatedly after each delay time has passed
    ''' </summary>
    Public Async Sub RunAndAwait(methodToRun As Action, delay As Integer)
        While True
            methodToRun()

            If delay > 0 Then
                Await Task.Delay(delay)
            Else
                Await Task.Delay(0)
            End If
        End While
    End Sub
End Module
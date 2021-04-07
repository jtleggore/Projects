Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization

Imports ClickerGameFramework

Public Module ClickerGameLogic

    Private Const DECIMAL_PRECISION As Integer = 2

    Private mainGame As New MainOperator
    Private _buildingTick As Integer
    Private _buildingList As New List(Of Building)
    Private _upgradeList As New List(Of Upgrade)

    Public Property BuildingList() As List(Of Building)
        Get
            Return _buildingList
        End Get
        Set(value As List(Of Building))

        End Set
    End Property

    Public Property UpgradeList() As List(Of Upgrade)
        Get
            Return _upgradeList
        End Get
        Set(value As List(Of Upgrade))

        End Set
    End Property

    Sub New()
        _buildingTick = 1000
        mainGame.CurrentDPC = 0.01

        BuildingList.Add(New Building("building1", 0.01, 0.25, 1.02))
        BuildingList.Add(New Building("building2", 0.05, 1))
        BuildingList.Add(New Building("building3", 0.25, 5.5))
        BuildingList.Add(New Building("building4", 0.95, 20, 1.5))

        UpgradeList.Add(New Upgrade("upgrade1", 0.01, AddressOf UnlockUpgrade1, AddressOf SetUpgradeBonus))
    End Sub

    Public Function UnlockUpgrade1() As Boolean
        If BuildingList(0).Quantity >= 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function SetUpgradeBonus() As String
        Return ""
    End Function

    ''' <summary>
    ''' Returns Building names To the UI For purpose Of dynamically building the buttons
    ''' </summary>
    Public Function ReturnBuildingNames() As List(Of String)
        Dim nameList As New List(Of String)

        For Each building In _buildingList
            nameList.Add(building.Name)
        Next

        Return nameList
    End Function

    ''' <summary>
    ''' Returns Upgrade names To the UI For purpose Of dynamically building the buttons
    ''' </summary>
    Public Function ReturnUpgradeNames() As List(Of String)
        Dim nameList As New List(Of String)

        For Each upgrade In _upgradeList
            nameList.Add(upgrade.Name)
        Next

        Return nameList
    End Function

    Public Sub StartGame()
        'Call RunAndAwait for each building that exists
        For Each building In _buildingList
            RunAndAwait(Sub() mainGame.CurrentDollars += building.CurrentDPT, _buildingTick)
        Next
    End Sub

    Public Sub EventClickButton()
#If DEBUG Then
        mainGame.doClick(100000)
#Else
        mainGame.doClick(mainGame.CurrentDPC)
#End If
    End Sub

    Public Sub EventClickBuilding(buildingNumber As Integer)
        Dim currentCost As Single = _buildingList(buildingNumber).CurrentCost

        If currentCost <= mainGame.CurrentDollars Then
            mainGame.CurrentDollars += -1 * currentCost
            _buildingList(buildingNumber).Quantity += 1
            _buildingList(buildingNumber).updateCost()
        End If
    End Sub

#Region "Framework Wrapper Functions"
    Public Function GetCurrentDollars() As Single
        Return Math.Round(mainGame.CurrentDollars, DECIMAL_PRECISION)
    End Function

    Public Function GetBuildingDPT(buildingNumber As Integer) As Single
        Return Math.Round(BuildingList(buildingNumber).CurrentDPT, DECIMAL_PRECISION)
    End Function

    Public Function GetBuildingCost(buildingNumber As Integer) As Single
        Return Math.Round(BuildingList(buildingNumber).CurrentCost, DECIMAL_PRECISION)
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

Public Module SaveFileHandler
    Private xmlGame As XDocument
    Private rootElement As String = "ClickerGame"
    Private saveDir As String = ".\SaveFile"
    Private saveLoc As String = saveDir & "\Save.sav"

    ''' <summary>
    ''' Serializes all objects of the game and saves xml to file
    ''' </summary>
    Public Sub SaveGame()
        Dim serializedGame As New StringBuilder()
        serializedGame.Append("<" & rootElement & ">")

        'Todo: maybe add using here
        Dim tempOperator As New MainOperator
        serializedGame.Append(tempOperator.Serialize)
        'continue here
        For Each building In BuildingList
            serializedGame.Append(building.Serialize)
        Next

        serializedGame.Append("</" & rootElement & ">")
        xmlGame = XDocument.Parse(serializedGame.ToString)

        Directory.CreateDirectory(saveDir)
        File.WriteAllText(saveLoc, xmlGame.ToString)

    End Sub

    Public Sub LoadGame()
        Dim serializedGame As String = File.ReadAllText(saveLoc)
        xmlGame = XDocument.Parse(serializedGame)
    End Sub
End Module


Public Module Extensions
    'Check if needs to be ByVal
    ''' <summary>
    ''' Serializes object into XML
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="val"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Serialize(Of T)(val As T) As String
        Dim xmlserializer As New XmlSerializer(GetType(T))
        Dim stringWriter As New StringWriter()
        'removes xml namespace
        Dim emptyNamespace As XmlSerializerNamespaces = New XmlSerializerNamespaces(New XmlQualifiedName() {XmlQualifiedName.Empty})
        Dim settings As New XmlWriterSettings

        'removes XML declaration so that multiple serialized objects can be appended together
        settings.OmitXmlDeclaration = True

        If val Is Nothing Then
            Throw New Exception("Object to serialize cannot be null")
        End If

        Using writer = XmlWriter.Create(stringWriter, settings)
            xmlserializer.Serialize(writer, val, emptyNamespace)
        End Using

        Return stringWriter.ToString

    End Function
End Module
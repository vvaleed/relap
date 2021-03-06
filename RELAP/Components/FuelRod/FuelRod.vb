﻿'    Fuel Rod Calculation Routines 
'    Copyright 2013 Sarah 
'
'    This file is part of RIFGen.
'
'    RIFGen is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    RIFGen is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    

Imports Microsoft.Msdn.Samples.GraphicObjects
'Imports RELAP.RELAP.Flowsheet.FlowSheetSolver

Namespace RELAP.SimulationObjects.UnitOps

    <System.Serializable()> Public Class FuelRod

        Inherits SimulationObjects_UnitOpBaseClass


     

        Private m_InitialSettingComponentName As String
        Public Property InitialSettingComponentName() As String
            Get
                Return m_InitialSettingComponentName
            End Get
            Set(ByVal value As String)
                m_InitialSettingComponentName = value
            End Set
        End Property

        Private m_NumberOfRods As Integer
        Public Property NumberOfRods() As Integer
            Get
                Return m_NumberOfRods
            End Get
            Set(ByVal value As Integer)
                m_NumberOfRods = value
            End Set
        End Property

        Private m_FuelRodPitch As Double
        Public Property FuelRodPitch() As Double
            Get
                Return m_FuelRodPitch
            End Get
            Set(ByVal value As Double)
                m_FuelRodPitch = value
            End Set
        End Property

        Private m_AverageBurnup As Double
        Public Property AverageBurnup() As Double
            Get
                Return m_AverageBurnup
            End Get
            Set(ByVal value As Double)
                m_AverageBurnup = value
            End Set
        End Property

        Private m_PlenumLength As Double
        Public Property PlenumLength() As Double
            Get
                Return m_PlenumLength
            End Get
            Set(ByVal value As Double)
                m_PlenumLength = value
            End Set
        End Property

        Private m_PlenumVoidVolume As String
        Public Property PlenumVoidVolume() As String
            Get
                Return m_PlenumVoidVolume
            End Get
            Set(ByVal value As String)
                m_PlenumVoidVolume = value
            End Set
        End Property

        Private m_LowerPlenumVoidVolume As String
        Public Property LowerPlenumVoidVolume() As String
            Get
                Return m_LowerPlenumVoidVolume
            End Get
            Set(ByVal value As String)
                m_LowerPlenumVoidVolume = value
            End Set
        End Property

        Private m_FuelRodDetails As FuelRodDetails
        Public Property FuelRodDetails() As FuelRodDetails
            Get
                Return m_FuelRodDetails
            End Get
            Set(ByVal value As FuelRodDetails)
                m_FuelRodDetails = value
            End Set
        End Property



        Private m_ControlVolumeAbove As String
        Public Property ControlVolumeAbove() As String
            Get
                Return m_ControlVolumeAbove
            End Get
            Set(ByVal value As String)
                m_ControlVolumeAbove = value
            End Set
        End Property

        Private m_ControlVolumeBelow As String
        Public Property ControlVolumeBelow() As String
            Get
                Return m_ControlVolumeBelow
            End Get
            Set(ByVal value As String)
                m_ControlVolumeBelow = value
            End Set
        End Property

       

        Private m_RadiusToRadialNode1 As Double
        Public Property RadiusToRadialNode1() As Double
            Get
                Return m_RadiusToRadialNode1
            End Get
            Set(ByVal value As Double)
                m_RadiusToRadialNode1 = value
            End Set
        End Property

        Private m_RadiusToRadialNodeN As Double
        Public Property RadiusToRadialNodeN() As Double
            Get
                Return m_RadiusToRadialNodeN
            End Get
            Set(ByVal value As Double)
                m_RadiusToRadialNodeN = value
            End Set
        End Property

        Private m_RadialMeshSpacingAxialNode As Integer
        Public Property RadialMeshSpacingAxialNode() As Integer
            Get
                Return m_RadialMeshSpacingAxialNode
            End Get
            Set(ByVal value As Integer)
                m_RadialMeshSpacingAxialNode = value
            End Set
        End Property

        Private m_TemperatureAtNode1 As Double
        Public Property TemperatureAtNode1() As Double
            Get
                Return m_TemperatureAtNode1
            End Get
            Set(ByVal value As Double)
                m_TemperatureAtNode1 = value
            End Set
        End Property

        Private m_TemperatureAtNodeN As Double
        Public Property TemperatureAtNodeN() As Double
            Get
                Return m_TemperatureAtNodeN
            End Get
            Set(ByVal value As Double)
                m_TemperatureAtNodeN = value
            End Set
        End Property

        Private m_InitialTemperaturesAxialNode As Integer
        Public Property InitialTemperaturesAxialNode() As Integer
            Get
                Return m_InitialTemperaturesAxialNode
            End Get
            Set(ByVal value As Integer)
                m_InitialTemperaturesAxialNode = value
            End Set
        End Property

        Private m_MaterialIndexNearCenter As Integer
        Public Property MaterialIndexNearCenter() As Integer
            Get
                Return m_MaterialIndexNearCenter
            End Get
            Set(ByVal value As Integer)
                m_MaterialIndexNearCenter = value
            End Set
        End Property

        Private m_MaterialIndexNextToCenter As Integer
        Public Property MaterialIndexNextToCenter() As Integer
            Get
                Return m_MaterialIndexNextToCenter
            End Get
            Set(ByVal value As Integer)
                m_MaterialIndexNextToCenter = value
            End Set
        End Property

        Private m_MaterialIndexNthLayer As Integer
        Public Property MaterialIndexNthLayer() As Integer
            Get
                Return m_MaterialIndexNthLayer
            End Get
            Set(ByVal value As Integer)
                m_MaterialIndexNthLayer = value
            End Set
        End Property

        Private m_Fraction As Double
        Public Property Fraction() As Double
            Get
                Return m_Fraction
            End Get
            Set(ByVal value As Double)
                m_Fraction = value
            End Set
        End Property

        Private m_TimeForWhichAxialPowerProfileApplies As Double
        Public Property TimeForWhichAxialPowerProfileApplies() As Double
            Get
                Return m_TimeForWhichAxialPowerProfileApplies
            End Get
            Set(ByVal value As Double)
                m_TimeForWhichAxialPowerProfileApplies = value
            End Set
        End Property

        Private m_AxialPowerFactor As Double
        Public Property AxialPowerFactor() As Double
            Get
                Return m_AxialPowerFactor
            End Get
            Set(ByVal value As Double)
                m_AxialPowerFactor = value
            End Set
        End Property

        Private m_RadialPowerFactor As Double
        Public Property RadialPowerFactor() As Double
            Get
                Return m_RadialPowerFactor
            End Get
            Set(ByVal value As Double)
                m_RadialPowerFactor = value
            End Set
        End Property

        Private m_RadialNode As Double
        Public Property RadialNode() As Double
            Get
                Return m_RadialNode
            End Get
            Set(ByVal value As Double)
                m_RadialNode = value
            End Set
        End Property

        Private m_ShutdownTime As Double
        Public Property ShutdownTime() As Double
            Get
                Return m_ShutdownTime
            End Get
            Set(ByVal value As Double)
                m_ShutdownTime = value
            End Set
        End Property

        Private m_FractionOfFuelDensity As Double
        Public Property FractionOfFuelDensity() As Double
            Get
                Return m_FractionOfFuelDensity
            End Get
            Set(ByVal value As Double)
                m_FractionOfFuelDensity = value
            End Set
        End Property

        Private m_PowerHistory As Double
        Public Property PowerHistory() As Double
            Get
                Return m_PowerHistory
            End Get
            Set(ByVal value As Double)
                m_PowerHistory = value
            End Set
        End Property

        Private m_TimeOfPowerHistory As Double
        Public Property TimeOfPowerHistory() As Double
            Get
                Return m_TimeOfPowerHistory
            End Get
            Set(ByVal value As Double)
                m_TimeOfPowerHistory = value
            End Set
        End Property

        Private m_CORSORSpeciesName As String
        Public Property CORSORSpeciesName() As String
            Get
                Return m_CORSORSpeciesName
            End Get
            Set(ByVal value As String)
                m_CORSORSpeciesName = value
            End Set
        End Property

        Private m_GapFissionProductsSpeciesName As String
        Public Property GapFissionProductsSpeciesName() As String
            Get
                Return m_GapFissionProductsSpeciesName
            End Get
            Set(ByVal value As String)
                m_GapFissionProductsSpeciesName = value
            End Set
        End Property

        Private m_HeliumGasInventory As Double
        Public Property HeliumGasInventory() As Double
            Get
                Return m_HeliumGasInventory
            End Get
            Set(ByVal value As Double)
                m_HeliumGasInventory = value
            End Set
        End Property

        Private m_InternalGasPressure As Double
        Public Property InternalGasPressure() As Double
            Get
                Return m_InternalGasPressure
            End Get
            Set(ByVal value As Double)
                m_InternalGasPressure = value
            End Set
        End Property

        Private m_Time As Double
        Public Property Time() As Double
            Get
                Return m_Time
            End Get
            Set(ByVal value As Double)
                m_Time = value
            End Set
        End Property

        Private m_Pressure As Double
        Public Property Pressure() As Double
            Get
                Return m_Pressure
            End Get
            Set(ByVal value As Double)
                m_Pressure = value
            End Set
        End Property

        Private m_Temperature As Double
        Public Property Temperature() As Double
            Get
                Return m_Temperature
            End Get
            Set(ByVal value As Double)
                m_Temperature = value
            End Set
        End Property

        Private m_Keyword As String
        Public Property Keyword() As String
            Get
                Return m_Keyword
            End Get
            Set(ByVal value As String)
                m_Keyword = value
            End Set
        End Property

        Private m_Flag As Boolean
        Public Property Flag() As Boolean
            Get
                Return m_Flag
            End Get
            Set(ByVal value As Boolean)
                m_Flag = value
            End Set
        End Property

        Private m_GapConductance As Double
        Public Property GapConductance() As Double
            Get
                Return m_GapConductance
            End Get
            Set(ByVal value As Double)
                m_GapConductance = value
            End Set
        End Property

        Private m_GapConductanceAxialNode As Integer
        Public Property GapConductanceAxialNode() As Integer
            Get
                Return m_GapConductanceAxialNode
            End Get
            Set(ByVal value As Integer)
                m_GapConductanceAxialNode = value
            End Set
        End Property

        Private m_FuelThermalConductivityMultiplier As Double
        Public Property FuelThermalConductivityMultiplier() As Double
            Get
                Return m_FuelThermalConductivityMultiplier
            End Get
            Set(ByVal value As Double)
                m_FuelThermalConductivityMultiplier = value
            End Set
        End Property

        Private m_FuelThermalConductivityAxialNode As Integer
        Public Property FuelThermalConductivityAxialNode() As Integer
            Get
                Return m_FuelThermalConductivityAxialNode
            End Get
            Set(ByVal value As Integer)
                m_FuelThermalConductivityAxialNode = value
            End Set
        End Property




        Public Sub New(ByVal nome As String, ByVal descricao As String)

            MyBase.CreateNew()
            Me.m_ComponentName = nome
            Me.m_ComponentDescription = descricao
            Me.FillNodeItems()
            Me.QTFillNodeItems()
            Me.FuelRodDetails = New FuelRodDetails
        End Sub

        
        Public Overrides Function Calculate(Optional ByVal args As Object = Nothing) As Integer


          
            Return 0
        End Function

        Public Overrides Function DeCalculate() As Integer

            'Dim form As Global.RELAP.FormFlowsheet = My.Application.ActiveSimulation

            'If Me.GraphicObject.OutputConnectors(0).IsAttached Then

            '    'Zerar valores da corrente de matéria conectada a jusante
            '    With form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.OutputConnectors(0).AttachedConnector.AttachedTo.Name)
            '        .Fases(0).SPMProperties.temperature = Nothing
            '        .Fases(0).SPMProperties.pressure = Nothing
            '        .Fases(0).SPMProperties.molarfraction = 1
            '        .Fases(0).SPMProperties.massfraction = 1
            '        .Fases(0).SPMProperties.enthalpy = Nothing
            '        Dim comp As RELAP.ClassesBasicasTermodinamica.Substancia
            '        Dim i As Integer = 0
            '        For Each comp In .Fases(0).Componentes.Values
            '            comp.FracaoMolar = 0
            '            comp.FracaoMassica = 0
            '            i += 1
            '        Next
            '        .Fases(0).SPMProperties.massflow = Nothing
            '        .Fases(0).SPMProperties.molarflow = Nothing
            '        .GraphicObject.Calculated = False
            '    End With

            'End If

            ''Call function to calculate flowsheet
            'Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            'With objargs
            '    .Calculado = False
            '    .Nome = Me.Nome
            '    .Tag = Me.GraphicObject.Tag
            '    .Tipo = TipoObjeto.Tank
            'End With

            'form.CalculationQueue.Enqueue(objargs)
            Return 0
        End Function

        Public Overloads Overrides Sub UpdatePropertyNodes(ByVal su As SistemasDeUnidades.Unidades, ByVal nf As String)

            Dim Conversor As New RELAP.SistemasDeUnidades.Conversor
            If Me.NodeTableItems Is Nothing Then
                Me.NodeTableItems = New System.Collections.Generic.Dictionary(Of Integer, RELAP.Outros.NodeItem)
                Me.FillNodeItems()
            End If

            For Each nti As Outros.NodeItem In Me.NodeTableItems.Values
                nti.Value = GetPropertyValue(nti.Text, FlowSheet.Options.SelectedUnitSystem)
                nti.Unit = GetPropertyUnit(nti.Text, FlowSheet.Options.SelectedUnitSystem)
            Next

            If Me.QTNodeTableItems Is Nothing Then
                Me.QTNodeTableItems = New System.Collections.Generic.Dictionary(Of Integer, RELAP.Outros.NodeItem)
                Me.QTFillNodeItems()
            End If

            'With Me.QTNodeTableItems

            '    Dim valor As String

            '    If Me.DeltaP.HasValue Then
            '        valor = Format(Conversor.ConverterDoSI(su.spmp_deltaP, Me.DeltaP), nf)
            '    Else
            '        valor = RELAP.App.GetLocalString("NC")
            '    End If
            '    .Item(0).Value = valor
            '    .Item(0).Unit = su.spmp_deltaP

            '    If Me.DeltaQ.HasValue Then
            '        valor = Format(Conversor.ConverterDoSI(su.spmp_heatflow, Me.DeltaQ), nf)
            '    Else
            '        valor = RELAP.App.GetLocalString("NC")
            '    End If
            '    .Item(1).Value = valor
            '    .Item(1).Unit = su.spmp_heatflow

            'End With


        End Sub

        Public Overrides Sub QTFillNodeItems()

            With Me.QTNodeTableItems

                .Clear()

                .Add(0, New RELAP.Outros.NodeItem("DP", "", "", 0, 0, ""))
                .Add(1, New RELAP.Outros.NodeItem("A/R", "", "", 1, 0, ""))

            End With

        End Sub

        Public Overrides Sub PopulatePropertyGrid(ByRef pgrid As PropertyGridEx.PropertyGridEx, ByVal su As SistemasDeUnidades.Unidades)

            Dim Conversor As New RELAP.SistemasDeUnidades.Conversor

            With pgrid

                .PropertySort = PropertySort.Categorized
                .ShowCustomProperties = True
                .Item.Clear()

                MyBase.PopulatePropertyGrid(pgrid, su)
                'input connector added
                Dim ent, saida, energ As String
                If Me.GraphicObject.InputConnectors(0).IsAttached = True Then
                    ent = Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Tag
                Else
                    ent = ""
                End If
                'output connector added
                If Me.GraphicObject.OutputConnectors(0).IsAttached = True Then
                    saida = Me.GraphicObject.OutputConnectors(0).AttachedConnector.AttachedTo.Tag
                Else
                    saida = ""
                End If
                'energy connector added
                If Me.GraphicObject.EnergyConnector.IsAttached = True Then
                    energ = Me.GraphicObject.EnergyConnector.AttachedConnector.AttachedTo.Tag
                Else
                    energ = ""
                End If
                'inlet stream , connections
                '.Item.Add(RELAP.App.GetLocalString("Correntedeentrada"), ent, False, RELAP.App.GetLocalString("Conexes1"), "", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .CustomEditor = New RELAP.Editors.Streams.UIInputMSSelector

                'End With
                ''outlet stream, connections
                '.Item.Add(RELAP.App.GetLocalString("Correntedesada"), saida, False, RELAP.App.GetLocalString("Conexes1"), "", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .CustomEditor = New RELAP.Editors.Streams.UIOutputMSSelector
                'End With
                ' pressure drop, Calculation parameters, Pressure drop in the tank
                Dim valor
                '.Item.Add(FT(RELAP.App.GetLocalString("Quedadepresso"), su.spmp_deltaP), valor, False, "Parameters", RELAP.App.GetLocalString("Quedadepressoaplicad5"), True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Nullable(Of Double))
                'End With
                ''desi kaam

                ''.Item.Add("Flow Area", FlowArea())



                ' '''''''''''''

                'valor = Me.ComponentName
                ''Tank Volume,Calculation parameters, Tank Volume
                '.Item.Add("Component Name", valor, False, "Initial Settings", "Word 2 is 'fuel' which is constant for fuel", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(String)
                'End With

                .Item.Add("Set Fuel Rod Details", Me, "FuelRodDetails", False, "Details", "Set Fuel Rod Details", True)
                With .Item(.Item.Count - 1)
                    .DefaultType = GetType(FuelRodDetails)
                    .CustomEditor = New RELAP.Editors.UIFuelRodEditor
                End With
                valor = Me.NumberOfRods
                .Item.Add("No. of rods", valor, False, "No. of Rods", " ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = (Me.FuelRodPitch)
                .Item.Add(FT("Fuel Rod Pitch", su.distance), valor, False, "No. of Rods", "0.0126 M ≤ x ≤ 0.0187 m.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Me.AverageBurnup
                .Item.Add(FT("Average Burnup", su.burnup), valor, False, "No. of Rods", "0.0 ≤ x ≤ 4752000.0 ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = (Me.PlenumLength)
                .Item.Add(FT("Plenum Length", su.distance), valor, False, "Fuel Rod Plenum Geometry", "Range is 3 – 11%", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = (Me.PlenumVoidVolume)
                .Item.Add(FT("Plenum Void Volume", su.volume), valor, False, "Fuel Rod Plenum Geometry", "0.0 < x ≤ 0.000049, Volume of Spring", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = (Me.LowerPlenumVoidVolume)
                .Item.Add(FT("Lower plenum Void Volume ", su.volume), valor, False, "Fuel Rod Plenum Geometry", "Volume of gas", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                'valor = Format((Me.FuelPelletRadius), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT(("Fuel pellet radius "), su.distance), valor, False, "Fuel Rod Dimensions", "0.00385 m ≤ x ≤ 0.00685 m", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With

                'valor = Format((Me.InnerCladdingRadius), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT(("Inner cladding radius "), su.distance), valor, False, "Fuel Rod Dimensions", "0.003935 m ≤ x ≤ 0.00634 m", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With

                'valor = Format((Me.OuterCladdingRadius), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT(RELAP.App.GetLocalString("Outer cladding radius"), su.distance), valor, False, "Fuel Rod Dimensions", "0.00457 m ≤ x ≤ 0.00715 m", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With

                'valor = Me.FuelRodDimensionsAxialNode
                '.Item.Add("Axial node", valor, False, "Fuel Rod Dimensions", "Hypothetical axis lines", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Integer)
                'End With

                'valor = Format((Me.ControlVolumeAbove), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT(("Control Volume Above"), su.volume), valor, False, "Upper and Lower Hydraulic Volumes", "Heat sinks for bottom", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With

                'valor = Format((Me.ControlVolumeBelow), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT(("Control Volume Below"), su.volume), valor, False, "Upper and Lower Hydraulic Volumes", "Heat sinks for bottom", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With

                'valor = Me.ControlVolumeNumber
                '.Item.Add("Control Volume Number", valor, False, "Hydraulic Volumes", "Starting from node 1 upwards axially", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Integer)
                'End With

                'valor = Me.Increment
                '.Item.Add("Increment", valor, False, "Hydraulic Volumes", "From 1st to last node.Can be 0,+ve,-ve", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Integer)
                'End With

                'valor = Me.HydraulicVolumesAxialNode
                '.Item.Add("Axial Node", valor, False, "Hydraulic Volumes", " ", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Integer)
                'End With

                'valor = Format((Me.RadiusToRadialNode1), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT(("Radius To Radial Node 1"), su.distance), valor, False, "Radial Mesh Spacing", "", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With

                'valor = Format((Me.RadiusToRadialNodeN), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT(("Radius To Radial Node N"), su.distance), valor, False, "Radial Mesh Spacing", "Enter radial node N. Ascending order and last node placed on the cladding outer surface.", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With

                'valor = Me.RadialMeshSpacingAxialNode
                '.Item.Add("Axial Node", valor, False, "Radial Mesh Spacing", " ", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Integer)
                'End With

                'valor = Format((Me.TemperatureAtNode1), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT(("Temperature at Node 1"), su.spmp_temperature), valor, False, "Initial Temperatures", "The range is 300 K ≤ x ≤ 3123 K. Initial temperature of Node 1", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With

                'valor = Format((Me.TemperatureAtNodeN), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT(("Temperature at Node N"), su.spmp_temperature), valor, False, "Initial Temperatures", "Initial temperature for each radial node to radial node N. Range is same as above.", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With

                'valor = Me.InitialTemperaturesAxialNode
                '.Item.Add("Axial Node", valor, False, "Initial Temperature", " ", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Integer)
                'End With

                'valor = Me.MaterialIndexNearCenter
                '.Item.Add("Material Index Near Center", valor, False, "Material Specification", "Defaults for a fuel rod component are UO2 (index=6), Gap (index=9), and Zircaloy (index=1).", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Integer)
                'End With

                'valor = Me.MaterialIndexNextToCenter
                '.Item.Add("Material Index Next To Center", valor, False, "Material Specification", "Defaults for a fuel rod component are UO2 (index=6), Gap (index=9), and Zircaloy (index=1).", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Integer)
                'End With

                'valor = Me.MaterialIndexNthLayer
                '.Item.Add("Material Index Nth Layer", valor, False, "Material Specification", "Defaults for a fuel rod component are UO2 (index=6), Gap (index=9), and Zircaloy (index=1).", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Integer)
                'End With

                valor = Me.Fraction
                .Item.Add("Fraction", valor, False, "Power Multiplier", "The range is 0.0 ≤ x ≤ 1.0, default is 0.0", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = (Me.TimeForWhichAxialPowerProfileApplies)
                .Item.Add(FT(("Axial Power Profile Time"), su.time), valor, False, "Axial Power Profile Time", "'P' is axial power profile number (start with Number 1).", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.AxialPowerFactor
                .Item.Add("Axial Power Factor", valor, False, "Axial Power Profile Data", "The range is 0.1 ≤ x ≤ 1.4, default is 1.0.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.RadialPowerFactor
                .Item.Add("Radial Power Factor", valor, False, "Radial Power Profile", "Range is x ≤ 20, default power factor is 1.0", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.RadialNode
                .Item.Add("Radial node", valor, False, "Radial Power Profile", "At which the power factor applies", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = (Me.ShutdownTime)
                .Item.Add(FT(("Shutdown Time"), su.time), valor, False, "Shutdown Time and Fuel Density", "", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.FractionOfFuelDensity
                .Item.Add("Fraction Of Fuel Density", valor, False, "Shutdown Time and Fuel Density", "Range is 0.94 ≤ x ≤ 0.96. It is theoretical ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format((Me.PowerHistory), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(("Power history"), su.powerdensity), valor, False, "Previous Power History", "Range is 40.57×106 W/m3 ≤ x ≤ 279.3×106 W/m3", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = (Me.TimeOfPowerHistory)
                .Item.Add(FT("Previous Power History Time", su.time), valor, False, "Previous Power History", " ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = (Me.HeliumGasInventory)
                .Item.Add(FT(("Helium Gas Inventory"), su.mass), valor, False, "Gas Internal Pressure", "In an individual fuel rod", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = (Me.InternalGasPressure)
                .Item.Add(FT(("Internal Gas Pressure"), su.spmp_pressure), valor, False, "Gas Internal Pressure", "In a rod", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = (Me.Time)
                .Item.Add(FT(("Time Profile"), su.time), valor, False, "Time-Temperature-Pressure Profile", "The time to which the axial surface temperature profile and fuel average hydrostatic pressure are used", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = (Me.Temperature)
                .Item.Add(FT(("Temperature"), su.spmp_temperature), valor, False, "Time-Temperature-Pressure Profile", "Cladding surface temperature", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = (Me.Pressure)
                .Item.Add(FT(("Pressure"), su.spmp_pressure), valor, False, "Time-Temperature-Pressure Profile", "Fuel hydrostatic pressure", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.Keyword
                .Item.Add("Keyword", valor, False, "Option Definition", "To identify optional model to be applied", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(String)
                End With

                valor = Me.Flag
                .Item.Add("Flag", valor, False, "Option Definition", "Specifying whether to apply model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Boolean)
                End With

                valor = (Me.GapConductance)
                .Item.Add(FT(("Gap Conductance"), su.conductance), valor, False, "Gap Conductance", "At steady-state conditions just before start of transient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.GapConductanceAxialNode
                .Item.Add("Axial Node", valor, False, "Gap Conductance", " ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.FuelThermalConductivityMultiplier
                .Item.Add("Fuel Thermal Conductivity Multiplier", valor, False, "Fuel Thermal Conductivity", "Default is 1.0", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.m_FuelThermalConductivityAxialNode
                .Item.Add("Fuel Thermal Conductivity  Axial Node", valor, False, "Fuel Thermal Conductivity", " ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

            End With

        End Sub

        Public Overrides Function GetPropertyValue(ByVal prop As String, Optional ByVal su As SistemasDeUnidades.Unidades = Nothing) As Object

            If su Is Nothing Then su = New RELAP.SistemasDeUnidades.UnidadesSI
            Dim cv As New RELAP.SistemasDeUnidades.Conversor
            Dim value As Double = 0
            Dim propidx As Integer = CInt(prop.Split("_")(2))

            'Select Case propidx

            '    Case 0
            '        'PROP_TK_0	Pressure Drop
            '        value = cv.ConverterDoSI(su.spmp_deltaP, Me.DeltaP.GetValueOrDefault)

            'End Select

            Return value

        End Function



        Public Overloads Overrides Function GetProperties(ByVal proptype As SimulationObjects_BaseClass.PropertyType) As String()
            Dim i As Integer = 0
            Dim proplist As New ArrayList
            Select Case proptype
                Case PropertyType.RW
                    For i = 2 To 2
                        proplist.Add("PROP_TK_" + CStr(i))
                    Next
                Case PropertyType.RW
                    For i = 0 To 2
                        proplist.Add("PROP_TK_" + CStr(i))
                    Next
                Case PropertyType.WR
                    For i = 0 To 1
                        proplist.Add("PROP_TK_" + CStr(i))
                    Next
                Case PropertyType.ALL
                    For i = 0 To 2
                        proplist.Add("PROP_TK_" + CStr(i))
                    Next
            End Select
            Return proplist.ToArray(GetType(System.String))
            proplist = Nothing
        End Function

        Public Overrides Function SetPropertyValue(ByVal prop As String, ByVal propval As Object, Optional ByVal su As RELAP.SistemasDeUnidades.Unidades = Nothing) As Object
            If su Is Nothing Then su = New RELAP.SistemasDeUnidades.UnidadesSI
            Dim cv As New RELAP.SistemasDeUnidades.Conversor
            Dim propidx As Integer = CInt(prop.Split("_")(2))

            'Select Case propidx
            '    Case 0
            '        'PROP_TK_0	Pressure Drop
            '        Me.DeltaP = cv.ConverterParaSI(su.spmp_deltaP, propval)
            '    Case 1
            '        'PROP_TK_1	Volume
            '        Me.DeltaP = cv.ConverterParaSI(su.volume, propval)
            'End Select
            Return 1
        End Function

        Public Overrides Function GetPropertyUnit(ByVal prop As String, Optional ByVal su As SistemasDeUnidades.Unidades = Nothing) As Object
            If su Is Nothing Then su = New RELAP.SistemasDeUnidades.UnidadesSI
            Dim cv As New RELAP.SistemasDeUnidades.Conversor
            Dim value As String = ""
            Dim propidx As Integer = CInt(prop.Split("_")(2))

            Select Case propidx

                Case 0
                    'PROP_TK_0	Pressure Drop
                    value = su.spmp_deltaP

                Case 1
                    'PROP_TK_1	Volume
                    value = su.volume

                Case 2
                    'PROP_TK_2	Residence Time
                    value = su.time

            End Select

            Return value
        End Function
    End Class
    <Serializable()> Public Class FuelRodDetails
        Protected m_collection As Generic.SortedDictionary(Of Integer, FuelRodDimensions)
        Protected m_collection2 As Generic.SortedDictionary(Of Integer, HydraulicVolumes)
        Protected m_collection3 As Generic.SortedDictionary(Of Integer, RadialMeshSpacing)
        Protected m_collection4 As Generic.SortedDictionary(Of Integer, RadialPowerProfile)
        Protected m_collection5 As Generic.SortedDictionary(Of Integer, PreviousPowerHistory)

        Private m_AxialPowerFactor As Generic.SortedDictionary(Of Integer, Double)
        Public Property AxialPowerFactor() As Generic.SortedDictionary(Of Integer, Double)
            Get
                Return m_AxialPowerFactor
            End Get
            Set(ByVal value As Generic.SortedDictionary(Of Integer, Double))
                m_AxialPowerFactor = value
            End Set
        End Property
        Public Property RadialPowerProfile() As Generic.SortedDictionary(Of Integer, RadialPowerProfile)
            Get
                Return m_collection4
            End Get
            Set(ByVal value As Generic.SortedDictionary(Of Integer, RadialPowerProfile))
                m_collection4 = value
            End Set
        End Property
        Public Property PreviousPowerHistory() As Generic.SortedDictionary(Of Integer, PreviousPowerHistory)
            Get
                Return m_collection5
            End Get
            Set(ByVal value As Generic.SortedDictionary(Of Integer, PreviousPowerHistory))
                m_collection5 = value
            End Set
        End Property

        ' Protected m_status As PipeEditorStatus = PipeEditorStatus.Definir

        Private _InitialTemperatures As Generic.SortedDictionary(Of Integer, String)
        Public Property InitialTemperatures() As Generic.SortedDictionary(Of Integer, String)
            Get
                Return _InitialTemperatures
            End Get
            Set(ByVal value As Generic.SortedDictionary(Of Integer, String))
                _InitialTemperatures = value
            End Set
        End Property

        Public Property RadialMeshSpacing() As Generic.SortedDictionary(Of Integer, RadialMeshSpacing)
            Get
                Return m_collection3
            End Get
            Set(ByVal value As Generic.SortedDictionary(Of Integer, RadialMeshSpacing))
                m_collection3 = value
            End Set
        End Property
        Public Property FuelRodDimensions() As Generic.SortedDictionary(Of Integer, FuelRodDimensions)
            Get
                Return m_collection
            End Get
            Set(ByVal value As Generic.SortedDictionary(Of Integer, FuelRodDimensions))
                m_collection = value
            End Set
        End Property

        Public Property HyrdraulicVolumes() As Generic.SortedDictionary(Of Integer, HydraulicVolumes)
            Get
                Return m_collection2
            End Get
            Set(ByVal value As Generic.SortedDictionary(Of Integer, HydraulicVolumes))
                m_collection2 = value
            End Set
        End Property

        Public Sub New()
            m_collection = New Generic.SortedDictionary(Of Integer, FuelRodDimensions)
            m_collection2 = New Generic.SortedDictionary(Of Integer, HydraulicVolumes)
            m_collection3 = New Generic.SortedDictionary(Of Integer, RadialMeshSpacing)
            m_collection4 = New Generic.SortedDictionary(Of Integer, RadialPowerProfile)
            _InitialTemperatures = New Generic.SortedDictionary(Of Integer, String)
            m_collection5 = New Generic.SortedDictionary(Of Integer, PreviousPowerHistory)
            m_AxialPowerFactor = New Generic.SortedDictionary(Of Integer, Double)
        End Sub
        Public Overrides Function ToString() As String
            Return "Click to Edit..."
        End Function

    End Class
    <Serializable()> Public Class FuelRodDimensions
        Private m_FuelPelletRadius As Double
        Public Property FuelPelletRadius() As Double
            Get
                Return m_FuelPelletRadius
            End Get
            Set(ByVal value As Double)
                m_FuelPelletRadius = value
            End Set
        End Property

        Private m_InnerCladdingRadius As Double
        Public Property InnerCladdingRadius() As Double
            Get
                Return m_InnerCladdingRadius
            End Get
            Set(ByVal value As Double)
                m_InnerCladdingRadius = value
            End Set
        End Property

        Private m_OuterCladdingRadius As Double
        Public Property OuterCladdingRadius() As Double
            Get
                Return m_OuterCladdingRadius
            End Get
            Set(ByVal value As Double)
                m_OuterCladdingRadius = value
            End Set
        End Property

        Private m_FuelRodDimensionsAxialNode As Integer
        Public Property FuelRodDimensionsAxialNode() As Integer
            Get
                Return m_FuelRodDimensionsAxialNode
            End Get
            Set(ByVal value As Integer)
                m_FuelRodDimensionsAxialNode = value
            End Set
        End Property
        Public Sub New(ByVal FuelPelletRadius As Double, ByVal InnerCladdingRadius As Double, ByVal OuterCladdingRadius As Double, ByVal AxialNode As Integer)
            Me.m_FuelPelletRadius = FuelPelletRadius
            Me.m_FuelRodDimensionsAxialNode = AxialNode
            m_InnerCladdingRadius = InnerCladdingRadius
            m_OuterCladdingRadius = OuterCladdingRadius
        End Sub
    End Class

    <Serializable()> Public Class HydraulicVolumes

        Private m_ControlVolumeNumber As String
        Public Property ControlVolumeNumber() As String
            Get
                Return m_ControlVolumeNumber
            End Get
            Set(ByVal value As String)
                m_ControlVolumeNumber = value
            End Set
        End Property

        Private m_Increment As Integer
        Public Property Increment() As Integer
            Get
                Return m_Increment
            End Get
            Set(ByVal value As Integer)
                m_Increment = value
            End Set
        End Property

        Private m_AxialNode As Integer
        Public Property AxialNode() As Integer
            Get
                Return m_AxialNode
            End Get
            Set(ByVal value As Integer)
                m_AxialNode = value
            End Set
        End Property



        Public Sub New(ByVal HydralicVolume As String, ByVal Increment As Integer, ByVal AxialNode As Integer)
            m_AxialNode = AxialNode
            m_ControlVolumeNumber = HydralicVolume
            m_Increment = Increment
        End Sub
    End Class

    <Serializable()> Public Class RadialMeshSpacing

        Private _NumberofIntervalsAcrossFuel As Integer
        Public Property NumberofIntervalsAcrossFuel() As Integer
            Get
                Return _NumberofIntervalsAcrossFuel
            End Get
            Set(ByVal value As Integer)
                _NumberofIntervalsAcrossFuel = value
            End Set
        End Property

        Private _NumberofIntervalsAcrossGap As Integer
        Public Property NumberofIntervalsAcrossGap() As Integer
            Get
                Return _NumberofIntervalsAcrossGap
            End Get
            Set(ByVal value As Integer)
                _NumberofIntervalsAcrossGap = value
            End Set
        End Property


        Private _NumberofIntervalsAcrossCladding As Integer
        Public Property NumberofIntervalsAcrossCladding() As Integer
            Get
                Return _NumberofIntervalsAcrossCladding
            End Get
            Set(ByVal value As Integer)
                _NumberofIntervalsAcrossCladding = value
            End Set
        End Property


        Private _AxialNode As Integer
        Public Property AxialNode() As Integer
            Get
                Return _AxialNode
            End Get
            Set(ByVal value As Integer)
                _AxialNode = value
            End Set
        End Property

        Public Sub New(ByVal IntervalsAcrossFuel As Integer, ByVal AcrossCladding As Integer, ByVal AcrossGap As Integer, ByVal AxialNode As Integer)
            _NumberofIntervalsAcrossCladding = AcrossCladding
            _NumberofIntervalsAcrossFuel = IntervalsAcrossFuel
            _NumberofIntervalsAcrossGap = AcrossGap
            _AxialNode = AxialNode
        End Sub
    End Class
    <Serializable()> Public Class RadialPowerProfile

        Private _RadialPowerFactor As Double
        Public Property RadialPowerFactor() As Double
            Get
                Return _RadialPowerFactor
            End Get
            Set(ByVal value As Double)
                _RadialPowerFactor = value
            End Set
        End Property

        Private _RadialNode As Integer
        Public Property RadialNode() As Integer
            Get
                Return _RadialNode
            End Get
            Set(ByVal value As Integer)
                _RadialNode = value
            End Set
        End Property


        Public Sub New(ByVal RadialPowerFactor As Double, ByVal RadialNode As Integer)
            _RadialNode = RadialNode
            _RadialPowerFactor = RadialPowerFactor
        End Sub
    End Class
    <Serializable()> Public Class PreviousPowerHistory

        Private _PowerHistory As Double
        Public Property PowerHistory() As Double
            Get
                Return _PowerHistory
            End Get
            Set(ByVal value As Double)
                _PowerHistory = value
            End Set
        End Property


        Private _Time As Double
        Public Property Time() As Double
            Get
                Return _Time
            End Get
            Set(ByVal value As Double)
                _Time = value
            End Set
        End Property



        Public Sub New(ByVal PowerHistory As Double, ByVal Time As Double)
            _Time = Time
            _PowerHistory = PowerHistory
        End Sub
    End Class
End Namespace



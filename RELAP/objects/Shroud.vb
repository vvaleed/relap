'    Fuel Rod Calculation Routines 
'    Copyright 2013 Sarah 
'
'    This file is part of RELAP.
'
'    RELAP is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    RELAP is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    

Imports Microsoft.Msdn.Samples.GraphicObjects
'Imports RELAP.RELAP.Flowsheet.FlowSheetSolver

Namespace RELAP.SimulationObjects.UnitOps

    <System.Serializable()> Public Class Shroud

        Inherits SimulationObjects_UnitOpBaseClass

        Private m_ShroudComponentName As String
        Public Property ShroudComponentName() As String
            Get
                Return m_ShroudComponentName
            End Get
            Set(ByVal value As String)
                m_ShroudComponentName = value
            End Set
        End Property

        Private m_NumberOfBoxStructure As Integer
        Public Property NumberOfBoxStructure() As Integer
            Get
                Return m_NumberOfBoxStructure
            End Get
            Set(ByVal value As Integer)
                m_NumberOfBoxStructure = value
            End Set
        End Property

        Private m_NumberOfAbsorberTubes As Integer
        Public Property NumberOfAbsorberTubes() As Integer
            Get
                Return m_NumberOfAbsorberTubes
            End Get
            Set(ByVal value As Integer)
                m_NumberOfAbsorberTubes = value
            End Set
        End Property

        Private m_InsideDiameterAbsorberTube As Double
        Public Property InsideDiameterAbsorberTube() As Double
            Get
                Return m_InsideDiameterAbsorberTube
            End Get
            Set(ByVal value As Double)
                m_InsideDiameterAbsorberTube = value
            End Set
        End Property

        Private m_ThicknessSSAbsorberTubeWall As Double
        Public Property ThicknessSSAbsorberTubeWall() As Double
            Get
                Return m_ThicknessSSAbsorberTubeWall
            End Get
            Set(ByVal value As Double)
                m_ThicknessSSAbsorberTubeWall = value
            End Set
        End Property

        Private m_ThicknessOfGap As Double
        Public Property ThicknessOfGap() As Double
            Get
                Return m_ThicknessOfGap
            End Get
            Set(ByVal value As Double)
                m_ThicknessOfGap = value
            End Set
        End Property

        Private m_ThicknessSSControlBladeSheath As Double
        Public Property ThicknessSSControlBladeSheath() As Double
            Get
                Return m_ThicknessSSControlBladeSheath
            End Get
            Set(ByVal value As Double)
                m_ThicknessSSControlBladeSheath = value
            End Set
        End Property


        Private m_Distance As Double
        Public Property Distance() As Double
            Get
                Return m_Distance
            End Get
            Set(ByVal value As Double)
                m_Distance = value
            End Set
        End Property

        Private m_ThicknessOfZrChannelBoxWall As Double
        Public Property ThicknessOfZrChannelBoxWall() As Double
            Get
                Return m_ThicknessOfZrChannelBoxWall
            End Get
            Set(ByVal value As Double)
                m_ThicknessOfZrChannelBoxWall = value
            End Set
        End Property

        Private m_WettedPerimeterChannelBoxSegment1 As Double
        Public Property WettedPerimeterChannelBoxSegment1() As Double
            Get
                Return m_WettedPerimeterChannelBoxSegment1
            End Get
            Set(ByVal value As Double)
                m_WettedPerimeterChannelBoxSegment1 = value
            End Set
        End Property

        Private m_WettedPerimeterChannelBoxSegment2 As Double
        Public Property WettedPerimeterChannelBoxSegment2() As Double
            Get
                Return m_WettedPerimeterChannelBoxSegment2
            End Get
            Set(ByVal value As Double)
                m_WettedPerimeterChannelBoxSegment2 = value
            End Set
        End Property

        Private m_GeometricViewFactorFromChannelBoxSegment1 As Integer
        Public Property GeometricViewFactorFromChannelBoxSegment1() As Integer
            Get
                Return m_GeometricViewFactorFromChannelBoxSegment1
            End Get
            Set(ByVal value As Integer)
                m_GeometricViewFactorFromChannelBoxSegment1 = value
            End Set
        End Property

        Private m_GeometricViewFactorFromChannelBoxSegment2 As Integer
        Public Property GeometricViewFactorFromChannelBoxSegment2() As Integer
            Get
                Return m_GeometricViewFactorFromChannelBoxSegment2
            End Get
            Set(ByVal value As Integer)
                m_GeometricViewFactorFromChannelBoxSegment2 = value
            End Set
        End Property


        Private m_VolumeNumberAbove As Integer
        Public Property VolumeNumberAbove() As Integer
            Get
                Return m_VolumeNumberAbove
            End Get
            Set(ByVal value As Integer)
                m_VolumeNumberAbove = value
            End Set
        End Property


        Private m_VolumeNumberBelow As Integer
        Public Property VolumeNumberBelow() As Integer
            Get
                Return m_VolumeNumberBelow
            End Get
            Set(ByVal value As Integer)
                m_VolumeNumberBelow = value
            End Set
        End Property


        Private m_VolumeNumberFuelBundleSide As Integer
        Public Property VolumeNumberFuelBundleSide() As Integer
            Get
                Return m_VolumeNumberFuelBundleSide
            End Get
            Set(ByVal value As Integer)
                m_VolumeNumberFuelBundleSide = value
            End Set
        End Property

        Private m_VolumeNumberControlBladeAxialNodeSide As Integer
        Public Property VolumeNumberControlBladeAxialNodeSide() As Integer
            Get
                Return m_VolumeNumberControlBladeAxialNodeSide
            End Get
            Set(ByVal value As Integer)
                m_VolumeNumberControlBladeAxialNodeSide = value
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

        Private m_InitialThicknessFuelBundleSide As Double
        Public Property InitialThicknessFuelBundleSide() As Double
            Get
                Return m_InitialThicknessFuelBundleSide
            End Get
            Set(ByVal value As Double)
                m_InitialThicknessFuelBundleSide = value
            End Set
        End Property

        Private m_InitialThicknessInterstitialSide As Double
        Public Property InitialThicknessInterstitialSide() As Double
            Get
                Return m_InitialThicknessInterstitialSide
            End Get
            Set(ByVal value As Double)
                m_InitialThicknessInterstitialSide = value
            End Set
        End Property


        Private m_InitialThicknessSSOxideLayer As Double
        Public Property InitialThicknessSSOxideLayer() As Double
            Get
                Return m_InitialThicknessSSOxideLayer
            End Get
            Set(ByVal value As Double)
                m_InitialThicknessSSOxideLayer = value
            End Set
        End Property

        Private m_InitialTemperaturesControlBlade As Integer
        Public Property InitialTemperaturesControlBlade() As Integer
            Get
                Return m_InitialTemperaturesControlBlade
            End Get
            Set(ByVal value As Integer)
                m_InitialTemperaturesControlBlade = value
            End Set
        End Property


        Private m_InitialTemperaturesChannelBox As Integer
        Public Property InitialTemperaturesChannelBox() As Integer
            Get
                Return m_InitialTemperaturesChannelBox
            End Get
            Set(ByVal value As Integer)
                m_InitialTemperaturesChannelBox = value
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


        Private m_ComponentNumberS1 As Integer
        Public Property ComponentNumberS1() As Integer
            Get
                Return m_ComponentNumberS1
            End Get
            Set(ByVal value As Integer)
                m_ComponentNumberS1 = value
            End Set
        End Property

        Private m_ComponentNumberS2 As Integer
        Public Property ComponentNumberS2() As Integer
            Get
                Return m_ComponentNumberS2
            End Get
            Set(ByVal value As Integer)
                m_ComponentNumberS2 = value
            End Set
        End Property


        Private m_MassFractionS1 As Double
        Public Property MassFractionS1() As Double
            Get
                Return m_MassFractionS1
            End Get
            Set(ByVal value As Double)
                m_MassFractionS1 = value
            End Set
        End Property

        Private m_MassFractionS2 As Double
        Public Property MassFractionS2() As Double
            Get
                Return m_MassFractionS2
            End Get
            Set(ByVal value As Double)
                m_MassFractionS2 = value
            End Set
        End Property





        Public Sub New(ByVal nome As String, ByVal descricao As String)

            MyBase.CreateNew()
            Me.m_ComponentName = nome
            Me.m_ComponentDescription = descricao
            Me.FillNodeItems()
            Me.QTFillNodeItems()
        End Sub


        Public Overrides Function Calculate(Optional ByVal args As Object = Nothing) As Integer


            'Dim form As Global.RELAP.FormFlowsheet = My.Application.ActiveSimulation
            'Dim Ti, Pi, Hi, Wi, rho_li, qli, qvi, ei, ein, P2, Q As Double

            'qvi = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(2).SPMProperties.volumetric_flow.GetValueOrDefault.ToString

            'Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            'If qvi > 0 Then
            '    'Call function to calculate flowsheet
            '    With objargs
            '        .Calculado = False
            '        .Nome = Me.Nome
            '        .Tipo = TipoObjeto.Tank
            '    End With
            '    CalculateFlowsheet(FlowSheet, objargs, Nothing)
            '    Throw New Exception(RELAP.App.GetLocalString("Existeumafasevaporna2"))
            'ElseIf Not Me.GraphicObject.OutputConnectors(0).IsAttached Then
            '    'Call function to calculate flowsheet
            '    With objargs
            '        .Calculado = False
            '        .Nome = Me.Nome
            '        .Tipo = TipoObjeto.Tank
            '    End With
            '    CalculateFlowsheet(FlowSheet, objargs, Nothing)
            '    Throw New Exception(RELAP.App.GetLocalString("Verifiqueasconexesdo"))
            'ElseIf Not Me.GraphicObject.InputConnectors(0).IsAttached Then
            '    'Call function to calculate flowsheet
            '    With objargs
            '        .Calculado = False
            '        .Nome = Me.Nome
            '        .Tipo = TipoObjeto.Tank
            '    End With
            '    CalculateFlowsheet(FlowSheet, objargs, Nothing)
            '    Throw New Exception(RELAP.App.GetLocalString("Verifiqueasconexesdo"))
            'End If

            'Me.PropertyPackage.CurrentMaterialStream = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name)
            'Ti = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).SPMProperties.temperature.GetValueOrDefault.ToString
            'Pi = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).SPMProperties.pressure.GetValueOrDefault.ToString
            'rho_li = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(1).SPMProperties.density.GetValueOrDefault.ToString
            'qli = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(1).SPMProperties.volumetric_flow.GetValueOrDefault.ToString
            'Hi = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).SPMProperties.enthalpy.GetValueOrDefault.ToString
            'Wi = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).SPMProperties.massflow.GetValueOrDefault.ToString
            'Q = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).SPMProperties.volumetric_flow.GetValueOrDefault
            'ei = Hi * Wi
            'ein = ei

            'P2 = Pi - Me.DeltaP.GetValueOrDefault

            ''Atribuir valores à corrente de matéria conectada à jusante
            'With form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.OutputConnectors(0).AttachedConnector.AttachedTo.Name)
            '    .Fases(0).SPMProperties.temperature = Ti
            '    .Fases(0).SPMProperties.pressure = P2
            '    .Fases(0).SPMProperties.enthalpy = Hi
            '    Dim comp As RELAP.ClassesBasicasTermodinamica.Substancia
            '    Dim i As Integer = 0
            '    For Each comp In .Fases(0).Componentes.Values
            '        comp.FracaoMolar = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).Componentes(comp.Nome).FracaoMolar
            '        comp.FracaoMassica = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).Componentes(comp.Nome).FracaoMassica
            '        i += 1
            '    Next
            '    .Fases(0).SPMProperties.massflow = form.Collections.CLCS_MaterialStreamCollection(Me.GraphicObject.InputConnectors(0).AttachedConnector.AttachedFrom.Name).Fases(0).SPMProperties.massflow.GetValueOrDefault
            'End With

            'Me.ResidenceTime = Me.Volume / Q

            ''Call function to calculate flowsheet
            'With objargs
            '    .Calculado = True
            '    .Nome = Me.Nome
            '    .Tipo = TipoObjeto.Tank
            'End With

            'form.CalculationQueue.Enqueue(objargs)
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

                valor = Me.ShroudComponentName
                'Tank Volume,Calculation parameters, Tank Volume
                .Item.Add("Component Name", valor, False, "Component Name", "Word 2 is 'fuel' which is constant for fuel", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(String)
                End With


                valor = Me.NumberOfBoxStructure
                .Item.Add("Number of individual BWR blade/box structures", valor, False, "No. of Individual Structure", "The range is 1 ≤ x. Rod absorber tubes length equal to Word 1 on Card 4CCC0300 and a channel box with length equal to the sum of Words 1 and 2 on Card 4CCC0300. Total mass = Mass of an individual blade/box structure X value on this card.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.NumberOfAbsorberTubes
                .Item.Add("Number of absorber tubes", valor, False, "Radial Dimensions", "TThe length (wetted perimeter) of a control blade is specified in Word 1 on Card 4CCC0300. The range is 1 ≤ x.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With


                valor = Format(Conversor.ConverterDoSI(su.distance, Me.InsideDiameterAbsorberTube), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Inside Diameter", su.distance), valor, False, "Radial Dimensions", "Stainless steel absorber tube. The range is 0.0 ≤ x ≤ 0.0070 m.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                valor = Format(Conversor.ConverterDoSI(su.distance, Me.ThicknessSSAbsorberTubeWall), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Thickness", su.distance), valor, False, "Radial Dimensions", "Of stainless steel absorber tube wall. The range is 0.0 ≤ x ≤ 0.0013 m", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.distance, Me.ThicknessOfGap), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Thickness of gap", su.distance), valor, False, "Radial Dimensions", "Between absorber tube and control blade sheath. The range is 0.0 ≤ x ≤ 0.0003 m.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.distance, Me.ThicknessSSControlBladeSheath), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Thickness", su.distance), valor, False, "Radial Dimensions", "Stainless steel control blade sheath. The range is 0.0 ≤ x ≤ 0.0030 m", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.distance, Me.Distance), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Distance", su.distance), valor, False, "Radial Dimensions", "Between control blade and channel box. The range is 0.0 ≤ x ≤ 0.0100 m.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                valor = Format(Conversor.ConverterDoSI(su.distance, Me.ThicknessOfZrChannelBoxWall), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Thickness"), su.distance), valor, False, "Radial Dimensions", "Of zircaloy channel box wall. The range is 0.0 ≤ x ≤ 0.0050 m.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.distance, Me.WettedPerimeterChannelBoxSegment1), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Length (wetted perimeter) channel box segment 1"), su.distance), valor, False, "Blade/Box Lengths and View Factors", "Of control blade and channel box segment number 1. The range is 0.0 m ≤ x.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.distance, Me.WettedPerimeterChannelBoxSegment2), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Length (wetted perimeter) channel box segment 1"), su.distance), valor, False, "Blade/Box Lengths and View Factors", "Of control blade and channel box segment number 2. The range is 0.0 m ≤ x.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.GeometricViewFactorFromChannelBoxSegment1
                .Item.Add("Geometric view factor from channel box segment 1", valor, False, "Blade/Box Lengths and View Factors", "To control blade. Based on area of channel box segment 1. The range is 0.0 ≤ x ≤ 1.0.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.GeometricViewFactorFromChannelBoxSegment2
                .Item.Add("Geometric view factor from channel box segment 2", valor, False, "Blade/Box Lengths and View Factors", "To control blade. Based on area of channel box segment 2. The range is 0.0 ≤ x ≤ 1.0.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.VolumeNumberAbove
                .Item.Add("Volume number above", valor, False, "Upper and Lower Volume Numbers", "Of hydraulic volume just above the fuel bundle volumes specified in Word 1 on Cards 4CCC0401 through 4CCC0499.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With


                valor = Me.VolumeNumberBelow
                .Item.Add("Volume number below", valor, False, "Upper and Lower Volume Numbers", "Of hydraulic volume just below the fuel bundle volumes specified in Word 1 on Cards 4CCC0401 through 4CCC0499.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.VolumeNumberFuelBundleSide
                .Item.Add("Volume number", valor, False, "Volume Connections", "Of hydraulic volume connected to fuel bundle side of channel box axial node.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.VolumeNumberControlBladeAxialNodeSide
                .Item.Add("Volume number", valor, False, "Volume Connections", "Of hydraulic volume connected to control blade axial node and interstitial side of channel box axial node", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.AxialNode
                .Item.Add("Axial Node", valor, False, "Volume Connections", "Range is 1 ≤ x ≤ N, where N is the number of axial nodes specified on Card 40000100.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.Increment
                .Item.Add("Increment", valor, False, "Volume Connections", "Can be 0,+ve,-ve", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Format(Conversor.ConverterDoSI(su.distance, Me.InitialThicknessFuelBundleSide), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Initial thickness "), su.distance), valor, False, "Initial Oxide Thicknesses", "ZrO2 layer on fuel bundle side of channel box. Default is 0.0 m and Range is 0.0 m ≤ x ≤ 0.5*W7 on Card 4CCC0200.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                valor = Format(Conversor.ConverterDoSI(su.distance, Me.InitialThicknessInterstitialSide), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Initial thickness "), su.distance), valor, False, "Initial Oxide Thicknesses", "ZrO2 layer on interstitial side of channel box. Default is 0.0 m and Range is 0.0 m ≤ x ≤ 0.5*W7 on Card 4CCC0200.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.distance, Me.InitialThicknessSSOxideLayer), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Initial thickness "), su.distance), valor, False, "Initial Oxide Thicknesses", "Stainless steel oxide layer on control blade surfaces. Default is 0.0 and the range is 0.0≤x≤MIN (W3 on Card 4CCC0200, 0.5*W5 on Card 4CCC0200)", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                valor = Format(Conversor.ConverterDoSI(su.spmp_temperature, Me.InitialTemperaturesControlBlade), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Initial Temperature"), su.spmp_temperature), valor, False, "Initial Temperatures", "Control blade. Range is 300 ≤ x ≤ 1505 K", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                valor = Format(Conversor.ConverterDoSI(su.spmp_temperature, Me.InitialTemperaturesChannelBox), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Initial Temperature"), su.spmp_temperature), valor, False, "Initial Temperatures", "Channel Box. Range is 300 ≤ x ≤ 1505 K", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.InitialTemperaturesAxialNode
                .Item.Add("Axial Node", valor, False, "Initial Temperature", "Range is 1 ≤ x ≤ N, where N is the number of axial nodes specified on Card 40000100. ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.ComponentNumberS1
                .Item.Add("Component number", valor, False, "Segment 1 Radial Spreading", "Of fuel rod or electrically-heated simulator rod component that can receive molten material from channel box segment 1.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.MassFractionS1
                .Item.Add("Mass Fraction", valor, False, "Segment 1 Radial Spreading", "Of molten material from channel box segment 1 received by component specified in Word 1. Range for each is 1.0e-6 ≤ x ≤ 1.0. Sum of all on Cards 4CCC0701 through 4CCC0799 must be unity.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                valor = Me.ComponentNumberS2
                .Item.Add("Component number", valor, False, "Segment 2 Radial Spreading", "Of fuel rod or electrically-heated simulator rod component that can receive molten material from channel box segment 2.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                valor = Me.MassFractionS2
                .Item.Add("Mass Fraction", valor, False, "Segment 2 Radial Spreading", "Of molten material from channel box segment 2 received by component specified in Word 1. Range for each is 1.0e-6 ≤ x ≤ 1.0. Sum of all on Cards 4CCC0701 through 4CCC0799 must be unity.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
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

End Namespace



'    Tank Calculation Routines 
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
'    You should have received a copy of the GNU General Public License
'    along with RELAP.  If not, see <http://www.gnu.org/licenses/>.

Imports Microsoft.Msdn.Samples.GraphicObjects
'Imports RELAP.RELAP.Flowsheet.FlowSheetSolver

Namespace RELAP.SimulationObjects.UnitOps

    <System.Serializable()> Public Class Simulator

        Inherits SimulationObjects_UnitOpBaseClass

        Private m_SimulatorComponentName As String
        Public Property SimulatorComponentName() As String
            Get
                Return m_SimulatorComponentName
            End Get
            Set(ByVal value As String)
                m_SimulatorComponentName = value
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

        Private m_RodPitch As Double
        Public Property RodPitch() As Double
            Get
                Return m_RodPitch
            End Get
            Set(ByVal value As Double)
                m_RodPitch = value
            End Set
        End Property

        Private m_TungstenElectrodeRadius As Double
        Public Property TungstenElectrodeRadius() As Double
            Get
                Return m_TungstenElectrodeRadius
            End Get
            Set(ByVal value As Double)
                m_TungstenElectrodeRadius = value
            End Set
        End Property


        Private m_PlenumVolume As Double
        Public Property PlenumVolume() As Double
            Get
                Return m_PlenumVolume
            End Get
            Set(ByVal value As Double)
                m_PlenumVolume = value
            End Set
        End Property


        Private m_UpperPlenumKeyword As String
        Public Property UpperPlenumKeyword() As String
            Get
                Return m_UpperPlenumKeyword
            End Get
            Set(ByVal value As String)
                m_UpperPlenumKeyword = value
            End Set
        End Property


        Private m_LowerPlenumKeyword As String
        Public Property LowerPlenumKeyword() As String
            Get
                Return m_LowerPlenumKeyword
            End Get
            Set(ByVal value As String)
                m_LowerPlenumKeyword = value
            End Set
        End Property


        Private m_UpperPlenumTableNumber As Integer
        Public Property UpperPlenumTableNumber() As Integer
            Get
                Return m_UpperPlenumTableNumber
            End Get
            Set(ByVal value As Integer)
                m_UpperPlenumTableNumber = value
            End Set
        End Property

        Private m_LowerPlenumTableNumber As Integer
        Public Property LowerPlenumTableNumber() As Integer
            Get
                Return m_LowerPlenumTableNumber
            End Get
            Set(ByVal value As Integer)
                m_LowerPlenumTableNumber = value
            End Set
        End Property

        Private m_TungstenRadius As Double
        Public Property TungstenRadius() As Double
            Get
                Return m_TungstenRadius
            End Get
            Set(ByVal value As Double)
                m_TungstenRadius = value
            End Set
        End Property

        Private m_ContactResistance As Double
        Public Property ContactResistance() As Double
            Get
                Return m_ContactResistance
            End Get
            Set(ByVal value As Double)
                m_ContactResistance = value
            End Set
        End Property

        Private m_MoCuElectrodeRadius As Double
        Public Property MoCuElectrodeRadius() As Double
            Get
                Return m_MoCuElectrodeRadius
            End Get
            Set(ByVal value As Double)
                m_MoCuElectrodeRadius = value
            End Set
        End Property

        Private m_MoCuElectrodeNumber As Integer
        Public Property MoCuElectrodeNumber() As Integer
            Get
                Return m_MoCuElectrodeNumber
            End Get
            Set(ByVal value As Integer)
                m_MoCuElectrodeNumber = value
            End Set
        End Property

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

        Private m_SimulatorDimensionsAxialNode As Integer
        Public Property SimulatorDimensionsAxialNode() As Integer
            Get
                Return m_SimulatorDimensionsAxialNode
            End Get
            Set(ByVal value As Integer)
                m_SimulatorDimensionsAxialNode = value
            End Set
        End Property

        Private m_VolumeAboveSimulator As Double
        Public Property VolumeAboveSimulator() As Double
            Get
                Return m_VolumeAboveSimulator
            End Get
            Set(ByVal value As Double)
                m_VolumeAboveSimulator = value
            End Set
        End Property

        Private m_VolumeBelowSimulator As Double
        Public Property VolumeBelowSimulator() As Double
            Get
                Return m_VolumeBelowSimulator
            End Get
            Set(ByVal value As Double)
                m_VolumeBelowSimulator = value
            End Set
        End Property

        Private m_VolumeNumber As Integer
        Public Property VolumeNumber() As Integer
            Get
                Return m_VolumeNumber
            End Get
            Set(ByVal value As Integer)
                m_VolumeNumber = value
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


        Private m_InitialTemperatureAtNode1 As Double
        Public Property TemperatureAtNode1() As Double
            Get
                Return m_InitialTemperatureAtNode1
            End Get
            Set(ByVal value As Double)
                m_InitialTemperatureAtNode1 = value
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

        Private m_RadialNode As Integer
        Public Property RadialNode() As Integer
            Get
                Return m_RadialNode
            End Get
            Set(ByVal value As Integer)
                m_RadialNode = value
            End Set
        End Property

        Private m_VolumeofExternalVolumes As Double
        Public Property VolumeofExternalVolumes() As Double
            Get
                Return m_VolumeofExternalVolumes
            End Get
            Set(ByVal value As Double)
                m_VolumeofExternalVolumes = value
            End Set
        End Property


        Private m_TemperatureofExternalVolume As Double
        Public Property TemperaturefExternalVolumes() As Double
            Get
                Return m_TemperatureofExternalVolume
            End Get
            Set(ByVal value As Double)
                m_TemperatureofExternalVolume = value
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
                '.Item.Add(FT(RELAP.App.GetLocalString("Quedadepresso"), su.spmp_deltaP), valor, False, RELAP.App.GetLocalString("Parmetrosdeclculo2"), RELAP.App.GetLocalString("Quedadepressoaplicad5"), True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Nullable(Of Double))
                'End With
                ''desi kaam

                ''.Item.Add("Flow Area", FlowArea())



                ' '''''''''''''

                valor = Me.ComponentName
                'Tank Volume,Calculation parameters, Tank Volume
                .Item.Add("Component Name", valor, False, "Simulator Component", "Word 2 is 'cora' which is constant for simulators", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(String)
                End With


                valor = Me.NumberOfRods
                .Item.Add("No. of rods", valor, False, "No. of Rods", " ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Format(Conversor.ConverterDoSI(su.distance, Me.RodPitch), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Rod Pitch", su.distance), valor, False, "No. of Rods", "0.0126 M ≤ x ≤ 0.0187 m.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Conversor.ConverterDoSI(su.burnup, Me.TungstenElectrodeRadius), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Tungsten Electrode Radius", su.distance), valor, False, "No. of Rods", "If this word is 0.0, then Card 400CC0300 must be input", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.volume, Me.PlenumVolume), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Plenum Volume", su.volume), valor, False, "Simulator Rod Geometry", "0.0 < x ≤ 0.000049", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.volume, Me.UpperPlenumKeyword), FlowSheet.Options.NumberFormat)
                .Item.Add("Keyword ", valor, False, "Upper Plenum Boundary Conditions", "Default is no axial heat conduction is modeled. 'control' is sink temperature defined by control variable. 'table' is sink temperature defined by general table", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(String)
                End With

                valor = Format(Conversor.ConverterDoSI(su.volume, Me.LowerPlenumKeyword), FlowSheet.Options.NumberFormat)
                .Item.Add("Keyword ", valor, False, "Lower Plenum Boundary Conditions", "Default is no axial heat conduction is modeled. 'control' is sink temperature defined by control variable. 'table' is sink temperature defined by general table", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(String)
                End With

                valor = Format(Conversor.ConverterDoSI(su.volume, Me.UpperPlenumTableNumber), FlowSheet.Options.NumberFormat)
                .Item.Add("Table Number ", valor, False, "Upper Plenum Boundary Conditions", "Or upper boundary control variable ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Format(Conversor.ConverterDoSI(su.volume, Me.LowerPlenumKeyword), FlowSheet.Options.NumberFormat)
                .Item.Add("Table Number ", valor, False, "Lower Plenum Boundary Conditions", "Or lower boundary control variable ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With


                valor = Format(Conversor.ConverterDoSI(su.distance, Me.TungstenRadius), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Tungsten Radius"), su.distance), valor, False, "Simulator Electrode Dimensions", "0.00385 m ≤ x ≤ 0.00685 m", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                valor = Format(Conversor.ConverterDoSI(su.distance, Me.ContactResistance), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Contact Resistance"), su.resistance), valor, False, "Simulator Electrode Dimensions", "The range is 0.0 to 1.0", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.distance, Me.MoCuElectrodeNumber), FlowSheet.Options.NumberFormat)
                .Item.Add("Number of Molybdenum/copper electrode", valor, False, "Simulator Electrode Dimensions", "At the top and bottom of tungsten. The nodes in middle are Tn. If this number is -ve, the bottom and top node is Cu and the rest are Mo. If this number is +ve, all of the electrode nodes are Mo. This number must be between 0 and no. of axial nodes/2.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With


                valor = Format(Conversor.ConverterDoSI(su.distance, Me.MoCuElectrodeRadius), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Molybdenum/copper electrode radius "), su.distance), valor, False, "Simulator Electrode Dimensions", "The range is 0.0 m < x < 0.00685 m.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                valor = Format(Conversor.ConverterDoSI(su.distance, Me.FuelPelletRadius), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Fuel pellet radius "), su.distance), valor, False, "Simulator Dimensions", "0.00385 m ≤ x ≤ 0.00685 m", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.distance, Me.InnerCladdingRadius), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Inner cladding radius "), su.distance), valor, False, "Simulator Dimensions", "0.003935 m ≤ x ≤ 0.00634 m", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.distance, Me.OuterCladdingRadius), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Outer cladding radius"), su.distance), valor, False, "Simulator Dimensions", "0.00457 m ≤ x ≤ 0.00715 m", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.SimulatorDimensionsAxialNode
                .Item.Add("Axial node", valor, False, "Simulator Dimensions", "Hypothetical axis lines", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Format(Conversor.ConverterDoSI(su.volume, Me.VolumeAboveSimulator), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Volume Above Simulator"), su.volume), valor, False, "Upper and Lower Hydraulic Volumes", "Volume located above simulator rod.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.volume, Me.VolumeBelowSimulator), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Volume Below Simulator"), su.volume), valor, False, "Upper and Lower Hydraulic Volumes", "Volume located below simulator rod.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.VolumeNumber
                .Item.Add("Volume Number", valor, False, "Hydraulic Volumes", "Starting from node 1 upwards axially", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Format(Conversor.ConverterDoSI(su.distance, Me.RadiusToRadialNode1), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Radius To Radial Node 1"), su.distance), valor, False, "Radial Mesh Spacing", "Enter pellet center radius of 0.0.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.distance, Me.RadiusToRadialNodeN), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Radius To Radial Node N"), su.distance), valor, False, "Radial Mesh Spacing", "Enter radial node N. Ascending order and last node placed on the cladding outer surface.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.RadialMeshSpacingAxialNode
                .Item.Add("Axial Node", valor, False, "Radial Mesh Spacing", "Hypothetical axis lines.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Format(Conversor.ConverterDoSI(su.spmp_temperature, Me.TemperatureAtNode1), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Temperature at Node 1"), su.spmp_temperature), valor, False, "Initial Temperatures", "The range is 300 K ≤ x ≤ 3123 K. Initial temperature of Node 1", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.Fraction
                .Item.Add("Fraction", valor, False, "Power Multiplier", "The range is 0.0 ≤ x ≤ 1.0, default is 0.0", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.time, Me.TimeForWhichAxialPowerProfileApplies), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Time"), su.time), valor, False, "Axial Power Profile Time", "'P' is axial power profile number (start with Number 1).", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.AxialPowerFactor
                .Item.Add("AxialPowerFactor", valor, False, "Axial Power Profile Data", "The range is 0.1 ≤ x ≤ 1.4, default is 1.0.", True)
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
                .Item.Add("Radial Node", valor, False, "Radial Power Profile", "At which the power factor applies", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Format(Conversor.ConverterDoSI(su.time, Me.Time), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Time"), su.time), valor, False, "Temperature History of External Volumes", " ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.volume, Me.VolumeofExternalVolumes), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Volume of External Volumes"), su.volume), valor, False, "Volume of external volumes", "Up to 10 external volumes may be specified", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.pdp_meltingTemperature, Me.TemperaturefExternalVolumes), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Temperature of External Volumes"), su.volume), valor, False, "Temperature History of External Volumes", "Word 2 is repeated for each external volume specified by card 40CC9000. A maximum of 10 time points may be specified.", True)
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




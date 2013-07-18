'    Tank Calculation Routines 
'    Copyright 2008 Daniel Wagner O. de Medeiros
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

    <System.Serializable()> Public Class SingleJunction

        Inherits SimulationObjects_UnitOpBaseClass

        Protected m_dp As Nullable(Of Double)
        Protected m_DQ As Nullable(Of Double)
        Protected m_vol As Double = 0
        Protected m_tRes As Double = 0

        Private m_EnterVelocityOrMassFlowRate As Boolean
        Public Property EnterVelocityOrMassFlowRate() As Boolean
            Get
                Return m_EnterVelocityOrMassFlowRate
            End Get
            Set(ByVal value As Boolean)
                m_EnterVelocityOrMassFlowRate = value
            End Set
        End Property

        Private m_InitialLiquidVelocity As Double
        Public Property InitialLiquidVelocity() As Double
            Get
                Return m_InitialLiquidVelocity
            End Get
            Set(ByVal value As Double)
                m_InitialLiquidVelocity = value
            End Set
        End Property

        Private m_InitialVaporVelocity As Double
        Public Property InitialVaporVelocity() As Double
            Get
                Return m_InitialVaporVelocity
            End Get
            Set(ByVal value As Double)
                m_InitialVaporVelocity = value
            End Set
        End Property

        Private m_InterphaseVelocity As Double
        Public Property InterphaseVelocity() As Double
            Get
                Return m_InterphaseVelocity
            End Get
            Set(ByVal value As Double)
                m_InterphaseVelocity = value
            End Set
        End Property

        Private m_InitialLiquidMassFlowRate As Double
        Public Property InitialLiquidMassFlowRate() As Double
            Get
                Return m_InitialLiquidMassFlowRate
            End Get
            Set(ByVal value As Double)
                m_InitialLiquidMassFlowRate = value
            End Set
        End Property

        Private m_InitialVaporMassFlowRate As Double
        Public Property InitialVaporMassFlowRate() As Double
            Get
                Return m_InitialVaporMassFlowRate
            End Get
            Set(ByVal value As Double)
                m_InitialVaporMassFlowRate = value
            End Set
        End Property

        Private m_InterphaseMassFlowRate As Double
        Public Property InterphaseMassFlowRate() As Double
            Get
                Return m_InterphaseMassFlowRate
            End Get
            Set(ByVal value As Double)
                m_InterphaseMassFlowRate = value
            End Set
        End Property

        Private m_ThermalStratificationModel As Boolean
        Public Property ThermalStratificationModel() As Boolean
            Get
                Return m_ThermalStratificationModel
            End Get
            Set(ByVal value As Boolean)
                m_ThermalStratificationModel = value
            End Set
        End Property

        Private m_LevelTrackingModel As Boolean
        Public Property LevelTrackingModel() As Boolean
            Get
                Return m_LevelTrackingModel
            End Get
            Set(ByVal value As Boolean)
                m_LevelTrackingModel = value
            End Set
        End Property

        Private m_InterphaseFriction As Boolean
        Public Property InterphaseFriction() As Boolean
            Get
                Return m_InterphaseFriction
            End Get
            Set(ByVal value As Boolean)
                m_InterphaseFriction = value
            End Set
        End Property

        Private m_ComputeWallFriction As Boolean
        Public Property ComputeWallFriction() As Boolean
            Get
                Return m_ComputeWallFriction
            End Get
            Set(ByVal value As Boolean)
                m_ComputeWallFriction = value
            End Set
        End Property

        Private m_EquilibriumTemp As Boolean
        Public Property EquilibriumTemperature() As Boolean
            Get
                Return m_EquilibriumTemp
            End Get
            Set(ByVal value As Boolean)
                m_EquilibriumTemp = value
            End Set
        End Property

        Private m_from As String
        Public Property FromComponent() As String
            Get
                Return m_from
            End Get
            Set(ByVal value As String)
                m_from = value
            End Set
        End Property


        Private m_to As String
        Public Property ToComponent() As String
            Get
                Return m_to
            End Get
            Set(ByVal value As String)
                m_to = value
            End Set
        End Property

        Private m_area As Double
        Public Property JunctionArea() As Double
            Get
                Return m_area
            End Get
            Set(ByVal value As Double)
                m_area = value
            End Set
        End Property

        Private m_subdisco As Double
        Public Property SubcooledDishargeCo() As Double
            Get
                Return m_subdisco
            End Get
            Set(ByVal value As Double)
                m_subdisco = value
            End Set
        End Property

        Private m_tpdisco As Double
        Public Property TwoPhaseDischargeCo() As Double
            Get
                Return m_tpdisco
            End Get
            Set(ByVal value As Double)
                m_tpdisco = value
            End Set
        End Property

        Private m_supdisco As Double
        Public Property SuperheatedDishargeCo() As Double
            Get
                Return m_supdisco
            End Get
            Set(ByVal value As Double)
                m_supdisco = value
            End Set
        End Property

        Private m_ffelc As Double
        Public Property FflowLossCo() As Double
            Get
                Return m_ffelc
            End Get
            Set(ByVal value As Double)
                m_ffelc = value
            End Set
        End Property

        Private m_rfelc As Double
        Public Property RflowLossCo() As Double
            Get
                Return m_rfelc
            End Get
            Set(ByVal value As Double)
                m_rfelc = value
            End Set
        End Property


        Public Sub New(ByVal nome As String, ByVal descricao As String)

            MyBase.CreateNew()
            Me.m_ComponentName = nome

            Me.m_ComponentDescription = descricao
            Me.m_InitialLiquidMassFlowRate = 0.0
            Me.m_InitialVaporMassFlowRate = 0.0
            Me.m_EnterVelocityOrMassFlowRate = True
            Me.FillNodeItems()
            Me.QTFillNodeItems()
        End Sub

        Public Property ResidenceTime() As Double
            Get
                Return m_tRes
            End Get
            Set(ByVal value As Double)
                m_tRes = value
            End Set
        End Property

        Public Property DeltaP() As Nullable(Of Double)
            Get
                Return m_dp
            End Get
            Set(ByVal value As Nullable(Of Double))
                m_dp = value
            End Set
        End Property

        Public Property DeltaQ() As Nullable(Of Double)
            Get
                Return m_DQ
            End Get
            Set(ByVal value As Nullable(Of Double))
                m_DQ = value
            End Set
        End Property

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

            With Me.QTNodeTableItems

                Dim valor As String

                If Me.DeltaP.HasValue Then
                    valor = Format(Conversor.ConverterDoSI(su.spmp_deltaP, Me.DeltaP), nf)
                Else
                    valor = RELAP.App.GetLocalString("NC")
                End If
                .Item(0).Value = valor
                .Item(0).Unit = su.spmp_deltaP

                If Me.DeltaQ.HasValue Then
                    valor = Format(Conversor.ConverterDoSI(su.spmp_heatflow, Me.DeltaQ), nf)
                Else
                    valor = RELAP.App.GetLocalString("NC")
                End If
                .Item(1).Value = valor
                .Item(1).Unit = su.spmp_heatflow

            End With


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
                Dim valor = Format(Conversor.ConverterDoSI(su.spmp_deltaP, Me.DeltaP.GetValueOrDefault), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT(RELAP.App.GetLocalString("Quedadepresso"), su.spmp_deltaP), valor, False, "Parameters", RELAP.App.GetLocalString("Quedadepressoaplicad5"), True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Nullable(Of Double))
                'End With
                ''desi kaam

                ''.Item.Add("Flow Area", FlowArea())



                ' '''''''''''''

                'valor = Format(Conversor.ConverterDoSI(su.no_unit, Me.FromComponent), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT("From Component", su.no_unit), valor, False, "Parameters", "From Component", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With

                'valor = Format(Conversor.ConverterDoSI(su.no_unit, Me.ToComponent), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT("To Component", su.no_unit), valor, False, "Parameters", "To component", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With

                valor = Format(Conversor.ConverterDoSI(su.area, Me.JunctionArea), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Junction Flow Area", su.area), valor, False, "Parameters", "Junction Flow Area", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.no_unit, Me.FflowLossCo), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Forward Flow Energy Loss Coefficient", su.no_unit), valor, False, "Parameters", "Forward Flow Energy Loss Coefficient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.no_unit, Me.RflowLossCo), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Reverse Flow Energy Loss Coefficient", su.no_unit), valor, False, "Parameters", "Reverse Flow Energy Loss Coefficient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.no_unit, Me.m_subdisco), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Subcooled Discharge Coefficient", su.no_unit), valor, False, "Parameters", "Subcooled Discharge Coefficient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.no_unit, Me.m_tpdisco), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Two phase Discharge Coefficient", su.no_unit), valor, False, "Parameters", "Two phase Discharge Coefficient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.no_unit, Me.m_supdisco), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Superheated Discharge Coefficient", su.no_unit), valor, False, "Parameters", "Superheated Discharge Coefficient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                .Item.Add(("True for Mass Flow rate"), Me, "EnterVelocityOrMassFlowRate", False, "Single Junction Initial Conditions", "True for Mass Flow rate", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                valor = Format(Conversor.ConverterDoSI(su.velocity, Me.InitialLiquidVelocity), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Initial Liquid Velocity", su.velocity), valor, False, "Single Junction Initial Conditions", "Initial Liquid Velocity", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.velocity, Me.InitialVaporVelocity), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Initial Vapor Velocity", su.velocity), valor, False, "Single Junction Initial Conditions", "Initial Vapor Velocity", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.velocity, Me.InterphaseVelocity), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Interphase Velocity", su.velocity), valor, False, "Single Junction Initial Conditions", "Interphase Velocity", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.spmp_massflow, Me.InitialLiquidMassFlowRate), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Initial Liquid Mass Flow Rate", su.spmp_massflow), valor, False, "Single Junction Initial Conditions", "Initial Liquid Mass Flow Rate", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.spmp_massflow, Me.InitialVaporMassFlowRate), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Initial Vapor Mass Flow Rate", su.spmp_massflow), valor, False, "Single Junction Initial Conditions", "Initial Vapor Mass Flow Rate", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.spmp_massflow, Me.InterphaseMassFlowRate), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Interphase Mass Flow Rate", su.spmp_massflow), valor, False, "Single Junction Initial Conditions", "Interphase Mass Flow Rate", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                ' valor = Format(Conversor.ConverterDoSI(su.volume, Me.Volume), FlowSheet.Options.NumberFormat)

                .Item.Add(("Thermal Stratification Model"), Me, "ThermalStratificationModel", True, "Volume Control Flags", "Thermal Stratification Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With
                .Item.Add(("Level Tracking Model"), Me, "LevelTrackingModel", True, "Volume Control Flags", "Level Tracking Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With
                .Item.Add(("Interphase Friction Model"), Me, "InterphaseFriction", False, "Volume Control Flags", "Interphase Friction Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With
                .Item.Add(("Compute Wall Friction"), Me, "ComputeWallFriction", False, "Volume Control Flags", "Compute Wall Friction", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With
                .Item.Add(("Equilibrium Temperature"), Me, "EquilibriumTemperature", False, "Volume Control Flags", "Equilibrium Temperature", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With




            End With

        End Sub

        Public Overrides Function GetPropertyValue(ByVal prop As String, Optional ByVal su As SistemasDeUnidades.Unidades = Nothing) As Object

            If su Is Nothing Then su = New RELAP.SistemasDeUnidades.UnidadesSI
            Dim cv As New RELAP.SistemasDeUnidades.Conversor
            Dim value As Double = 0
            Dim propidx As Integer = CInt(prop.Split("_")(2))

            Select Case propidx

                Case 0
                    'PROP_TK_0	Pressure Drop
                    value = cv.ConverterDoSI(su.spmp_deltaP, Me.DeltaP.GetValueOrDefault)

            End Select

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

            Select Case propidx
                Case 0
                    'PROP_TK_0	Pressure Drop
                    Me.DeltaP = cv.ConverterParaSI(su.spmp_deltaP, propval)
                Case 1
                    'PROP_TK_1	Volume
                    Me.DeltaP = cv.ConverterParaSI(su.volume, propval)
            End Select
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




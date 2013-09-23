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

    <System.Serializable()> Public Class Pump

        Inherits SimulationObjects_UnitOpBaseClass

        Protected m_dp As Nullable(Of Double)
        Protected m_DQ As Nullable(Of Double)
        Protected m_vol As Double = 0
        Protected m_tRes As Double = 0

        Structure RelapProperty
            Public value As String
            Public cardno As String
            Public wordno As String
        End Structure

        Enum Direction
            Inlet = 1
            Outlet = 2
        End Enum
        Enum inletAreaChangeEnum
            No_Area_Change
            Smooth_Area_Change
            Full_Abrupt_Area_Change
            Partial_Abrupt_Area_Change
        End Enum

        Enum inletMomentumEquationEnum
            Two_velocity_Momentum_Equations
            Single_velocity_Momentum_Equations
        End Enum
        Enum outletAreaChangeEnum
            No_Area_Change
            Smooth_Area_Change
            Full_Abrupt_Area_Change
            Partial_Abrupt_Area_Change
        End Enum

        Enum outletMomentumEquationEnum
            Two_velocity_Momentum_Equations
            Single_velocity_Momentum_Equations
        End Enum

        Enum pumptableEnum
            Single_Phase_Homologous_Table
            Obtain_Single_Phase_Tables_for_this_Number
            Use_builtin_data_for_Bingham_pump
            Use_builtin_data_for_Westinghouse_pump
        End Enum

        Enum TwoPhaseIndexEnum
            Do_Not_USe_Two_Phase_Option

        End Enum


        'basic properties start

        Private m_flowarea As Double
        Public Property FlowArea() As Double
            Get
                Return m_flowarea
            End Get
            Set(ByVal value As Double)
                m_flowarea = value
            End Set
        End Property

        Private m_LengthofVolume As Double
        Public Property LengthofVolume() As Double
            Get
                Return m_LengthofVolume
            End Get
            Set(ByVal value As Double)
                m_LengthofVolume = value
            End Set
        End Property

        Private m_VolumeofVolume As Double
        Public Property VolumeofVolume() As Double
            Get
                Return m_VolumeofVolume
            End Get
            Set(ByVal value As Double)
                m_VolumeofVolume = value
            End Set
        End Property

        Private m_ElevationChange As Double
        Public Property ElevationChange() As Double
            Get
                Return m_ElevationChange
            End Get
            Set(ByVal value As Double)
                m_ElevationChange = value
            End Set
        End Property

        Private m_InclinationAngle As Double
        Public Property InclinationAngle() As Double
            Get
                Return m_InclinationAngle
            End Get
            Set(ByVal value As Double)
                m_InclinationAngle = value
            End Set
        End Property

        Private m_Azimuthalangle As Double
        Public Property Azimuthalangle() As Double
            Get
                Return m_Azimuthalangle
            End Get
            Set(ByVal value As Double)
                m_Azimuthalangle = value
            End Set
        End Property

        Private _ThermoDynamicStates As ThermoDynamicStates
        Public Property ThermoDynamicStates() As ThermoDynamicStates
            Get
                Return _ThermoDynamicStates
            End Get
            Set(ByVal value As ThermoDynamicStates)
                _ThermoDynamicStates = value
            End Set
        End Property

        'basic properties end

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

        Private _FromVolume As String
        Public Property FromVolume() As String
            Get
                Return _FromVolume
            End Get
            Set(ByVal value As String)
                _FromVolume = value
            End Set
        End Property
        Private _ToVolume As String
        Public Property ToVolume() As String
            Get
                Return _ToVolume
            End Get
            Set(ByVal value As String)
                _ToVolume = value
            End Set
        End Property

        Private _FromDirection As Direction
        Public Property FromDirection() As Direction
            Get
                Return _FromDirection
            End Get
            Set(ByVal value As Direction)
                _FromDirection = value
            End Set
        End Property
        Private _ToDirection As Direction
        Public Property ToDirection() As Direction
            Get
                Return _ToDirection
            End Get
            Set(ByVal value As Direction)
                _ToDirection = value
            End Set
        End Property




        'pump suction data
        Private m_inlet_JunctionArea As Double
        Public Property JunctionArea() As Double
            Get
                Return m_inlet_JunctionArea
            End Get
            Set(ByVal value As Double)
                m_inlet_JunctionArea = value
            End Set
        End Property

        Private m_inlet_ffelc As Double
        Public Property FflowLossCo() As Double
            Get
                Return m_inlet_ffelc
            End Get
            Set(ByVal value As Double)
                m_inlet_ffelc = value
            End Set
        End Property

        Private m__inlet_rfelc As Double
        Public Property RflowLossCo() As Double
            Get
                Return m__inlet_rfelc
            End Get
            Set(ByVal value As Double)
                m__inlet_rfelc = value
            End Set
        End Property

        Private inlet_CCFL As Boolean
        Public Property CCFL() As Boolean
            Get
                Return inlet_CCFL
            End Get
            Set(ByVal value As Boolean)
                inlet_CCFL = value
            End Set
        End Property

        Private inlet_chokingModel As Boolean
        Public Property chokingModel() As Boolean
            Get
                Return inlet_chokingModel
            End Get
            Set(ByVal value As Boolean)
                inlet_chokingModel = value
            End Set
        End Property

        Private inlet_AreaChange As inletAreaChangeEnum
        Public Property AreaChange() As inletAreaChangeEnum
            Get
                Return inlet_AreaChange
            End Get
            Set(ByVal value As inletAreaChangeEnum)
                inlet_AreaChange = value
            End Set
        End Property

        Private inlet_MomentumEquation As inletMomentumEquationEnum
        Public Property MomentumEquation() As inletMomentumEquationEnum
            Get
                Return inlet_MomentumEquation
            End Get
            Set(ByVal value As inletMomentumEquationEnum)
                inlet_MomentumEquation = value
            End Set
        End Property



        'pump discharge data
        Private m_outlet_JunctionArea As Double
        Public Property OJunctionArea() As Double
            Get
                Return m_outlet_JunctionArea
            End Get
            Set(ByVal value As Double)
                m_outlet_JunctionArea = value
            End Set
        End Property

        Private m_outlet_ffelc As Double
        Public Property OFflowLossCo() As Double
            Get
                Return m_outlet_ffelc
            End Get
            Set(ByVal value As Double)
                m_outlet_ffelc = value
            End Set
        End Property

        Private m__outlet_rfelc As Double
        Public Property ORflowLossCo() As Double
            Get
                Return m__outlet_rfelc
            End Get
            Set(ByVal value As Double)
                m__outlet_rfelc = value
            End Set
        End Property

        Private outlet_CCFL As Boolean
        Public Property OCCFL() As Boolean
            Get
                Return outlet_CCFL
            End Get
            Set(ByVal value As Boolean)
                outlet_CCFL = value
            End Set
        End Property

        Private outlet_chokingModel As Boolean
        Public Property OchokingModel() As Boolean
            Get
                Return outlet_chokingModel
            End Get
            Set(ByVal value As Boolean)
                outlet_chokingModel = value
            End Set
        End Property

        Private outlet_AreaChange As outletAreaChangeEnum
        Public Property OAreaChange() As outletAreaChangeEnum
            Get
                Return outlet_AreaChange
            End Get
            Set(ByVal value As outletAreaChangeEnum)
                outlet_AreaChange = value
            End Set
        End Property

        Private outlet_MomentumEquation As outletMomentumEquationEnum
        Public Property OMomentumEquation() As outletMomentumEquationEnum
            Get
                Return outlet_MomentumEquation
            End Get
            Set(ByVal value As outletMomentumEquationEnum)
                outlet_MomentumEquation = value
            End Set
        End Property


        'pump suction initial conditions
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



        'pump Discharge initial conditions
        Private _EnterVelocityOrMassFlowRate As Boolean
        Public Property OEnterVelocityOrMassFlowRate() As Boolean
            Get
                Return _EnterVelocityOrMassFlowRate
            End Get
            Set(ByVal value As Boolean)
                _EnterVelocityOrMassFlowRate = value
            End Set
        End Property

        Private _InitialLiquidVelocity As Double
        Public Property OInitialLiquidVelocity() As Double
            Get
                Return _InitialLiquidVelocity
            End Get
            Set(ByVal value As Double)
                _InitialLiquidVelocity = value
            End Set
        End Property

        Private _InitialVaporVelocity As Double
        Public Property OInitialVaporVelocity() As Double
            Get
                Return _InitialVaporVelocity
            End Get
            Set(ByVal value As Double)
                _InitialVaporVelocity = value
            End Set
        End Property

        Private _InterphaseVelocity As Double
        Public Property OInterphaseVelocity() As Double
            Get
                Return _InterphaseVelocity
            End Get
            Set(ByVal value As Double)
                _InterphaseVelocity = value
            End Set
        End Property

        Private _InitialLiquidMassFlowRate As Double
        Public Property OInitialLiquidMassFlowRate() As Double
            Get
                Return _InitialLiquidMassFlowRate
            End Get
            Set(ByVal value As Double)
                _InitialLiquidMassFlowRate = value
            End Set
        End Property

        Private _InitialVaporMassFlowRate As Double
        Public Property OInitialVaporMassFlowRate() As Double
            Get
                Return _InitialVaporMassFlowRate
            End Get
            Set(ByVal value As Double)
                _InitialVaporMassFlowRate = value
            End Set
        End Property

        'pump index cards
        Private _PumpTable As pumptableEnum
        Public Property PumpTable() As pumptableEnum
            Get
                Return _PumpTable
            End Get
            Set(ByVal value As pumptableEnum)
                _PumpTable = value
            End Set
        End Property

        'pump description
        Private _Ratedpumpvelocity As Double
        Public Property Ratedpumpvelocity() As String
            Get
                Return _Ratedpumpvelocity
            End Get
            Set(ByVal value As String)
                _Ratedpumpvelocity = value
            End Set
        End Property

        Private _RatioRatedVelocity As Double
        Public Property RatioRatedVelocity() As Double
            Get
                Return _RatioRatedVelocity
            End Get
            Set(ByVal value As Double)
                _RatioRatedVelocity = value
            End Set
        End Property

        Private _RatedFlow As Double
        Public Property RatedFlow() As Double
            Get
                Return _RatedFlow
            End Get
            Set(ByVal value As Double)
                _RatedFlow = value
            End Set
        End Property

        Private _RateHead As Double
        Public Property RatedHead() As Double
            Get
                Return _RateHead
            End Get
            Set(ByVal value As Double)
                _RateHead = value
            End Set
        End Property

        Private _RatedTorque As Double
        Public Property RatedTorque() As Double
            Get
                Return _RatedTorque
            End Get
            Set(ByVal value As Double)
                _RatedTorque = value
            End Set
        End Property

        Private _MomentofInertia As Double
        Public Property MomentofInertia() As Double
            Get
                Return _MomentofInertia
            End Get
            Set(ByVal value As Double)
                _MomentofInertia = value
            End Set
        End Property

        Private _RatedDensity As Double
        Public Property RatedDensity() As Double
            Get
                Return _RatedDensity
            End Get
            Set(ByVal value As Double)
                _RatedDensity = value
            End Set
        End Property

        Private _RatedMotorTorque As Double
        Public Property RatedMotorTorque() As Double
            Get
                Return _RatedMotorTorque
            End Get
            Set(ByVal value As Double)
                _RatedMotorTorque = value
            End Set
        End Property

        Private _TF2 As Double
        Public Property TF2() As Double
            Get
                Return _TF2
            End Get
            Set(ByVal value As Double)
                _TF2 = value
            End Set
        End Property

        Private _TF0 As Double
        Public Property TF0() As Double
            Get
                Return _TF0
            End Get
            Set(ByVal value As Double)
                _TF0 = value
            End Set
        End Property

        Private _TF3 As Double
        Public Property TF3() As Double
            Get
                Return _TF3
            End Get
            Set(ByVal value As Double)
                _TF3 = value
            End Set
        End Property



        Public Sub New(ByVal nome As String, ByVal descricao As String)

            MyBase.CreateNew()
            Me.m_ComponentName = nome
            Me.m_ComponentDescription = descricao
            Me.FillNodeItems()
            Me.QTFillNodeItems()
            Me._ThermoDynamicStates = New ThermoDynamicStates
            Me._ToVolume = 1
            Me._FromVolume = 1
            Me.m_flowarea = 20.0
            Me.m_LengthofVolume = 0.0
            Me.m_VolumeofVolume = 1000000.0
            Me.m_Azimuthalangle = 0.0
            Me.m_InclinationAngle = -90.0
            Me.m_ElevationChange = -50000.0
            Me.inlet_CCFL = False
            Me.inlet_chokingModel = False
            Me.AreaChange = inletAreaChangeEnum.No_Area_Change
            Me.MomentumEquation = inletMomentumEquationEnum.Two_velocity_Momentum_Equations
            Me.outlet_CCFL = False
            Me.outlet_chokingModel = False
            Me.OAreaChange = outletAreaChangeEnum.No_Area_Change
            Me.OMomentumEquation = outletMomentumEquationEnum.Two_velocity_Momentum_Equations
            Me._PumpTable = pumptableEnum.Obtain_Single_Phase_Tables_for_this_Number



        End Sub

        Public Property Volume() As Double
            Get
                Return m_vol
            End Get
            Set(ByVal value As Double)
                m_vol = value
            End Set
        End Property

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

                valor = Format(Me.FlowArea, FlowSheet.Options.NumberFormat)
                .Item.Add("Volume Flow Area", valor, False, "1.Parameters", "Volume Flow Area", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Me.LengthofVolume, FlowSheet.Options.NumberFormat)
                .Item.Add("Length of Volume", valor, False, "1.Parameters", "Length of Volume", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Me.VolumeofVolume, FlowSheet.Options.NumberFormat)
                .Item.Add("Volume of Volume", valor, False, "1.Parameters", "Volume of Volume", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Me.Azimuthalangle, FlowSheet.Options.NumberFormat)
                .Item.Add("Azimuthal Angle", valor, False, "1.Parameters", "Azimuthal Angle", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Me.InclinationAngle, FlowSheet.Options.NumberFormat)
                .Item.Add("Inclination Angle", valor, False, "1.Parameters", "Inclination Angle", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Me.ElevationChange, FlowSheet.Options.NumberFormat)
                .Item.Add("Elevation Change", valor, False, "1.Parameters", "Elevation Change", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                .Item.Add("Thermo Dynamic States", Me, "ThermoDynamicStates", False, "1.Parameters", "Thermo Dynamic States", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(ThermoDynamicState)
                    .CustomEditor = New RELAP.Editors.UIThermoDynamicStatesEditor
                End With

                'pump suction
                valor = App.GetTagFromUID(Me.FromComponent)
                .Item.Add("From Component", valor, True, "3.Pump Suction Data", "From Component", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = (Me.FromVolume)
                .Item.Add("From Volume", valor, False, "3.Pump Suction Data", "From Volume", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .CustomEditor = New RELAP.Editors.UIVolumeSelector
                End With

                .Item.Add("From Direction", Me, "FromDirection", False, "3.Pump Suction Data", "From Direction", True)

                valor = Format(Me.JunctionArea, FlowSheet.Options.NumberFormat)
                .Item.Add("Inlet Junction Area", valor, False, "3.Pump Suction Data", "Inlet Junction Area", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Me.FflowLossCo, FlowSheet.Options.NumberFormat)
                .Item.Add("Inlet Forward Flow Energy Loss Coefficient", valor, False, "3.Pump Suction Data", "Inlet Forward Flow Energy Loss Coefficient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Me.RflowLossCo, FlowSheet.Options.NumberFormat)
                .Item.Add("Inlet Reverse Flow Energy Loss Coefficient", valor, False, "3.Pump Suction Data", "Inlet Reverse Flow Energy Loss Coefficient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                .Item.Add(("Inlet CCFL Model"), Me, "CCFL", False, "3.Pump Suction Data", "CCFL Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Inlet Choking Model"), Me, "ChokingModel", False, "3.Pump Suction Data", "Choking Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add("Inlet Area Change", Me, "AreaChange", False, "3.Pump Suction Data", "Area Change Options", True)

                .Item.Add("Inlet Momentum Equation", Me, "MomentumEquation", False, "3.Pump Suction Data", "Specify homogenius or nonhomogenius", True)




                'pump discharge
                valor = App.GetTagFromUID(Me.ToComponent)
                .Item.Add("To Component", valor, True, "4.Pump Discharge Data", "To Component", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = (Me.ToVolume)
                .Item.Add("To Volume", valor, False, "4.Pump Discharge Data", "To Volume", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .CustomEditor = New RELAP.Editors.UIVolumeSelector
                End With

                .Item.Add("To Direction", Me, "ToDirection", False, "4.Pump Discharge Data", "To Direction", True)

                valor = Format(Me.OJunctionArea, FlowSheet.Options.NumberFormat)
                .Item.Add("Outlet Junction Area", valor, False, "4.Pump Discharge Data", "Outlet Junction Area", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Me.OFflowLossCo, FlowSheet.Options.NumberFormat)
                .Item.Add("Outlet Forward Flow Energy Loss Coefficient", valor, False, "4.Pump Discharge Data", "Outlet Forward Flow Energy Loss Coefficient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Me.ORflowLossCo, FlowSheet.Options.NumberFormat)
                .Item.Add("Outlet Reverse Flow Energy Loss Coefficient", valor, False, "4.Pump Discharge Data", "Outlet Reverse Flow Energy Loss Coefficient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                .Item.Add(("Outlet CCFL Model"), Me, "OCCFL", False, "4.Pump Discharge Data", "CCFL Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Outlet Choking Model"), Me, "OChokingModel", False, "4.Pump Discharge Data", "Choking Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add("Outlet Area Change", Me, "OAreaChange", False, "4.Pump Discharge Data", "Area Change Options", True)

                .Item.Add("Outlet Momentum Equation", Me, "OMomentumEquation", False, "4.Pump Discharge Data", "Specify homogenius or nonhomogenius", True)


                'pump suction initial conditions
                valor = Format(Me.InterphaseVelocity, FlowSheet.Options.NumberFormat)
                .Item.Add("Interphase Velocity (suction)", valor, False, "5.Pump Suction Initial Conditions", "Interphase Velocity (suction)", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                .Item.Add(("True for Mass Flow rate (suction)"), Me, "EnterVelocityOrMassFlowRate", False, "5.Pump Suction Initial Conditions", "True for Mass Flow rate (suction)", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                valor = Format(Me.InitialLiquidVelocity, FlowSheet.Options.NumberFormat)
                .Item.Add("Initial Liquid Velocity (suction)", valor, False, "5.Pump Suction Initial Conditions", "Initial Liquid Velocity (suction)", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Me.InitialVaporVelocity, FlowSheet.Options.NumberFormat)
                .Item.Add("Initial Vapor Velocity (suction)", valor, False, "5.Pump Suction Initial Conditions", "Initial Vapor Velocity (suction)", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Me.InitialLiquidMassFlowRate, FlowSheet.Options.NumberFormat)
                .Item.Add("Initial Liquid Mass Flow Rate (suction)", valor, False, "5.Pump Suction Initial Conditions", "Initial Liquid Mass Flow Rate (suction)", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Me.InitialVaporMassFlowRate, FlowSheet.Options.NumberFormat)
                .Item.Add("Initial Vapor Mass Flow Rate (suction)", valor, False, "5.Pump Suction Initial Conditions", "Initial Vapor Mass Flow Rate (suction)", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                'pump discharge initial conditions
                valor = Format(Me.OInterphaseVelocity, FlowSheet.Options.NumberFormat)
                .Item.Add("Interphase Velocity (discharge)", valor, False, "6.Pump discharge Initial Conditions", "Interphase Velocity (discharge)", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                .Item.Add(("True for Mass Flow rate (discharge)"), Me, "OEnterVelocityOrMassFlowRate", False, "6.Pump discharge Initial Conditions", "True for Mass Flow rate (discharge)", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                valor = Format(Me.OInitialLiquidVelocity, FlowSheet.Options.NumberFormat)
                .Item.Add("Initial Liquid Velocity (discharge)", valor, False, "6.Pump discharge Initial Conditions", "Initial Liquid Velocity (discharge)", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Me.OInitialVaporVelocity, FlowSheet.Options.NumberFormat)
                .Item.Add("Initial Vapor Velocity (discharge)", valor, False, "6.Pump discharge Initial Conditions", "Initial Vapor Velocity (discharge)", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Me.OInitialLiquidMassFlowRate, FlowSheet.Options.NumberFormat)
                .Item.Add("Initial Liquid Mass Flow Rate (discharge)", valor, False, "6.Pump discharge Initial Conditions", "Initial Liquid Mass Flow Rate (discharge)", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Me.OInitialVaporMassFlowRate, FlowSheet.Options.NumberFormat)
                .Item.Add("Initial Vapor Mass Flow Rate (discharge)", valor, False, "6.Pump discharge Initial Conditions", "Initial Vapor Mass Flow Rate (discharge)", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                .Item.Add("Pump Table Data Indicator", Me, "PumpTable", False, "7.Pump Index and Option Data", "Pump Table Data Indicator", True)
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




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

        'Private m_HydraulicDiameter As Double
        'Public Property HydraulicDiameter() As Double
        '    Get
        '        Return m_HydraulicDiameter
        '    End Get
        '    Set(ByVal value As Double)
        '        m_HydraulicDiameter = value
        '    End Set
        'End Property

        'Private m_WallRoughness As Double
        'Public Property WallRoughness() As Double
        '    Get
        '        Return m_WallRoughness
        '    End Get
        '    Set(ByVal value As Double)
        '        m_WallRoughness = value
        '    End Set
        'End Property

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

        'basic properties end




        'control flags variable initialization

        Private m_t As Boolean
        Public Property ThermalStratificationModel() As Boolean
            Get
                Return m_t
            End Get
            Set(ByVal value As Boolean)
                m_t = value
            End Set
        End Property

        Private m_l As Boolean
        Public Property LevelTrackingModel() As Boolean
            Get
                Return m_l
            End Get
            Set(ByVal value As Boolean)
                m_l = value
            End Set
        End Property

        Private m_p As Boolean
        Public Property WaterPackingScheme() As Boolean
            Get
                Return m_p
            End Get
            Set(ByVal value As Boolean)
                m_p = value
            End Set
        End Property

        Private m_v As Boolean
        Public Property VerticalStratificationModel() As Boolean
            Get
                Return m_v
            End Get
            Set(ByVal value As Boolean)
                m_v = value
            End Set
        End Property

        Private m_b As Boolean
        Public Property InterphaseFriction() As Boolean
            Get
                Return m_b
            End Get
            Set(ByVal value As Boolean)
                m_b = value
            End Set
        End Property

        Private m_f As Boolean
        Public Property ComputeWallFriction() As Boolean
            Get
                Return m_f
            End Get
            Set(ByVal value As Boolean)
                m_f = value
            End Set
        End Property

        Private m_e As Boolean
        Public Property EquilibriumTemperature() As Boolean
            Get
                Return m_e
            End Get
            Set(ByVal value As Boolean)
                m_e = value
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

        Private m_f_inlet As Boolean
        Public Property CCFLModel() As Boolean
            Get
                Return m_f_inlet
            End Get
            Set(ByVal value As Boolean)
                m_f_inlet = value
            End Set
        End Property

        Private m_c_inlet As Boolean
        Public Property ChokingModel() As Boolean
            Get
                Return m_c_inlet
            End Get
            Set(ByVal value As Boolean)
                m_c_inlet = value
            End Set
        End Property

        Private m_a_inlet_smooth As Boolean
        Public Property SmoothAreaChange() As Boolean
            Get
                Return m_a_inlet_smooth
            End Get
            Set(ByVal value As Boolean)
                m_a_inlet_smooth = value
            End Set
        End Property

        Private m_a_inlet_abrupt As Boolean
        Public Property FullAbruptAreaChange() As Boolean
            Get
                Return m_a_inlet_abrupt
            End Get
            Set(ByVal value As Boolean)
                m_a_inlet_abrupt = value
            End Set
        End Property

        Private m_a_inlet_partial As Boolean
        Public Property PartialAbruptAreaChange() As Boolean
            Get
                Return m_a_inlet_partial
            End Get
            Set(ByVal value As Boolean)
                m_a_inlet_partial = value
            End Set
        End Property

        Private m_h_inlet_homogeneus As Boolean
        Public Property TwoVelocityMomentumEquations() As Boolean
            Get
                Return m_h_inlet_homogeneus
            End Get
            Set(ByVal value As Boolean)
                m_h_inlet_homogeneus = value
            End Set
        End Property

        Private m_h_inlet_nonhomogeneus As Boolean
        Public Property SingleVelocityMomentumEquations() As Boolean
            Get
                Return m_h_inlet_nonhomogeneus
            End Get
            Set(ByVal value As Boolean)
                m_h_inlet_nonhomogeneus = value
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

        Private m_f_outlet As Boolean
        Public Property OCCFLModel() As Boolean
            Get
                Return m_f_outlet
            End Get
            Set(ByVal value As Boolean)
                m_f_outlet = value
            End Set
        End Property

        Private m_c_outlet As Boolean
        Public Property OChokingModel() As Boolean
            Get
                Return m_c_outlet
            End Get
            Set(ByVal value As Boolean)
                m_c_outlet = value
            End Set
        End Property

        Private m_a_outlet_smooth As Boolean
        Public Property OSmoothAreaChange() As Boolean
            Get
                Return m_a_outlet_smooth
            End Get
            Set(ByVal value As Boolean)
                m_a_outlet_smooth = value
            End Set
        End Property

        Private m_a_outlet_abrupt As Boolean
        Public Property OFullAbruptAreaChange() As Boolean
            Get
                Return m_a_outlet_abrupt
            End Get
            Set(ByVal value As Boolean)
                m_a_outlet_abrupt = value
            End Set
        End Property

        Private m_a_outlet_partial As Boolean
        Public Property OPartialAbruptAreaChange() As Boolean
            Get
                Return m_a_outlet_partial
            End Get
            Set(ByVal value As Boolean)
                m_a_outlet_partial = value
            End Set
        End Property

        Private m_h_outlet_homogeneus As Boolean
        Public Property OTwoVelocityMomentumEquations() As Boolean
            Get
                Return m_h_outlet_homogeneus
            End Get
            Set(ByVal value As Boolean)
                m_h_outlet_homogeneus = value
            End Set
        End Property

        Private m_h_outlet_nonhomogeneus As Boolean
        Public Property OSingleVelocityMomentumEquations() As Boolean
            Get
                Return m_h_outlet_nonhomogeneus
            End Get
            Set(ByVal value As Boolean)
                m_h_outlet_nonhomogeneus = value
            End Set
        End Property



        Private m_pressure As Double
        Public Property Pressure() As Double
            Get
                Return m_pressure
            End Get
            Set(ByVal value As Double)
                m_pressure = value
            End Set
        End Property


        Private m_temperature As Double
        Public Property Temperature() As Double
            Get
                Return m_temperature
            End Get
            Set(ByVal value As Double)
                m_temperature = value
            End Set
        End Property

        Private m_liquidspecificinternalenergy As Double
        Public Property LiquidSpecificInternalEnergy() As Double
            Get
                Return m_liquidspecificinternalenergy
            End Get
            Set(ByVal value As Double)
                m_liquidspecificinternalenergy = value
            End Set
        End Property


        Private _vapourspecificinternalEnergy As Double
        Public Property VapourSpecificInternalEnergy() As Double
            Get
                Return _vapourspecificinternalEnergy
            End Get
            Set(ByVal value As Double)
                _vapourspecificinternalEnergy = value
            End Set
        End Property

        Private _voidFraction As Double
        Public Property VoidFraction() As Double
            Get
                Return _voidFraction
            End Get
            Set(ByVal value As Double)
                _voidFraction = value
            End Set
        End Property

        Private _staticquality As Double
        Public Property StaticQuality() As Double
            Get
                Return _staticquality
            End Get
            Set(ByVal value As Double)
                _staticquality = value
            End Set
        End Property

        Private _noncondensablequality As Double
        Public Property NonCondensableQuality() As Double
            Get
                Return _noncondensablequality
            End Get
            Set(ByVal value As Double)
                _noncondensablequality = value
            End Set
        End Property



        Private _liquidtemperature As Double
        Public Property LiquidTemperature() As Double
            Get
                Return _liquidtemperature
            End Get
            Set(ByVal value As Double)
                _liquidtemperature = value
            End Set
        End Property


        Private _vapourtemperature As Double
        Public Property VapourTemperature() As Double
            Get
                Return _vapourtemperature
            End Get
            Set(ByVal value As Double)
                _vapourtemperature = value
            End Set
        End Property






    



        Public Sub New(ByVal nome As String, ByVal descricao As String)

            MyBase.CreateNew()
            Me.m_ComponentName = nome
            Me.m_ComponentDescription = descricao
            Me.FillNodeItems()
            Me.QTFillNodeItems()
            Me.m_flowarea = 20.0
            Me.m_LengthofVolume = 0.0
            Me.m_VolumeofVolume = 1000000.0
            Me.m_Azimuthalangle = 0.0
            Me.m_InclinationAngle = -90.0
            Me.m_ElevationChange = -50000.0
            'Me.m_WallRoughness = 0.0
            'Me.m_HydraulicDiameter = 0

            '& kvkvp.Value.HydraulicDiameter & " ") & "0000000"

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

                valor = Format(Conversor.ConverterDoSI(su.area, Me.FlowArea), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Volume Flow Area", su.area), valor, False, "1.Parameters", "Volume Flow Area", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Conversor.ConverterDoSI(su.distance, Me.LengthofVolume), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Length of Volume", su.distance), valor, False, "1.Parameters", "Length of Volume", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Conversor.ConverterDoSI(su.volume, Me.VolumeofVolume), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Volume of Volume", su.volume), valor, False, "1.Parameters", "Volume of Volume", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Conversor.ConverterDoSI(su.angle, Me.Azimuthalangle), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Azimuthal Angle", su.angle), valor, False, "1.Parameters", "Azimuthal Angle", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Conversor.ConverterDoSI(su.angle, Me.InclinationAngle), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Inclination Angle", su.angle), valor, False, "1.Parameters", "Inclination Angle", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                valor = Format(Conversor.ConverterDoSI(su.distance, Me.ElevationChange), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Elevation Change", su.distance), valor, False, "1.Parameters", "Elevation Change", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                'valor = Format(Conversor.ConverterDoSI(su.distance, Me.WallRoughness), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT("Wall Roughness", su.distance), valor, False, "Parameters", "Wall Roughness", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With
                'valor = Format(Conversor.ConverterDoSI(su.distance, Me.HydraulicDiameter), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT("Hydraulic Diameter", su.distance), valor, False, "Parameters", "Hydraulic Diameter", True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With


                'valor = Format(Conversor.ConverterDoSI(su.volume, Me.Volume), FlowSheet.Options.NumberFormat)
                '.Item.Add(FT(RELAP.App.GetLocalString("TKVol"), su.volume), valor, False, "Parameters", RELAP.App.GetLocalString("TKVol"), True)
                'With .Item(.Item.Count - 1)
                '    .DefaultValue = Nothing
                '    .DefaultType = GetType(Double)
                'End With

                'valor = Format(Conversor.ConverterDoSI(su.volume, Me.Volume), FlowSheet.Options.NumberFormat)


                'control flags

                .Item.Add(("Thermal Stratification Model"), Me, "ThermalStratificationModel", True, "2.Volume Control Flags", "Thermal Stratification Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With
                .Item.Add(("Mixture Level Tracking Model"), Me, "LevelTrackingModel", True, "2.Volume Control Flags", "Mixture Level Tracking Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With
                .Item.Add(("Water Packing Scheme"), Me, "WaterPackingScheme", True, "2.Volume Control Flags", "Water Packing Scheme", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With
                .Item.Add(("Vertical Stratification Model"), Me, "VerticalStratificationModel", True, "2.Volume Control Flags", "Vertical Stratification Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Interphase Friction Model"), Me, "InterphaseFriction", True, "2.Volume Control Flags", "Interphase Friction Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With
                .Item.Add(("Compute Wall Friction"), Me, "ComputeWallFriction", True, "2.Volume Control Flags", "Compute Wall Friction", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With
                .Item.Add(("Equilibrium Temperature"), Me, "EquilibriumTemperature", False, "2.Volume Control Flags", "Equilibrium Temperature", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With



                'pump suction
                valor = Format(Conversor.ConverterDoSI(su.area, Me.JunctionArea), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Inlet Junction Area", su.area), valor, False, "3.Pump Suction Data", "Inlet Junction Area", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.no_unit, Me.FflowLossCo), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Inlet Forward Flow Energy Loss Coefficient", su.no_unit), valor, False, "3.Pump Suction Data", "Inlet Forward Flow Energy Loss Coefficient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.no_unit, Me.RflowLossCo), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Inlet Reverse Flow Energy Loss Coefficient", su.no_unit), valor, False, "3.Pump Suction Data", "Inlet Reverse Flow Energy Loss Coefficient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                .Item.Add(("Inlet CCFL Model"), Me, "CCFLModel", False, "3.Pump Suction Data", "Inlet CCFL Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Inlet Choking Model"), Me, "ChokingModel", False, "3.Pump Suction Data", "Inlet Choking Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Inlet Smooth Area Change"), Me, "SmoothAreaChange", False, "3.Pump Suction Data", "Inlet Smooth Area Change", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Inlet Full Abrupt Area Change"), Me, "FullAbruptAreaChange", False, "3.Pump Suction Data", "Inlet Full Abrupt Area Change", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Inlet Partial Abrupt Area Change"), Me, "PartialAbruptAreaChange", False, "3.Pump Suction Data", "Inlet Partial Abrupt Area Change", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Inlet Two Velocity Momentum Equations"), Me, "TwoVelocityMomentumEquations", False, "3.Pump Suction Data", "Inlet Two Velocity Momentum Equations", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Inlet Single Velocity Momentum Equations"), Me, "SingleVelocityMomentumEquations", False, "3.Pump Suction Data", "Inlet Single Velocity Momentum Equations", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With




                'pump discharge
                valor = Format(Conversor.ConverterDoSI(su.area, Me.OJunctionArea), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Outlet Junction Area", su.area), valor, False, "4.Pump Discharge Data", "Outlet Junction Area", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.no_unit, Me.OFflowLossCo), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Outlet Forward Flow Energy Loss Coefficient", su.no_unit), valor, False, "4.Pump Discharge Data", "Outlet Forward Flow Energy Loss Coefficient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Format(Conversor.ConverterDoSI(su.no_unit, Me.ORflowLossCo), FlowSheet.Options.NumberFormat)
                .Item.Add(FT("Outlet Reverse Flow Energy Loss Coefficient", su.no_unit), valor, False, "4.Pump Discharge Data", "Outlet Reverse Flow Energy Loss Coefficient", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                .Item.Add(("Outlet CCFL Model"), Me, "OCCFLModel", False, "4.Pump Discharge Data", "Outlet CCFL Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Outlet Choking Model"), Me, "OChokingModel", False, "4.Pump Discharge Data", "Outlet Choking Model", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Outlet Smooth Area Change"), Me, "OSmoothAreaChange", False, "4.Pump Discharge Data", "Outlet Smooth Area Change", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Outlet Full Abrupt Area Change"), Me, "OFullAbruptAreaChange", False, "4.Pump Discharge Data", "Outlet Full Abrupt Area Change", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Outlet Partial Abrupt Area Change"), Me, "OPartialAbruptAreaChange", False, "4.Pump Discharge Data", "Outlet Partial Abrupt Area Change", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Outlet Two Velocity Momentum Equations"), Me, "OTwoVelocityMomentumEquations", False, "4.Pump Discharge Data", "Outlet Two Velocity Momentum Equations", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = False
                    .DefaultType = GetType(Boolean)
                End With

                .Item.Add(("Outlet Single Velocity Momentum Equations"), Me, "OSingleVelocityMomentumEquations", False, "4.Pump Discharge Data", "Outlet Single Velocity Momentum Equations", True)
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




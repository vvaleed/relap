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

    <System.Serializable()> Public Class PWRControlRod

        Inherits SimulationObjects_UnitOpBaseClass



        Private _ControlRodDetails As ControlRodDetails
        Public Property ControlRodDetails() As ControlRodDetails
            Get
                Return _ControlRodDetails
            End Get
            Set(ByVal value As ControlRodDetails)
                _ControlRodDetails = value
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

        Private m_AbsorberMaterialIndex As Integer
        Public Property AbsorberMaterialIndex() As Integer
            Get
                Return m_AbsorberMaterialIndex
            End Get
            Set(ByVal value As Integer)
                m_AbsorberMaterialIndex = value
            End Set
        End Property

        Private m_SheathMaterialIndex As Integer
        Public Property SheathMaterialIndex() As Integer
            Get
                Return m_SheathMaterialIndex
            End Get
            Set(ByVal value As Integer)
                m_SheathMaterialIndex = value
            End Set
        End Property

        Private m_GuideTubeMaterialIndex As Integer
        Public Property GuideTubeMaterialIndex() As Integer
            Get
                Return m_GuideTubeMaterialIndex
            End Get
            Set(ByVal value As Integer)
                m_GuideTubeMaterialIndex = value
            End Set
        End Property


        Private m_OuterRadius1 As Double
        Public Property OuterRadius1() As Double
            Get
                Return m_OuterRadius1
            End Get
            Set(ByVal value As Double)
                m_OuterRadius1 = value
            End Set
        End Property


        Private m_OuterRadius2 As Double
        Public Property OuterRadius2() As Double
            Get
                Return m_OuterRadius2
            End Get
            Set(ByVal value As Double)
                m_OuterRadius2 = value
            End Set
        End Property


        Private m_InnerRadius3 As Double
        Public Property InnerRadius3() As Double
            Get
                Return m_InnerRadius3
            End Get
            Set(ByVal value As Double)
                m_InnerRadius3 = value
            End Set
        End Property


        Private m_OuterRadius4 As Double
        Public Property OuterRadius4() As Double
            Get
                Return m_OuterRadius4
            End Get
            Set(ByVal value As Double)
                m_OuterRadius4 = value
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

        Private m_VolumeAbove As String
        Public Property VolumeAbove() As String
            Get
                Return m_VolumeAbove
            End Get
            Set(ByVal value As String)
                m_VolumeAbove = value
            End Set
        End Property

        Private m_VolumeBelow As String
        Public Property VolumeBelow() As String
            Get
                Return m_VolumeBelow
            End Get
            Set(ByVal value As String)
                m_VolumeBelow = value
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

        Private m_Increment As Integer
        Public Property Increment() As Integer
            Get
                Return m_Increment
            End Get
            Set(ByVal value As Integer)
                m_Increment = value
            End Set
        End Property

        Private m_HydraulicVolumesAxialNode As Integer
        Public Property HydraulicVolumesAxialNode() As Integer
            Get
                Return m_HydraulicVolumesAxialNode
            End Get
            Set(ByVal value As Integer)
                m_HydraulicVolumesAxialNode = value
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


        Private m_InternalGasPressure As Double
        Public Property InternalGasPressure() As Double
            Get
                Return m_InternalGasPressure
            End Get
            Set(ByVal value As Double)
                m_InternalGasPressure = value
            End Set
        End Property


        Private m_MassOfTin As Double
        Public Property MassOfTin() As Double
            Get
                Return m_MassOfTin
            End Get
            Set(ByVal value As Double)
                m_MassOfTin = value
            End Set
        End Property


        Private m_MassOfSilver As Double
        Public Property MassOfSilver() As Double
            Get
                Return m_MassOfSilver
            End Get
            Set(ByVal value As Double)
                m_MassOfSilver = value
            End Set
        End Property






        Public Sub New(ByVal nome As String, ByVal descricao As String)

            MyBase.CreateNew()
            Me.m_ComponentName = nome
            Me.m_ComponentDescription = descricao
            Me.FillNodeItems()
            Me.QTFillNodeItems()
            ControlRodDetails = New ControlRodDetails
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


                valor = Me.NumberOfRods
                .Item.Add("No. of rods", valor, False, "No. of Rods", " ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.RodPitch
                .Item.Add(FT("Rod Pitch", su.distance), valor, False, "No. of Rods", "If a fuel rod component is entered, the control rod pitch should be equal to the pitch of the fuel rod, if it is in the same bundle.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With
                
                valor = Me.AbsorberMaterialIndex
                .Item.Add("Absorber material index", valor, False, "Material", "Material index for control rod absorber.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.SheathMaterialIndex
                .Item.Add("Sheath material index", valor, False, "Material", "Material index for control rod sheath.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.GuideTubeMaterialIndex
                .Item.Add("Guide tube material index", valor, False, "Material", "Material index for guide tube.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With


                valor = Me.OuterRadius1
                .Item.Add(FT(RELAP.App.GetLocalString("Outer cladding radius"), su.distance), valor, False, "Geometry", "Control rod absorber. Range is 0.0 < x < W2", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.OuterRadius1
                .Item.Add(FT(RELAP.App.GetLocalString("Outer radius CR Absorber"), su.distance), valor, False, "Geometry", "Control rod absorber. Range is 0.0 < x < W2", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                valor = Me.OuterRadius2
                .Item.Add(FT(RELAP.App.GetLocalString("Outer radius SS Sheath"), su.distance), valor, False, "Geometry", "Stainless steel sheath. Range is W1< x ≤W3", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                valor = Format(Conversor.ConverterDoSI(su.distance, Me.InnerRadius3), FlowSheet.Options.NumberFormat)
                .Item.Add(FT(RELAP.App.GetLocalString("Inner radius Guide Tube"), su.distance), valor, False, "Geometry", "Zr guide tube. Range is W2 ≤ x < W4.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With


                valor = Me.OuterRadius4
                .Item.Add(FT(RELAP.App.GetLocalString("Outer radius Guide Tube"), su.distance), valor, False, "Geometry", "Zr guide tube.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.AxialNode
                .Item.Add("Axial Node", valor, False, "Geometry", ".", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With


                valor = Me.VolumeAbove
                .Item.Add(FT(RELAP.App.GetLocalString("Volume Above"), su.volume), valor, False, "Upper and Lower Hydraulic Volumes", "Volume located above control rod.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.VolumeBelow
                .Item.Add(FT(RELAP.App.GetLocalString("Volume Below"), su.volume), valor, False, "Upper and Lower Hydraulic Volumes", "Volume located below control rod.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.VolumeNumber
                .Item.Add("Volume Number", valor, False, "Hydraulic Volumes", "", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.Increment
                .Item.Add("Increment", valor, False, "Hydraulic Volumes", "The range is from 0.0 to 1.0", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.HydraulicVolumesAxialNode
                .Item.Add("Axial Node", valor, False, "Hydraulic Volumes", "Sequential expansion applies. ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.RadiusToRadialNode1
                .Item.Add(FT(RELAP.App.GetLocalString("Radial dimension of Node 1"), su.distance), valor, False, "Radial Mesh Spacing", "", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.RadiusToRadialNodeN
                .Item.Add(FT(RELAP.App.GetLocalString("Radial dimension of Node N"), su.distance), valor, False, "Radial Mesh Spacing", "", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.RadialMeshSpacingAxialNode
                .Item.Add("Axial Node", valor, False, "Radial Mesh Spacing", " ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

                valor = Me.TemperatureAtNode1
                .Item.Add(FT(RELAP.App.GetLocalString("Temperature at Node 1"), su.spmp_temperature), valor, False, "Initial Temperatures", "The range is 300 K ≤ x ≤ 3123 K. Initial temperature of Node 1", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.TemperatureAtNodeN
                .Item.Add(FT(RELAP.App.GetLocalString("Temperature at Node N"), su.spmp_temperature), valor, False, "Initial Temperatures", "Initial temperature for each radial node to radial node N. Range is same as above.", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.InitialTemperaturesAxialNode
                .Item.Add("Axial Node", valor, False, "Initial Temperature", "Input temperature at each radial node ", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Integer)
                End With

             
                valor = Me.InternalGasPressure
                .Item.Add(FT(RELAP.App.GetLocalString("Internal Gas Pressure"), su.spmp_pressure), valor, False, "Internal Gas Pressure", "In a rod", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.MassOfTin
                .Item.Add(FT(RELAP.App.GetLocalString("Initial mass of Tin"), su.mass), valor, False, "Initial Masses of Fission Products, Tin and Silver", "In kg", True)
                With .Item(.Item.Count - 1)
                    .DefaultValue = Nothing
                    .DefaultType = GetType(Double)
                End With

                valor = Me.MassOfSilver
                .Item.Add(FT(RELAP.App.GetLocalString("Initial mass of Silver"), su.mass), valor, False, "Initial Masses of Fission Products, Tin and Silver", "In kg", True)
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
    <Serializable()> Public Class ControlRodDetails
        Protected m_collection As Generic.SortedDictionary(Of Integer, Geometry)
        Protected m_collection2 As Generic.SortedDictionary(Of Integer, HydraulicVolumes)
        Protected m_collection3 As Generic.SortedDictionary(Of Integer, RadialMeshSpacing)
  

        Private m_AxialPowerFactor As Generic.SortedDictionary(Of Integer, Double)
        Public Property AxialPowerFactor() As Generic.SortedDictionary(Of Integer, Double)
            Get
                Return m_AxialPowerFactor
            End Get
            Set(ByVal value As Generic.SortedDictionary(Of Integer, Double))
                m_AxialPowerFactor = value
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
        Public Property ControlRodDimensions() As Generic.SortedDictionary(Of Integer, Geometry)
            Get
                Return m_collection
            End Get
            Set(ByVal value As Generic.SortedDictionary(Of Integer, Geometry))
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
            m_collection = New Generic.SortedDictionary(Of Integer, Geometry)
            m_collection2 = New Generic.SortedDictionary(Of Integer, HydraulicVolumes)
            m_collection3 = New Generic.SortedDictionary(Of Integer, RadialMeshSpacing)

            _InitialTemperatures = New Generic.SortedDictionary(Of Integer, String)

            m_AxialPowerFactor = New Generic.SortedDictionary(Of Integer, Double)
        End Sub
        Public Overrides Function ToString() As String
            Return "Click to Edit..."
        End Function

    End Class
    <Serializable()> Public Class Geometry

        Private _OutRadiusofControlRodAbsorber As Double
        Public Property OuterRadiusofControlRodAbsorber() As Double
            Get
                Return _OutRadiusofControlRodAbsorber
            End Get
            Set(ByVal value As Double)
                _OutRadiusofControlRodAbsorber = value
            End Set
        End Property

        Private _OuterRadiusofSS As Double
        Public Property OuterRadiusofSS() As Double
            Get
                Return _OuterRadiusofSS
            End Get
            Set(ByVal value As Double)
                _OuterRadiusofSS = value
            End Set
        End Property

        Private _InnerofZircaloy As Double
        Public Property InnerofZr() As Double
            Get
                Return _InnerofZircaloy
            End Get
            Set(ByVal value As Double)
                _InnerofZircaloy = value
            End Set
        End Property

        Private _OuterofZr As Double
        Public Property OuterofZr() As Double
            Get
                Return _OuterofZr
            End Get
            Set(ByVal value As Double)
                _OuterofZr = value
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


        Public Sub New(ByVal OuterofCRAbsorber As Double, ByVal OuterofSS As Double, ByVal OuterofZr As Double, ByVal InnerofZr As Double, ByVal AxialNode As Integer)
            _AxialNode = AxialNode
            _OuterofZr = OuterofZr
            _InnerofZircaloy = InnerofZr
            _OuterRadiusofSS = OuterofSS
            _OutRadiusofControlRodAbsorber = OuterofCRAbsorber
        End Sub
    End Class

End Namespace



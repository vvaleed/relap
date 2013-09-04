Imports WeifenLuo.WinFormsUI.Docking
Imports Microsoft.MSDN.Samples.GraphicObjects
Imports LukeSw.Windows.Forms
'Imports RELAP.RELAP.Flowsheet.FlowSheetSolver
Imports RELAP.RELAP

Public Class frmProps
    Inherits DockContent

#Region "    Declaração de eventos "

    Private Event ObjectStatusChanged(ByVal obj As Microsoft.Msdn.Samples.GraphicObjects.GraphicObject)

#End Region

    Private ChildParent As FormFlowsheet
    Private Conversor As New RELAP.SistemasDeUnidades.Conversor

    Private Sub frmObjList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ChildParent = My.Application.ActiveSimulation
    End Sub

    Public Function ReturnForm(ByVal str As String) As IDockContent

        If str = Me.ToString Then
            Return Me
        Else
            Return Nothing
        End If

    End Function

    'Public Sub PGEx1_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PGEx1.PropertyValueChanged

    '    ChildParent = Me.ParentForm

    '    Dim sobj As Microsoft.Msdn.Samples.GraphicObjects.GraphicObject = ChildParent.FormSurface.FlowsheetDesignSurface.SelectedObject

    '    'handle changes internally
    '    If Not sobj Is Nothing Then

    '        If sobj.TipoObjeto <> TipoObjeto.GO_Tabela And sobj.TipoObjeto <> TipoObjeto.GO_MasterTable Then

    '            ChildParent.Collections.ObjectCollection(sobj.Name).PropertyValueChanged(s, e)

    '        End If

    '    End If

    '    'more...

    '    ChildParent.FormSurface.FlowsheetDesignSurface.SelectedObject = sobj

    '    If Not sobj Is Nothing Then

    '        If sobj.TipoObjeto = TipoObjeto.GO_MasterTable Then

    '            Dim mt As RELAP.GraphicObjects.MasterTableGraphic = sobj

    '            If e.ChangedItem.PropertyDescriptor.Category.Contains(RELAP.App.GetLocalString("MT_PropertiesToShow")) Then
    '                If Not mt.PropertyList.ContainsKey(e.ChangedItem.Label) Then
    '                    mt.PropertyList.Add(e.ChangedItem.Label, e.ChangedItem.Value)
    '                Else
    '                    mt.PropertyList(e.ChangedItem.Label) = e.ChangedItem.Value
    '                End If
    '            ElseIf e.ChangedItem.PropertyDescriptor.Category.Contains(RELAP.App.GetLocalString("MT_ObjectsToShow")) Then
    '                If Not mt.ObjectList.ContainsKey(e.ChangedItem.Label) Then
    '                    mt.ObjectList.Add(e.ChangedItem.Label, e.ChangedItem.Value)
    '                Else
    '                    mt.ObjectList(e.ChangedItem.Label) = e.ChangedItem.Value
    '                End If
    '            End If

    '            mt.Update(ChildParent)

    '        ElseIf sobj.TipoObjeto = TipoObjeto.MaterialStream Then

    '            Dim ms As RELAP.SimulationObjects.Streams.MaterialStream = ChildParent.Collections.CLCS_MaterialStreamCollection.Item(sobj.Name)

    '            If ms.Fases.Count <= 3 Then
    '                ms.Fases.Add("3", New RELAP.ClassesBasicasTermodinamica.Fase(RELAP.App.GetLocalString("Liquid1"), ""))
    '                ms.Fases.Add("4", New RELAP.ClassesBasicasTermodinamica.Fase(RELAP.App.GetLocalString("Liquid2"), ""))
    '                ms.Fases.Add("5", New RELAP.ClassesBasicasTermodinamica.Fase(RELAP.App.GetLocalString("Liquid3"), ""))
    '                ms.Fases.Add("6", New RELAP.ClassesBasicasTermodinamica.Fase(RELAP.App.GetLocalString("Aqueous"), ""))
    '                If ChildParent.Options.SelectedComponents.Count = 0 Then
    '                    VDialog.Show(RELAP.App.GetLocalString("Nohcomponentesaadici"))
    '                Else
    '                    Dim comp2 As RELAP.ClassesBasicasTermodinamica.ConstantProperties
    '                    For Each comp2 In ChildParent.Options.SelectedComponents.Values
    '                        ms.Fases(3).Componentes.Add(comp2.Name, New RELAP.ClassesBasicasTermodinamica.Substancia(comp2.Name, ""))
    '                        ms.Fases(3).Componentes(comp2.Name).ConstantProperties = comp2
    '                        ms.Fases(4).Componentes.Add(comp2.Name, New RELAP.ClassesBasicasTermodinamica.Substancia(comp2.Name, ""))
    '                        ms.Fases(4).Componentes(comp2.Name).ConstantProperties = comp2
    '                        ms.Fases(5).Componentes.Add(comp2.Name, New RELAP.ClassesBasicasTermodinamica.Substancia(comp2.Name, ""))
    '                        ms.Fases(5).Componentes(comp2.Name).ConstantProperties = comp2
    '                        ms.Fases(6).Componentes.Add(comp2.Name, New RELAP.ClassesBasicasTermodinamica.Substancia(comp2.Name, ""))
    '                        ms.Fases(6).Componentes(comp2.Name).ConstantProperties = comp2
    '                    Next
    '                End If
    '            ElseIf ms.Fases.Count <= 6 Then
    '                ms.Fases.Add("6", New RELAP.ClassesBasicasTermodinamica.Fase(RELAP.App.GetLocalString("Aqueous"), ""))
    '                If ChildParent.Options.SelectedComponents.Count = 0 Then
    '                    VDialog.Show(RELAP.App.GetLocalString("Nohcomponentesaadici"))
    '                Else
    '                    Dim comp2 As RELAP.ClassesBasicasTermodinamica.ConstantProperties
    '                    For Each comp2 In ChildParent.Options.SelectedComponents.Values
    '                        ms.Fases(6).Componentes.Add(comp2.Name, New RELAP.ClassesBasicasTermodinamica.Substancia(comp2.Name, ""))
    '                        ms.Fases(6).Componentes(comp2.Name).ConstantProperties = comp2
    '                    Next
    '                End If
    '            End If

    '            If Not e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Base")) Then

    '                Dim T, P, W, Q, QV, HM, SM, VF As Double

    '                If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Temperatura")) Then
    '                    T = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_temperature, e.ChangedItem.Value)
    '                    ms.Fases(0).SPMProperties.temperature = T
    '                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Presso")) Then
    '                    P = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_pressure, e.ChangedItem.Value)
    '                    ms.Fases(0).SPMProperties.pressure = P
    '                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomssica")) Then
    '                    W = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_massflow, e.ChangedItem.Value)
    '                    ms.Fases(0).SPMProperties.massflow = W
    '                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomolar")) Then
    '                    Q = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_molarflow, e.ChangedItem.Value)
    '                    ms.Fases(0).SPMProperties.molarflow = Q
    '                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazovolumtrica")) Then
    '                    QV = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_volumetricFlow, e.ChangedItem.Value)
    '                    ms.Fases(0).SPMProperties.volumetric_flow = QV
    '                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("EntalpiaEspecfica")) Then
    '                    HM = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_enthalpy, e.ChangedItem.Value)
    '                    ms.Fases(0).SPMProperties.enthalpy = HM
    '                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("EntropiaEspecfica")) Then
    '                    SM = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_entropy, e.ChangedItem.Value)
    '                    ms.Fases(0).SPMProperties.entropy = SM
    '                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetPropertyName("PROP_MS_106")) Then
    '                    VF = e.ChangedItem.Value
    '                    ms.Fases(2).SPMProperties.molarfraction = VF
    '                End If

    '                T = ms.Fases(0).SPMProperties.temperature.GetValueOrDefault
    '                P = ms.Fases(0).SPMProperties.pressure.GetValueOrDefault
    '                W = ms.Fases(0).SPMProperties.massflow.GetValueOrDefault
    '                Q = ms.Fases(0).SPMProperties.molarflow.GetValueOrDefault
    '                QV = ms.Fases(0).SPMProperties.volumetric_flow.GetValueOrDefault
    '                HM = ms.Fases(0).SPMProperties.enthalpy.GetValueOrDefault
    '                SM = ms.Fases(0).SPMProperties.entropy.GetValueOrDefault
    '                VF = ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault

    '                Dim subs As RELAP.ClassesBasicasTermodinamica.Substancia
    '                Dim comp As Double = 0
    '                For Each subs In ms.Fases(0).Componentes.Values
    '                    comp += subs.FracaoMolar.GetValueOrDefault
    '                Next

    '                If ChildParent.Options.CalculatorActivated Then

    '                    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Temperatura")) Or _
    '                    e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Presso")) Or _
    '                    e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("EntalpiaEspecfica")) Or _
    '                    e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("EntropiaEspecfica")) Or _
    '                    e.ChangedItem.Label.Contains(RELAP.App.GetPropertyName("PROP_MS_106")) Or _
    '                    e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomssica")) Or _
    '                    e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomolar")) Or _
    '                    e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazovolumtrica")) Then
    '                        If (W >= 0 Or Q >= 0 Or QV >= 0) And Math.Abs(comp - 1) <= 0.0001 Then
    '                            With ms.PropertyPackage
    '                                .CurrentMaterialStream = ms
    '                                'Select Case ms.SpecType
    '                                '    Case SimulationObjects.Streams.MaterialStream.Flashspec.Temperature_and_Pressure
    '                                '        .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.T, RELAP.SimulationObjects.PropertyPackages.FlashSpec.P)
    '                                '    Case SimulationObjects.Streams.MaterialStream.Flashspec.Pressure_and_Enthalpy
    '                                '        .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.P, RELAP.SimulationObjects.PropertyPackages.FlashSpec.H)
    '                                '    Case SimulationObjects.Streams.MaterialStream.Flashspec.Pressure_and_Entropy
    '                                '        .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.P, RELAP.SimulationObjects.PropertyPackages.FlashSpec.S)
    '                                '    Case SimulationObjects.Streams.MaterialStream.Flashspec.Pressure_and_VaporFraction
    '                                '        .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.P, RELAP.SimulationObjects.PropertyPackages.FlashSpec.VAP)
    '                                '    Case SimulationObjects.Streams.MaterialStream.Flashspec.Temperature_and_VaporFraction
    '                                '        .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.T, RELAP.SimulationObjects.PropertyPackages.FlashSpec.VAP)
    '                                'End Select
    '                                If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomssica")) Then
    '                                    .DW_CalcVazaoMolar()
    '                                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomolar")) Then
    '                                    .DW_CalcVazaoMassica()
    '                                End If
    '                                'If ms.Fases(3).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                                '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                                'Else
    '                                '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                                'End If
    '                                'If ms.Fases(4).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                                '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                                'Else
    '                                '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                                'End If
    '                                'If ms.Fases(5).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                                '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                                'Else
    '                                '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                                'End If
    '                                'If ms.Fases(6).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                                '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
    '                                'Else
    '                                '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
    '                                'End If
    '                                'If ms.Fases(7).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                                '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                                'Else
    '                                '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                                'End If
    '                                'If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                                '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                                'Else
    '                                '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                                'End If
    '                                'If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault >= 0 And ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault < 1 Then
    '                                '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
    '                                'Else
    '                                '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
    '                                'End If
    '                                .DW_CalcCompMolarFlow(-1)
    '                                .DW_CalcCompMassFlow(-1)
    '                                .DW_CalcCompVolFlow(-1)
    '                                .DW_CalcLiqMixtureProps()
    '                                .DW_CalcOverallProps()
    '                                ' .DW_CalcTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                                If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomssica")) Then
    '                                    .DW_CalcVazaoVolumetrica()
    '                                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomolar")) Then
    '                                    .DW_CalcVazaoVolumetrica()
    '                                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazovolumtrica")) Then
    '                                    ms.Fases(0).SPMProperties.massflow = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_volumetricFlow, e.ChangedItem.Value) * ms.Fases(0).SPMProperties.density.GetValueOrDefault
    '                                    .DW_CalcVazaoMolar()
    '                                    .DW_CalcVazaoMassica()
    '                                Else
    '                                    .DW_CalcVazaoVolumetrica()
    '                                End If
    '                                .DW_CalcKvalue()
    '                                .CurrentMaterialStream = Nothing
    '                            End With
    '                            ms.UpdatePropertyNodes(ChildParent.Options.SelectedUnitSystem, ChildParent.Options.NumberFormat)
    '                            sobj.Calculated = True
    '                            RaiseEvent ObjectStatusChanged(sobj)
    '                            ms.PopulatePropertyGrid(Me.PGEx1, ChildParent.Options.SelectedUnitSystem)
    '                            Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                            With objargs
    '                                .Calculado = True
    '                                .Nome = ms.Nome
    '                                .Tipo = TipoObjeto.MaterialStream
    '                            End With
    '                            'If ms.IsSpecAttached = True And ms.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then
    '                            '    ChildParent.Collections.CLCS_SpecCollection(ms.AttachedSpecId).Calculate()
    '                            'End If
    '                            'CalculateFlowsheet(ChildParent, objargs, ms)
    '                            'ChildParent.CalculationQueue.Enqueue(objargs)
    '                        Else
    '                            With ms.PropertyPackage
    '                                .CurrentMaterialStream = ms
    '                                .DW_ZerarVazaoMolar()
    '                                '.DW_ZerarTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                                '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
    '                                '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                                '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                                '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                                '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                                '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
    '                                '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                                '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
    '                                '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                                '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                                '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                                '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                                '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                                '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
    '                                .DW_ZerarOverallProps()
    '                                .CurrentMaterialStream = Nothing
    '                            End With
    '                            sobj.Calculated = False
    '                            RaiseEvent ObjectStatusChanged(sobj)
    '                        End If

    '                        'ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomssica")) Then
    '                        '    If W > 0 And T > 0 And P > 0 And Math.Abs(comp - 1) <= 0.0001 Then
    '                        '        With ms.PropertyPackage
    '                        '            .CurrentMaterialStream = ms
    '                        '            .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.T, RELAP.SimulationObjects.PropertyPackages.FlashSpec.P)
    '                        '            If ms.Fases(3).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                        '            End If
    '                        '            If ms.Fases(4).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                        '            End If
    '                        '            If ms.Fases(5).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                        '            End If
    '                        '            If ms.Fases(6).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
    '                        '            End If
    '                        '            If ms.Fases(7).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                        '            End If
    '                        '            If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            End If
    '                        '            If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault >= 0 And ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault < 1 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
    '                        '            End If
    '                        '            .DW_CalcCompMolarFlow(-1)
    '                        '            .DW_CalcCompMassFlow(-1)
    '                        '            .DW_CalcCompVolFlow(-1)
    '                        '            .DW_CalcOverallProps()
    '                        '            .DW_CalcTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            .DW_CalcVazaoVolumetrica()
    '                        '            .DW_CalcKvalue()
    '                        '            .CurrentMaterialStream = Nothing
    '                        '        End With
    '                        '        ms.UpdatePropertyNodes(ChildParent.Options.SelectedUnitSystem, ChildParent.Options.NumberFormat)
    '                        '        sobj.Calculated = True
    '                        '        RaiseEvent ObjectStatusChanged(sobj)
    '                        '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                        '        With objargs
    '                        '            .Calculado = True
    '                        '            .Nome = ms.Nome
    '                        '            .Tipo = TipoObjeto.MaterialStream
    '                        '        End With
    '                        '        If ms.IsSpecAttached = True And ms.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(ms.AttachedSpecId).Calculate()
    '                        '        ChildParent.CalculationQueue.Enqueue(objargs)
    '                        '    Else
    '                        '        With ms.PropertyPackage
    '                        '            .CurrentMaterialStream = ms
    '                        '            .DW_ZerarVazaoMolar()
    '                        '            .DW_ZerarVazaoVolumetrica()
    '                        '            .DW_ZerarVazaoMassica()
    '                        '            .DW_ZerarTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                        '            '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
    '                        '            .DW_ZerarOverallProps()
    '                        '            .CurrentMaterialStream = Nothing
    '                        '        End With
    '                        '        sobj.Calculated = False
    '                        '        RaiseEvent ObjectStatusChanged(sobj)
    '                        '    End If
    '                        'ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomolar")) Then
    '                        '    If Q > 0 And T > 0 And P > 0 And Math.Abs(comp - 1) <= 0.0001 Then
    '                        '        With ms.PropertyPackage
    '                        '            .CurrentMaterialStream = ms
    '                        '            .DW_CalcVazaoMassica()
    '                        '            .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.T, RELAP.SimulationObjects.PropertyPackages.FlashSpec.P)
    '                        '            If ms.Fases(3).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                        '            End If
    '                        '            If ms.Fases(4).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                        '            End If
    '                        '            If ms.Fases(5).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                        '            End If
    '                        '            If ms.Fases(6).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
    '                        '            End If
    '                        '            If ms.Fases(7).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                        '            End If
    '                        '            If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            End If
    '                        '            If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault >= 0 And ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault < 1 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
    '                        '            End If
    '                        '            .DW_CalcCompMolarFlow(-1)
    '                        '            .DW_CalcCompMassFlow(-1)
    '                        '            .DW_CalcCompVolFlow(-1)
    '                        '            .DW_CalcOverallProps()
    '                        '            .DW_CalcTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            .DW_CalcVazaoVolumetrica()
    '                        '            .DW_CalcKvalue()
    '                        '            .CurrentMaterialStream = Nothing
    '                        '        End With
    '                        '        ms.UpdatePropertyNodes(ChildParent.Options.SelectedUnitSystem, ChildParent.Options.NumberFormat)
    '                        '        sobj.Calculated = True
    '                        '        RaiseEvent ObjectStatusChanged(sobj)
    '                        '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                        '        With objargs
    '                        '            .Calculado = True
    '                        '            .Nome = ms.Nome
    '                        '            .Tipo = TipoObjeto.MaterialStream
    '                        '        End With
    '                        '        If ms.IsSpecAttached = True And ms.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(ms.AttachedSpecId).Calculate()
    '                        '        ChildParent.CalculationQueue.Enqueue(objargs)
    '                        '    Else
    '                        '        With ms.PropertyPackage
    '                        '            .CurrentMaterialStream = ms
    '                        '            .DW_ZerarVazaoMolar()
    '                        '            .DW_ZerarVazaoVolumetrica()
    '                        '            .DW_ZerarVazaoMassica()
    '                        '            .DW_ZerarTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                        '            '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
    '                        '            .DW_ZerarOverallProps()
    '                        '            .CurrentMaterialStream = Nothing
    '                        '        End With
    '                        '        sobj.Calculated = False
    '                        '        RaiseEvent ObjectStatusChanged(sobj)
    '                        '    End If
    '                        'ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazovolumtrica")) Then
    '                        '    If QV > 0 And T > 0 And P > 0 And Math.Abs(comp - 1) <= 0.0001 Then
    '                        '        With ms.PropertyPackage
    '                        '            .CurrentMaterialStream = ms
    '                        '            'ms.Fases(0).SPMProperties.massflow = 0
    '                        '            .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.T, RELAP.SimulationObjects.PropertyPackages.FlashSpec.P)
    '                        '            If ms.Fases(3).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                        '            End If
    '                        '            If ms.Fases(4).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                        '            End If
    '                        '            If ms.Fases(5).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                        '            End If
    '                        '            If ms.Fases(6).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
    '                        '            End If
    '                        '            If ms.Fases(7).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                        '            End If
    '                        '            If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            End If
    '                        '            If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault >= 0 And ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault < 1 Then
    '                        '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
    '                        '            Else
    '                        '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
    '                        '            End If
    '                        '            .DW_CalcOverallProps()
    '                        '            .DW_CalcTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            ms.Fases(0).SPMProperties.massflow = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_volumetricFlow, e.ChangedItem.Value) * ms.Fases(0).SPMProperties.density.GetValueOrDefault
    '                        '            .DW_CalcVazaoMolar()
    '                        '            .DW_CalcVazaoMassica()
    '                        '            .DW_CalcCompMolarFlow(-1)
    '                        '            .DW_CalcCompMassFlow(-1)
    '                        '            .DW_CalcCompVolFlow(-1)
    '                        '            .DW_CalcKvalue()
    '                        '            .CurrentMaterialStream = Nothing
    '                        '        End With
    '                        '        ms.UpdatePropertyNodes(ChildParent.Options.SelectedUnitSystem, ChildParent.Options.NumberFormat)
    '                        '        sobj.Calculated = True
    '                        '        RaiseEvent ObjectStatusChanged(sobj)
    '                        '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                        '        With objargs
    '                        '            .Calculado = True
    '                        '            .Nome = ms.Nome
    '                        '            .Tipo = TipoObjeto.MaterialStream
    '                        '        End With
    '                        '        If ms.IsSpecAttached = True And ms.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(ms.AttachedSpecId).Calculate()
    '                        '        ChildParent.CalculationQueue.Enqueue(objargs)
    '                        '    Else
    '                        '        With ms.PropertyPackage
    '                        '            .CurrentMaterialStream = ms
    '                        '            .DW_ZerarVazaoMolar()
    '                        '            .DW_ZerarVazaoVolumetrica()
    '                        '            .DW_ZerarVazaoMassica()
    '                        '            .DW_ZerarTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                        '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
    '                        '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
    '                        '            '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
    '                        '            .DW_ZerarOverallProps()
    '                        '            .CurrentMaterialStream = Nothing
    '                        '        End With
    '                        '        sobj.Calculated = False
    '                        '        RaiseEvent ObjectStatusChanged(sobj)
    '                        '    End If

    '                    End If

    '                End If

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.EnergyStream Then

    '            Dim es As RELAP.SimulationObjects.Streams.EnergyStream = ChildParent.Collections.CLCS_EnergyStreamCollection.Item(sobj.Name)

    '            es.Energia = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_heatflow, e.ChangedItem.Value)

    '            If ChildParent.Options.CalculatorActivated Then

    '                sobj.Calculated = True
    '                RaiseEvent ObjectStatusChanged(sobj)

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = True
    '                    .Nome = sobj.Name
    '                    .Tag = sobj.Tag
    '                    .Tipo = TipoObjeto.EnergyStream
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If es.IsSpecAttached = True And es.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(es.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If


    '        ElseIf sobj.TipoObjeto = TipoObjeto.NodeOut Then

    '            Dim sp As RELAP.SimulationObjects.UnitOps.Splitter = ChildParent.Collections.CLCS_SplitterCollection.Item(sobj.Name)

    '            If e.ChangedItem.Parent.Label.Contains(RELAP.App.GetLocalString("Fraesdascorrentes2")) Then

    '                If e.ChangedItem.Value < 0 Or e.ChangedItem.Value > 1 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

    '                Dim i As Integer = 0
    '                Dim j As Integer = 0

    '                Dim cp As ConnectionPoint
    '                For Each cp In sp.GraphicObject.OutputConnectors
    '                    If cp.IsAttached Then
    '                        If cp.AttachedConnector.AttachedTo.Tag = e.ChangedItem.Label Then
    '                            sp.Ratios(i) = e.ChangedItem.Value
    '                        End If
    '                    End If
    '                    i += 1
    '                Next

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                sobj.Calculated = True

    '                RaiseEvent ObjectStatusChanged(sobj)

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Nome = sobj.Name
    '                    .Tag = sobj.Tag
    '                    .Tipo = TipoObjeto.NodeOut
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If sp.IsSpecAttached = True And sp.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(sp.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.Pump Then

    '            Dim bb As RELAP.SimulationObjects.UnitOps.Pump = ChildParent.Collections.CLCS_PumpCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains("Delta P") Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Pressoajusante")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.Pout = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_pressure, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Eficincia")) Then

    '                If e.ChangedItem.Value <= 20 Or e.ChangedItem.Value > 100 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Correntedeentrada")) Then

    '                If FormFlowsheet.SearchSurfaceObjectsByTag(e.ChangedItem.Value, ChildParent.FormSurface.FlowsheetDesignSurface) Is Nothing Then
    '                    Dim oguid As String = ChildParent.FormSurface.AddObjectToSurface(TipoObjeto.MaterialStream, sobj.X - 40, sobj.Y, e.ChangedItem.Value)
    '                End If

    '                If Not sobj.InputConnectors(0).IsAttached Then
    '                    ChildParent.ConnectObject(FormFlowsheet.SearchSurfaceObjectsByTag(e.ChangedItem.Value, ChildParent.FormSurface.FlowsheetDesignSurface), sobj)
    '                Else
    '                    ChildParent.DisconnectObject(sobj.InputConnectors(0).AttachedConnector.AttachedFrom, sobj)
    '                    ChildParent.ConnectObject(FormFlowsheet.SearchSurfaceObjectsByTag(e.ChangedItem.Value, ChildParent.FormSurface.FlowsheetDesignSurface), sobj)
    '                End If

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Correntedesada")) Then

    '                If FormFlowsheet.SearchSurfaceObjectsByTag(e.ChangedItem.Value, ChildParent.FormSurface.FlowsheetDesignSurface) Is Nothing Then
    '                    Dim oguid As String = ChildParent.FormSurface.AddObjectToSurface(TipoObjeto.MaterialStream, sobj.X + sobj.Width + 40, sobj.Y, e.ChangedItem.Value)
    '                End If

    '                If Not sobj.OutputConnectors(0).IsAttached Then
    '                    ChildParent.ConnectObject(sobj, FormFlowsheet.SearchSurfaceObjectsByTag(e.ChangedItem.Value, ChildParent.FormSurface.FlowsheetDesignSurface))
    '                Else
    '                    ChildParent.DisconnectObject(sobj, sobj.OutputConnectors(0).AttachedConnector.AttachedTo)
    '                    ChildParent.ConnectObject(sobj, FormFlowsheet.SearchSurfaceObjectsByTag(e.ChangedItem.Value, ChildParent.FormSurface.FlowsheetDesignSurface))
    '                End If

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Tag = sobj.Tag
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.Pump
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.Valve Then

    '            Dim bb As RELAP.SimulationObjects.UnitOps.Valve = ChildParent.Collections.CLCS_ValveCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

    '                bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '                'If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("ValveOutletPressure")) Then

    '                bb.OutletPressure = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_pressure, e.ChangedItem.Value)

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Tag = sobj.Tag
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.Valve
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.Compressor Then

    '            Dim bb As RELAP.SimulationObjects.UnitOps.Compressor = ChildParent.Collections.CLCS_CompressorCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains("Delta P") Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Eficincia")) Then

    '                If e.ChangedItem.Value <= 20 Or e.ChangedItem.Value > 100 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Tag = sobj.Tag
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.Compressor
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.Expander Then

    '            Dim bb As RELAP.SimulationObjects.UnitOps.Expander = ChildParent.Collections.CLCS_TurbineCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Eficincia")) Then

    '                If e.ChangedItem.Value <= 20 Or e.ChangedItem.Value > 100 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Tag = sobj.Tag
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.Expander
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.Pipe Then

    '            Dim bb As RELAP.SimulationObjects.UnitOps.Pipe = ChildParent.Collections.CLCS_PipeCollection.Item(sobj.Name)

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Tag = sobj.Tag
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.Pipe
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.Heater Then

    '            Dim bb As RELAP.SimulationObjects.UnitOps.Heater = ChildParent.Collections.CLCS_HeaterCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Eficincia")) Then

    '                If e.ChangedItem.Value <= 20 Or e.ChangedItem.Value > 100 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Calor")) Then

    '                bb.DeltaQ = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_heatflow, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HeaterCoolerOutletTemperature")) Then

    '                bb.OutletTemperature = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_temperature, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("FraomolardafaseFaseV")) Then

    '                bb.OutletVaporFraction = Double.Parse(e.ChangedItem.Value)

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Tag = sobj.Tag
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.Heater
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.Cooler Then

    '            Dim bb As RELAP.SimulationObjects.UnitOps.Cooler = ChildParent.Collections.CLCS_CoolerCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Eficincia")) Then

    '                If e.ChangedItem.Value <= 20 Or e.ChangedItem.Value > 100 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Calor")) Then

    '                bb.DeltaQ = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_heatflow, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HeaterCoolerOutletTemperature")) Then

    '                bb.OutletTemperature = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_temperature, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("FraomolardafaseFaseV")) Then

    '                bb.OutletVaporFraction = Double.Parse(e.ChangedItem.Value)

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Tag = sobj.Tag
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.Cooler
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.Tank Then

    '            Dim bb As RELAP.SimulationObjects.UnitOps.Tank = ChildParent.Collections.CLCS_TankCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("AquecimentoResfriame")) Then

    '                bb.DeltaQ = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_heatflow, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("TKVol")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.Volume = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.volume, e.ChangedItem.Value)

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Tag = sobj.Tag
    '                    .Calculado = False
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.Tank
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.OT_Ajuste Then

    '            Dim adj As RELAP.SimulationObjects.SpecialOps.Adjust = ChildParent.Collections.CLCS_AdjustCollection.Item(sobj.Name)

    '            With adj
    '                If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Controlada")) Then
    '                    .ControlledObject = ChildParent.Collections.ObjectCollection(.ControlledObjectData.m_ID)
    '                    .ControlledVariable = .ControlledObjectData.m_Property
    '                    CType(ChildParent.Collections.AdjustCollection(adj.Nome), AdjustGraphic).ConnectedToCv = .ControlledObject.GraphicObject
    '                    .ReferenceObject = Nothing
    '                    .ReferenceVariable = Nothing
    '                    With .ReferencedObjectData
    '                        .m_ID = ""
    '                        .m_Name = ""
    '                        .m_Property = ""
    '                        .m_Type = ""
    '                    End With
    '                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Manipulada")) Then
    '                    .ManipulatedObject = ChildParent.Collections.ObjectCollection(.ManipulatedObjectData.m_ID)
    '                    Dim gr As AdjustGraphic = ChildParent.Collections.AdjustCollection(adj.Nome)
    '                    gr.ConnectedToMv = .ManipulatedObject.GraphicObject
    '                    .ManipulatedVariable = .ManipulatedObjectData.m_Property
    '                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("ObjetoVariveldeRefer")) Then
    '                    .ReferenceObject = ChildParent.Collections.ObjectCollection(.ReferencedObjectData.m_ID)
    '                    .ReferenceVariable = .ReferencedObjectData.m_Property
    '                    Dim gr As AdjustGraphic = ChildParent.Collections.AdjustCollection(adj.Nome)
    '                    gr.ConnectedToRv = .ReferenceObject.GraphicObject
    '                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Valormnimoopcional")) Then
    '                    adj.MinVal = Conversor.ConverterParaSI(adj.ManipulatedObject.GetPropertyUnit(adj.ManipulatedObjectData.m_Property, ChildParent.Options.SelectedUnitSystem), e.ChangedItem.Value)
    '                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Valormximoopcional")) Then
    '                    adj.MaxVal = Conversor.ConverterParaSI(adj.ManipulatedObject.GetPropertyUnit(adj.ManipulatedObjectData.m_Property, ChildParent.Options.SelectedUnitSystem), e.ChangedItem.Value)
    '                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("ValordeAjusteouOffse")) Then
    '                    adj.AdjustValue = Conversor.ConverterParaSI(adj.ControlledObject.GetPropertyUnit(adj.ControlledObjectData.m_Property, ChildParent.Options.SelectedUnitSystem), e.ChangedItem.Value)
    '                End If
    '            End With

    '        ElseIf sobj.TipoObjeto = TipoObjeto.OT_Especificacao Then

    '            Dim spec As RELAP.SimulationObjects.SpecialOps.Spec = ChildParent.Collections.CLCS_SpecCollection.Item(sobj.Name)

    '            With spec
    '                If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Destino")) Then
    '                    .TargetObject = ChildParent.Collections.ObjectCollection(.TargetObjectData.m_ID)
    '                    .TargetVariable = .TargetObjectData.m_Property
    '                    CType(ChildParent.Collections.SpecCollection(spec.Nome), SpecGraphic).ConnectedToTv = .TargetObject.GraphicObject
    '                ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Fonte")) Then
    '                    .SourceObject = ChildParent.Collections.ObjectCollection(.SourceObjectData.m_ID)
    '                    Dim gr As SpecGraphic = ChildParent.Collections.SpecCollection(spec.Nome)
    '                    gr.ConnectedToSv = .SourceObject.GraphicObject
    '                    .SourceVariable = .SourceObjectData.m_Property
    '                End If
    '            End With

    '        ElseIf sobj.TipoObjeto = TipoObjeto.Vessel Then

    '            Dim vessel As RELAP.SimulationObjects.UnitOps.Vessel = ChildParent.Collections.CLCS_VesselCollection.Item(sobj.Name)

    '            Dim T, P As Double
    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Temperatura")) Then
    '                T = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_temperature, e.ChangedItem.Value)
    '                vessel.FlashTemperature = T
    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Presso")) Then
    '                P = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_pressure, e.ChangedItem.Value)
    '                vessel.FlashPressure = P
    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Tag = sobj.Tag
    '                    .Calculado = False
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.Vessel
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If vessel.IsSpecAttached = True And vessel.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(vessel.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.OT_Reciclo Then

    '            Dim rec As RELAP.SimulationObjects.SpecialOps.Recycle = ChildParent.Collections.CLCS_RecycleCollection.Item(sobj.Name)

    '            Dim T, P, W As Double
    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Temperatura")) Then
    '                T = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaT, e.ChangedItem.Value)
    '                rec.ConvergenceParameters.Temperatura = T
    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Presso")) Then
    '                P = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)
    '                rec.ConvergenceParameters.Pressao = P
    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("mssica")) Then
    '                W = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_massflow, e.ChangedItem.Value)
    '                rec.ConvergenceParameters.VazaoMassica = W
    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.RCT_Conversion Then

    '            Dim bb As RELAP.SimulationObjects.Reactors.Reactor_Conversion = ChildParent.Collections.CLCS_ReactorConversionCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Tag = sobj.Tag
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.RCT_Conversion
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.RCT_Equilibrium Then

    '            Dim bb As RELAP.SimulationObjects.Reactors.Reactor_Equilibrium = ChildParent.Collections.CLCS_ReactorEquilibriumCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Tag = sobj.Tag
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.RCT_Equilibrium
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.RCT_Gibbs Then

    '            Dim bb As RELAP.SimulationObjects.Reactors.Reactor_Gibbs = ChildParent.Collections.CLCS_ReactorGibbsCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Tag = sobj.Tag
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.RCT_Gibbs
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.RCT_CSTR Then

    '            Dim bb As RELAP.SimulationObjects.Reactors.Reactor_CSTR = ChildParent.Collections.CLCS_ReactorCSTRCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '            End If

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("RCSTRPGridItem1")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.Volume = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.volume, e.ChangedItem.Value)

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Tag = sobj.Tag
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.RCT_CSTR
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.RCT_PFR Then

    '            Dim bb As RELAP.SimulationObjects.Reactors.Reactor_PFR = ChildParent.Collections.CLCS_ReactorPFRCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '            End If

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("RCSTRPGridItem1")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.Volume = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.volume, e.ChangedItem.Value)

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Tag = sobj.Tag
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.RCT_PFR
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.HeatStructure Then

    '            Dim bb As RELAP.SimulationObjects.UnitOps.HeatStructure = ChildParent.Collections.CLCS_HeatStructureCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("OverallHeatTranferCoefficient")) Then

    '                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
    '                bb.OverallCoefficient = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.heat_transf_coeff, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Area")) Then

    '                bb.Area = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.area, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HeatLoad")) Then

    '                bb.Q = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_heatflow, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HXHotSidePressureDrop")) Then

    '                bb.HotSidePressureDrop = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HXColdSidePressureDrop")) Then

    '                bb.ColdSidePressureDrop = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HXTempHotOut")) Then

    '                bb.HotSideOutletTemperature = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_temperature, e.ChangedItem.Value)

    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HXTempColdOut")) Then

    '                bb.ColdSideOutletTemperature = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_temperature, e.ChangedItem.Value)

    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Tag = sobj.Tag
    '                    .Calculado = False
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.HeatStructure
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.ShortcutColumn Then

    '            Dim sc As RELAP.SimulationObjects.UnitOps.ShortcutColumn = ChildParent.Collections.CLCS_ShortcutColumnCollection.Item(sobj.Name)
    '            Dim Pr, Pc As Double

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("SCCondenserType")) Then
    '                sc.GraphicObject.Shape = sc.condtype
    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("SCCondenserPressure")) Then
    '                Pc = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_pressure, e.ChangedItem.Value)
    '                sc.m_condenserpressure = Pc
    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("SCReboilerPressure")) Then
    '                Pr = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_pressure, e.ChangedItem.Value)
    '                sc.m_boilerpressure = Pr
    '            ElseIf e.ChangedItem.Label.Equals(RELAP.App.GetLocalString("SCLightKey")) Then
    '                sc.m_lightkey = e.ChangedItem.Value
    '            ElseIf e.ChangedItem.Label.Equals(RELAP.App.GetLocalString("SCHeavyKey")) Then
    '                sc.m_heavykey = e.ChangedItem.Value
    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Tag = sobj.Tag
    '                    .Calculado = False
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.ShortcutColumn
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If sc.IsSpecAttached = True And sc.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(sc.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If

    '        ElseIf sobj.TipoObjeto = TipoObjeto.OrificePlate Then

    '            Dim op As RELAP.SimulationObjects.UnitOps.OrificePlate = ChildParent.Collections.CLCS_OrificePlateCollection.Item(sobj.Name)

    '            If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("OPOrificeDiameter")) Then
    '                op.OrificeDiameter = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.diameter, e.ChangedItem.Value)
    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("OPBeta")) Then
    '                op.Beta = e.ChangedItem.Value
    '            ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("OPCorrectionFactor")) Then
    '                op.CorrectionFactor = e.ChangedItem.Value
    '            End If

    '            If ChildParent.Options.CalculatorActivated Then

    '                'Call function to calculate flowsheet
    '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
    '                With objargs
    '                    .Calculado = False
    '                    .Tag = sobj.Tag
    '                    .Nome = sobj.Name
    '                    .Tipo = TipoObjeto.OrificePlate
    '                    .Emissor = "PropertyGrid"
    '                End With

    '                If op.IsSpecAttached = True And op.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(op.AttachedSpecId).Calculate()
    '                ChildParent.CalculationQueue.Enqueue(objargs)

    '            End If


    '        End If

    '    End If

    '    Call ChildParent.FormSurface.UpdateSelectedObject()
    '    Call ChildParent.FormSurface.FlowsheetDesignSurface.Invalidate()
    '    Application.DoEvents()
    '    If ChildParent.Options.CalculatorActivated Then ProcessCalculationQueue(ChildParent)

    'End Sub

    Private Sub FormChild_ObjectStatusChanged(ByVal obj As Microsoft.Msdn.Samples.GraphicObjects.GraphicObject) Handles Me.ObjectStatusChanged

        If obj.Active = False Then
            LblStatusObj.Text = RELAP.App.GetLocalString("Inativo")
            LblStatusObj.ForeColor = Color.DimGray
        ElseIf obj.Calculated = False Then
            LblStatusObj.Text = RELAP.App.GetLocalString("NoCalculado")
            LblStatusObj.ForeColor = Color.Red
        Else
            LblStatusObj.Text = RELAP.App.GetLocalString("Calculado")
            LblStatusObj.ForeColor = Color.DarkGreen
        End If

    End Sub


    Private Sub PGEx2_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PGEx2.PropertyValueChanged
        ChildParent = Me.ParentForm
        If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Nome")) Then
            If FormFlowsheet.SearchSurfaceObjectsByTag(e.ChangedItem.Value, ChildParent.FormSurface.FlowsheetDesignSurface) Is Nothing Then
                Try
                    If Not ChildParent.Collections.ObjectCollection(ChildParent.FormSurface.FlowsheetDesignSurface.SelectedObject.Name).Tabela Is Nothing Then
                        ChildParent.Collections.ObjectCollection(ChildParent.FormSurface.FlowsheetDesignSurface.SelectedObject.Name).Tabela.HeaderText = ChildParent.FormSurface.FlowsheetDesignSurface.SelectedObject.Tag
                    End If
                    'ChildParent.FormObjList.TreeViewObj.Nodes.Find(ChildParent.FormSurface.FlowsheetDesignSurface.SelectedObject.Name, True)(0).Text = e.ChangedItem.Value
                Catch ex As Exception
                    'ChildParent.WriteToLog(ex.ToString, Color.Red, FormClasses.TipoAviso.Erro)
                Finally
                    CType(FormFlowsheet.SearchSurfaceObjectsByTag(e.OldValue, ChildParent.FormSurface.FlowsheetDesignSurface), GraphicObject).Tag = e.ChangedItem.Value
                End Try
            Else
                VDialog.Show(RELAP.App.GetLocalString("JaExisteObjetoNome"), RELAP.App.GetLocalString("Erro"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            ChildParent.FormSurface.FlowsheetDesignSurface.Invalidate()
        End If
    End Sub

    Private Sub PGEx1_PropertyValueChanged(s As Object, e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PGEx1.PropertyValueChanged
        ChildParent = Me.ParentForm

        Dim sobj As Microsoft.Msdn.Samples.GraphicObjects.GraphicObject = ChildParent.FormSurface.FlowsheetDesignSurface.SelectedObject

        'handle changes internally
        If Not sobj Is Nothing Then

            If sobj.TipoObjeto <> TipoObjeto.GO_Tabela And sobj.TipoObjeto <> TipoObjeto.GO_MasterTable Then

                ChildParent.Collections.ObjectCollection(sobj.Name).PropertyValueChanged(s, e)

            End If

        End If

        'more...

        ChildParent.FormSurface.FlowsheetDesignSurface.SelectedObject = sobj

        '   If Not sobj Is Nothing Then

        If sobj.TipoObjeto = TipoObjeto.GO_MasterTable Then

            Dim mt As RELAP.GraphicObjects.MasterTableGraphic = sobj

            If e.ChangedItem.PropertyDescriptor.Category.Contains(RELAP.App.GetLocalString("MT_PropertiesToShow")) Then
                If Not mt.PropertyList.ContainsKey(e.ChangedItem.Label) Then
                    mt.PropertyList.Add(e.ChangedItem.Label, e.ChangedItem.Value)
                Else
                    mt.PropertyList(e.ChangedItem.Label) = e.ChangedItem.Value
                End If
            ElseIf e.ChangedItem.PropertyDescriptor.Category.Contains(RELAP.App.GetLocalString("MT_ObjectsToShow")) Then
                If Not mt.ObjectList.ContainsKey(e.ChangedItem.Label) Then
                    mt.ObjectList.Add(e.ChangedItem.Label, e.ChangedItem.Value)
                Else
                    mt.ObjectList(e.ChangedItem.Label) = e.ChangedItem.Value
                End If
            End If

            mt.Update(ChildParent)

        ElseIf sobj.TipoObjeto = TipoObjeto.MaterialStream Then

            ' Dim ms As RELAP.SimulationObjects.Streams.MaterialStream = ChildParent.Collections.CLCS_MaterialStreamCollection.Item(sobj.Name)

            'If ms.Fases.Count <= 3 Then
            '    ms.Fases.Add("3", New RELAP.ClassesBasicasTermodinamica.Fase(RELAP.App.GetLocalString("Liquid1"), ""))
            '    ms.Fases.Add("4", New RELAP.ClassesBasicasTermodinamica.Fase(RELAP.App.GetLocalString("Liquid2"), ""))
            '    ms.Fases.Add("5", New RELAP.ClassesBasicasTermodinamica.Fase(RELAP.App.GetLocalString("Liquid3"), ""))
            '    ms.Fases.Add("6", New RELAP.ClassesBasicasTermodinamica.Fase(RELAP.App.GetLocalString("Aqueous"), ""))
            '    If ChildParent.Options.SelectedComponents.Count = 0 Then
            '        VDialog.Show(RELAP.App.GetLocalString("Nohcomponentesaadici"))
            '    Else
            '        Dim comp2 As RELAP.ClassesBasicasTermodinamica.ConstantProperties
            '        For Each comp2 In ChildParent.Options.SelectedComponents.Values
            '            ms.Fases(3).Componentes.Add(comp2.Name, New RELAP.ClassesBasicasTermodinamica.Substancia(comp2.Name, ""))
            '            ms.Fases(3).Componentes(comp2.Name).ConstantProperties = comp2
            '            ms.Fases(4).Componentes.Add(comp2.Name, New RELAP.ClassesBasicasTermodinamica.Substancia(comp2.Name, ""))
            '            ms.Fases(4).Componentes(comp2.Name).ConstantProperties = comp2
            '            ms.Fases(5).Componentes.Add(comp2.Name, New RELAP.ClassesBasicasTermodinamica.Substancia(comp2.Name, ""))
            '            ms.Fases(5).Componentes(comp2.Name).ConstantProperties = comp2
            '            ms.Fases(6).Componentes.Add(comp2.Name, New RELAP.ClassesBasicasTermodinamica.Substancia(comp2.Name, ""))
            '            ms.Fases(6).Componentes(comp2.Name).ConstantProperties = comp2
            '        Next
            '    End If
            'ElseIf ms.Fases.Count <= 6 Then
            '    ms.Fases.Add("6", New RELAP.ClassesBasicasTermodinamica.Fase(RELAP.App.GetLocalString("Aqueous"), ""))
            '    If ChildParent.Options.SelectedComponents.Count = 0 Then
            '        VDialog.Show(RELAP.App.GetLocalString("Nohcomponentesaadici"))
            '    Else
            '        Dim comp2 As RELAP.ClassesBasicasTermodinamica.ConstantProperties
            '        For Each comp2 In ChildParent.Options.SelectedComponents.Values
            '            ms.Fases(6).Componentes.Add(comp2.Name, New RELAP.ClassesBasicasTermodinamica.Substancia(comp2.Name, ""))
            '            ms.Fases(6).Componentes(comp2.Name).ConstantProperties = comp2
            '        Next
            '    End If
            'End If

            'If Not e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Base")) Then

            '    Dim T, P, W, Q, QV, HM, SM, VF As Double

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Temperatura")) Then
            '        T = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_temperature, e.ChangedItem.Value)
            '        ms.Fases(0).SPMProperties.temperature = T
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Presso")) Then
            '        P = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_pressure, e.ChangedItem.Value)
            '        ms.Fases(0).SPMProperties.pressure = P
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomssica")) Then
            '        W = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_massflow, e.ChangedItem.Value)
            '        ms.Fases(0).SPMProperties.massflow = W
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomolar")) Then
            '        Q = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_molarflow, e.ChangedItem.Value)
            '        ms.Fases(0).SPMProperties.molarflow = Q
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazovolumtrica")) Then
            '        QV = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_volumetricFlow, e.ChangedItem.Value)
            '        ms.Fases(0).SPMProperties.volumetric_flow = QV
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("EntalpiaEspecfica")) Then
            '        HM = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_enthalpy, e.ChangedItem.Value)
            '        ms.Fases(0).SPMProperties.enthalpy = HM
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("EntropiaEspecfica")) Then
            '        SM = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_entropy, e.ChangedItem.Value)
            '        ms.Fases(0).SPMProperties.entropy = SM
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetPropertyName("PROP_MS_106")) Then
            '        VF = e.ChangedItem.Value
            '        ms.Fases(2).SPMProperties.molarfraction = VF
            '    End If

            '    T = ms.Fases(0).SPMProperties.temperature.GetValueOrDefault
            '    P = ms.Fases(0).SPMProperties.pressure.GetValueOrDefault
            '    W = ms.Fases(0).SPMProperties.massflow.GetValueOrDefault
            '    Q = ms.Fases(0).SPMProperties.molarflow.GetValueOrDefault
            '    QV = ms.Fases(0).SPMProperties.volumetric_flow.GetValueOrDefault
            '    HM = ms.Fases(0).SPMProperties.enthalpy.GetValueOrDefault
            '    SM = ms.Fases(0).SPMProperties.entropy.GetValueOrDefault
            '    VF = ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault

            '    Dim subs As RELAP.ClassesBasicasTermodinamica.Substancia
            '    Dim comp As Double = 0
            '    For Each subs In ms.Fases(0).Componentes.Values
            '        comp += subs.FracaoMolar.GetValueOrDefault
            '    Next

            '    If ChildParent.Options.CalculatorActivated Then

            '        If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Temperatura")) Or _
            '        e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Presso")) Or _
            '        e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("EntalpiaEspecfica")) Or _
            '        e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("EntropiaEspecfica")) Or _
            '        e.ChangedItem.Label.Contains(RELAP.App.GetPropertyName("PROP_MS_106")) Or _
            '        e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomssica")) Or _
            '        e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomolar")) Or _
            '        e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazovolumtrica")) Then
            '            If (W >= 0 Or Q >= 0 Or QV >= 0) And Math.Abs(comp - 1) <= 0.0001 Then
            '                With ms.PropertyPackage
            '                    .CurrentMaterialStream = ms
            '                    'Select Case ms.SpecType
            '                    '    Case SimulationObjects.Streams.MaterialStream.Flashspec.Temperature_and_Pressure
            '                    '        .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.T, RELAP.SimulationObjects.PropertyPackages.FlashSpec.P)
            '                    '    Case SimulationObjects.Streams.MaterialStream.Flashspec.Pressure_and_Enthalpy
            '                    '        .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.P, RELAP.SimulationObjects.PropertyPackages.FlashSpec.H)
            '                    '    Case SimulationObjects.Streams.MaterialStream.Flashspec.Pressure_and_Entropy
            '                    '        .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.P, RELAP.SimulationObjects.PropertyPackages.FlashSpec.S)
            '                    '    Case SimulationObjects.Streams.MaterialStream.Flashspec.Pressure_and_VaporFraction
            '                    '        .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.P, RELAP.SimulationObjects.PropertyPackages.FlashSpec.VAP)
            '                    '    Case SimulationObjects.Streams.MaterialStream.Flashspec.Temperature_and_VaporFraction
            '                    '        .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.T, RELAP.SimulationObjects.PropertyPackages.FlashSpec.VAP)
            '                    'End Select
            '                    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomssica")) Then
            '                        .DW_CalcVazaoMolar()
            '                    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomolar")) Then
            '                        .DW_CalcVazaoMassica()
            '                    End If
            '                    'If ms.Fases(3).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '                    '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '                    'Else
            '                    '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '                    'End If
            '                    'If ms.Fases(4).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '                    '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '                    'Else
            '                    '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '                    'End If
            '                    'If ms.Fases(5).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '                    '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '                    'Else
            '                    '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '                    'End If
            '                    'If ms.Fases(6).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '                    '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
            '                    'Else
            '                    '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
            '                    'End If
            '                    'If ms.Fases(7).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '                    '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '                    'Else
            '                    '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '                    'End If
            '                    'If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '                    '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '                    'Else
            '                    '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '                    'End If
            '                    'If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault >= 0 And ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault < 1 Then
            '                    '    .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
            '                    'Else
            '                    '    .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
            '                    'End If
            '                    .DW_CalcCompMolarFlow(-1)
            '                    .DW_CalcCompMassFlow(-1)
            '                    .DW_CalcCompVolFlow(-1)
            '                    .DW_CalcLiqMixtureProps()
            '                    .DW_CalcOverallProps()
            '                    ' .DW_CalcTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '                    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomssica")) Then
            '                        .DW_CalcVazaoVolumetrica()
            '                    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomolar")) Then
            '                        .DW_CalcVazaoVolumetrica()
            '                    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazovolumtrica")) Then
            '                        ms.Fases(0).SPMProperties.massflow = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_volumetricFlow, e.ChangedItem.Value) * ms.Fases(0).SPMProperties.density.GetValueOrDefault
            '                        .DW_CalcVazaoMolar()
            '                        .DW_CalcVazaoMassica()
            '                    Else
            '                        .DW_CalcVazaoVolumetrica()
            '                    End If
            '                    .DW_CalcKvalue()
            '                    .CurrentMaterialStream = Nothing
            '                End With
            '                ms.UpdatePropertyNodes(ChildParent.Options.SelectedUnitSystem, ChildParent.Options.NumberFormat)
            '                sobj.Calculated = True
            '                RaiseEvent ObjectStatusChanged(sobj)
            '                ms.PopulatePropertyGrid(Me.PGEx1, ChildParent.Options.SelectedUnitSystem)
            '                Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '                With objargs
            '                    .Calculado = True
            '                    .Nome = ms.Nome
            '                    .Tipo = TipoObjeto.MaterialStream
            '                End With
            '                'If ms.IsSpecAttached = True And ms.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then
            '                '    ChildParent.Collections.CLCS_SpecCollection(ms.AttachedSpecId).Calculate()
            '                'End If
            '                'CalculateFlowsheet(ChildParent, objargs, ms)
            '                'ChildParent.CalculationQueue.Enqueue(objargs)
            '            Else
            '                With ms.PropertyPackage
            '                    .CurrentMaterialStream = ms
            '                    .DW_ZerarVazaoMolar()
            '                    '.DW_ZerarTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '                    '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
            '                    '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '                    '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '                    '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '                    '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '                    '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
            '                    '.DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '                    '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
            '                    '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '                    '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '                    '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '                    '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '                    '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '                    '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
            '                    .DW_ZerarOverallProps()
            '                    .CurrentMaterialStream = Nothing
            '                End With
            '                sobj.Calculated = False
            '                RaiseEvent ObjectStatusChanged(sobj)
            '            End If

            '            'ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomssica")) Then
            '            '    If W > 0 And T > 0 And P > 0 And Math.Abs(comp - 1) <= 0.0001 Then
            '            '        With ms.PropertyPackage
            '            '            .CurrentMaterialStream = ms
            '            '            .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.T, RELAP.SimulationObjects.PropertyPackages.FlashSpec.P)
            '            '            If ms.Fases(3).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '            '            End If
            '            '            If ms.Fases(4).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '            '            End If
            '            '            If ms.Fases(5).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '            '            End If
            '            '            If ms.Fases(6).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
            '            '            End If
            '            '            If ms.Fases(7).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '            '            End If
            '            '            If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            End If
            '            '            If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault >= 0 And ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault < 1 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
            '            '            End If
            '            '            .DW_CalcCompMolarFlow(-1)
            '            '            .DW_CalcCompMassFlow(-1)
            '            '            .DW_CalcCompVolFlow(-1)
            '            '            .DW_CalcOverallProps()
            '            '            .DW_CalcTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            .DW_CalcVazaoVolumetrica()
            '            '            .DW_CalcKvalue()
            '            '            .CurrentMaterialStream = Nothing
            '            '        End With
            '            '        ms.UpdatePropertyNodes(ChildParent.Options.SelectedUnitSystem, ChildParent.Options.NumberFormat)
            '            '        sobj.Calculated = True
            '            '        RaiseEvent ObjectStatusChanged(sobj)
            '            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '            '        With objargs
            '            '            .Calculado = True
            '            '            .Nome = ms.Nome
            '            '            .Tipo = TipoObjeto.MaterialStream
            '            '        End With
            '            '        If ms.IsSpecAttached = True And ms.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(ms.AttachedSpecId).Calculate()
            '            '        ChildParent.CalculationQueue.Enqueue(objargs)
            '            '    Else
            '            '        With ms.PropertyPackage
            '            '            .CurrentMaterialStream = ms
            '            '            .DW_ZerarVazaoMolar()
            '            '            .DW_ZerarVazaoVolumetrica()
            '            '            .DW_ZerarVazaoMassica()
            '            '            .DW_ZerarTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '            '            '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
            '            '            .DW_ZerarOverallProps()
            '            '            .CurrentMaterialStream = Nothing
            '            '        End With
            '            '        sobj.Calculated = False
            '            '        RaiseEvent ObjectStatusChanged(sobj)
            '            '    End If
            '            'ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazomolar")) Then
            '            '    If Q > 0 And T > 0 And P > 0 And Math.Abs(comp - 1) <= 0.0001 Then
            '            '        With ms.PropertyPackage
            '            '            .CurrentMaterialStream = ms
            '            '            .DW_CalcVazaoMassica()
            '            '            .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.T, RELAP.SimulationObjects.PropertyPackages.FlashSpec.P)
            '            '            If ms.Fases(3).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '            '            End If
            '            '            If ms.Fases(4).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '            '            End If
            '            '            If ms.Fases(5).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '            '            End If
            '            '            If ms.Fases(6).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
            '            '            End If
            '            '            If ms.Fases(7).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '            '            End If
            '            '            If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            End If
            '            '            If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault >= 0 And ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault < 1 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
            '            '            End If
            '            '            .DW_CalcCompMolarFlow(-1)
            '            '            .DW_CalcCompMassFlow(-1)
            '            '            .DW_CalcCompVolFlow(-1)
            '            '            .DW_CalcOverallProps()
            '            '            .DW_CalcTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            .DW_CalcVazaoVolumetrica()
            '            '            .DW_CalcKvalue()
            '            '            .CurrentMaterialStream = Nothing
            '            '        End With
            '            '        ms.UpdatePropertyNodes(ChildParent.Options.SelectedUnitSystem, ChildParent.Options.NumberFormat)
            '            '        sobj.Calculated = True
            '            '        RaiseEvent ObjectStatusChanged(sobj)
            '            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '            '        With objargs
            '            '            .Calculado = True
            '            '            .Nome = ms.Nome
            '            '            .Tipo = TipoObjeto.MaterialStream
            '            '        End With
            '            '        If ms.IsSpecAttached = True And ms.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(ms.AttachedSpecId).Calculate()
            '            '        ChildParent.CalculationQueue.Enqueue(objargs)
            '            '    Else
            '            '        With ms.PropertyPackage
            '            '            .CurrentMaterialStream = ms
            '            '            .DW_ZerarVazaoMolar()
            '            '            .DW_ZerarVazaoVolumetrica()
            '            '            .DW_ZerarVazaoMassica()
            '            '            .DW_ZerarTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '            '            '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
            '            '            .DW_ZerarOverallProps()
            '            '            .CurrentMaterialStream = Nothing
            '            '        End With
            '            '        sobj.Calculated = False
            '            '        RaiseEvent ObjectStatusChanged(sobj)
            '            '    End If
            '            'ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Vazovolumtrica")) Then
            '            '    If QV > 0 And T > 0 And P > 0 And Math.Abs(comp - 1) <= 0.0001 Then
            '            '        With ms.PropertyPackage
            '            '            .CurrentMaterialStream = ms
            '            '            'ms.Fases(0).SPMProperties.massflow = 0
            '            '            .DW_CalcEquilibrium(RELAP.SimulationObjects.PropertyPackages.FlashSpec.T, RELAP.SimulationObjects.PropertyPackages.FlashSpec.P)
            '            '            If ms.Fases(3).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '            '            End If
            '            '            If ms.Fases(4).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '            '            End If
            '            '            If ms.Fases(5).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '            '            End If
            '            '            If ms.Fases(6).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Aqueous)
            '            '            End If
            '            '            If ms.Fases(7).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '            '            End If
            '            '            If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault > 0 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            End If
            '            '            If ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault >= 0 And ms.Fases(2).SPMProperties.molarfraction.GetValueOrDefault < 1 Then
            '            '                .DW_CalcPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
            '            '            Else
            '            '                .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
            '            '            End If
            '            '            .DW_CalcOverallProps()
            '            '            .DW_CalcTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            ms.Fases(0).SPMProperties.massflow = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_volumetricFlow, e.ChangedItem.Value) * ms.Fases(0).SPMProperties.density.GetValueOrDefault
            '            '            .DW_CalcVazaoMolar()
            '            '            .DW_CalcVazaoMassica()
            '            '            .DW_CalcCompMolarFlow(-1)
            '            '            .DW_CalcCompMassFlow(-1)
            '            '            .DW_CalcCompVolFlow(-1)
            '            '            .DW_CalcKvalue()
            '            '            .CurrentMaterialStream = Nothing
            '            '        End With
            '            '        ms.UpdatePropertyNodes(ChildParent.Options.SelectedUnitSystem, ChildParent.Options.NumberFormat)
            '            '        sobj.Calculated = True
            '            '        RaiseEvent ObjectStatusChanged(sobj)
            '            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '            '        With objargs
            '            '            .Calculado = True
            '            '            .Nome = ms.Nome
            '            '            .Tipo = TipoObjeto.MaterialStream
            '            '        End With
            '            '        If ms.IsSpecAttached = True And ms.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(ms.AttachedSpecId).Calculate()
            '            '        ChildParent.CalculationQueue.Enqueue(objargs)
            '            '    Else
            '            '        With ms.PropertyPackage
            '            '            .CurrentMaterialStream = ms
            '            '            .DW_ZerarVazaoMolar()
            '            '            .DW_ZerarVazaoVolumetrica()
            '            '            .DW_ZerarVazaoMassica()
            '            '            .DW_ZerarTwoPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid, RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '            '            .DW_ZerarPhaseProps(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid1)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid2)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Liquid3)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Vapor)
            '            '            .DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Solid)
            '            '            '.DW_ZerarComposicoes(RELAP.SimulationObjects.PropertyPackages.Fase.Mixture)
            '            '            .DW_ZerarOverallProps()
            '            '            .CurrentMaterialStream = Nothing
            '            '        End With
            '            '        sobj.Calculated = False
            '            '        RaiseEvent ObjectStatusChanged(sobj)
            '            '    End If

            '        End If

            '    End If

            'End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.EnergyStream Then

            '    Dim es As RELAP.SimulationObjects.Streams.EnergyStream = ChildParent.Collections.CLCS_EnergyStreamCollection.Item(sobj.Name)

            '    es.Energia = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_heatflow, e.ChangedItem.Value)

            '    If ChildParent.Options.CalculatorActivated Then

            '        sobj.Calculated = True
            '        RaiseEvent ObjectStatusChanged(sobj)

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = True
            '            .Nome = sobj.Name
            '            .Tag = sobj.Tag
            '            .Tipo = TipoObjeto.EnergyStream
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If es.IsSpecAttached = True And es.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(es.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If


            'ElseIf sobj.TipoObjeto = TipoObjeto.NodeOut Then

            '    Dim sp As RELAP.SimulationObjects.UnitOps.Splitter = ChildParent.Collections.CLCS_SplitterCollection.Item(sobj.Name)

            '    If e.ChangedItem.Parent.Label.Contains(RELAP.App.GetLocalString("Fraesdascorrentes2")) Then

            '        If e.ChangedItem.Value < 0 Or e.ChangedItem.Value > 1 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

            '        Dim i As Integer = 0
            '        Dim j As Integer = 0

            '        Dim cp As ConnectionPoint
            '        For Each cp In sp.GraphicObject.OutputConnectors
            '            If cp.IsAttached Then
            '                If cp.AttachedConnector.AttachedTo.Tag = e.ChangedItem.Label Then
            '                    sp.Ratios(i) = e.ChangedItem.Value
            '                End If
            '            End If
            '            i += 1
            '        Next

            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        sobj.Calculated = True

            '        RaiseEvent ObjectStatusChanged(sobj)

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Nome = sobj.Name
            '            .Tag = sobj.Tag
            '            .Tipo = TipoObjeto.NodeOut
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If sp.IsSpecAttached = True And sp.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(sp.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.Pump Then

            '    Dim bb As RELAP.SimulationObjects.UnitOps.Pump = ChildParent.Collections.CLCS_PumpCollection.Item(sobj.Name)

            '    If e.ChangedItem.Label.Contains("Delta P") Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Pressoajusante")) Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.Pout = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_pressure, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Eficincia")) Then

            '        If e.ChangedItem.Value <= 20 Or e.ChangedItem.Value > 100 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Correntedeentrada")) Then

            '        If FormFlowsheet.SearchSurfaceObjectsByTag(e.ChangedItem.Value, ChildParent.FormSurface.FlowsheetDesignSurface) Is Nothing Then
            '            Dim oguid As String = ChildParent.FormSurface.AddObjectToSurface(TipoObjeto.MaterialStream, sobj.X - 40, sobj.Y, e.ChangedItem.Value)
            '        End If

            '        If Not sobj.InputConnectors(0).IsAttached Then
            '            ChildParent.ConnectObject(FormFlowsheet.SearchSurfaceObjectsByTag(e.ChangedItem.Value, ChildParent.FormSurface.FlowsheetDesignSurface), sobj)
            '        Else
            '            ChildParent.DisconnectObject(sobj.InputConnectors(0).AttachedConnector.AttachedFrom, sobj)
            '            ChildParent.ConnectObject(FormFlowsheet.SearchSurfaceObjectsByTag(e.ChangedItem.Value, ChildParent.FormSurface.FlowsheetDesignSurface), sobj)
            '        End If

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Correntedesada")) Then

            '        If FormFlowsheet.SearchSurfaceObjectsByTag(e.ChangedItem.Value, ChildParent.FormSurface.FlowsheetDesignSurface) Is Nothing Then
            '            Dim oguid As String = ChildParent.FormSurface.AddObjectToSurface(TipoObjeto.MaterialStream, sobj.X + sobj.Width + 40, sobj.Y, e.ChangedItem.Value)
            '        End If

            '        If Not sobj.OutputConnectors(0).IsAttached Then
            '            ChildParent.ConnectObject(sobj, FormFlowsheet.SearchSurfaceObjectsByTag(e.ChangedItem.Value, ChildParent.FormSurface.FlowsheetDesignSurface))
            '        Else
            '            ChildParent.DisconnectObject(sobj, sobj.OutputConnectors(0).AttachedConnector.AttachedTo)
            '            ChildParent.ConnectObject(sobj, FormFlowsheet.SearchSurfaceObjectsByTag(e.ChangedItem.Value, ChildParent.FormSurface.FlowsheetDesignSurface))
            '        End If

            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Tag = sobj.Tag
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.Pump
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.Valve Then

            '    Dim bb As RELAP.SimulationObjects.UnitOps.Valve = ChildParent.Collections.CLCS_ValveCollection.Item(sobj.Name)

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

            '        bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

            '        'If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("ValveOutletPressure")) Then

            '        bb.OutletPressure = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_pressure, e.ChangedItem.Value)

            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Tag = sobj.Tag
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.Valve
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.Compressor Then

            '    Dim bb As RELAP.SimulationObjects.UnitOps.Compressor = ChildParent.Collections.CLCS_CompressorCollection.Item(sobj.Name)

            '    If e.ChangedItem.Label.Contains("Delta P") Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Eficincia")) Then

            '        If e.ChangedItem.Value <= 20 Or e.ChangedItem.Value > 100 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Tag = sobj.Tag
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.Compressor
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.Expander Then

            '    Dim bb As RELAP.SimulationObjects.UnitOps.Expander = ChildParent.Collections.CLCS_TurbineCollection.Item(sobj.Name)

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Eficincia")) Then

            '        If e.ChangedItem.Value <= 20 Or e.ChangedItem.Value > 100 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Tag = sobj.Tag
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.Expander
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.Pipe Then

            '    Dim bb As RELAP.SimulationObjects.UnitOps.Pipe = ChildParent.Collections.CLCS_PipeCollection.Item(sobj.Name)

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Tag = sobj.Tag
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.Pipe
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.Heater Then

            '    Dim bb As RELAP.SimulationObjects.UnitOps.Heater = ChildParent.Collections.CLCS_HeaterCollection.Item(sobj.Name)

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Eficincia")) Then

            '        If e.ChangedItem.Value <= 20 Or e.ChangedItem.Value > 100 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Calor")) Then

            '        bb.DeltaQ = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_heatflow, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HeaterCoolerOutletTemperature")) Then

            '        bb.OutletTemperature = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_temperature, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("FraomolardafaseFaseV")) Then

            '        bb.OutletVaporFraction = Double.Parse(e.ChangedItem.Value)

            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Tag = sobj.Tag
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.Heater
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.Cooler Then

            '    Dim bb As RELAP.SimulationObjects.UnitOps.Cooler = ChildParent.Collections.CLCS_CoolerCollection.Item(sobj.Name)

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Eficincia")) Then

            '        If e.ChangedItem.Value <= 20 Or e.ChangedItem.Value > 100 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Calor")) Then

            '        bb.DeltaQ = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_heatflow, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HeaterCoolerOutletTemperature")) Then

            '        bb.OutletTemperature = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_temperature, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("FraomolardafaseFaseV")) Then

            '        bb.OutletVaporFraction = Double.Parse(e.ChangedItem.Value)

            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Tag = sobj.Tag
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.Cooler
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

        ElseIf sobj.TipoObjeto = TipoObjeto.Tank Then

            Dim bb As RELAP.SimulationObjects.UnitOps.Tank = ChildParent.Collections.CLCS_TankCollection.Item(sobj.Name)

            If e.ChangedItem.Label.Contains("Volume Flow Area") Then

                If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
                bb.FlowArea = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Length of Volume") Then

                bb.LengthofVolume = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Volume of Volume") Then
                bb.VolumeofVolume = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Azimuthal Angle") Then
                bb.Azimuthalangle = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inclination Angle") Then
                bb.InclinationAngle = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Elevation Change") Then
                bb.ElevationChange = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Wall Roughness") Then
                bb.WallRoughness = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Hydraulic Diameter") Then
                bb.HydraulicDiameter = e.ChangedItem.Value

                'control flags
            ElseIf e.ChangedItem.Label.Contains("Thermal Stratification Model") Then
                bb.ThermalStratificationModel = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Level Tracking Model") Then
                bb.LevelTrackingModel = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Water Packing Scheme") Then
                bb.WaterPackingScheme = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Vertical Stratification Model") Then
                bb.VerticalStratificationModel = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Interphase Friction Model") Then
                bb.InterphaseFriction = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Compute Wall Friction") Then
                bb.ComputeWallFriction = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Equilibrium Temperature") Then
                bb.EquilibriumTemperature = e.ChangedItem.Value
            End If

        ElseIf sobj.TipoObjeto = TipoObjeto.SingleVolume Then

            Dim bb As RELAP.SimulationObjects.UnitOps.SingleVolume = ChildParent.Collections.CLCS_SingleVolumeCollection.Item(sobj.Name)

            If e.ChangedItem.Label.Contains("Volume Flow Area") Then
                bb.FlowArea = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Length of Volume") Then
                bb.LengthofVolume = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Volume of Volume") Then
                bb.VolumeofVolume = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Azimuthal Angle") Then
                bb.Azimuthalangle = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inclination Angle") Then
                bb.InclinationAngle = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Elevation Change") Then
                bb.ElevationChange = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Wall Roughness") Then
                bb.WallRoughness = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Hydraulic Diameter") Then
                bb.HydraulicDiameter = e.ChangedItem.Value

                'control flags
            ElseIf e.ChangedItem.Label.Contains("Thermal Front Tracking Model") Then
                bb.ThermalStratificationModel = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Level Tracking Model") Then
                bb.LevelTrackingModel = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Water Packing Scheme") Then
                bb.WaterPackingScheme = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Vertical Stratification Model") Then
                bb.VerticalStratificationModel = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Pipe Interphase Friction Model") Then
                bb.PipeInterphaseFriction = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Rod Bundle Interphase Friction Model") Then
                bb.RodInterphaseFriction = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Compute Wall Friction") Then
                bb.ComputeWallFriction = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Equilibrium Temperature Calculation") Then
                bb.EquilibriumTemperature = e.ChangedItem.Value
            End If

        ElseIf sobj.TipoObjeto = TipoObjeto.Branch Then

            Dim bb As RELAP.SimulationObjects.UnitOps.Branch = ChildParent.Collections.CLCS_BranchCollection.Item(sobj.Name)

            If e.ChangedItem.Label.Contains("Number of Junctions") Then
                bb.NumberofJunctions = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Volume Flow Area") Then
                bb.FlowArea = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Length of Volume") Then
                bb.LengthofVolume = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Volume of Volume") Then
                bb.VolumeofVolume = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Azimuthal Angle") Then
                bb.Azimuthalangle = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inclination Angle") Then
                bb.InclinationAngle = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Elevation Change") Then
                bb.ElevationChange = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Wall Roughness") Then
                bb.WallRoughness = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Hydraulic Diameter") Then
                bb.HydraulicDiameter = e.ChangedItem.Value

                'control flags
            End If

        ElseIf sobj.TipoObjeto = TipoObjeto.Valve Then

            Dim sjn As RELAP.SimulationObjects.UnitOps.Valve = ChildParent.Collections.CLCS_ValveCollection.Item(sobj.Name)
            If e.ChangedItem.Label.Contains("From Component") Then
                sjn.FromComponent = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("To Component") Then
                sjn.ToComponent = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("To Volume") Then
                sjn.ToVolume = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("From Volume") Then
                sjn.FromVolume = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Junction Flow Area") Then
                sjn.JunctionArea = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Forward Flow Energy Loss Coefficient") Then
                sjn.FflowLossCo = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Reverse Flow Energy Loss Coefficient") Then
                sjn.RflowLossCo = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Modified PV term Applied") Then
                sjn.pvterm = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("CCFL Model") Then
                sjn.CCFL = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Choking Model") Then
                sjn.chokingModel = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("True for Mass Flow rate") Then
                sjn.EnterVelocityOrMassFlowRate = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Initial Liquid Velocity") Then
                sjn.InitialLiquidVelocity = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Initial Vapor Velocity") Then
                sjn.InitialVaporVelocity = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Interphase Velocity") Then
                sjn.InterphaseVelocity = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Initial Liquid Mass Flow Rate") Then
                sjn.InitialLiquidMassFlowRate = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Initial Vapor Mass Flow Rate") Then
                sjn.InitialVaporMassFlowRate = e.ChangedItem.Value
            
            End If

        ElseIf sobj.TipoObjeto = TipoObjeto.TimeDependentJunction Then

            Dim sjn As RELAP.SimulationObjects.UnitOps.TimeDependentJunction = ChildParent.Collections.CLCS_TimeDependentJunctionCollection.Item(sobj.Name)
            If e.ChangedItem.Label.Contains("From Component") Then
                sjn.FromComponent = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("To Component") Then
                sjn.ToComponent = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("To Volume") Then
                sjn.ToVolume = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("From Volume") Then
                sjn.FromVolume = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Junction Flow Area") Then
                sjn.JunctionArea = e.ChangedItem.Value
            End If

        ElseIf sobj.TipoObjeto = TipoObjeto.SingleJunction Then

            Dim sjn As RELAP.SimulationObjects.UnitOps.SingleJunction = ChildParent.Collections.CLCS_SingleJunctionCollection.Item(sobj.Name)

            If e.ChangedItem.Label.Contains("From Component") Then
                sjn.FromComponent = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("To Component") Then
                sjn.ToComponent = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("To Volume") Then
                sjn.ToVolume = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("From Volume") Then
                sjn.FromVolume = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Junction Flow Area") Then
                sjn.JunctionArea = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Forward Flow Energy Loss Coefficient") Then
                sjn.FflowLossCo = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Reverse Flow Energy Loss Coefficient") Then
                sjn.RflowLossCo = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Subcooled Discharge Coefficient") Then
                sjn.SubcooledDishargeCo = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Two phase Discharge Coefficient") Then
                sjn.TwoPhaseDischargeCo = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Superheated Discharge Coefficient") Then
                sjn.SuperheatedDishargeCo = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("True for Mass Flow rate") Then
                sjn.EnterVelocityOrMassFlowRate = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Initial Liquid Velocity") Then
                sjn.InitialLiquidVelocity = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Initial Vapor Velocity") Then
                sjn.InitialVaporVelocity = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Interphase Velocity") Then
                sjn.InterphaseVelocity = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Initial Liquid Mass Flow Rate") Then
                sjn.InitialLiquidMassFlowRate = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Initial Vapor Mass Flow Rate") Then
                sjn.InitialVaporMassFlowRate = e.ChangedItem.Value

            End If

        ElseIf sobj.TipoObjeto = TipoObjeto.Pipe Then

            Dim pip As RELAP.SimulationObjects.UnitOps.pipe = ChildParent.Collections.CLCS_PipeCollection.Item(sobj.Name)

            If e.ChangedItem.Label.Contains("Number of Volumes") Then
                pip.NumberOfVoulmes = e.ChangedItem.Value


            End If

        ElseIf sobj.TipoObjeto = TipoObjeto.Pump Then

            Dim pp As RELAP.SimulationObjects.UnitOps.Pump = ChildParent.Collections.CLCS_PumpCollection.Item(sobj.Name)

            If e.ChangedItem.Label.Contains("Volume Flow Area") Then

                pp.FlowArea = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Length of Volume") Then

                pp.LengthofVolume = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Volume of Volume") Then
                pp.VolumeofVolume = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Azimuthal Angle") Then
                pp.Azimuthalangle = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inclination Angle") Then
                pp.InclinationAngle = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Elevation Change") Then
                pp.ElevationChange = e.ChangedItem.Value

                'control flags
            ElseIf e.ChangedItem.Label.Contains("Thermal Stratification Model") Then
                pp.ThermalStratificationModel = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Level Tracking Model") Then
                pp.LevelTrackingModel = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Water Packing Scheme") Then
                pp.WaterPackingScheme = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Vertical Stratification Model") Then
                pp.VerticalStratificationModel = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Interphase Friction Model") Then
                pp.InterphaseFriction = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Compute Wall Friction") Then
                pp.ComputeWallFriction = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Equilibrium Temperature") Then
                pp.EquilibriumTemperature = e.ChangedItem.Value

                'pump suction
            ElseIf e.ChangedItem.Label.Contains("Inlet Junction Area") Then
                pp.JunctionArea = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inlet Forward Flow Energy Loss Coefficient") Then
                pp.FflowLossCo = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inlet Reverse Flow Energy Loss Coefficient") Then
                pp.RflowLossCo = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inlet CCFL Model") Then
                pp.CCFLModel = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inlet Choking Model") Then
                pp.ChokingModel = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inlet Smooth Area Change") Then
                pp.SmoothAreaChange = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inlet Full Abrupt Area Change") Then
                pp.FullAbruptAreaChange = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inlet Partial Abrupt Area Change") Then
                pp.PartialAbruptAreaChange = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inlet Two Velocity Momentum Equations") Then
                pp.TwoVelocityMomentumEquations = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inlet Single Velocity Momentum Equations") Then
                pp.SingleVelocityMomentumEquations = e.ChangedItem.Value


                'pump discharge
            ElseIf e.ChangedItem.Label.Contains("Outlet Junction Area") Then
                pp.OJunctionArea = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Outlet Forward Flow Energy Loss Coefficient") Then
                pp.OFflowLossCo = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Outlet Reverse Flow Energy Loss Coefficient") Then
                pp.ORflowLossCo = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Outlet CCFL Model") Then
                pp.OCCFLModel = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Outlet Choking Model") Then
                pp.OChokingModel = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Outlet Smooth Area Change") Then
                pp.OSmoothAreaChange = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Outlet Full Abrupt Area Change") Then
                pp.OFullAbruptAreaChange = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Outlet Partial Abrupt Area Change") Then
                pp.OPartialAbruptAreaChange = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Outlet Two Velocity Momentum Equations") Then
                pp.OTwoVelocityMomentumEquations = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Outlet Single Velocity Momentum Equations") Then
                pp.OSingleVelocityMomentumEquations = e.ChangedItem.Value


                'pump suction initial conditions
            ElseIf e.ChangedItem.Label.Contains("Interphase Velocity (suction)") Then
                pp.InterphaseVelocity = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("True for Mass Flow rate (suction)") Then
                pp.EnterVelocityOrMassFlowRate = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Initial Liquid Velocity (suction)") Then
                pp.InitialLiquidVelocity = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Initial Vapor Velocity (suction)") Then
                pp.InitialVaporVelocity = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Initial Liquid Mass Flow Rate (suction)") Then
                pp.InitialLiquidMassFlowRate = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Initial Vapor Mass Flow Rate (suction)") Then
                pp.InitialVaporMassFlowRate = e.ChangedItem.Value



                'pump discharge initial conditions
            ElseIf e.ChangedItem.Label.Contains("Interphase Velocity (discharge)") Then
                pp.OInterphaseVelocity = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("True for Mass Flow rate (discharge)") Then
                pp.OEnterVelocityOrMassFlowRate = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Initial Liquid Velocity (discharge)") Then
                pp.OInitialLiquidVelocity = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Initial Vapor Velocity (discharge)") Then
                pp.OInitialVaporVelocity = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Initial Liquid Mass Flow Rate (discharge)") Then
                pp.OInitialLiquidMassFlowRate = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Initial Vapor Mass Flow Rate (discharge)") Then
                pp.OInitialVaporMassFlowRate = e.ChangedItem.Value


            End If





        ElseIf sobj.TipoObjeto = TipoObjeto.FuelRod Then


            Dim fr As RELAP.SimulationObjects.UnitOps.FuelRod = ChildParent.Collections.CLCS_FuelRodCollection.Item(sobj.Name)
            If e.ChangedItem.Label.Contains("Average Burnup") Then
                fr.AverageBurnup = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("No. of rods") Then
                fr.NumberOfRods = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Fuel Rod Pitch") Then
                fr.FuelRodPitch = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Plenum Length") Then
                fr.PlenumLength = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Plenum Void Volume") Then
                fr.PlenumVoidVolume = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Lower Plenum Void Volume") Then
                fr.LowerPlenumVoidVolume = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Fuel Pellet Radius") Then
                fr.FuelPelletRadius = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Inner Cladding Radius") Then
                fr.InnerCladdingRadius = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Outer Cladding Radius") Then
                fr.OuterCladdingRadius = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial node") And e.ChangedItem.PropertyDescriptor.Category.Contains("Fuel Rod Dimensions") Then
                fr.FuelRodDimensionsAxialNode = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Control Volume Above") Then
                fr.ControlVolumeAbove = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Control Volume Below") Then
                fr.ControlVolumeBelow = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Control Volume Number") Then
                fr.ControlVolumeNumber = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Increment") Then
                fr.Increment = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial node") And e.ChangedItem.PropertyDescriptor.Category.Contains("Hydraulic Volumes") Then
                fr.HydraulicVolumesAxialNode = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Radius To Radial Node 1") Then
                fr.RadiusToRadialNode1 = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Radius To Radial Node N") Then
                fr.RadiusToRadialNodeN = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial node") And e.ChangedItem.PropertyDescriptor.Category.Contains("Radial Mesh Spacing") Then
                fr.RadialMeshSpacingAxialNode = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Temperature at Node 1") Then
                fr.TemperatureAtNode1 = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Temperature at Node N") Then
                fr.TemperatureAtNodeN = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial node") And e.ChangedItem.PropertyDescriptor.Category.Contains("Initial Temperature") Then
                fr.InitialTemperaturesAxialNode = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Material Index Near Center") Then
                fr.MaterialIndexNearCenter = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Material Index Next To Center") Then
                fr.MaterialIndexNextToCenter = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Material Index Nth Layer") Then
                fr.MaterialIndexNthLayer = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Fraction") Then
                fr.Fraction = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.TimeForWhichAxialPowerProfileApplies = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Factor") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Radial Power Factor") Then
                fr.RadialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If
            If e.ChangedItem.Label.Contains("Axial Power Profile Time") Then
                fr.AxialPowerFactor = e.ChangedItem.Value
            End If


        ElseIf sobj.TipoObjeto = TipoObjeto.HeatStructure Then
            Dim hs As RELAP.SimulationObjects.UnitOps.HeatStructure = ChildParent.Collections.CLCS_HeatStructureCollection.Item(sobj.Name)

            If e.ChangedItem.Label.Contains("No. of axial Heat structures") Then
                hs.NumberOfAxialHS = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("No. of Radial Mesh Points") Then
                hs.NumberOfRadialMP = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Left Boundary Coordinate") Then
                hs.LeftBoundaryCO = e.ChangedItem.Value


            End If





            'If ChildParent.Options.CalculatorActivated Then

            '    'Call function to calculate flowsheet
            '    Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '    With objargs
            '        .Tag = sobj.Tag
            '        .Calculado = False
            '        .Nome = sobj.Name
            '        .Tipo = TipoObjeto.Tank
            '        .Emissor = "PropertyGrid"
            '    End With

            '    If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '    ChildParent.CalculationQueue.Enqueue(objargs)

            'End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.OT_Ajuste Then

            '    Dim adj As RELAP.SimulationObjects.SpecialOps.Adjust = ChildParent.Collections.CLCS_AdjustCollection.Item(sobj.Name)

            '    With adj
            '        If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Controlada")) Then
            '            .ControlledObject = ChildParent.Collections.ObjectCollection(.ControlledObjectData.m_ID)
            '            .ControlledVariable = .ControlledObjectData.m_Property
            '            CType(ChildParent.Collections.AdjustCollection(adj.Nome), AdjustGraphic).ConnectedToCv = .ControlledObject.GraphicObject
            '            .ReferenceObject = Nothing
            '            .ReferenceVariable = Nothing
            '            With .ReferencedObjectData
            '                .m_ID = ""
            '                .m_Name = ""
            '                .m_Property = ""
            '                .m_Type = ""
            '            End With
            '        ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Manipulada")) Then
            '            .ManipulatedObject = ChildParent.Collections.ObjectCollection(.ManipulatedObjectData.m_ID)
            '            Dim gr As AdjustGraphic = ChildParent.Collections.AdjustCollection(adj.Nome)
            '            gr.ConnectedToMv = .ManipulatedObject.GraphicObject
            '            .ManipulatedVariable = .ManipulatedObjectData.m_Property
            '        ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("ObjetoVariveldeRefer")) Then
            '            .ReferenceObject = ChildParent.Collections.ObjectCollection(.ReferencedObjectData.m_ID)
            '            .ReferenceVariable = .ReferencedObjectData.m_Property
            '            Dim gr As AdjustGraphic = ChildParent.Collections.AdjustCollection(adj.Nome)
            '            gr.ConnectedToRv = .ReferenceObject.GraphicObject
            '        ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Valormnimoopcional")) Then
            '            adj.MinVal = Conversor.ConverterParaSI(adj.ManipulatedObject.GetPropertyUnit(adj.ManipulatedObjectData.m_Property, ChildParent.Options.SelectedUnitSystem), e.ChangedItem.Value)
            '        ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Valormximoopcional")) Then
            '            adj.MaxVal = Conversor.ConverterParaSI(adj.ManipulatedObject.GetPropertyUnit(adj.ManipulatedObjectData.m_Property, ChildParent.Options.SelectedUnitSystem), e.ChangedItem.Value)
            '        ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("ValordeAjusteouOffse")) Then
            '            adj.AdjustValue = Conversor.ConverterParaSI(adj.ControlledObject.GetPropertyUnit(adj.ControlledObjectData.m_Property, ChildParent.Options.SelectedUnitSystem), e.ChangedItem.Value)
            '        End If
            '    End With

            'ElseIf sobj.TipoObjeto = TipoObjeto.OT_Especificacao Then

            '    Dim spec As RELAP.SimulationObjects.SpecialOps.Spec = ChildParent.Collections.CLCS_SpecCollection.Item(sobj.Name)

            '    With spec
            '        If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Destino")) Then
            '            .TargetObject = ChildParent.Collections.ObjectCollection(.TargetObjectData.m_ID)
            '            .TargetVariable = .TargetObjectData.m_Property
            '            CType(ChildParent.Collections.SpecCollection(spec.Nome), SpecGraphic).ConnectedToTv = .TargetObject.GraphicObject
            '        ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Fonte")) Then
            '            .SourceObject = ChildParent.Collections.ObjectCollection(.SourceObjectData.m_ID)
            '            Dim gr As SpecGraphic = ChildParent.Collections.SpecCollection(spec.Nome)
            '            gr.ConnectedToSv = .SourceObject.GraphicObject
            '            .SourceVariable = .SourceObjectData.m_Property
            '        End If
            '    End With

            'ElseIf sobj.TipoObjeto = TipoObjeto.Vessel Then

            '    Dim vessel As RELAP.SimulationObjects.UnitOps.Vessel = ChildParent.Collections.CLCS_VesselCollection.Item(sobj.Name)

            '    Dim T, P As Double
            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Temperatura")) Then
            '        T = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_temperature, e.ChangedItem.Value)
            '        vessel.FlashTemperature = T
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Presso")) Then
            '        P = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_pressure, e.ChangedItem.Value)
            '        vessel.FlashPressure = P
            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Tag = sobj.Tag
            '            .Calculado = False
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.Vessel
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If vessel.IsSpecAttached = True And vessel.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(vessel.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.OT_Reciclo Then

            '    Dim rec As RELAP.SimulationObjects.SpecialOps.Recycle = ChildParent.Collections.CLCS_RecycleCollection.Item(sobj.Name)

            '    Dim T, P, W As Double
            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Temperatura")) Then
            '        T = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaT, e.ChangedItem.Value)
            '        rec.ConvergenceParameters.Temperatura = T
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Presso")) Then
            '        P = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)
            '        rec.ConvergenceParameters.Pressao = P
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("mssica")) Then
            '        W = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_massflow, e.ChangedItem.Value)
            '        rec.ConvergenceParameters.VazaoMassica = W
            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.RCT_Conversion Then

            '    Dim bb As RELAP.SimulationObjects.Reactors.Reactor_Conversion = ChildParent.Collections.CLCS_ReactorConversionCollection.Item(sobj.Name)

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Tag = sobj.Tag
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.RCT_Conversion
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.RCT_Equilibrium Then

            '    Dim bb As RELAP.SimulationObjects.Reactors.Reactor_Equilibrium = ChildParent.Collections.CLCS_ReactorEquilibriumCollection.Item(sobj.Name)

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Tag = sobj.Tag
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.RCT_Equilibrium
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.RCT_Gibbs Then

            '    Dim bb As RELAP.SimulationObjects.Reactors.Reactor_Gibbs = ChildParent.Collections.CLCS_ReactorGibbsCollection.Item(sobj.Name)

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Tag = sobj.Tag
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.RCT_Gibbs
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.RCT_CSTR Then

            '    Dim bb As RELAP.SimulationObjects.Reactors.Reactor_CSTR = ChildParent.Collections.CLCS_ReactorCSTRCollection.Item(sobj.Name)

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

            '    End If

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("RCSTRPGridItem1")) Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.Volume = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.volume, e.ChangedItem.Value)

            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Tag = sobj.Tag
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.RCT_CSTR
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.RCT_PFR Then

            '    Dim bb As RELAP.SimulationObjects.Reactors.Reactor_PFR = ChildParent.Collections.CLCS_ReactorPFRCollection.Item(sobj.Name)

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Quedadepresso")) Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.DeltaP = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

            '    End If

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("RCSTRPGridItem1")) Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.Volume = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.volume, e.ChangedItem.Value)

            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Tag = sobj.Tag
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.RCT_PFR
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.HeatStructure Then

            '    Dim bb As RELAP.SimulationObjects.UnitOps.HeatStructure = ChildParent.Collections.CLCS_HeatStructureCollection.Item(sobj.Name)

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("OverallHeatTranferCoefficient")) Then

            '        If e.ChangedItem.Value < 0 Then Throw New InvalidCastException(RELAP.App.GetLocalString("Ovalorinformadonovli"))
            '        bb.OverallCoefficient = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.heat_transf_coeff, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("Area")) Then

            '        bb.Area = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.area, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HeatLoad")) Then

            '        bb.Q = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_heatflow, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HXHotSidePressureDrop")) Then

            '        bb.HotSidePressureDrop = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HXColdSidePressureDrop")) Then

            '        bb.ColdSidePressureDrop = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_deltaP, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HXTempHotOut")) Then

            '        bb.HotSideOutletTemperature = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_temperature, e.ChangedItem.Value)

            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("HXTempColdOut")) Then

            '        bb.ColdSideOutletTemperature = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_temperature, e.ChangedItem.Value)

            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Tag = sobj.Tag
            '            .Calculado = False
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.HeatStructure
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If bb.IsSpecAttached = True And bb.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(bb.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.ShortcutColumn Then

            '    Dim sc As RELAP.SimulationObjects.UnitOps.ShortcutColumn = ChildParent.Collections.CLCS_ShortcutColumnCollection.Item(sobj.Name)
            '    Dim Pr, Pc As Double

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("SCCondenserType")) Then
            '        sc.GraphicObject.Shape = sc.condtype
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("SCCondenserPressure")) Then
            '        Pc = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_pressure, e.ChangedItem.Value)
            '        sc.m_condenserpressure = Pc
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("SCReboilerPressure")) Then
            '        Pr = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.spmp_pressure, e.ChangedItem.Value)
            '        sc.m_boilerpressure = Pr
            '    ElseIf e.ChangedItem.Label.Equals(RELAP.App.GetLocalString("SCLightKey")) Then
            '        sc.m_lightkey = e.ChangedItem.Value
            '    ElseIf e.ChangedItem.Label.Equals(RELAP.App.GetLocalString("SCHeavyKey")) Then
            '        sc.m_heavykey = e.ChangedItem.Value
            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Tag = sobj.Tag
            '            .Calculado = False
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.ShortcutColumn
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If sc.IsSpecAttached = True And sc.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(sc.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If

            'ElseIf sobj.TipoObjeto = TipoObjeto.OrificePlate Then

            '    Dim op As RELAP.SimulationObjects.UnitOps.OrificePlate = ChildParent.Collections.CLCS_OrificePlateCollection.Item(sobj.Name)

            '    If e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("OPOrificeDiameter")) Then
            '        op.OrificeDiameter = Conversor.ConverterParaSI(ChildParent.Options.SelectedUnitSystem.diameter, e.ChangedItem.Value)
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("OPBeta")) Then
            '        op.Beta = e.ChangedItem.Value
            '    ElseIf e.ChangedItem.Label.Contains(RELAP.App.GetLocalString("OPCorrectionFactor")) Then
            '        op.CorrectionFactor = e.ChangedItem.Value
            '    End If

            '    If ChildParent.Options.CalculatorActivated Then

            '        'Call function to calculate flowsheet
            '        Dim objargs As New RELAP.Outros.StatusChangeEventArgs
            '        With objargs
            '            .Calculado = False
            '            .Tag = sobj.Tag
            '            .Nome = sobj.Name
            '            .Tipo = TipoObjeto.OrificePlate
            '            .Emissor = "PropertyGrid"
            '        End With

            '        If op.IsSpecAttached = True And op.SpecVarType = RELAP.SimulationObjects.SpecialOps.Helpers.Spec.TipoVar.Fonte Then ChildParent.Collections.CLCS_SpecCollection(op.AttachedSpecId).Calculate()
            '        ChildParent.CalculationQueue.Enqueue(objargs)

            '    End If


            'End If

        End If

        Call ChildParent.FormSurface.UpdateSelectedObject()
        Call ChildParent.FormSurface.FlowsheetDesignSurface.Invalidate()
        Application.DoEvents()
        '    If ChildParent.Options.CalculatorActivated Then ProcessCalculationQueue(ChildParent)

    End Sub
End Class
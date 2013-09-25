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

                Dim gObj As BranchGraphic = FormFlowsheet.SearchSurfaceObjectsByTag(LblNomeObj.Text, ChildParent.FormSurface.FlowsheetDesignSurface)
                gObj.Volumes = e.ChangedItem.Value
              
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
            ElseIf e.ChangedItem.Label.Contains("Modified PV term Applied") Then
                bb.pvterm = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("CCFL Model") Then
                bb.CCFL = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Choking Model") Then
                bb.chokingModel = e.ChangedItem.Value
                'control flags
            End If
        ElseIf sobj.TipoObjeto = TipoObjeto.Separator Then

            Dim bb As RELAP.SimulationObjects.UnitOps.Separator = ChildParent.Collections.CLCS_SeparatorCollection.Item(sobj.Name)

            If e.ChangedItem.Label.Contains("Number of Junctions") Then
                bb.NumberofJunctions = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Number of Separator Components") Then
                bb.Noseparator = e.ChangedItem.Value

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
            ElseIf e.ChangedItem.Label.Contains("Modified PV term Applied") Then
                bb.pvterm = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("CCFL Model") Then
                bb.CCFL = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Choking Model") Then
                bb.chokingModel = e.ChangedItem.Value
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

                'pump suction
            ElseIf e.ChangedItem.Label.Contains("From Component") Then
                pp.FromComponent = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("To Component") Then
                pp.ToComponent = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("To Volume") Then
                pp.ToVolume = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("From Volume") Then
                pp.FromVolume = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Inlet Junction Area") Then
                pp.JunctionArea = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inlet Forward Flow Energy Loss Coefficient") Then
                pp.FflowLossCo = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Inlet Reverse Flow Energy Loss Coefficient") Then
                pp.RflowLossCo = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("inlet CCFL Model") Then
                pp.CCFL = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("inlet Choking Model") Then
                pp.chokingModel = e.ChangedItem.Value


                'pump discharge
            ElseIf e.ChangedItem.Label.Contains("Outlet Junction Area") Then
                pp.OJunctionArea = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Outlet Forward Flow Energy Loss Coefficient") Then
                pp.OFflowLossCo = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Outlet Reverse Flow Energy Loss Coefficient") Then
                pp.ORflowLossCo = e.ChangedItem.Value

            ElseIf e.ChangedItem.Label.Contains("Outlet CCFL Model") Then
                pp.CCFL = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Outlet Choking Model") Then
                pp.chokingModel = e.ChangedItem.Value

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

            ElseIf e.ChangedItem.Label.Contains("Rated pump velocity") Then
                pp.Ratedpumpvelocity = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Ratio of Velocities") Then
                pp.RatioRatedVelocity = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Rated Flow") Then
                pp.RatedFlow = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Rated Head") Then
                pp.RatedHead = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Rated Torque") Then
                pp.RatedTorque = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Moment of Inertia") Then
                pp.MomentofInertia = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Rated Density") Then
                pp.RatedDensity = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("Rated pump Motor Torque") Then
                pp.RatedMotorTorque = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("TF2, Friction Torque Cooefficient") Then
                pp.TF2 = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("TF0, Friction Torque Cooefficient") Then
                pp.TF0 = e.ChangedItem.Value
            ElseIf e.ChangedItem.Label.Contains("TF3, Friction Torque Cooefficient") Then
                pp.TF3 = e.ChangedItem.Value
            
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
            Dim gObj As HeatStructureGraphic = FormFlowsheet.SearchSurfaceObjectsByTag(LblNomeObj.Text, ChildParent.FormSurface.FlowsheetDesignSurface)

            If e.ChangedItem.Label.Contains("No. of axial Heat structures") Then
            hs.NumberOfAxialHS = e.ChangedItem.Value

        ElseIf e.ChangedItem.Label.Contains("No. of Radial Mesh Points") Then
            hs.NumberOfRadialMP = e.ChangedItem.Value

        ElseIf e.ChangedItem.Label.Contains("Left Boundary Coordinate") Then
            hs.LeftBoundaryCO = e.ChangedItem.Value


        End If


        End If


        Call ChildParent.FormSurface.UpdateSelectedObject()
        Call ChildParent.FormSurface.FlowsheetDesignSurface.Invalidate()
        Application.DoEvents()
       
    End Sub
End Class

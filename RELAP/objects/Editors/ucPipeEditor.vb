
Imports System.Windows.Forms

<System.Serializable()> Public Class ucPipeEditor
    Inherits System.Windows.Forms.UserControl
    Protected m_profile As PipeProfile

    Public Property Profile() As PipeProfile
        Get
            Return m_profile
        End Get
        Set(ByVal value As PipeProfile)
            m_profile = value
        End Set
    End Property

    Private _us As RELAP.SistemasDeUnidades.Unidades

    Public Property SystemOfUnits() As RELAP.SistemasDeUnidades.Unidades
        Get
            Return _us
        End Get
        Set(ByVal value As RELAP.SistemasDeUnidades.Unidades)
            _us = value
        End Set
    End Property

    Private _nf As String

    Public Property NumberFormat() As String
        Get
            Return _nf
        End Get
        Set(ByVal value As String)
            _nf = value
        End Set
    End Property
End Class

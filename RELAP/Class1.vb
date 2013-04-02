
Class Class1

    Private Shared _sngl_vol As Object
    Private Shared _singjunc As Object
    Private Shared _pipeannulus As Object
    Private Shared _annulus As Object
    Private Shared _pump As Object
    Private Shared _tmdpjun As Object
    Private Shared _tmdpvol As Object
    Private Shared _valve As Object
    Private Shared _accum As Object
    Private Shared _branch As Object
    Friend Shared initial As Object
    Friend Shared lb_time_count As Object
    Friend Shared plotcounter As Integer
    Private Shared _lbplot As Object

    Shared Property sngl_vol(i As Integer) As Object
        Get
            Return _sngl_vol
        End Get
        Set(value As Object)
            _sngl_vol = value
        End Set
    End Property

    Shared Property singjunc(i As Integer) As Object
        Get
            Return _singjunc
        End Get
        Set(value As Object)
            _singjunc = value
        End Set
    End Property

    Shared Property pipeannulus(i As Integer, p2 As Integer) As Object
        Get
            Return _pipeannulus
        End Get
        Set(value As Object)
            _pipeannulus = value
        End Set
    End Property

    Shared Property annulus(i As Integer, p2 As Integer) As Object
        Get
            Return _annulus
        End Get
        Set(value As Object)
            _annulus = value
        End Set
    End Property

    Shared Property pump(i As Integer, p2 As Integer) As Object
        Get
            Return _pump
        End Get
        Set(value As Object)
            _pump = value
        End Set
    End Property

    Shared Property tmdpjun(i As Integer, p2 As Integer) As Object
        Get
            Return _tmdpjun
        End Get
        Set(value As Object)
            _tmdpjun = value
        End Set
    End Property

    Shared Property tmdpvol(i As Integer, p2 As Integer) As Object
        Get
            Return _tmdpvol
        End Get
        Set(value As Object)
            _tmdpvol = value
        End Set
    End Property

    Shared Property valve(i As Integer) As Object
        Get
            Return _valve
        End Get
        Set(value As Object)
            _valve = value
        End Set
    End Property

    Shared Property accum(i As Integer) As Object
        Get
            Return _accum
        End Get
        Set(value As Object)
            _accum = value
        End Set
    End Property

    Shared Property branch(i As Integer, p2 As Integer) As Object
        Get
            Return _branch
        End Get
        Set(value As Object)
            _branch = value
        End Set
    End Property

    Shared Property lbplot(i As Integer) As Object
        Get
            Return _lbplot
        End Get
        Set(value As Object)
            _lbplot = value
        End Set
    End Property

    Shared Function timecontrol(p1 As Integer) As String
        Throw New NotImplementedException
    End Function

    Shared Function heat(i As Integer, p2 As Integer) As Object
        Throw New NotImplementedException
    End Function

    Shared Function word1lbc(i As Integer, j As Integer) As Object
        Throw New NotImplementedException
    End Function

    Shared Function ITDF2(i As Integer, k As Integer, p3 As Integer) As Object
        Throw New NotImplementedException
    End Function

    Shared Function word1rbc(i As Integer, j As Integer) As Object
        Throw New NotImplementedException
    End Function

    Shared Function valvetable(i As Integer, j As Integer) As String
        Throw New NotImplementedException
    End Function

End Class

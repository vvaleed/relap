'Copyright (C) 2002 Microsoft Corporation
'All rights reserved.
'
'THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
'EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
'MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'
'Date: June 2002
'Author: Duncan Mackenzie
'
'Requires the release version of .NET Framework

Imports System.Drawing

Namespace GraphicObjects

    <Serializable()> Public MustInherit Class ImageGraphic
        Inherits GraphicObject
        Protected Sub New()
            MyBase.New()
            Me.TipoObjeto = GraphicObjects.TipoObjeto.GO_Figura
        End Sub
        Public MustOverride Function GetImage() As Image

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

    <Serializable()> Public Class LinkedImageGraphic
        Inherits ImageGraphic
        Protected m_ImagePath As String
        <NonSerialized()> Protected m_Image As Image

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.TipoObjeto = GraphicObjects.TipoObjeto.GO_Figura
        End Sub

        Public Sub New(ByVal graphicPosition As Point, ByVal ImagePath As String)
            Me.New()
            Me.SetPosition(graphicPosition)
            Me.ImagePath = ImagePath
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal ImagePath As String)
            Me.New(New Point(posX, posY), ImagePath)
        End Sub

        Public Sub New(ByVal graphicPosition As Point, ByVal graphicSize As Size, ByVal ImagePath As String)
            Me.New(graphicPosition, ImagePath)
            Me.SetSize(graphicSize)
            Me.AutoSize = False
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal graphicSize As Size, ByVal ImagePath As String)
            Me.New(New Point(posX, posY), graphicSize, ImagePath)
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal width As Integer, ByVal height As Integer, ByVal ImagePath As String)
            Me.New(New Point(posX, posY), New Size(width, height), ImagePath)
        End Sub

        Public Sub New(ByVal graphicPosition As Point, ByVal Rotation As Single, ByVal ImagePath As String)
            Me.New(graphicPosition, ImagePath)
            Me.Rotation = Rotation
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal Rotation As Single, ByVal ImagePath As String)
            Me.New(New Point(posX, posY), Rotation, ImagePath)
        End Sub

        Public Sub New(ByVal graphicPosition As Point, ByVal graphicSize As Size, ByVal Rotation As Single, ByVal ImagePath As String)
            Me.New(graphicPosition, Rotation, ImagePath)
            Me.SetSize(graphicSize)
            Me.AutoSize = False
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal graphicSize As Size, ByVal Rotation As Single, ByVal ImagePath As String)
            Me.New(New Point(posX, posY), graphicSize, Rotation, ImagePath)
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal width As Integer, _
                               ByVal height As Integer, ByVal Rotation As Single, ByVal ImagePath As String)
            Me.New(New Point(posX, posY), New Size(width, height), Rotation, ImagePath)
        End Sub

#End Region

        Public Overrides Function GetImage() As System.Drawing.Image
            Try
                If m_Image Is Nothing Then
                    m_Image = New Bitmap(m_ImagePath)
                End If
                Return m_Image
            Catch ex As System.Exception
                Return Nothing
            End Try
        End Function

        Public Property ImagePath() As String
            Get
                Return m_ImagePath
            End Get
            Set(ByVal Value As String)
                If Value <> m_ImagePath Then
                    m_ImagePath = Value
                    m_Image = Nothing
                End If
            End Set
        End Property

        Public Overrides Sub Draw(ByVal g As System.Drawing.Graphics)
            Dim container As System.Drawing.Drawing2D.GraphicsContainer
            Dim myMatrix As Drawing2D.Matrix
            container = g.BeginContainer()
            myMatrix = g.Transform()
            If m_Rotation <> 0 Then
                myMatrix.RotateAt(m_rotation, New PointF(X, Y), Drawing.Drawing2D.MatrixOrder.Append)
                g.Transform = myMatrix
            End If
            Dim myImage As Image
            myImage = Me.GetImage
            If Not myImage Is Nothing Then
                If Me.AutoSize Then
                    Dim myNewWidth As Integer = _
                        (myImage.Width / myImage.HorizontalResolution) _
                            * Me.Container.HorizontalResolution
                    Dim myNewHeight As Integer = _
                        (myImage.Height / myImage.VerticalResolution) _
                            * Me.Container.VerticalResolution
                    Me.Height = myNewHeight
                    Me.Width = myNewWidth
                End If
                g.DrawImage(myImage, X, Y, Width, Height)
            End If
            g.EndContainer(container)
        End Sub
    End Class

    <Serializable()> Public Class EmbeddedImageGraphic
        Inherits ImageGraphic
        Protected m_Image As Image

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.TipoObjeto = GraphicObjects.TipoObjeto.GO_Figura
        End Sub

        Public Sub New(ByVal graphicPosition As Point, ByVal startingImage As Image)
            Me.New()
            Me.SetPosition(graphicPosition)
            Me.Image = startingImage
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal startingImage As Image)
            Me.New(New Point(posX, posY), startingImage)
        End Sub

        Public Sub New(ByVal graphicPosition As Point, ByVal graphicSize As Size, ByVal startingImage As Image)
            Me.New(graphicPosition, startingImage)
            Me.SetSize(graphicSize)
            Me.AutoSize = False
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal graphicSize As Size, ByVal startingImage As Image)
            Me.New(New Point(posX, posY), graphicSize, startingImage)
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal width As Integer, ByVal height As Integer, ByVal startingImage As Image)
            Me.New(New Point(posX, posY), New Size(width, height), startingImage)
        End Sub

        Public Sub New(ByVal graphicPosition As Point, ByVal Rotation As Single, ByVal startingImage As Image)
            Me.New(graphicPosition, startingImage)
            Me.Rotation = Rotation
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal Rotation As Single, ByVal startingImage As Image)
            Me.New(New Point(posX, posY), Rotation, startingImage)
        End Sub

        Public Sub New(ByVal graphicPosition As Point, ByVal graphicSize As Size, ByVal Rotation As Single, ByVal startingImage As Image)
            Me.New(graphicPosition, Rotation, startingImage)
            Me.SetSize(graphicSize)
            Me.AutoSize = False
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal graphicSize As Size, ByVal Rotation As Single, ByVal startingImage As Image)
            Me.New(New Point(posX, posY), graphicSize, Rotation, startingImage)
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal width As Integer, _
                               ByVal height As Integer, ByVal Rotation As Single, ByVal startingImage As Image)
            Me.New(New Point(posX, posY), New Size(width, height), Rotation, startingImage)
        End Sub

#End Region

        Public Property Image() As Image
            Get
                Return m_Image
            End Get
            Set(ByVal Value As Image)
                m_Image = Value
            End Set
        End Property

        Public Overrides Function GetImage() As System.Drawing.Image
            Return Me.Image
        End Function

        Public Overrides Sub Draw(ByVal g As System.Drawing.Graphics)
            Dim container As System.Drawing.Drawing2D.GraphicsContainer
            Dim myMatrix As Drawing2D.Matrix
            container = g.BeginContainer()
            myMatrix = g.Transform()
            If m_Rotation <> 0 Then
                myMatrix.RotateAt(m_rotation, New PointF(X, Y), Drawing.Drawing2D.MatrixOrder.Append)
                g.Transform = myMatrix
            End If
            If Not m_Image Is Nothing Then
                If Me.AutoSize Then
                    Dim myNewWidth As Integer = _
                        (m_Image.Width / m_Image.HorizontalResolution) _
                            * Me.Container.HorizontalResolution
                    Dim myNewHeight As Integer = _
                        (m_Image.Height / m_Image.VerticalResolution) _
                            * Me.Container.VerticalResolution
                    Me.Height = myNewHeight
                    Me.Width = myNewWidth
                End If
                g.DrawImage(m_Image, X, Y, Width, Height)
            End If
            g.EndContainer(container)
        End Sub

    End Class


    <Serializable()> Public Class EmbeddedAnimationGraphic
        Inherits ImageGraphic
        Protected m_Image As Image

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.TipoObjeto = GraphicObjects.TipoObjeto.GO_Animation
        End Sub

        Public Sub New(ByVal graphicPosition As Point, ByVal startingImage As Image)
            Me.New()
            Me.SetPosition(graphicPosition)
            Me.Image = startingImage
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal startingImage As Image)
            Me.New(New Point(posX, posY), startingImage)
        End Sub

        Public Sub New(ByVal graphicPosition As Point, ByVal graphicSize As Size, ByVal startingImage As Image)
            Me.New(graphicPosition, startingImage)
            Me.SetSize(graphicSize)
            Me.AutoSize = False
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal graphicSize As Size, ByVal startingImage As Image)
            Me.New(New Point(posX, posY), graphicSize, startingImage)
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal width As Integer, ByVal height As Integer, ByVal startingImage As Image)
            Me.New(New Point(posX, posY), New Size(width, height), startingImage)
        End Sub

        Public Sub New(ByVal graphicPosition As Point, ByVal Rotation As Single, ByVal startingImage As Image)
            Me.New(graphicPosition, startingImage)
            Me.Rotation = Rotation
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal Rotation As Single, ByVal startingImage As Image)
            Me.New(New Point(posX, posY), Rotation, startingImage)
        End Sub

        Public Sub New(ByVal graphicPosition As Point, ByVal graphicSize As Size, ByVal Rotation As Single, ByVal startingImage As Image)
            Me.New(graphicPosition, Rotation, startingImage)
            Me.SetSize(graphicSize)
            Me.AutoSize = False
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal graphicSize As Size, ByVal Rotation As Single, ByVal startingImage As Image)
            Me.New(New Point(posX, posY), graphicSize, Rotation, startingImage)
        End Sub

        Public Sub New(ByVal posX As Integer, ByVal posY As Integer, ByVal width As Integer, _
                               ByVal height As Integer, ByVal Rotation As Single, ByVal startingImage As Image)
            Me.New(New Point(posX, posY), New Size(width, height), Rotation, startingImage)
        End Sub

#End Region

        Public Property Image() As Image
            Get
                Return m_Image
            End Get
            Set(ByVal Value As Image)
                m_Image = Value
            End Set
        End Property

        Public Overrides Function GetImage() As System.Drawing.Image
            Return Me.Image
        End Function

        Public Overrides Sub Draw(ByVal g As System.Drawing.Graphics)
            Dim container As System.Drawing.Drawing2D.GraphicsContainer
            Dim myMatrix As Drawing2D.Matrix
            container = g.BeginContainer()
            myMatrix = g.Transform()
            If m_Rotation <> 0 Then
                myMatrix.RotateAt(m_rotation, New PointF(X, Y), Drawing.Drawing2D.MatrixOrder.Append)
                g.Transform = myMatrix
            End If
            If Not m_Image Is Nothing Then
                If Me.AutoSize Then
                    Dim myNewWidth As Integer = _
                        (m_Image.Width / m_Image.HorizontalResolution) _
                            * Me.Container.HorizontalResolution
                    Dim myNewHeight As Integer = _
                        (m_Image.Height / m_Image.VerticalResolution) _
                            * Me.Container.VerticalResolution
                    Me.Height = myNewHeight
                    Me.Width = myNewWidth
                End If

                'Begin the animation.

                If Not currentlyAnimating Then

                    'Begin the animation only once.
                    ImageAnimator.Animate(m_Image, New EventHandler(AddressOf Me.OnFrameChanged))
                    currentlyAnimating = True

                End If

                'Get the next frame ready for rendering.
                ImageAnimator.UpdateFrames()

                'Draw the next frame in the animation.
                g.DrawImage(m_Image, X, Y, Width, Height)

            End If

            g.EndContainer(container)

        End Sub

        Private Sub OnFrameChanged(ByVal o As Object, ByVal e As EventArgs)

            'Force a call to the Paint event handler.
            'Me.AdditionalInfo.Invalidate()

        End Sub

        Private currentlyAnimating As Boolean = False

    End Class

End Namespace

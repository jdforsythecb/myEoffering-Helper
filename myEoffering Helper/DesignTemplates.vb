Imports System.IO

Public Class DesignTemplates

    '' constants to paths of design templates
    Private Const TEMPLATEBULLETIN As String = "G:\myeoffering\Design Files\MEO Bulletin.indd"
    Private Const TEMPLATEPOSTER As String = "G:\myeoffering\Design Files\MEO Poster.indd"
    Private Const TEMPLATELETTER As String = "G:\myeoffering\Design Files\MEO Letter - Intro to members.indd"

    '' save path
    Private Const SAVEPATH As String = "g:\myeoffering\marketing_materials\"

    '' types of templates
    Public Enum TemplateTypes As Integer
        Bulletin = 1
        Poster = 2
        Letter = 3
        HTML = 4
    End Enum

    '' private copies of the public properties
    Private tmpl As TemplateTypes
    Private psidnum As String = ""
    Private svpth As String = ""

    '' public property allowing get/set template type
    Public Property TemplateType() As TemplateTypes
        Get
            Return tmpl
        End Get

        Set(value As TemplateTypes)
            tmpl = value
        End Set
    End Property

    '' public property allowing get/set folder number
    Public Property PSID() As String
        Get
            Return psidnum
        End Get

        Set(value As String)
            psidnum = value
        End Set
    End Property



    '' constructor
    Public Sub New(Optional ParishSupportID As String = "")
        If Not (ParishSupportID = "") Then
            psidnum = ParishSupportID
        End If
    End Sub




    '' public methods
    Public Sub create()
        If (psidnum = "") Then
            '' can't do anything
            Exit Sub
        End If

        Dim templatePath As String = getTemplatePath()
        Dim targetFileName As String = getFileName()
        Dim fullTargetPath As String = ""
        svpth = SAVEPATH & psidnum

        fullTargetPath = svpth & "\" & targetFileName

        '' check that the template file exists
        If Not (File.Exists(templatePath)) Then
            MessageBox.Show("Uh Oh! The template you chose is missing! Call for help!")
            Exit Sub
        End If

        '' check that the save path exists, and if not, create it
        If Not (Directory.Exists(svpth)) Then
            Directory.CreateDirectory(svpth)
            MessageBox.Show("Created a new folder for " & psidnum & "at: " & svpth)
        End If

        '' check that the file we're creating doesn't exist
        If (File.Exists(fullTargetPath)) Then
            MessageBox.Show("Sorry, a design file with that name already exists.")
            Exit Sub
        End If

        '' we know the template exists, the save path exists, and the save file does not
        '' so we can safely copy the template to the new file
        Try

            File.Copy(templatePath, fullTargetPath)
        Catch copyError As IOException
            MessageBox.Show("Error creating new design file. Message: " & copyError.Message)
        End Try

    End Sub





    '' private helper methods
    Private Function getTemplatePath() As String
        Select Case tmpl
            Case TemplateTypes.Bulletin
                Return TEMPLATEBULLETIN

            Case TemplateTypes.Poster
                Return TEMPLATEPOSTER

            Case TemplateTypes.Letter
                Return TEMPLATELETTER

            Case Else
                Return ""
        End Select

    End Function

    Private Function getFileName() As String
        Select Case tmpl
            Case TemplateTypes.Bulletin
                Return psidnum & " MEO Bulletin.indd"

            Case TemplateTypes.Poster
                Return psidnum & " MEO Poster.indd"

            Case TemplateTypes.Letter
                Return psidnum & " MEO Letter - intro to members.indd"

            Case Else
                Return ""
        End Select
    End Function

End Class

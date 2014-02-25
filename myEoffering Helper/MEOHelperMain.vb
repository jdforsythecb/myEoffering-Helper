Imports System.IO
Imports System.Text

Public Class MEOHelperMain

    Private Const MEO_BASE_URL As String = "http://www.myeoffering.com/eonline/index.php/dashboard/login/"
    Private Const SAVEPATH As String = "g:\myeoffering\marketing_materials\"
    Private Const QT_ZINT_PATH As String = "c:\Program Files (x86)\Zint\zint.exe"

    Private psid As String = ""

    Private sql As New MySQL_Connection

    Private Sub MEOHelperMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub


    Private Sub do_connect()
        sql = New MySQL_Connection
        '' when the form loads, connect to the mysql server
        sql.server = "208.109.248.69"
        sql.username = "newadmin"
        sql.password = "Skipjif23%"
        '' development
        'sql.database = "parishsupport_dev"
        '' live
        sql.database = "parishsupport_live"
        '' options
        sql.options = "pooling=false; Allow Zero Datetime=true"

        If (Not sql.openConnection()) Then
            MessageBox.Show("Connection to database failed. Any database-driven functionality will not work.")
            'Else
            'MessageBox.Show("Connection made")
        End If
    End Sub

    Private Sub do_disconnect()
        sql.closeConnection()
        sql = Nothing
    End Sub







    Private Sub uiTxtPSID_KeyDown(sender As Object, e As KeyEventArgs) Handles uiTxtPSID.KeyDown
        '' any time a key is pressed, disable buttons
        uiBtn_CreateMaterials.Enabled = False

        '' only turn to a good state when pressing enter
        If Not (e.KeyCode = Keys.Return) Then
            Exit Sub
        End If

        '' highlight the text in the box
        uiTxtPSID.SelectAll()

        '' clear all check boxes
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is CheckBox Then
                DirectCast(ctrl, CheckBox).CheckState = CheckState.Unchecked
            End If
        Next

        '' this is our only validation - that the number is 4 digits
        Dim psidnum As String = uiTxtPSID.Text.Trim

        '' if it's 4 digits, enable the buttons and set the psid property
        If (psidnum.Length = 4) Then
            uiBtn_CreateMaterials.Enabled = True

            '' check all the boxes by default
            For i As Integer = 0 To uiChkListMaterials.Items.Count - 1
                uiChkListMaterials.SetItemChecked(i, True)
            Next

            psid = psidnum

            '' get the database data
            getChurchInfo()
        End If

    End Sub





    Private Sub uiBtn_CreateMaterials_Click(sender As Object, e As EventArgs) Handles uiBtn_CreateMaterials.Click
        '' for each checkbox that is checked, create the templates

        '' find all checked boxes
        For Each itemChecked In uiChkListMaterials.CheckedItems
            Dim item As String = itemChecked.ToString()
            'MessageBox.Show("Item with title: " & item)

            '' find what kind of template
            Select Case item
                Case "Bulletin"
                    createTemplate(DesignTemplates.TemplateTypes.Bulletin)
                Case "Poster"
                    createTemplate(DesignTemplates.TemplateTypes.Poster)
                Case "Letter"
                    createTemplate(DesignTemplates.TemplateTypes.Letter)
                Case "HTML"
                    createHTML()
                Case "QR Code"
                    createQR()
            End Select
        Next
    End Sub





    Private Sub createHTML()
        Dim dq As String = """"
        Dim crlf As String = Environment.NewLine

        Dim html As New StringBuilder()

        html.AppendLine("<!--Snip Start-->")
        html.AppendLine("<div align=""center"" style=""cursor:pointer;background-color:#fff;padding:0px;width:250px;"" >")
        html.AppendLine("  <div style=""background-color:#fff;border:3px solid #CCCC66;padding:3px;-webkit-border-radius: 10px;-moz-border-radius: 10px;border-radius: 10px;"">")
        html.AppendLine("    <a href=""http://www.myeoffering.com/eonline/index.php/dashboard/login/" & psid & """ target=""_blank""/>")
        html.AppendLine("      <img src=""http://myeoffering.com/images/myEoffering_header_logo2.png"" width=""100%"">")
        html.AppendLine("      <div style=""color:#ffffff;background-color:#24b04b;padding:0px;-webkit-border-radius: 10px;-moz-border-radius: 10px;border-radius: 10px;"">")
        html.AppendLine("        <h2>Donate Now</h2>")
        html.AppendLine("      </div>")
        html.AppendLine("    </a>")
        html.AppendLine("  </div>")
        html.AppendLine("</div>")
        html.AppendLine("<!--Snip End-->")

        'MessageBox.Show(html.ToString())

        Using htmlfile As New StreamWriter(SAVEPATH & psid & "\" & psid & " MEO Website Code.html")
            htmlfile.Write(html.ToString())
        End Using
    End Sub






    Private Sub createTemplate(templateType As DesignTemplates.TemplateTypes)
        '' copy template and rename
        Dim template As New DesignTemplates(psid)
        template.TemplateType = templateType
        template.create()
    End Sub


    Private Sub createQR()
        '' the meo login url for their church
        Dim url As String = MEO_BASE_URL & psid
        Dim outfile As String = SAVEPATH & psid & "\" & psid & "_MEO_QR_CODE."

        '' if the outfile's path doesn't exist, create it
        If Not (Directory.Exists(SAVEPATH & psid)) Then
            Directory.CreateDirectory(SAVEPATH & psid)
        End If

        '' copy the web site address for their church's myeoffering site to the clipboard
        Clipboard.SetText(url)

        '' save eps QR code
        Dim cmd As String = String.Format("{0} --output={1} --barcode=58 --data=""{2}""", QT_ZINT_PATH, (outfile & "eps"), url)
        Call Shell(cmd, AppWinStyle.Hide)

        '' save png QR code
        cmd = String.Format("{0} --output={1} --barcode=58 --data=""{2}""", QT_ZINT_PATH, (outfile & "png"), url)
        Call Shell(cmd, AppWinStyle.Hide)

        ' options
        '
        ' --barcode=58  qr code

    End Sub






    '' now that we've created the file, open it in the default program
    'Dim openFile As New ProcessStartInfo()
    '    openFile.FileName = fullTargetPath
    '    openFile.UseShellExecute = True
    '    Process.Start(openFile)

    Private Sub uiBtnOpenFolder_Click(sender As Object, e As EventArgs) Handles uiBtnOpenFolder.Click
        Call Shell("explorer.exe " & SAVEPATH & psid, AppWinStyle.NormalFocus)
    End Sub



    Private Sub getChurchInfo()
        '' we already have the private property "sql" that has an open connection (unless we got an error message)
        '' x that, we need to create and dispose of the connection to prevent timeouts and memory leaks
        do_connect()

        '    '' build a parameterized query
        '    Dim query As String = "SELECT * FROM ps_parish WHERE id=@ID"
        '    '' create dictionary of parameters
        '    Dim params As New Dictionary(Of String, String)
        '    params.Add("ID", psid)

        '    '' now call the select query
        '    Dim results As New List(Of Dictionary(Of String, String))
        '    results = sql.selectQuery(query)

        '    '' if there are no records returned
        '    If Not (results.Count > 0) Then
        '        MessageBox.Show("Not an active church")
        '    Else
        '        '' for each record returned...
        '        For Each record As Dictionary(Of String, String) In results
        '            '' for each key/value pair in the record
        '            For Each pair As KeyValuePair(Of String, String) In record
        '                '' show a message
        '                MessageBox.Show("key: " & pair.Key & " - value: " & pair.Value)
        '            Next

        '        Next
        '    End If




        ''MessageBox.Show(sql.selectQueryForSingleValue("SELECT phone FROM ps_parish WHERE id=" & psid & " LIMIT 1"))

        Dim results As List(Of Dictionary(Of String, String)) = sql.selectQuery("SELECT * FROM ps_parish WHERE id='" & psid & "' LIMIT 1")

        If (results.Count > 0) Then

            '' for each record, should iterate only once
            For Each record As Dictionary(Of String, String) In results
                '' set text boxes
                uiTxtChurchName.Text = record.Item("church_name")
                uiTxtCity.Text = record.Item("city")
                uiTxtState.Text = record.Item("state")
                uiTxtZip.Text = record.Item("zip")

                '' set the account status
                Dim acctStatus As String = record.Item("status")

                If (acctStatus = "0") Then
                    uiTxtAcctStatus.Text = "Disabled"
                ElseIf (acctStatus = "1") Then
                    uiTxtAcctStatus.Text = "Enabled"
                Else
                    uiTxtAcctStatus.Text = "Unknown: " & acctStatus
                End If

                uiTxtContact.Text = record.Item("contact")
                uiTxtPhone.Text = record.Item("phone")
                uiTxtPhoneTwo.Text = record.Item("phone_2")
                uiTxtEmail.Text = record.Item("email")

                uiTxtSalesperson.Text = record.Item("sales_person")

                '' which module
                Dim mdl As String = record.Item("module")
                If (mdl = "1") Then
                    uiTxtModule.Text = "MyEOffering"
                ElseIf (mdl = "2") Then
                    uiTxtModule.Text = "Full Access"
                ElseIf (mdl = "3") Then
                    uiTxtModule.Text = "OLM"
                Else
                    uiTxtModule.Text = "Unknown: " & mdl
                End If

            Next

        Else
            '' no results, give error and clear the output fields
            uiTxtChurchName.Text = ""
            uiTxtCity.Text = ""
            uiTxtState.Text = ""
            uiTxtZip.Text = ""
            uiTxtAcctStatus.Text = ""
            uiTxtContact.Text = ""
            uiTxtPhone.Text = ""
            uiTxtPhoneTwo.Text = ""
            uiTxtEmail.Text = ""
            uiTxtSalesperson.Text = ""
            uiTxtModule.Text = ""
            MessageBox.Show("No results for this PSID")

        End If

        do_disconnect()
    End Sub

End Class














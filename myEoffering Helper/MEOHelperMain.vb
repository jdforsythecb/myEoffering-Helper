Imports System.IO
Imports System.Text

Public Class MEOHelperMain

    Private Const MEO_BASE_URL As String = "http://www.myeoffering.com/eonline/index.php/dashboard/login/"
    Private Const SAVEPATH As String = "g:\myeoffering\marketing_materials\"
    Private Const QT_ZINT_PATH As String = "c:\Program Files (x86)\Zint\zint.exe"

    Private Enum SearchFields As Integer
        Church = 1
        City = 2
        State = 3
        Zip = 4
        Contact = 5
        Phone = 6
        Email = 7
    End Enum

    Private psid As String = ""

    Private sql As New MySQL_Connection

    Private Sub MEOHelperMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' when the form loads, we add columns to the uiLstVwSearchResults with the modified ColumnHeaderSortable
        '' set to Details view (to show column headers)
        uiLstVwSearchResults.View = View.Details
        '' ad columns using the ColumnHeaderSortable class - the fourth parameter specifies True for ascending, false for descending
        uiLstVwSearchResults.Columns.Add(New ColumnHeaderSortable("PSID", 40, HorizontalAlignment.Left, True))
        uiLstVwSearchResults.Columns.Add(New ColumnHeaderSortable("Church", 250, HorizontalAlignment.Left, True))
        uiLstVwSearchResults.Columns.Add(New ColumnHeaderSortable("City", 120, HorizontalAlignment.Left, True))
        uiLstVwSearchResults.Columns.Add(New ColumnHeaderSortable("ST", 30, HorizontalAlignment.Left, True))

        '' add the event handler for the ListView.ColumnClick
        AddHandler uiLstVwSearchResults.ColumnClick, AddressOf uiLstVwSearchResults_ColumnClick
    End Sub

    '' SQL STATE ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub do_connect()
        sql = New MySQL_Connection
        '' when the form loads, connect to the mysql server
        sql.server = "72.52.179.83"
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


    '' HELPER METHODS '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub clearCheckboxes()
        '' clear all check boxes
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is CheckBox Then
                DirectCast(ctrl, CheckBox).CheckState = CheckState.Unchecked
            End If
        Next
    End Sub

    Private Sub clearChurchInfoBoxes()
        '' clear all text fields
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
    End Sub


    Private Sub displayChurchInfo(ByVal churchInfo As Dictionary(Of String, String))
        '' set the id from our search
        psid = churchInfo.Item("id")
        '' set text boxes
        uiTxtPSID.Text = churchInfo.Item("id")
        uiTxtChurchName.Text = churchInfo.Item("church_name")
        uiTxtCity.Text = churchInfo.Item("city")
        uiTxtState.Text = churchInfo.Item("state")
        uiTxtZip.Text = churchInfo.Item("zip")

        '' set the account status
        Dim acctStatus As String = churchInfo.Item("status")

        If (acctStatus = "0") Then
            uiTxtAcctStatus.Text = "Disabled"
        ElseIf (acctStatus = "1") Then
            uiTxtAcctStatus.Text = "Enabled"
        Else
            uiTxtAcctStatus.Text = "Unknown: " & acctStatus
        End If

        uiTxtContact.Text = churchInfo.Item("contact")
        uiTxtPhone.Text = churchInfo.Item("phone")
        uiTxtPhoneTwo.Text = churchInfo.Item("phone_2")
        uiTxtEmail.Text = churchInfo.Item("email")

        uiTxtSalesperson.Text = churchInfo.Item("sales_person")

        '' which module
        Dim mdl As String = churchInfo.Item("module")
        If (mdl = "1") Then
            uiTxtModule.Text = "MyEOffering"
        ElseIf (mdl = "2") Then
            uiTxtModule.Text = "Full Access"
        ElseIf (mdl = "3") Then
            uiTxtModule.Text = "OLM"
        Else
            uiTxtModule.Text = "Unknown: " & mdl
        End If

        '' display login url
        uiTxtLoginURL.Text = MEO_BASE_URL & psid
    End Sub



    '' HELPER METHODS FOR DESIGN FILES '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

    Private Sub uiBtnOpenFolder_Click(sender As Object, e As EventArgs) Handles uiBtnOpenFolder.Click
        Call Shell("explorer.exe " & SAVEPATH & psid, AppWinStyle.NormalFocus)
    End Sub





    '' SQL SEARCHING '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Sub getChurchInfo()
        '' make an SQL connection
        do_connect()

        Dim results As List(Of Dictionary(Of String, String)) = sql.selectQuery("SELECT * FROM ps_parish WHERE id='" & psid & "' LIMIT 1")

        If (results.Count > 0) Then
            displayChurchInfo(results.Item(0))
        Else
            '' no results, give error and clear the output fields
            clearChurchInfoBoxes()
            MessageBox.Show("No results for this PSID")
        End If
        '' disconnect from SQL
        do_disconnect()
    End Sub

   
    Private Sub getChurchInfoByField(ByVal field As SearchFields, ByVal value As String)

        '' clear list box of search results
        uiLstVwSearchResults.Items.Clear()

        '' clear text fields of search results
        clearChurchInfoBoxes()

        '' make and SQL connection
        do_connect()

        Dim query As String = "SELECT * FROM ps_parish WHERE "

        Select Case field
            Case SearchFields.Church
                query &= "UPPER(church_name) LIKE UPPER('%" & value & "%')"
            Case SearchFields.City
                query &= "UPPER(city) LIKE UPPER('%" & value & "%')"
            Case SearchFields.Contact
                query &= "UPPER(contact) LIKE UPPER('%" & value & "%')"
            Case SearchFields.Email
                query &= "UPPER(email) LIKE UPPER('%" & value & "%')"
            Case SearchFields.State
                query &= "UPPER(state) LIKE UPPER('%" & value & "%')"
            Case SearchFields.Zip
                query &= "UPPER(zip) LIKE UPPER('%" & value & "%')"
            Case SearchFields.Phone
                '' phone can be in phone or phone_2 fields
                '' need to replace (, ), -, and " " to get just the number
                ' replace(replace(replace(replace(phone, " ", ""), "-", ""), ")", ""), "(", "")'
                query &= "(replace(replace(replace(replace(phone, ' ', ''), '-', ''), ')', ''), '(', '') LIKE ('%" & value & "%')) OR " & _
                         "(replace(replace(replace(replace(phone_2, ' ', ''), '-', ''), ')', ''), '(', '') LIKE ('%" & value & "%'))"
                'Console.WriteLine(query)
            Case Else
                Exit Sub
        End Select

        Dim results As List(Of Dictionary(Of String, String)) = sql.selectQuery(query)
        If (results.Count = 1) Then
            displayChurchInfo(results.Item(0))
        ElseIf (results.Count > 1) Then

            '' if there's more than one result we need to populate the uiLstViewSearchResults.items
            populateSearchResults(results)
        Else
            MessageBox.Show("No results")
        End If


        do_disconnect()
    End Sub


    Private Sub populateSearchResults(results As List(Of Dictionary(Of String, String)))
        For Each result As Dictionary(Of String, String) In results
            '' with each record, add an entry to the list view - built a listviewitem
            Dim resultItem As New ListViewItem
            resultItem.Text = result.Item("id")
            resultItem.SubItems.Add(result.Item("church_name"))
            resultItem.SubItems.Add(result.Item("city"))
            resultItem.SubItems.Add(result.Item("state"))
            '' add the listviewitem to the listview
            uiLstVwSearchResults.Items.Add(resultItem)
        Next
    End Sub



    '' EVENT HANDLERS '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '' BUTTONS'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub uiBtnClearForm_Click(sender As Object, e As EventArgs) Handles uiBtnClearForm.Click
        clearCheckboxes()
        clearChurchInfoBoxes()
    End Sub



    '' TEXT BOXES - KEYDOWN ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Sub uiTxtPSID_KeyDown(sender As Object, e As KeyEventArgs) Handles uiTxtPSID.KeyDown
        '' any time a key is pressed, disable buttons
        uiBtn_CreateMaterials.Enabled = False
        uiBtnOpenFolder.Enabled = False

        '' only turn to a good state when pressing enter
        If Not (e.KeyCode = Keys.Return) Then
            Exit Sub
        End If

        '' highlight the text in the box
        uiTxtPSID.SelectAll()

        clearCheckboxes()
        clearChurchInfoBoxes()
        uiLstVwSearchResults.Items.Clear()

        '' this is our only validation - that the number is 4 digits
        Dim psidnum As String = uiTxtPSID.Text.Trim

        '' if it's 4 digits, enable the buttons and set the psid property
        If (psidnum.Length = 4) Then
            uiBtn_CreateMaterials.Enabled = True
            uiBtnOpenFolder.Enabled = True

            '' check all the boxes by default
            For i As Integer = 0 To uiChkListMaterials.Items.Count - 1
                uiChkListMaterials.SetItemChecked(i, True)
            Next

            psid = psidnum

            '' get the database data
            getChurchInfo()
        End If

    End Sub

    Private Sub uiTxtChurchName_KeyDown(sender As Object, e As KeyEventArgs) Handles uiTxtChurchName.KeyDown
        '' only turn to a good state when pressing enter
        If (e.KeyCode = Keys.Return) Then
            getChurchInfoByField(SearchFields.Church, uiTxtChurchName.Text)
        End If
    End Sub

    Private Sub uiTxtCity_KeyDown(sender As Object, e As KeyEventArgs) Handles uiTxtCity.KeyDown
        '' only turn to a good state when pressing enter
        If (e.KeyCode = Keys.Return) Then
            getChurchInfoByField(SearchFields.City, uiTxtCity.Text)
        End If
    End Sub

    Private Sub uiTxtState_KeyDown(sender As Object, e As KeyEventArgs) Handles uiTxtState.KeyDown
        '' only turn to a good state when pressing enter
        If (e.KeyCode = Keys.Return) Then
            getChurchInfoByField(SearchFields.State, uiTxtState.Text)
        End If
    End Sub

    Private Sub uiTxtZip_KeyDown(sender As Object, e As KeyEventArgs) Handles uiTxtZip.KeyDown
        '' only turn to a good state when pressing enter
        If (e.KeyCode = Keys.Return) Then
            getChurchInfoByField(SearchFields.Zip, uiTxtZip.Text)
        End If
    End Sub

    Private Sub uiTxtContact_KeyDown(sender As Object, e As KeyEventArgs) Handles uiTxtContact.KeyDown
        '' only turn to a good state when pressing enter
        If (e.KeyCode = Keys.Return) Then
            getChurchInfoByField(SearchFields.Contact, uiTxtContact.Text)
        End If
    End Sub

    Private Sub uiTxtPhone_KeyDown(sender As Object, e As KeyEventArgs) Handles uiTxtPhone.KeyDown
        '' only turn to a good state when pressing enter
        If (e.KeyCode = Keys.Return) Then
            getChurchInfoByField(SearchFields.Phone, uiTxtPhone.Text)
        End If
    End Sub

    Private Sub uiTxtEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles uiTxtEmail.KeyDown
        '' only turn to a good state when pressing enter
        If (e.KeyCode = Keys.Return) Then
            getChurchInfoByField(SearchFields.Email, uiTxtEmail.Text)
        End If
    End Sub

    Private Sub uiBtnCopyToClipboard_Click(sender As Object, e As EventArgs) Handles uiBtnCopyToClipboard.Click
        Dim clipboardString As String = uiTxtChurchName.Text & Environment.NewLine & _
                                        uiTxtCity.Text & ", " & uiTxtState.Text & " " & uiTxtZip.Text & Environment.NewLine & _
                                        uiTxtPhone.Text & Environment.NewLine & _
                                        uiTxtPhoneTwo.Text & Environment.NewLine & _
                                        uiTxtContact.Text & Environment.NewLine & _
                                        uiTxtEmail.Text & Environment.NewLine & _
                                        "PSID: " & psid & Environment.NewLine & _
                                        uiTxtModule.Text
        Clipboard.SetText(clipboardString)
    End Sub

    Private Sub uiLstVwSearchResults_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs)
        '' create and instance of the ColumnHeaderSortable class
        Dim clickedColumn As ColumnHeaderSortable = CType(uiLstVwSearchResults.Columns(e.Column), ColumnHeaderSortable)

        ' set the ascending property to sort in the opposite order
        clickedColumn.ascending = Not clickedColumn.ascending

        ' get the number of items inthe list
        Dim numItems As Integer = uiLstVwSearchResults.Items.Count

        ' turn off display while data is repopulated
        uiLstVwSearchResults.BeginUpdate()

        ' populate an ArrayList with a ListViewColumnSorter of each list item
        Dim SortArray As New ArrayList
        Dim i As Integer
        For i = 0 To (numItems - 1)
            SortArray.Add(New ListViewColumnSorter(uiLstVwSearchResults.Items(i), e.Column))
        Next

        '' sort the elements in the ArrayList using a new instance of the SortComparer class.
        '' the parameters are the starting index, the length of the range to sort, and the IComparer implementation to use for comparing elements
        '' note that the IComparer implementation (SortComparer) requires the sort direction for its constructor - true = ascending
        SortArray.Sort(0, SortArray.Count, New ListViewColumnSorter.SortComparer(clickedColumn.ascending))

        '' clear the list and repopulate with the sorted items
        uiLstVwSearchResults.Items.Clear()
        For i = 0 To (numItems - 1)
            uiLstVwSearchResults.Items.Add(CType(SortArray(i), ListViewColumnSorter).sortItem)
        Next

        '' turn display of items in list back on
        uiLstVwSearchResults.EndUpdate()
    End Sub

    Private Sub uiLstVwSearchResults_SelectedIndexChanged(sender As Object, e As EventArgs) Handles uiLstVwSearchResults.SelectedIndexChanged
        '' set the psid to the selected item
        psid = uiLstVwSearchResults.SelectedItems(0).Text
        '' set the psid text to reflect the new number
        uiTxtPSID.Text = psid
        '' run the search on that psid for the results to populate the text box
        getChurchInfo()
    End Sub

    Private Sub uiBtnCopyURLToClipboard_Click(sender As Object, e As EventArgs) Handles uiBtnCopyURLToClipboard.Click
        If (uiTxtLoginURL.Text.Trim <> "") Then Clipboard.SetText(uiTxtLoginURL.Text.Trim)
    End Sub
End Class














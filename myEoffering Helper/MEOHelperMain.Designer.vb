<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MEOHelperMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.uiTxtPSID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.uiChkListMaterials = New System.Windows.Forms.CheckedListBox()
        Me.uiBtn_CreateMaterials = New System.Windows.Forms.Button()
        Me.uiBtnOpenFolder = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.uiTxtChurchName = New System.Windows.Forms.TextBox()
        Me.uiTxtAcctStatus = New System.Windows.Forms.TextBox()
        Me.uiTxtCity = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.uiTxtState = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.uiTxtZip = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.uiTxtContact = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.uiTxtPhone = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.uiTxtPhoneTwo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.uiTxtEmail = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.uiTxtSalesperson = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.uiTxtModule = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.uiBtnClearForm = New System.Windows.Forms.Button()
        Me.uiBtnCopyToClipboard = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.uiLstVwSearchResults = New System.Windows.Forms.ListView()
        Me.uiTxtLoginURL = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.uiBtnCopyURLToClipboard = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'uiTxtPSID
        '
        Me.uiTxtPSID.Location = New System.Drawing.Point(57, 27)
        Me.uiTxtPSID.Name = "uiTxtPSID"
        Me.uiTxtPSID.Size = New System.Drawing.Size(100, 20)
        Me.uiTxtPSID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PSID#"
        '
        'uiChkListMaterials
        '
        Me.uiChkListMaterials.CheckOnClick = True
        Me.uiChkListMaterials.FormattingEnabled = True
        Me.uiChkListMaterials.Items.AddRange(New Object() {"Bulletin", "Poster", "Letter", "HTML", "QR Code"})
        Me.uiChkListMaterials.Location = New System.Drawing.Point(20, 26)
        Me.uiChkListMaterials.Name = "uiChkListMaterials"
        Me.uiChkListMaterials.Size = New System.Drawing.Size(99, 79)
        Me.uiChkListMaterials.TabIndex = 2
        '
        'uiBtn_CreateMaterials
        '
        Me.uiBtn_CreateMaterials.Location = New System.Drawing.Point(20, 120)
        Me.uiBtn_CreateMaterials.Name = "uiBtn_CreateMaterials"
        Me.uiBtn_CreateMaterials.Size = New System.Drawing.Size(99, 23)
        Me.uiBtn_CreateMaterials.TabIndex = 3
        Me.uiBtn_CreateMaterials.Text = "Create Materials"
        Me.uiBtn_CreateMaterials.UseVisualStyleBackColor = True
        '
        'uiBtnOpenFolder
        '
        Me.uiBtnOpenFolder.Location = New System.Drawing.Point(20, 166)
        Me.uiBtnOpenFolder.Name = "uiBtnOpenFolder"
        Me.uiBtnOpenFolder.Size = New System.Drawing.Size(99, 23)
        Me.uiBtnOpenFolder.TabIndex = 4
        Me.uiBtnOpenFolder.Text = "Open Folder"
        Me.uiBtnOpenFolder.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Church Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Acct Status"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uiTxtChurchName
        '
        Me.uiTxtChurchName.Location = New System.Drawing.Point(83, 23)
        Me.uiTxtChurchName.Name = "uiTxtChurchName"
        Me.uiTxtChurchName.Size = New System.Drawing.Size(266, 20)
        Me.uiTxtChurchName.TabIndex = 7
        '
        'uiTxtAcctStatus
        '
        Me.uiTxtAcctStatus.Location = New System.Drawing.Point(83, 136)
        Me.uiTxtAcctStatus.Name = "uiTxtAcctStatus"
        Me.uiTxtAcctStatus.Size = New System.Drawing.Size(175, 20)
        Me.uiTxtAcctStatus.TabIndex = 8
        '
        'uiTxtCity
        '
        Me.uiTxtCity.Location = New System.Drawing.Point(83, 49)
        Me.uiTxtCity.Name = "uiTxtCity"
        Me.uiTxtCity.Size = New System.Drawing.Size(148, 20)
        Me.uiTxtCity.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(57, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "City"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'uiTxtState
        '
        Me.uiTxtState.Location = New System.Drawing.Point(83, 75)
        Me.uiTxtState.Name = "uiTxtState"
        Me.uiTxtState.Size = New System.Drawing.Size(100, 20)
        Me.uiTxtState.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(49, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "State"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'uiTxtZip
        '
        Me.uiTxtZip.Location = New System.Drawing.Point(83, 101)
        Me.uiTxtZip.Name = "uiTxtZip"
        Me.uiTxtZip.Size = New System.Drawing.Size(100, 20)
        Me.uiTxtZip.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(60, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Zip"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'uiTxtContact
        '
        Me.uiTxtContact.Location = New System.Drawing.Point(83, 173)
        Me.uiTxtContact.Name = "uiTxtContact"
        Me.uiTxtContact.Size = New System.Drawing.Size(266, 20)
        Me.uiTxtContact.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(37, 177)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Contact"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'uiTxtPhone
        '
        Me.uiTxtPhone.Location = New System.Drawing.Point(83, 199)
        Me.uiTxtPhone.Name = "uiTxtPhone"
        Me.uiTxtPhone.Size = New System.Drawing.Size(148, 20)
        Me.uiTxtPhone.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(44, 203)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Phone"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'uiTxtPhoneTwo
        '
        Me.uiTxtPhoneTwo.Location = New System.Drawing.Point(83, 225)
        Me.uiTxtPhoneTwo.Name = "uiTxtPhoneTwo"
        Me.uiTxtPhoneTwo.Size = New System.Drawing.Size(148, 20)
        Me.uiTxtPhoneTwo.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 229)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Phone2"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'uiTxtEmail
        '
        Me.uiTxtEmail.Location = New System.Drawing.Point(83, 251)
        Me.uiTxtEmail.Name = "uiTxtEmail"
        Me.uiTxtEmail.Size = New System.Drawing.Size(266, 20)
        Me.uiTxtEmail.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(50, 255)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Email"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'uiTxtSalesperson
        '
        Me.uiTxtSalesperson.Location = New System.Drawing.Point(83, 284)
        Me.uiTxtSalesperson.Name = "uiTxtSalesperson"
        Me.uiTxtSalesperson.Size = New System.Drawing.Size(100, 20)
        Me.uiTxtSalesperson.TabIndex = 24
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 288)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Salesperson"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'uiTxtModule
        '
        Me.uiTxtModule.Location = New System.Drawing.Point(83, 318)
        Me.uiTxtModule.Name = "uiTxtModule"
        Me.uiTxtModule.Size = New System.Drawing.Size(148, 20)
        Me.uiTxtModule.TabIndex = 26
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(40, 322)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Module"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'uiBtnClearForm
        '
        Me.uiBtnClearForm.Location = New System.Drawing.Point(15, 53)
        Me.uiBtnClearForm.Name = "uiBtnClearForm"
        Me.uiBtnClearForm.Size = New System.Drawing.Size(141, 23)
        Me.uiBtnClearForm.TabIndex = 27
        Me.uiBtnClearForm.Text = "Clear"
        Me.uiBtnClearForm.UseVisualStyleBackColor = True
        '
        'uiBtnCopyToClipboard
        '
        Me.uiBtnCopyToClipboard.Location = New System.Drawing.Point(83, 346)
        Me.uiBtnCopyToClipboard.Name = "uiBtnCopyToClipboard"
        Me.uiBtnCopyToClipboard.Size = New System.Drawing.Size(148, 23)
        Me.uiBtnCopyToClipboard.TabIndex = 28
        Me.uiBtnCopyToClipboard.Text = "Copy To Clipboard"
        Me.uiBtnCopyToClipboard.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.uiBtnCopyToClipboard)
        Me.GroupBox1.Controls.Add(Me.uiTxtModule)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.uiTxtSalesperson)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.uiTxtEmail)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.uiTxtPhoneTwo)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.uiTxtPhone)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.uiTxtContact)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.uiTxtZip)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.uiTxtState)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.uiTxtCity)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.uiTxtAcctStatus)
        Me.GroupBox1.Controls.Add(Me.uiTxtChurchName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(167, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(371, 377)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Contact Info"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.uiBtnOpenFolder)
        Me.GroupBox2.Controls.Add(Me.uiBtn_CreateMaterials)
        Me.GroupBox2.Controls.Add(Me.uiChkListMaterials)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 97)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(142, 208)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Marketing"
        '
        'uiLstVwSearchResults
        '
        Me.uiLstVwSearchResults.FullRowSelect = True
        Me.uiLstVwSearchResults.GridLines = True
        Me.uiLstVwSearchResults.Location = New System.Drawing.Point(544, 27)
        Me.uiLstVwSearchResults.Name = "uiLstVwSearchResults"
        Me.uiLstVwSearchResults.Size = New System.Drawing.Size(445, 402)
        Me.uiLstVwSearchResults.TabIndex = 31
        Me.uiLstVwSearchResults.UseCompatibleStateImageBehavior = False
        Me.uiLstVwSearchResults.View = System.Windows.Forms.View.Details
        '
        'uiTxtLoginURL
        '
        Me.uiTxtLoginURL.Location = New System.Drawing.Point(15, 409)
        Me.uiTxtLoginURL.Name = "uiTxtLoginURL"
        Me.uiTxtLoginURL.Size = New System.Drawing.Size(456, 20)
        Me.uiTxtLoginURL.TabIndex = 29
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 386)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Login URL:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'uiBtnCopyURLToClipboard
        '
        Me.uiBtnCopyURLToClipboard.Location = New System.Drawing.Point(477, 409)
        Me.uiBtnCopyURLToClipboard.Name = "uiBtnCopyURLToClipboard"
        Me.uiBtnCopyURLToClipboard.Size = New System.Drawing.Size(61, 23)
        Me.uiBtnCopyURLToClipboard.TabIndex = 29
        Me.uiBtnCopyURLToClipboard.Text = "Copy"
        Me.uiBtnCopyURLToClipboard.UseVisualStyleBackColor = True
        '
        'MEOHelperMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 438)
        Me.Controls.Add(Me.uiBtnCopyURLToClipboard)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.uiTxtLoginURL)
        Me.Controls.Add(Me.uiLstVwSearchResults)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.uiBtnClearForm)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.uiTxtPSID)
        Me.Name = "MEOHelperMain"
        Me.Text = "MEO Helper"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents uiTxtPSID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents uiChkListMaterials As System.Windows.Forms.CheckedListBox
    Friend WithEvents uiBtn_CreateMaterials As System.Windows.Forms.Button
    Friend WithEvents uiBtnOpenFolder As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents uiTxtChurchName As System.Windows.Forms.TextBox
    Friend WithEvents uiTxtAcctStatus As System.Windows.Forms.TextBox
    Friend WithEvents uiTxtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents uiTxtState As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents uiTxtZip As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents uiTxtContact As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents uiTxtPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents uiTxtPhoneTwo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents uiTxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents uiTxtSalesperson As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents uiTxtModule As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents uiBtnClearForm As System.Windows.Forms.Button
    Friend WithEvents uiBtnCopyToClipboard As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents uiLstVwSearchResults As System.Windows.Forms.ListView
    Friend WithEvents uiTxtLoginURL As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents uiBtnCopyURLToClipboard As System.Windows.Forms.Button

End Class

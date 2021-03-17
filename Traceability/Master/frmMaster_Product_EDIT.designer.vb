<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaster_Product_EDIT
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
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCustomer_Barcode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPartNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTGRT_Barcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTGRT_Code = New System.Windows.Forms.TextBox()
        Me.txtPartname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCutDigit = New DevExpress.XtraEditors.SpinEdit()
        CType(Me.txtCutDigit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(298, 14)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(82, 23)
        Me.btnBack.TabIndex = 9
        Me.btnBack.TabStop = False
        Me.btnBack.Text = "BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(204, 14)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Part Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "Customer Barcode"
        '
        'txtCustomer_Barcode
        '
        Me.txtCustomer_Barcode.Location = New System.Drawing.Point(12, 154)
        Me.txtCustomer_Barcode.Name = "txtCustomer_Barcode"
        Me.txtCustomer_Barcode.Size = New System.Drawing.Size(181, 20)
        Me.txtCustomer_Barcode.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(207, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "Location"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(210, 116)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(181, 20)
        Me.txtLocation.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(207, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 94
        Me.Label8.Text = "Part No"
        '
        'txtPartNo
        '
        Me.txtPartNo.Location = New System.Drawing.Point(210, 78)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Size = New System.Drawing.Size(181, 20)
        Me.txtPartNo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "TGRT Barcode"
        '
        'txtTGRT_Barcode
        '
        Me.txtTGRT_Barcode.Location = New System.Drawing.Point(12, 116)
        Me.txtTGRT_Barcode.Name = "txtTGRT_Barcode"
        Me.txtTGRT_Barcode.Size = New System.Drawing.Size(181, 20)
        Me.txtTGRT_Barcode.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "TGRT Code"
        '
        'txtTGRT_Code
        '
        Me.txtTGRT_Code.Location = New System.Drawing.Point(12, 78)
        Me.txtTGRT_Code.Name = "txtTGRT_Code"
        Me.txtTGRT_Code.Size = New System.Drawing.Size(181, 20)
        Me.txtTGRT_Code.TabIndex = 0
        '
        'txtPartname
        '
        Me.txtPartname.Location = New System.Drawing.Point(12, 195)
        Me.txtPartname.Name = "txtPartname"
        Me.txtPartname.Size = New System.Drawing.Size(379, 20)
        Me.txtPartname.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(207, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Cut Digit"
        '
        'txtCutDigit
        '
        Me.txtCutDigit.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtCutDigit.Location = New System.Drawing.Point(210, 154)
        Me.txtCutDigit.Name = "txtCutDigit"
        Me.txtCutDigit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtCutDigit.Properties.Mask.EditMask = "N0"
        Me.txtCutDigit.Properties.MaxValue = New Decimal(New Integer() {999, 0, 0, 0})
        Me.txtCutDigit.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtCutDigit.Size = New System.Drawing.Size(100, 20)
        Me.txtCutDigit.TabIndex = 101
        '
        'frmMaster_Product_EDIT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 229)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtCutDigit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPartname)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCustomer_Barcode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtLocation)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPartNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTGRT_Barcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTGRT_Code)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "frmMaster_Product_EDIT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRODUCT EDIT"
        CType(Me.txtCutDigit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCustomer_Barcode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPartNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTGRT_Barcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTGRT_Code As System.Windows.Forms.TextBox
    Friend WithEvents txtPartname As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCutDigit As DevExpress.XtraEditors.SpinEdit
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBarcodeVerification
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtScan1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New DevExpress.XtraEditors.PictureEdit()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblStatusWait = New System.Windows.Forms.Label()
        Me.lblStatusOK = New System.Windows.Forms.Label()
        Me.lblStatusNG = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CbZoom = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblCountUp = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCusBarcode = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblPartNo = New System.Windows.Forms.Label()
        Me.lblTGRT_Code = New System.Windows.Forms.Label()
        Me.lblPartName = New System.Windows.Forms.Label()
        Me.lblBarcode = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtScan2 = New System.Windows.Forms.TextBox()
        Me.lblScan2 = New System.Windows.Forms.Label()
        Me.lblScan1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(578, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(138, 57)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'txtScan1
        '
        Me.txtScan1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtScan1.Location = New System.Drawing.Point(127, 21)
        Me.txtScan1.Name = "txtScan1"
        Me.txtScan1.Size = New System.Drawing.Size(199, 26)
        Me.txtScan1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(464, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Scan"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(464, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Scan2"
        Me.Label2.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 191)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(724, 259)
        Me.Panel1.TabIndex = 1
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox3.Location = New System.Drawing.Point(0, 55)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Properties.AllowFocused = False
        Me.PictureBox3.Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.[False]
        Me.PictureBox3.Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.[False]
        Me.PictureBox3.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureBox3.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.[True]
        Me.PictureBox3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureBox3.Size = New System.Drawing.Size(724, 204)
        Me.PictureBox3.TabIndex = 10
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblStatusWait)
        Me.Panel3.Controls.Add(Me.lblStatusOK)
        Me.Panel3.Controls.Add(Me.lblStatusNG)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(724, 55)
        Me.Panel3.TabIndex = 9
        '
        'lblStatusWait
        '
        Me.lblStatusWait.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblStatusWait.AutoSize = True
        Me.lblStatusWait.BackColor = System.Drawing.Color.Orange
        Me.lblStatusWait.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusWait.Location = New System.Drawing.Point(83, 4)
        Me.lblStatusWait.Name = "lblStatusWait"
        Me.lblStatusWait.Size = New System.Drawing.Size(558, 42)
        Me.lblStatusWait.TabIndex = 10
        Me.lblStatusWait.Text = "WAINT SCAN TGRT BARCODE"
        Me.lblStatusWait.Visible = False
        '
        'lblStatusOK
        '
        Me.lblStatusOK.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblStatusOK.AutoSize = True
        Me.lblStatusOK.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.lblStatusOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!)
        Me.lblStatusOK.Location = New System.Drawing.Point(297, -10)
        Me.lblStatusOK.Name = "lblStatusOK"
        Me.lblStatusOK.Size = New System.Drawing.Size(125, 73)
        Me.lblStatusOK.TabIndex = 8
        Me.lblStatusOK.Text = "OK"
        Me.lblStatusOK.Visible = False
        '
        'lblStatusNG
        '
        Me.lblStatusNG.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblStatusNG.AutoSize = True
        Me.lblStatusNG.BackColor = System.Drawing.Color.Red
        Me.lblStatusNG.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusNG.Location = New System.Drawing.Point(294, -10)
        Me.lblStatusNG.Name = "lblStatusNG"
        Me.lblStatusNG.Size = New System.Drawing.Size(128, 73)
        Me.lblStatusNG.TabIndex = 9
        Me.lblStatusNG.Text = "NG"
        Me.lblStatusNG.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.CbZoom)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.lblCountUp)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.txtScan2)
        Me.Panel2.Controls.Add(Me.lblScan2)
        Me.Panel2.Controls.Add(Me.lblScan1)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.txtScan1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(724, 191)
        Me.Panel2.TabIndex = 0
        '
        'CbZoom
        '
        Me.CbZoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbZoom.AutoSize = True
        Me.CbZoom.Location = New System.Drawing.Point(578, 67)
        Me.CbZoom.Name = "CbZoom"
        Me.CbZoom.Size = New System.Drawing.Size(58, 17)
        Me.CbZoom.TabIndex = 24
        Me.CbZoom.Text = "ZOOM"
        Me.CbZoom.UseVisualStyleBackColor = True
        Me.CbZoom.Visible = False
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(578, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 33)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Count :"
        '
        'lblCountUp
        '
        Me.lblCountUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCountUp.AutoSize = True
        Me.lblCountUp.BackColor = System.Drawing.Color.White
        Me.lblCountUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!)
        Me.lblCountUp.Location = New System.Drawing.Point(578, 111)
        Me.lblCountUp.Name = "lblCountUp"
        Me.lblCountUp.Size = New System.Drawing.Size(68, 73)
        Me.lblCountUp.TabIndex = 22
        Me.lblCountUp.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 20)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "TGRT SCAN :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 20)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "CUS SCAN :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblCusBarcode)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblPartNo)
        Me.GroupBox1.Controls.Add(Me.lblTGRT_Code)
        Me.GroupBox1.Controls.Add(Me.lblPartName)
        Me.GroupBox1.Controls.Add(Me.lblBarcode)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 100)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "TGRT CODE :"
        '
        'lblCusBarcode
        '
        Me.lblCusBarcode.AutoSize = True
        Me.lblCusBarcode.BackColor = System.Drawing.Color.Transparent
        Me.lblCusBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblCusBarcode.Location = New System.Drawing.Point(140, 69)
        Me.lblCusBarcode.Name = "lblCusBarcode"
        Me.lblCusBarcode.Size = New System.Drawing.Size(33, 20)
        Me.lblCusBarcode.TabIndex = 17
        Me.lblCusBarcode.Text = "......"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "BARCODE :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(129, 20)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Cus BARCODE :"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(311, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "PART NAME :"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(330, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 20)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "PART NO. :"
        '
        'lblPartNo
        '
        Me.lblPartNo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPartNo.AutoSize = True
        Me.lblPartNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblPartNo.Location = New System.Drawing.Point(426, 47)
        Me.lblPartNo.Name = "lblPartNo"
        Me.lblPartNo.Size = New System.Drawing.Size(33, 20)
        Me.lblPartNo.TabIndex = 14
        Me.lblPartNo.Text = "......"
        '
        'lblTGRT_Code
        '
        Me.lblTGRT_Code.AutoSize = True
        Me.lblTGRT_Code.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblTGRT_Code.Location = New System.Drawing.Point(140, 25)
        Me.lblTGRT_Code.Name = "lblTGRT_Code"
        Me.lblTGRT_Code.Size = New System.Drawing.Size(33, 20)
        Me.lblTGRT_Code.TabIndex = 11
        Me.lblTGRT_Code.Text = "......"
        '
        'lblPartName
        '
        Me.lblPartName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPartName.AutoSize = True
        Me.lblPartName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblPartName.Location = New System.Drawing.Point(426, 23)
        Me.lblPartName.Name = "lblPartName"
        Me.lblPartName.Size = New System.Drawing.Size(33, 20)
        Me.lblPartName.TabIndex = 13
        Me.lblPartName.Text = "......"
        '
        'lblBarcode
        '
        Me.lblBarcode.AutoSize = True
        Me.lblBarcode.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.lblBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblBarcode.Location = New System.Drawing.Point(140, 47)
        Me.lblBarcode.Name = "lblBarcode"
        Me.lblBarcode.Size = New System.Drawing.Size(33, 20)
        Me.lblBarcode.TabIndex = 12
        Me.lblBarcode.Text = "......"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Button2.Location = New System.Drawing.Point(578, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(138, 57)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "CLEAR"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'txtScan2
        '
        Me.txtScan2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtScan2.Location = New System.Drawing.Point(127, 58)
        Me.txtScan2.MaxLength = 0
        Me.txtScan2.Name = "txtScan2"
        Me.txtScan2.Size = New System.Drawing.Size(199, 26)
        Me.txtScan2.TabIndex = 1
        '
        'lblScan2
        '
        Me.lblScan2.AutoSize = True
        Me.lblScan2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblScan2.Location = New System.Drawing.Point(332, 61)
        Me.lblScan2.Name = "lblScan2"
        Me.lblScan2.Size = New System.Drawing.Size(25, 20)
        Me.lblScan2.TabIndex = 7
        Me.lblScan2.Text = "...."
        '
        'lblScan1
        '
        Me.lblScan1.AutoSize = True
        Me.lblScan1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblScan1.Location = New System.Drawing.Point(332, 21)
        Me.lblScan1.Name = "lblScan1"
        Me.lblScan1.Size = New System.Drawing.Size(25, 20)
        Me.lblScan1.TabIndex = 6
        Me.lblScan1.Text = "...."
        '
        'frmBarcodeVerification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(724, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.KeyPreview = True
        Me.Name = "frmBarcodeVerification"
        Me.Text = "frmBarcodeVerification"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents txtScan1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtScan2 As TextBox
    Friend WithEvents lblStatusNG As Label
    Friend WithEvents lblStatusOK As Label
    Friend WithEvents lblScan2 As Label
    Friend WithEvents lblScan1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblCusBarcode As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblPartNo As Label
    Friend WithEvents lblTGRT_Code As Label
    Friend WithEvents lblPartName As Label
    Friend WithEvents lblBarcode As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents lblCountUp As Label
    Friend WithEvents lblStatusWait As Label
    Friend WithEvents PictureBox3 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents CbZoom As CheckBox
End Class

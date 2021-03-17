<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaster_MC_EDIT
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMC_UNIT = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMC_NAME = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMC_MODEL = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMC_CODE = New System.Windows.Forms.TextBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAddPic = New System.Windows.Forms.Button()
        Me.PART_PIC = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMC_type = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMC_line = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMC_Remark = New System.Windows.Forms.TextBox()
        CType(Me.PART_PIC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(580, 171)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 20)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "MC Unit"
        '
        'txtMC_UNIT
        '
        Me.txtMC_UNIT.Location = New System.Drawing.Point(585, 195)
        Me.txtMC_UNIT.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMC_UNIT.Name = "txtMC_UNIT"
        Me.txtMC_UNIT.Size = New System.Drawing.Size(270, 26)
        Me.txtMC_UNIT.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(580, 112)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 20)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "MC Name"
        '
        'txtMC_NAME
        '
        Me.txtMC_NAME.Location = New System.Drawing.Point(585, 137)
        Me.txtMC_NAME.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMC_NAME.Name = "txtMC_NAME"
        Me.txtMC_NAME.Size = New System.Drawing.Size(270, 26)
        Me.txtMC_NAME.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(284, 171)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "MC Model"
        '
        'txtMC_MODEL
        '
        Me.txtMC_MODEL.Location = New System.Drawing.Point(288, 195)
        Me.txtMC_MODEL.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMC_MODEL.Name = "txtMC_MODEL"
        Me.txtMC_MODEL.Size = New System.Drawing.Size(270, 26)
        Me.txtMC_MODEL.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(284, 112)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 20)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "MC Code"
        '
        'txtMC_CODE
        '
        Me.txtMC_CODE.Location = New System.Drawing.Point(288, 137)
        Me.txtMC_CODE.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMC_CODE.Name = "txtMC_CODE"
        Me.txtMC_CODE.Size = New System.Drawing.Size(270, 26)
        Me.txtMC_CODE.TabIndex = 0
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(717, 38)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(123, 35)
        Me.btnBack.TabIndex = 8
        Me.btnBack.TabStop = False
        Me.btnBack.Text = "BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(576, 38)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(132, 35)
        Me.btnSave.TabIndex = 7
        Me.btnSave.TabStop = False
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAddPic
        '
        Me.btnAddPic.Enabled = False
        Me.btnAddPic.Location = New System.Drawing.Point(40, 308)
        Me.btnAddPic.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddPic.Name = "btnAddPic"
        Me.btnAddPic.Size = New System.Drawing.Size(216, 35)
        Me.btnAddPic.TabIndex = 78
        Me.btnAddPic.Text = "Add Picture From Folder"
        Me.btnAddPic.UseVisualStyleBackColor = True
        '
        'PART_PIC
        '
        Me.PART_PIC.Location = New System.Drawing.Point(40, 18)
        Me.PART_PIC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PART_PIC.Name = "PART_PIC"
        Me.PART_PIC.Size = New System.Drawing.Size(216, 280)
        Me.PART_PIC.TabIndex = 77
        Me.PART_PIC.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(284, 229)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 20)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "MC type"
        '
        'txtMC_type
        '
        Me.txtMC_type.Location = New System.Drawing.Point(288, 254)
        Me.txtMC_type.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMC_type.Name = "txtMC_type"
        Me.txtMC_type.Size = New System.Drawing.Size(270, 26)
        Me.txtMC_type.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(580, 229)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 20)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "MC Line"
        '
        'txtMC_line
        '
        Me.txtMC_line.Location = New System.Drawing.Point(584, 254)
        Me.txtMC_line.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMC_line.Name = "txtMC_line"
        Me.txtMC_line.Size = New System.Drawing.Size(270, 26)
        Me.txtMC_line.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(284, 292)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 20)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Remark"
        '
        'txtMC_Remark
        '
        Me.txtMC_Remark.Location = New System.Drawing.Point(288, 317)
        Me.txtMC_Remark.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMC_Remark.Name = "txtMC_Remark"
        Me.txtMC_Remark.Size = New System.Drawing.Size(270, 26)
        Me.txtMC_Remark.TabIndex = 6
        '
        'frmMaster_MC_EDIT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 380)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtMC_Remark)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMC_line)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMC_type)
        Me.Controls.Add(Me.btnAddPic)
        Me.Controls.Add(Me.PART_PIC)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtMC_UNIT)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtMC_NAME)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMC_MODEL)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMC_CODE)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSave)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmMaster_MC_EDIT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MC EDIT"
        CType(Me.PART_PIC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMC_UNIT As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMC_NAME As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMC_MODEL As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMC_CODE As System.Windows.Forms.TextBox
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnAddPic As System.Windows.Forms.Button
    Friend WithEvents PART_PIC As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMC_type As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMC_line As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMC_Remark As System.Windows.Forms.TextBox
End Class

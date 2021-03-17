<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImport1
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImport1))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.DGV = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.PGB1 = New DevExpress.XtraEditors.ProgressBarControl()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.PGB1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.GridControl1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GridControl1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.DGV
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1127, 537)
        Me.GridControl1.TabIndex = 28
        Me.GridControl1.UseEmbeddedNavigator = True
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DGV, Me.GridView1})
        '
        'DGV
        '
        Me.DGV.ActiveFilterEnabled = False
        Me.DGV.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DGV.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.DGV.Appearance.EvenRow.Options.UseBackColor = True
        Me.DGV.Appearance.EvenRow.Options.UseForeColor = True
        Me.DGV.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV.Appearance.FilterCloseButton.Options.UseFont = True
        Me.DGV.Appearance.FilterPanel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV.Appearance.FilterPanel.Options.UseFont = True
        Me.DGV.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV.Appearance.HeaderPanel.Options.UseFont = True
        Me.DGV.Appearance.Preview.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV.Appearance.Preview.Options.UseFont = True
        Me.DGV.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV.Appearance.Row.Options.UseFont = True
        Me.DGV.GridControl = Me.GridControl1
        Me.DGV.IndicatorWidth = 60
        Me.DGV.Name = "DGV"
        Me.DGV.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.DGV.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.DGV.OptionsBehavior.Editable = False
        Me.DGV.OptionsBehavior.ReadOnly = True
        Me.DGV.OptionsCustomization.AllowQuickHideColumns = False
        Me.DGV.OptionsFilter.AllowFilterEditor = False
        Me.DGV.OptionsFilter.UseNewCustomFilterDialog = True
        Me.DGV.OptionsFind.AlwaysVisible = True
        Me.DGV.OptionsLayout.Columns.AddNewColumns = False
        Me.DGV.OptionsLayout.Columns.RemoveOldColumns = False
        Me.DGV.OptionsMenu.EnableFooterMenu = False
        Me.DGV.OptionsView.ColumnAutoWidth = False
        Me.DGV.OptionsView.EnableAppearanceEvenRow = True
        Me.DGV.OptionsView.EnableAppearanceOddRow = True
        Me.DGV.OptionsView.ShowGroupPanel = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.IsSplitterFixed = True
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ComboBox1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SimpleButton4)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SimpleButton3)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.PGB1)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1127, 637)
        Me.SplitContainerControl1.SplitterPosition = 92
        Me.SplitContainerControl1.TabIndex = 2
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(862, 42)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 35)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(423, 23)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(378, 43)
        Me.ComboBox1.TabIndex = 4
        Me.ComboBox1.Visible = False
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Enabled = False
        Me.SimpleButton4.ImageOptions.Image = CType(resources.GetObject("SimpleButton4.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton4.Location = New System.Drawing.Point(236, 18)
        Me.SimpleButton4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(160, 58)
        Me.SimpleButton4.TabIndex = 3
        Me.SimpleButton4.Text = "Import"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(18, 18)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(208, 58)
        Me.SimpleButton3.TabIndex = 3
        Me.SimpleButton3.Text = "Browse"
        '
        'PGB1
        '
        Me.PGB1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PGB1.Location = New System.Drawing.Point(822, 14)
        Me.PGB1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PGB1.Name = "PGB1"
        Me.PGB1.Properties.ShowTitle = True
        Me.PGB1.Properties.Step = 1
        Me.PGB1.Properties.TextOrientation = DevExpress.Utils.Drawing.TextOrientation.Horizontal
        Me.PGB1.Size = New System.Drawing.Size(287, 43)
        Me.PGB1.TabIndex = 29
        '
        'frmImport1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1127, 637)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "frmImport1"
        Me.Text = "frmImport1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.PGB1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents DGV As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PGB1 As DevExpress.XtraEditors.ProgressBarControl
End Class

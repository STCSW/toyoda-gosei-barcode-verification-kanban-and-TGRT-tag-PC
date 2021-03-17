Imports System.Data.SqlClient
Imports System.Text

Public Class frmMainMenu

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmMainMenu_METRO_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try

            Dim strprompt As String = "Do you want to exit software"

            If MsgBox(strprompt, MsgBoxStyle.Question + MsgBoxStyle.YesNo) =
                MsgBoxResult.No Then
                e.Cancel = True

            Else


                frmLogin.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub


   

    Private Sub tiBackup_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        Try
            Dim Filename As String
            Dim dt As DateTime = Today
            Dim destdir As String = My.Settings.Database & System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") & ".bak"
            Dim objdlg As New SaveFileDialog
            objdlg.FileName = destdir
            objdlg.ShowDialog()
            Filename = objdlg.FileName
            Cursor = Cursors.WaitCursor

            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "backup database " & My.Settings.Database & " to disk='" & Filename & "'with init,stats=10"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   

    Private Sub TileItem10_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiBackUp.ItemClick
        Try
            Dim Filename As String
            Dim dt As DateTime = Today
            Dim destdir As String = My.Settings.Database & System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") & ".bak"
            Dim objdlg As New SaveFileDialog
            objdlg.FileName = destdir
            objdlg.ShowDialog()
            Filename = objdlg.FileName
            Cursor = Cursors.WaitCursor

            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "backup database " & My.Settings.Database & " to disk='" & Filename & "'with init,stats=10"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub Open_PrintProductionControl()

    '    Dim frm As New frmPrintProductionControl()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub tiPlanFront_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiPD.ItemClick
    '    Call Open_PrintProductionControl()
    'End Sub

    'Private Sub tiPlanREAR_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiPD_Reprint.ItemClick
    '    Dim frm As New frmPrintProductionControl_reprint()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiFinalSerial.ItemClick


    '    Dim frm As New frmPrintFinalSerialProduct()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem3_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiBattery.ItemClick


    '    Dim frm As New frmPrintBattery()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem4_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiBattery_Reprint.ItemClick

    '    Dim frm As New frmPrintBattery_Reprint()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()

    'End Sub

    'Private Sub TileItem7_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiHistoryBattery.ItemClick
    '    Dim frm As New frmHistoryBattery()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem8_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiHistoryBattery_Reprint.ItemClick

    '    Dim frm As New frmHistoryBattery_REPRINT()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    Private Sub tiUserManagement_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiUserManagement.ItemClick
        Dim frm As New frmUser()
        'frm.topmost = true
        frm.WindowState = FormWindowState.Maximized
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
    End Sub

    'Private Sub TileItem9_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiPacking_LabelF.ItemClick
    '    Dim frm As New frmPacking_Label_F()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiFinalSerial_Reprint.ItemClick

    '    Dim frm As New frmPrintFinalSerialProduct_reprint()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem12_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiHistoryPD.ItemClick

    '    Dim frm As New frmHistoryPD()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem11_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiHistoryPD_Reprint.ItemClick


    '    Dim frm As New frmHistoryPD_REPRINT()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem13_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiHistoryFinalSerial.ItemClick


    '    Dim frm As New frmHistoryFinalSerial()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem14_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiHistoryFinalSerial_Reprint.ItemClick

    '    Dim frm As New frmHistoryFinalSerial_REPRINT()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem5_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiPacking_LabelDsub.ItemClick
    '    Dim frm As New frmPacking_Label_D_SUB()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem6_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiPacking_LabelDMaster.ItemClick
    '    Dim frm As New frmPacking_Label_D_Master()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem21_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiPacking_LabelF_Reprint.ItemClick
    '    Dim frm As New frmPacking_Label_F_Reprint()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem22_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiPacking_LabelDsub_Reprint.ItemClick
    '    Dim frm As New frmPacking_Label_D_SUB_Reprint()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    'End Sub

    'Private Sub TileItem15_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiHistoryLabelF.ItemClick

    '    Dim frm As New frmHistoryLabelF()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    ''Private Sub TileItem16_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem16.ItemClick
    ''    Dim frm As New frmHistoryLabelF()
    ''    'frm.topmost = true
    ''    frm.WindowState = FormWindowState.Maximized
    ''    frm.StartPosition = FormStartPosition.CenterScreen
    ''    frm.ShowDialog()
    ''End Sub

    'Private Sub TileItem17_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiHistoryLabelDsub.ItemClick

    '    Dim frm As New frmHistoryLabelDsub()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem19_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiHistoryLabelDMaster.ItemClick

    '    Dim frm As New frmHistoryLabelDmaster()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem16_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiHistoryLabelF_Reprint.ItemClick

    '    Dim frm As New frmHistoryLabelF_REPRINT()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem18_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiHistoryLabelDsub_Reprint.ItemClick

    '    Dim frm As New frmHistoryLabelDsub_REPRINT()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem20_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiHistoryLabelDMaster_Reprint.ItemClick

    '    Dim frm As New frmHistoryLabelDmaster_REPRINT()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    'Private Sub TileItem23_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiPacking_LabelDMaster_Reprint.ItemClick


    '    Dim frm As New frmPacking_Label_D_Master_REPRINT()
    '    'frm.topmost = true
    '    frm.WindowState = FormWindowState.Maximized
    '    frm.StartPosition = FormStartPosition.CenterScreen
    '    frm.ShowDialog()
    'End Sub

    Private Sub frmMainMenu_BT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Permission()
    End Sub

    Private Sub Permission()


        Try
            Dim StrSQL As New StringBuilder()
            Dim dt As New DataTable
            StrSQL.Remove(0, StrSQL.Length)
            StrSQL.Append("select *")

            StrSQL.Append(" from [tb_User]")

            StrSQL.Append(" where [UserID] = '" & C_Variable.USER_LOGIN & "'")
            DT = SQLConnect._SQL.Read(StrSQL.ToString)

            C_Variable.USER_Type = DT.Rows(0).Item("UserType")

            StrSQL.Remove(0, StrSQL.Length)
            StrSQL.Append(" SELECT *")

            StrSQL.Append(" FROM [Tbl_USETYP]")
            StrSQL.Append(" where [TYPE_NAME] = '" & DT.Rows(0).Item("UserType") & "'")

            DT = SQLConnect._SQL.Read(StrSQL.ToString)

            For i = 1 To DT.Columns.Count - 1

                Select Case DT.Columns(i).ColumnName
                    Case "F_Admin"
                        If DT.Rows(0).Item(i).ToString = "1" Then
                            C_Variable.Permission_Admin = True
                        Else
                            C_Variable.Permission_Admin = False
                        End If
                    Case "Packing_Label_D_Master"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiPacking_LabelDMaster.Enabled = True
                        Else
                            tiPacking_LabelDMaster.Enabled = False
                        End If
                    Case "Packing_Label_D_Master_REPRINT"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiPacking_LabelDMaster_Reprint.Enabled = True
                        Else
                            tiPacking_LabelDMaster_Reprint.Enabled = False
                        End If
                    Case "Packing_Label_D_SUB"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiPacking_LabelDsub.Enabled = True
                        Else
                            tiPacking_LabelDsub.Enabled = False
                        End If
                    Case "Packing_Label_D_SUB_Reprint"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiPacking_LabelDsub_Reprint.Enabled = True
                        Else
                            tiPacking_LabelDsub_Reprint.Enabled = False
                        End If
                    Case "Packing_Label_F"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiPacking_LabelF.Enabled = True
                        Else
                            tiPacking_LabelF.Enabled = False
                        End If
                    Case "Packing_Label_F_Reprint"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiPacking_LabelF_Reprint.Enabled = True
                        Else
                            tiPacking_LabelF_Reprint.Enabled = False
                        End If
                        'Case "PrintBattery"
                        '    If dt.Rows(0).Item(i).ToString = "1" Then
                        '        tiBattery.Enabled = True
                        '    Else
                        '        tiBattery.Enabled = False
                        '    End If

                        'Case "PrintBattery_Reprint"
                        '    If dt.Rows(0).Item(i).ToString = "1" Then
                        '        tiBattery_Reprint.Enabled = True
                        '    Else
                        '        tiBattery_Reprint.Enabled = False
                        '    End If
                        'Case "PrintFinalSerialProduct"
                        '    If dt.Rows(0).Item(i).ToString = "1" Then
                        '        tiFinalSerial.Enabled = True
                        '    Else
                        '        tiFinalSerial.Enabled = False
                        '    End If
                        'Case "PrintFinalSerialProduct_reprint"
                        '    If dt.Rows(0).Item(i).ToString = "1" Then
                        '        tiFinalSerial_Reprint.Enabled = True
                        '    Else
                        '        tiFinalSerial_Reprint.Enabled = False
                        '    End If
                        'Case "PrintProductionControl"
                        '    If dt.Rows(0).Item(i).ToString = "1" Then
                        '        tiPD.Enabled = True
                        '    Else
                        '        tiPD.Enabled = False
                        '    End If
                        'Case "PrintProductionControl_reprint"
                        '    If dt.Rows(0).Item(i).ToString = "1" Then
                        '        tiPD_Reprint.Enabled = True
                        '    Else
                        '        tiPD_Reprint.Enabled = False
                        '    End If
                    Case "User_Management"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiUserManagement.Enabled = True
                        Else
                            tiUserManagement.Enabled = False
                        End If
                    Case "HistoryFinalSerial"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiHistoryFinalSerial.Enabled = True
                        Else
                            tiHistoryFinalSerial.Enabled = False
                        End If
                    Case "HistoryFinalSerial_REPRINT"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiHistoryFinalSerial_Reprint.Enabled = True
                        Else
                            tiHistoryFinalSerial_Reprint.Enabled = False
                        End If
                    Case "HistoryLabelDmaster"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiHistoryLabelDMaster.Enabled = True
                        Else
                            tiHistoryLabelDMaster.Enabled = False
                        End If
                    Case "HistoryLabelDmaster_REPRINT"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiHistoryLabelDMaster_Reprint.Enabled = True
                        Else
                            tiHistoryLabelDMaster_Reprint.Enabled = False
                        End If
                    Case "HistoryLabelDsub"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiHistoryLabelDsub.Enabled = True
                        Else
                            tiHistoryLabelDsub.Enabled = False
                        End If
                    Case "HistoryLabelDsub_REPRINT"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiHistoryLabelDsub_Reprint.Enabled = True
                        Else
                            tiHistoryLabelDsub_Reprint.Enabled = False
                        End If
                    Case "HistoryLabelF"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiHistoryLabelF.Enabled = True
                        Else
                            tiHistoryLabelF.Enabled = False
                        End If
                    Case "HistoryLabelF_REPRINT"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiHistoryLabelF_Reprint.Enabled = True
                        Else
                            tiHistoryLabelF_Reprint.Enabled = False
                        End If
                    Case "HistoryPD"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiHistoryPD.Enabled = True
                        Else
                            tiHistoryPD.Enabled = False
                        End If
                    Case "HistoryPD_REPRINT"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiHistoryPD_Reprint.Enabled = True
                        Else
                            tiHistoryPD_Reprint.Enabled = False
                        End If
                    Case "HistoryBattery"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiHistoryBattery.Enabled = True
                        Else
                            tiHistoryBattery.Enabled = False
                        End If
                    Case "HistoryBattery_REPRINT"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiHistoryBattery_Reprint.Enabled = True
                        Else
                            tiHistoryBattery_Reprint.Enabled = False
                        End If

                    Case "BACKUP_DB"
                        If dt.Rows(0).Item(i).ToString = "1" Then
                            tiBackUp.Enabled = True
                        Else
                            tiBackUp.Enabled = False
                        End If

                        '   User()

                End Select


            Next i





        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tiMaster_MC_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiMaster_MC.ItemClick
        Dim frm As New frmMaster_MC()
        'frm.topmost = true
        frm.WindowState = FormWindowState.Maximized
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
    End Sub

    Private Sub TileItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tiMaster_Product.ItemClick
        Dim frm As New frmMaster_Product()
        'frm.topmost = true
        frm.WindowState = FormWindowState.Maximized
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.ShowDialog()
    End Sub


End Class

Imports System.Data.SqlClient
Imports System.Text

Public Class frmMainribbon

    Public Sub OpenForm(ByVal typeform As Type)
        For Each frm As Form In MdiChildren
            If frm.GetType() = typeform Then
                frm.Activate()
                frm.Refresh()


                Return
            End If
        Next
        Dim f As Form = DirectCast(Activator.CreateInstance(typeform), Form)
        f.MdiParent = Me
        f.Show()
        f.Focus()
    End Sub

    Private Sub rbUserManagement_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rbUserManagement.ItemClick
        'Try

        '    frmUser.Owner = Me
        '    frmUser.MdiParent = Me
        '    frmUser.WindowState = FormWindowState.Maximized
        '    frmUser.StartPosition = FormStartPosition.CenterScreen
        '    frmUser.Show()
        'Catch ex As Exception

        'End Try
        'frmUser.Focus()
        ''Me.Refresh()



        'Try

        '    frm_User_Master.Owner = Me
        '    frm_User_Master.MdiParent = Me
        '    frm_User_Master.Show()

        'Catch ex As Exception

        'End Try
        'frm_User_Master.Focus()
        ''Me.Refresh()

        OpenForm(GetType(frm_User_Master))
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rbMasterProduct.ItemClick
        'Try
        '    frmMaster_Product.Owner = Me
        '    frmMaster_Product.MdiParent = Me
        '    frmMaster_Product.WindowState = FormWindowState.Maximized
        '    frmMaster_Product.StartPosition = FormStartPosition.CenterScreen
        '    frmMaster_Product.Show()
        'Catch ex As Exception

        'End Try
        'frmMaster_Product.Focus()
        ''Me.Refresh()

        OpenForm(GetType(frmMaster_Product))

    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rbBarcode_Verify.ItemClick

        'Try
        '    frmMaster_MC.Owner = Me
        '    frmMaster_MC.MdiParent = Me
        '    frmMaster_MC.WindowState = FormWindowState.Maximized
        '    frmMaster_MC.StartPosition = FormStartPosition.CenterScreen
        '    frmMaster_MC.Show()
        'Catch ex As Exception

        'End Try
        'frmMaster_MC.Focus()
        ''Me.Refresh()

        OpenForm(GetType(frmBarcodeVerification))
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick


        'Try
        '    frmPrintSticker.Owner = Me
        '    frmPrintSticker.MdiParent = Me
        '    frmPrintSticker.WindowState = FormWindowState.Maximized
        '    frmPrintSticker.StartPosition = FormStartPosition.CenterScreen
        '    frmPrintSticker.Show()
        'Catch ex As Exception

        'End Try
        'frmPrintSticker.Focus()
        ''Me.Refresh()


    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick



        'Try
        '    frmGenerateSticker.Owner = Me
        '    frmGenerateSticker.MdiParent = Me
        '    frmGenerateSticker.WindowState = FormWindowState.Maximized
        '    frmGenerateSticker.StartPosition = FormStartPosition.CenterScreen
        '    frmGenerateSticker.Show()
        'Catch ex As Exception

        'End Try
        'frmGenerateSticker.Focus()
        ''Me.Refresh()

    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Try
            Dim frm As New frmDesign_Format

            frm.WindowState = FormWindowState.Maximized
            frm.StartPosition = FormStartPosition.CenterScreen
            frm.ShowDialog()
            '  frm.Focus()
        Catch ex As Exception

        End Try



    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rbImportProduct.ItemClick



        'Try
        '    frmImport1.Owner = Me
        '    frmImport1.MdiParent = Me
        '    frmImport1.WindowState = FormWindowState.Maximized
        '    frmImport1.StartPosition = FormStartPosition.CenterScreen
        '    frmImport1.Show()
        'Catch ex As Exception

        'End Try
        'frmImport1.Focus()
        ''Me.Refresh()
        OpenForm(GetType(frmImport1))

    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rbLabel_Printing.ItemClick

        'Try
        '    frmProductionPlan.Owner = Me
        '    frmProductionPlan.MdiParent = Me
        '    frmProductionPlan.WindowState = FormWindowState.Maximized
        '    frmProductionPlan.StartPosition = FormStartPosition.CenterScreen
        '    frmProductionPlan.Show()

        'Catch ex As Exception

        'End Try
        'frmProductionPlan.Focus()
        ''Me.Refresh()

        OpenForm(GetType(frmPrintLabel))


    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rbBackup.ItemClick
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

    Private Sub frmMainribbon_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try

            Dim strprompt As String = "Do you want to exit software"

            If MsgBox(strprompt, MsgBoxStyle.Question + MsgBoxStyle.YesNo) =
                MsgBoxResult.No Then
                e.Cancel = True

            Else
                '   Timer1.Enabled = False

                '===== NUT
                '   bgwork = False
                '   bwAutoprint.CancelAsync()
                '===== NUT

                frmLogin.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub frmMainribbon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bsServer.Caption = My.Settings.Server
        bsUSER.Caption = C_Variable.USER_LOGIN
        bsPermission.Caption = C_Variable.USER_Type
        bsDate.Caption = GetDate_now("dd-MMM-yyyy")

        txtVersion.Caption = C_VERSION.GetVersionSoftware()

        Call Permission()
    End Sub


    Private Sub Permission()


        Try
            Dim StrSQL As New StringBuilder()
            Dim dt As New DataTable
            StrSQL.Remove(0, StrSQL.Length)
            StrSQL.Append("select *")

            StrSQL.Append(" from [tbUser]")

            StrSQL.Append(" where [UserID] = '" & C_Variable.USER_LOGIN & "'")
            ' dt = SQLConnect._SQL.Read(StrSQL.ToString)
            'dt = DatabaseConnection.SQLConnect.SQL.Read(StrSQL.ToString, cs, False)
            dt = DatabaseConnection.OleDBConnect.Access.Read(StrSQL.ToString, css, False)

            C_Variable.USER_Type = dt.Rows(0).Item("UserType")

            StrSQL.Remove(0, StrSQL.Length)
            StrSQL.Append(" SELECT *")

            StrSQL.Append(" FROM [Tbl_USETYP]")
            StrSQL.Append(" where [TYPE_NAME] = '" & dt.Rows(0).Item("UserType") & "'")

            'dt = DatabaseConnection.SQLConnect.SQL.Read(StrSQL.ToString, cs, False)
            dt = DatabaseConnection.OleDBConnect.Access.Read(StrSQL.ToString, css, False)

            For i = 1 To dt.Columns.Count - 1
                Try

                    Select Case dt.Columns(i).ColumnName
                        Case "F_Admin"
                            If dt.Rows(0).Item(i).ToString = "1" Then
                                C_Variable.Permission_Admin = True
                                '   RibbonPageGroup9.Enabled = True
                                ' rbTraceability_Shipment.Enabled = True
                            Else
                                C_Variable.Permission_Admin = False
                                '    RibbonPageGroup9.Enabled = False
                                '   rbTraceability_Shipment.Enabled = False
                            End If

                        Case "User_Management"
                            If dt.Rows(0).Item(i).ToString = "1" Then
                                rbUserManagement.Enabled = True
                            Else
                                rbUserManagement.Enabled = False
                            End If

                        Case "Master_Product"
                            If dt.Rows(0).Item(i).ToString = "1" Then
                                rbMasterProd.Enabled = True
                            Else
                                rbMasterProd.Enabled = False
                            End If
                        Case "Import_Product"
                            If dt.Rows(0).Item(i).ToString = "1" Then
                                rbImportProduct.Enabled = True
                            Else
                                rbImportProduct.Enabled = False
                            End If

                        Case "Label_Printing"
                            If dt.Rows(0).Item(i).ToString = "1" Then
                                rbLabel_Printing.Enabled = True
                            Else
                                rbLabel_Printing.Enabled = False
                            End If
                        Case "Report_Printing"
                            If dt.Rows(0).Item(i).ToString = "1" Then
                                rbLabel_Printing_Report.Enabled = True
                            Else
                                rbLabel_Printing_Report.Enabled = False
                            End If

                        Case "Barcode_Verify"
                            If dt.Rows(0).Item(i).ToString = "1" Then
                                rbBarcode_Verify.Enabled = True
                            Else
                                rbBarcode_Verify.Enabled = False
                            End If
                        Case "Report_Barcode_Verify"
                            If dt.Rows(0).Item(i).ToString = "1" Then
                                rbBarcode_Verify_Report.Enabled = True
                            Else
                                rbBarcode_Verify_Report.Enabled = False
                            End If



                        Case "BACKUP_DB"
                            If dt.Rows(0).Item(i).ToString = "1" Then
                                rbBackup.Enabled = True
                            Else
                                rbBackup.Enabled = False
                            End If
                    End Select

                Catch ex As Exception

                End Try

            Next i





        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rbTraceability_In.ItemClick
        'Try
        '    frmTraceability_In.Owner = Me
        '    frmTraceability_In.MdiParent = Me
        '    frmTraceability_In.WindowState = FormWindowState.Maximized
        '    frmTraceability_In.StartPosition = FormStartPosition.CenterScreen
        '    frmTraceability_In.Show()
        'Catch ex As Exception

        'End Try
        'frmTraceability_In.Focus()
        'frmTraceability_In.txtQRcode.Focus()
        ''Me.Refresh()



    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rbTraceability_Receive.ItemClick
        'Try
        '    frmTraceability_RC_WH.Owner = Me
        '    frmTraceability_RC_WH.MdiParent = Me
        '    frmTraceability_RC_WH.WindowState = FormWindowState.Maximized
        '    frmTraceability_RC_WH.StartPosition = FormStartPosition.CenterScreen
        '    frmTraceability_RC_WH.Show()
        'Catch ex As Exception

        'End Try
        'frmTraceability_RC_WH.Focus()
        'frmTraceability_RC_WH.txtQRcode.Focus()



        'Me.Refresh()
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick

        'Try
        '    frmMRP_WRL.Owner = Me
        '    frmMRP_WRL.MdiParent = Me
        '    frmMRP_WRL.WindowState = FormWindowState.Maximized
        '    frmMRP_WRL.StartPosition = FormStartPosition.CenterScreen
        '    frmMRP_WRL.Show()
        'Catch ex As Exception

        'End Try
        'frmMRP_WRL.Focus()

        'Me.Refresh()
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick

        'Try
        '    XtraForm1.Owner = Me
        '    XtraForm1.MdiParent = Me
        '    XtraForm1.WindowState = FormWindowState.Maximized
        '    XtraForm1.StartPosition = FormStartPosition.CenterScreen
        '    XtraForm1.Show()
        'Catch ex As Exception

        'End Try
        'XtraForm1.Focus()
        OpenForm(GetType(XtraForm1))

    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rbRepack_Product.ItemClick
        'Try
        '    frmRepack_sticker.Owner = Me
        '    frmRepack_sticker.MdiParent = Me
        '    frmRepack_sticker.WindowState = FormWindowState.Maximized
        '    frmRepack_sticker.StartPosition = FormStartPosition.CenterScreen
        '    frmRepack_sticker.Show()
        'Catch ex As Exception

        'End Try
        'frmRepack_sticker.Focus()
        'frmRepack_sticker.txtQRcode.Focus()
        ''Me.Refresh()


    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rbLabel_Printing_Report.ItemClick

        'Try
        '    frmReport.Owner = Me
        '    frmReport.MdiParent = Me
        '    frmReport.WindowState = FormWindowState.Maximized
        '    frmReport.StartPosition = FormStartPosition.CenterScreen
        '    frmReport.Show()

        'Catch ex As Exception

        'End Try
        'frmReport.Focus()
        ''Me.Refresh()

        OpenForm(GetType(frmReport_PrintLabel))

    End Sub



    Private Sub rbTraceability_Shipment_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rbTraceability_Shipment.ItemClick

    End Sub

    Private Sub BarButtonItem1_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rbBarcode_Verify_Report.ItemClick

        OpenForm(GetType(frmReport_BarcodeVerification))

    End Sub


    Private Sub BarButtonItem7_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Try
            Dim Filename As String
            Dim dt As DateTime = Today
            Dim destdir As String = My.Settings.Database_MRP & System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") & ".bak"
            Dim objdlg As New SaveFileDialog
            objdlg.FileName = destdir
            objdlg.ShowDialog()
            Filename = objdlg.FileName
            Cursor = Cursors.WaitCursor

            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "backup database " & My.Settings.Database_MRP & " to disk='" & Filename & "'with init,stats=10"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
           
            Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        Dim zITEM_CD As String = "880545-"
        Dim zLOC_CD As String = "FGWH"
        Dim zLOT_NO As String = "PL2019013"
        Dim zTRANS_DATE As String = "2019-04-02 00:00:00.000"
        Dim zQTY As Integer = 235
        Dim zREF_SLIP_NO As String = "1999999999"
        Dim zREMARK As String = "NEXTINNOVATION SYSTEM " & (Now).ToString("MMddhhmmss")
        Dim zFOR_MACHINE As String = "NEXT"
        Dim zSHIFT_CLS As String = "A"
        Dim zBY_MACHINE As String = C_Variable.var_MACHINE
        Dim zBY_USER As String = C_Variable.USER_LOGIN

        'Dim data() As String
        'Dim data2() As String
        'data = cmbShift.Text.Split(":")
        'data2 = cmbStoredLoc.Text.Split(":")
        'zSHIFT_CLS = data(0)
        'zLOC_CD = data2(0)

        Sent_RCV_TO_MRP(zITEM_CD, "FGWH", zLOT_NO, Now().ToString("yyyy-MM-dd 00:00:00"), zQTY, zREF_SLIP_NO, zREMARK, "", "", "", C_Variable.USER_LOGIN)

        '   Sent_RCV_TO_MRP(zITEM_CD, zLOC_CD, zLOT_NO, zTRANS_DATE, zQTY, zREF_SLIP_NO, zREMARK, zFOR_MACHINE, zSHIFT_CLS, zBY_MACHINE, zBY_USER) = False Then

    End Sub

    Private Sub BarButtonItem8_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles rbMasterProd.ItemClick
        OpenForm(GetType(frmMaster_Product))

    End Sub

    'Private Function Sent_RCV_TO_MRP(ByVal zITEM_CD As String, ByVal zLOC_CD As String, ByVal zLOT_NO As String, ByVal zTRANS_DATE As String _
    '                                , ByVal zQTY As String, ByVal zREF_SLIP_NO As String, ByVal zREMARK As String, ByVal zFOR_MACHINE As String _
    '                                , ByVal zSHIFT_CLS As String, ByVal zBY_MACHINE As String, ByVal zBY_USER As String) As Boolean
    '    Dim query_parameters(10) As SqlParameter
    '    query_parameters(0) = New SqlParameter("@ITEM_CD", SqlDbType.NVarChar)
    '    query_parameters(0).Value = zITEM_CD
    '    query_parameters(1) = New SqlParameter("@LOC_CD", SqlDbType.NVarChar)
    '    query_parameters(1).Value = zLOC_CD
    '    query_parameters(2) = New SqlParameter("@LOT_NO", SqlDbType.NVarChar)
    '    query_parameters(2).Value = zLOT_NO
    '    query_parameters(3) = New SqlParameter("@TRANS_DATE", SqlDbType.NVarChar)
    '    query_parameters(3).Value = zTRANS_DATE
    '    query_parameters(4) = New SqlParameter("@QTY", SqlDbType.NVarChar)
    '    query_parameters(4).Value = zQTY
    '    query_parameters(5) = New SqlParameter("@REF_SLIP_NO", SqlDbType.NVarChar)
    '    query_parameters(5).Value = zREF_SLIP_NO
    '    query_parameters(6) = New SqlParameter("@REMARK", SqlDbType.NVarChar)
    '    query_parameters(6).Value = zREMARK
    '    query_parameters(7) = New SqlParameter("@FOR_MACHINE", SqlDbType.NVarChar)
    '    query_parameters(7).Value = zFOR_MACHINE
    '    query_parameters(8) = New SqlParameter("@SHIFT_CLS", SqlDbType.NVarChar)
    '    query_parameters(8).Value = zSHIFT_CLS


    '    '  query_parameters(8).Value = "A"
    '    'query_parameters(9) = New SqlParameter("@BY_MACHINE", SqlDbType.NVarChar)
    '    'query_parameters(9).Value = zBY_MACHINE
    '    'query_parameters(10) = New SqlParameter("@BY_USER", SqlDbType.NVarChar)
    '    'query_parameters(10).Value = zBY_USER

    '    '  Dim tmp_dt As New DataTable
    '    ' tmp_dt()
    '    Return DatabaseConnection.SQLConnect.SQL.ExecuteSP("spb_RCV_to_MRP", cs_MRP, query_parameters, True)

    '    'If tmp_dt Is Nothing Then
    '    '    Return False
    '    'Else
    '    '    ' tmp_dt.Rows(0).Item(0) = "tmp_dt"
    '    '    Return True
    '    'End If


    'End Function
End Class
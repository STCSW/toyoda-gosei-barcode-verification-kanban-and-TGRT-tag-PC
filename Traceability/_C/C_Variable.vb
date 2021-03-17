Public Class C_Variable
    
  



    Public Shared IS_LOGIN_ADMIN As Boolean = False
    Public Shared USER_ID As String = String.Empty
    Public Shared USER_LOGIN As String = String.Empty
    Public Shared USER_Name As String = String.Empty

    Public Shared USER_Type As String = String.Empty
    Public Shared Permission_Admin As Boolean = False
    Public Shared Line_Operattion As String = String.Empty

    Public Shared PASSWORD_LOCK_SCREEN As String = "Admin"

    Public Shared TIMER_REFRESH_MSEC As Integer = 30000
    Public Shared FLAG_SHOW_COUNT_REFRESH As Boolean = False
    Public Shared QrCode As String = String.Empty

    'DIFF_CASE,'FRONT_DHL_CARRIER,'FRONT_DHL_GEAR,'FRONT_DHL_HYB,
    'REAR_DHL_CARRIER,'REAR_DHL_GEAR,'REAR_DHL_HYB
    'Public Shared _label_path_PRODUCTION As String = Application.StartupPath & "\label\PRODUCTION.lbl"
  
    Public Shared _label_path_PRODUCTION_PLAN As String = Application.StartupPath & "\label\Planning_SHEET1.repx"
    Public Shared _label_path_STICKER_SERIAL As String = Application.StartupPath & "\label\Serial_Sticker.repx"
    Public Shared _label_path_SHIPMENT_PLAN As String = Application.StartupPath & "\label\Shipment_SHEET.repx"
    Public Shared _label_path_SHIPMENT_DETAIL_PLAN As String = Application.StartupPath & "\label\Shipment_DETAIL_SHEET.repx"
    Public Shared _label_path_Label As String = Application.StartupPath & "\label\Label.nlbl"



    Public Shared ReadOnly _file_path_setting_DB As String = Application.StartupPath & "\AllSetting_ini\setting_DB.txt"
    Public Shared ReadOnly _file_path_setting_Folder_Picture1 As String = Application.StartupPath & "\AllSetting_ini\Folder_Picture1.txt"
    Public Shared ReadOnly _file_path_setting_Folder_Picture1_Zoom As String = Application.StartupPath & "\AllSetting_ini\Folder_Picture1_Zoom.txt"

    Public Shared ReadOnly _file_path_setting_Folder_Picture2 As String = Application.StartupPath & "\AllSetting_ini\Folder_Picture2.txt"
    Public Shared ReadOnly _file_path_setting_Folder_Picture2_Zoom As String = Application.StartupPath & "\AllSetting_ini\Folder_Picture2_Zoom.txt"

    Public Shared ReadOnly _file_path_setting_Count_CutDigit As String = Application.StartupPath & "\AllSetting_ini\Count_CutDigit.txt"


    Public Shared ReadOnly _file_path_setting_DB_MRP As String = Application.StartupPath & "\AllSetting_ini\setting_DB_MRP.txt"
    Public Shared var_Status_Printer As String
    Public Shared var_MACHINE As String = "COMPUTER_USER"


   



    Public Property VarQrCode() As String
        Get
            Return QrCode
        End Get
        Set(ByVal value As String)
            QrCode = value
        End Set
    End Property
End Class


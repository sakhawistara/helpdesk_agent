Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Public Class user_sett
    Inherits System.Web.UI.Page

    Dim a As String = "satu"
    Dim strArray
    Dim strArr
    Dim strTrustee
    Dim strCheckBox As String = ""
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
    Dim com As SqlCommand
    Dim sqlDr As SqlDataReader
    Dim countuserlevel As String
    Dim CIF, Simpanan, Pinjaman_Kredit As String
    Dim insertdata, sql, str As String
    Dim Proses As New ClsConn
    Dim VTicket, VTwitter, VFacebook, VEmail, VFax, Vchat, VSms As String
    Dim TWT, TKY, FCB, FKY, EMA, FAX, CHA, SMS As String
    Dim MT, MT_STY, MT_GTY, MT_TTY, MT_CON, MT_CTW, MT_CTR, MT_STS, MT_DKY, MT_EAL, MT_EAD As String
    Dim DS, CH, CH_TWT, CH_TKS, CH_FCB, CH_FKS, CH_EMA, CH_SMS, CH_FAX, CH_CHA As String
    Dim TIK, TK_CRT, TK_THS, UM, UM_ADS, UM_SUP As String
    Dim RP, CT, GF, KB As String
    Dim strArrUp As String()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sql_muser_trustee.SelectCommand = "select * from menuMaster"
        sql_user.SelectCommand = "select * from MTrustee"
        sql_level_user.SelectCommand = "select DISTINCT(LEVEL_USER) as Name from MTrustee"
        sql_user_level.SelectCommand = "select * from msLevelUser"
        Btn_Add.Visible = True
        Btn_Save.Visible = False
        Btn_Update.Visible = False
        Btn_Cancel.Visible = False
        gridLevelUser.Visible = True
        div_new.Visible = False
    End Sub

    Protected Sub callbackPanelX_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles callbackPanelX.Callback
        Dim CH_TWT, CH_TKY, CH_FCB, CH_FKY, CH_EMA, CH_FAX, CH_CHA, CH_SMS As String
        Dim smastertrustee As String = ""
        sql = "select * from mApplikasi"
        sqlDr = Proses.ExecuteReader(sql)
        If sqlDr.Read Then
            VTicket = sqlDr("Ticket").ToString
            VTwitter = sqlDr("Twitter").ToString
            VFacebook = sqlDr("Facebook").ToString
            VEmail = sqlDr("Email").ToString
            VFax = sqlDr("Fax").ToString
            Vchat = sqlDr("Chat").ToString
            VSms = sqlDr("Sms").ToString
        End If
        sqlDr.Close()
        smastertrustee = "select * from MTrustee where TrusteeID='" & txtGroupID.Value & "'"
        com = New SqlCommand(smastertrustee, con)
        con.Open()
        sqlDr = com.ExecuteReader()
        If sqlDr.Read() Then
            If VTicket = "Yes" Then
                strCheckBox += "" & sqlDr("MT") & ";"
                strCheckBox += "" & sqlDr("MT_STY") & ";"
                strCheckBox += "" & sqlDr("MT_GTY") & ";"
                strCheckBox += "" & sqlDr("MT_TTY") & ";"
                strCheckBox += "" & sqlDr("MT_CON") & ";"
                strCheckBox += "" & sqlDr("MT_CTW") & ";"
                strCheckBox += "" & sqlDr("MT_CTR") & ";"
                strCheckBox += "" & sqlDr("MT_STS") & ";"
                strCheckBox += "" & sqlDr("MT_DKY") & ";"
                strCheckBox += "" & sqlDr("MT_EAL") & ";"
                strCheckBox += "" & sqlDr("MT_EAD") & ";"
                strCheckBox += "" & sqlDr("DS") & ";"
                strCheckBox += "" & sqlDr("CH") & ";"
                If VEmail = "Yes" Then
                    strCheckBox += "" & sqlDr("CH_EMA") & ";"
                Else
                End If
                If VTwitter = "Yes" Then
                    strCheckBox += "" & sqlDr("CH_TWT") & ";"
                    strCheckBox += "" & sqlDr("CH_TKS") & ";"
                Else
                End If
                If VFacebook = "Yes" Then
                    strCheckBox += "" & sqlDr("CH_FCB") & ";"
                    strCheckBox += "" & sqlDr("CH_FKS") & ";"
                Else
                End If
                If VFax = "Yes" Then
                    strCheckBox += "" & sqlDr("CH_FAX") & ";"
                Else
                End If
                If VSms = "Yes" Then
                    strCheckBox += "" & sqlDr("CH_SMS") & ";"
                Else
                End If
                If Vchat = "Yes" Then
                    strCheckBox += "" & sqlDr("CH_CHA") & ";"
                Else
                End If
                strCheckBox += "" & sqlDr("TIK") & ";"
                strCheckBox += "" & sqlDr("TK_CRT") & ";"
                strCheckBox += "" & sqlDr("TK_THS") & ";"
                strCheckBox += "" & sqlDr("UM") & ";"
                strCheckBox += "" & sqlDr("UM_ADS") & ";"
                strCheckBox += "" & sqlDr("UM_SUP") & ";"
                strCheckBox += "" & sqlDr("RP") & ";"
                strCheckBox += "" & sqlDr("CT") & ";"
                strCheckBox += "" & sqlDr("GF") & ";"
                strCheckBox += "" & sqlDr("KB") & ";"

                strArr = strCheckBox.Split(";")
                For i = 0 To checkBoxList.Items.Count - 1
                    checkBoxList.Items(i).Selected = False
                    For count = 0 To strArr.Length - 1
                        If strArr(i) = "TRUE" Then
                            checkBoxList.Items(i).Selected = True
                        Else
                            checkBoxList.Items(i).Selected = False
                        End If
                        'MsgBox(strArr(count), vbSystemModal)
                    Next
                Next

            Else

                strCheckBox += "" & sqlDr("MT") & ";"
                strCheckBox += "" & sqlDr("MT_STY") & ";"
                strCheckBox += "" & sqlDr("MT_GTY") & ";"
                strCheckBox += "" & sqlDr("MT_TTY") & ";"
                strCheckBox += "" & sqlDr("MT_STS") & ";"
                strCheckBox += "" & sqlDr("MT_DKY") & ";"
                strCheckBox += "" & sqlDr("DS") & ";"
                strCheckBox += "" & sqlDr("CH") & ";"
                If VEmail = "Yes" Then
                    strCheckBox += "" & sqlDr("CH_EMA") & ";"
                Else
                End If
                If VTwitter = "Yes" Then
                    strCheckBox += "" & sqlDr("CH_TWT") & ";"
                    strCheckBox += "" & sqlDr("CH_TKS") & ";"
                Else
                End If
                If VFacebook = "Yes" Then
                    strCheckBox += "" & sqlDr("CH_FCB") & ";"
                    strCheckBox += "" & sqlDr("CH_FKS") & ";"
                Else
                End If
                If VFax = "Yes" Then
                    strCheckBox += "" & sqlDr("CH_FAX") & ";"
                Else
                End If
                If VSms = "Yes" Then
                    strCheckBox += "" & sqlDr("CH_SMS") & ";"
                Else
                End If
                If Vchat = "Yes" Then
                    strCheckBox += "" & sqlDr("CH_CHA") & ";"
                Else
                End If
                strCheckBox += "" & sqlDr("UM") & ";"
                strCheckBox += "" & sqlDr("UM_ADS") & ";"
                strCheckBox += "" & sqlDr("UM_SUP") & ";"
                strCheckBox += "" & sqlDr("RP") & ";"
                strCheckBox += "" & sqlDr("CT") & ";"
                strCheckBox += "" & sqlDr("GF") & ";"
                strCheckBox += "" & sqlDr("KB") & ";"

                strArr = strCheckBox.Split(";")
                For i = 0 To checkBoxList.Items.Count - 1
                    checkBoxList.Items(i).Selected = False
                    For count = 0 To strArr.Length - 1
                        If strArr(i) = "TRUE" Then
                            checkBoxList.Items(i).Selected = True
                        Else
                            checkBoxList.Items(i).Selected = False
                        End If
                        'MsgBox(strArr(count), vbSystemModal)
                    Next
                Next

            End If
        End If
        sqlDr.Close()
        con.Close()

        Btn_Update.Visible = True
        Btn_Add.Visible = False
        Btn_Cancel.Visible = True
    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Dim index As Integer = 0
        Dim Insert As String
        Dim Name As String
        str = "select * from menuMaster"
        sqlDr = Proses.ExecuteReader(str)
        While sqlDr.Read
            Name += sqlDr("Name") & ";"
        End While
        sqlDr.Close()
        Name = Name.TrimEnd(";")

        strArrUp = Name.Split(";")
        For i = 0 To strArrUp.Length - 1
            If checkBoxList.Items(i).Selected = True Then
                MT = "TRUE"
                Insert += "UPDATE MTRUSTEE SET " & strArrUp(i) & "='" & MT & "' WHERE TrusteeID='" & txtGroupID.Value & "'"
            Else
                checkBoxList.Items(i).Selected = False
                MT = "FALSE"
                Insert += "UPDATE MTRUSTEE SET " & strArrUp(i) & "='" & MT & "' WHERE TrusteeID='" & txtGroupID.Value & "'"
            End If
            com = New SqlCommand(Insert, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Next
    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        Response.Redirect("user_sett.aspx")
    End Sub

    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        gridLevelUser.Visible = False
        Btn_Save.Visible = True
        Btn_Update.Visible = False
        Btn_Add.Visible = False
        Btn_Cancel.Visible = True
        div_new.Visible = True
    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        'Dim i As Integer = 0
        'Dim ii As Integer = 0
        'Dim ld As String = 0
        'Dim listBarangID As String = 0
        'If checkBoxList.Items(0).Selected = True Then
        '    MT = "True"
        'Else
        '    MT = "False"
        'End If
        'If checkBoxList.Items(1).Selected = True Then
        '    TIC = "True"
        'Else
        '    TIC = "False"
        'End If
        'If checkBoxList.Items(2).Selected = True Then
        '    Customer = "True"
        'Else
        '    Customer = "False"
        'End If
        'If checkBoxList.Items(3).Selected = True Then
        '    TH = "True"
        'Else
        '    TH = "False"
        'End If
        'If checkBoxList.Items(4).Selected = True Then
        '    KB = "True"
        'Else
        '    KB = "False"
        'End If
        'If checkBoxList.Items(5).Selected = True Then
        '    RPT = "True"
        'Else
        '    RPT = "False"
        'End If
        'If checkBoxList.Items(6).Selected = True Then
        '    Email = "True"
        'Else
        '    Email = "False"
        'End If
        'If checkBoxList.Items(7).Selected = True Then
        '    UM = "True"
        'Else
        '    UM = "False"
        'End If

        'insertdata = "insert into msUserTrustee (LevelUser,LevelUserSbg,Description,MasterTable,TIC,Customer,TH,KB,RPT,Email,UM )" & _
        '       " values ('" & txt_level_user.Text & "','" & KodeLevelUserSbg.Value & "','" & txt_description.Text & "','" & MT & "','" & TIC & "','" & Customer & "','" & TH & "','" & KB & "','" & RPT & "','" & Email & "','" & UM & "')"
        'com = New SqlCommand(insertdata, con)
        'con.Open()
        'com.ExecuteNonQuery()
        'con.Close()
        'Response.Redirect("user_sett.aspx")
    End Sub

    Sub Note_Develope()
        sql = "select * from mApplikasi"
        sqlDr = Proses.ExecuteReader(sql)
        If sqlDr.Read Then
            VTicket = sqlDr("Ticket").ToString
            VTwitter = sqlDr("Twitter").ToString
            VFacebook = sqlDr("Facebook").ToString
            VEmail = sqlDr("Email").ToString
            VFax = sqlDr("Fax").ToString
            Vchat = sqlDr("Chat").ToString
            VSms = sqlDr("Sms").ToString
        End If
        sqlDr.Close()
        If VTicket = "Yes" Then
            If VTwitter = "Yes" Then
                TWT = "TWT"
                TKY = "TKY"
            Else
            End If
            If VFacebook = "Yes" Then
                FCB = "FCB"
                FKY = "FKY"
            Else
            End If
            If VEmail = "Yes" Then
                EMA = "EMA"
            Else
            End If
            If VFax = "Yes" Then
                FAX = "FAX"
            Else
            End If
            If Vchat = "Yes" Then
                CHA = "CHA"
            Else
            End If
            If VSms = "Yes" Then
                SMS = "SMS"
            Else
            End If
            sql_muser_trustee.SelectCommand = "Select * from menuMaster where Flag='Ticket' or Flag='ALL' or Flag='" & FCB & "' or Flag='" & FKY & "' or Flag='" & TWT & "' or Flag='" & TKY & "' or Flag='" & EMA & "' or Flag='" & FAX & "' or Flag='" & CHA & "' or Flag='" & SMS & "'"
        Else
            If VTwitter = "Yes" Then
                TWT = "TWT"
                TKY = "TKY"
            Else
            End If
            If VFacebook = "Yes" Then
                FCB = "FCB"
                FKY = "FKY"
            Else
            End If
            If VEmail = "Yes" Then
                EMA = "EMA"
            Else
            End If
            If VFax = "Yes" Then
                FAX = "FAX"
            Else
            End If
            If Vchat = "Yes" Then
                CHA = "CHA"
            Else
            End If
            If VSms = "Yes" Then
                SMS = "SMS"
            Else
            End If
            sql_muser_trustee.SelectCommand = "Select * from menuMaster where Flag='ALL' or Flag='" & FCB & "' or Flag='" & FKY & "' or Flag='" & TWT & "' or Flag='" & TKY & "' or Flag='" & EMA & "' or Flag='" & FAX & "' or Flag='" & CHA & "' or Flag='" & SMS & "'"
        End If
    End Sub

    Sub update()
        If VTicket = "Yes" Then
            Dim query As String = ""
            If checkBoxList.Items(0).Selected = True Then
                MT = "True"
                query += "UPDATE MTRUSTEE SET MT='" & MT & "',"
            Else
                MT = "False"
                query += "UPDATE MTRUSTEE SET MT='" & MT & "',"
            End If
            If checkBoxList.Items(1).Selected = True Then
                MT_STY = "True"
                query += "MT_STY='" & MT_STY & "',"
            Else
                MT_STY = "False"
                query += "MT_STY='" & MT_STY & "',"
            End If
            If checkBoxList.Items(2).Selected = True Then
                MT_GTY = "True"
                query += "MT_GTY='" & MT_GTY & "',"
            Else
                MT_GTY = "False"
                query += "MT_GTY='" & MT_GTY & "',"
            End If
            If checkBoxList.Items(3).Selected = True Then
                MT_TTY = "True"
                query += "MT_TTY='" & MT_TTY & "',"
            Else
                MT_TTY = "False"
                query += "MT_TTY='" & MT_TTY & "',"
            End If
            If checkBoxList.Items(4).Selected = True Then
                MT_CON = "True"
                query += "MT_CON='" & MT_CON & "',"
            Else
                MT_CON = "False"
                query += "MT_CON='" & MT_CON & "',"
            End If
            If checkBoxList.Items(5).Selected = True Then
                MT_CTW = "True"
                query += "MT_CTW='" & MT_CTW & "',"
            Else
                MT_CTW = "False"
                query += "MT_CTW='" & MT_CTW & "',"
            End If
            If checkBoxList.Items(6).Selected = True Then
                MT_CTR = "True"
                query += "MT_CTR='" & MT_CTR & "',"
            Else
                MT_CTR = "False"
                query += "MT_CTR='" & MT_CTR & "',"
            End If
            If checkBoxList.Items(7).Selected = True Then
                MT_STS = "True"
                query += "MT_STS='" & MT_STS & "',"
            Else
                MT_STS = "False"
                query += "MT_STS='" & MT_STS & "',"
            End If
            If checkBoxList.Items(8).Selected = True Then
                MT_DKY = "True"
                query += "MT_DKY='" & MT_DKY & "',"
            Else
                MT_DKY = "False"
                query += "MT_DKY='" & MT_DKY & "',"
            End If
            If checkBoxList.Items(9).Selected = True Then
                MT_EAL = "True"
                query += "MT_EAL='" & MT_EAL & "',"
            Else
                MT_EAL = "False"
                query += "MT_EAL='" & MT_EAL & "',"
            End If
            If checkBoxList.Items(10).Selected = True Then
                MT_EAD = "True"
                query += "MT_EAD='" & MT_EAD & "',"
            Else
                MT_EAD = "False"
                query += "MT_EAD='" & MT_EAD & "',"
            End If
            If checkBoxList.Items(11).Selected = True Then
                DS = "True"
                query += "DS='" & DS & "',"
            Else
                DS = "False"
                query += "DS='" & DS & "',"
            End If
            If checkBoxList.Items(12).Selected = True Then
                CH = "True"
                query += "CH='" & CH & "',"
            Else
                CH = "False"
                query += "CH='" & CH & "',"
            End If

            If VEmail = "Yes" Then
                If checkBoxList.Items(13).Selected = True Then
                    CH_EMA = "True"
                    query += "CH_EMA='" & CH_EMA & "',"
                Else
                    CH_EMA = "False"
                    query += "CH_EMA='" & CH_EMA & "',"
                End If
            Else
                If checkBoxList.Items(13).Selected = True Then
                    CH_EMA = "True"
                Else
                    CH_EMA = "False"
                End If
            End If
            If VTwitter = "Yes" Then
                If checkBoxList.Items(14).Selected = True Then
                    CH_TWT = "True"
                    query += "CH_TWT='" & CH_TWT & "',"
                Else
                    CH_TWT = "False"
                    query += "CH_TWT='" & CH_TWT & "',"
                End If
                If checkBoxList.Items(15).Selected = True Then
                    CH_TKS = "True"
                    query += "CH_TKS='" & CH_TKS & "',"
                Else
                    CH_TKS = "False"
                    query += "CH_TKS='" & CH_TKS & "',"
                End If
            Else
                If checkBoxList.Items(14).Selected = True Then
                    CH_TWT = "True"
                Else
                    CH_TWT = "False"
                End If
                If checkBoxList.Items(15).Selected = True Then
                    CH_TKS = "True"
                Else
                    CH_TKS = "False"
                End If
            End If
            If VFacebook = "Yes" Then
                If checkBoxList.Items(16).Selected = True Then
                    CH_FCB = "True"
                    query += "CH_FCB='" & CH_FCB & "',"
                Else
                    CH_FCB = "False"
                    query += "CH_FCB='" & CH_FCB & "',"
                End If
                If checkBoxList.Items(17).Selected = True Then
                    CH_FKS = "True"
                    query += "CH_FKS='" & CH_FKS & "',"
                Else
                    CH_FKS = "False"
                    query += "CH_FKS='" & CH_FKS & "',"
                End If
            Else
                If checkBoxList.Items(16).Selected = True Then
                    CH_FCB = "True"
                Else
                    CH_FCB = "False"
                End If
                If checkBoxList.Items(17).Selected = True Then
                    CH_FKS = "True"
                Else
                    CH_FKS = "False"
                End If
            End If
            If VFax = "Yes" Then
                If checkBoxList.Items(18).Selected = True Then
                    CH_FAX = "True"
                    query += "CH_FAX='" & CH_FAX & "',"
                Else
                    CH_FAX = "False"
                    query += "CH_FAX='" & CH_FAX & "',"
                End If
            Else
                If checkBoxList.Items(18).Selected = True Then
                    CH_FAX = "True"
                Else
                    CH_FAX = "False"
                End If
            End If

            If VSms = "Yes" Then
                If checkBoxList.Items(19).Selected = True Then
                    CH_SMS = "True"
                    query += "CH_SMS='" & CH_SMS & "',"
                Else
                    CH_SMS = "False"
                    query += "CH_SMS='" & CH_SMS & "',"
                End If
            Else
                If checkBoxList.Items(19).Selected = True Then
                    CH_SMS = "True"
                Else
                    CH_SMS = "False"
                End If
            End If

            If Vchat = "Yes" Then
                If checkBoxList.Items(20).Selected = True Then
                    CH_CHA = "True"
                    query += "CH_CHA='" & CH_CHA & "',"
                Else
                    CH_CHA = "False"
                    query += "CH_CHA='" & CH_CHA & "',"
                End If
            Else
                If checkBoxList.Items(20).Selected = True Then
                    CH_CHA = "True"
                Else
                    CH_CHA = "False"
                End If
            End If

            If checkBoxList.Items(21).Selected = True Then
                TIK = "True"
                query += "TIK='" & TIK & "',"
            Else
                TIK = "False"
                query += "TIK='" & TIK & "',"
            End If

            If checkBoxList.Items(22).Selected = True Then
                TK_CRT = "True"
                query += "TK_CRT='" & TK_CRT & "',"
            Else
                TK_CRT = "False"
                query += "TK_CRT='" & TK_CRT & "',"
            End If

            If checkBoxList.Items(23).Selected = True Then
                TK_THS = "True"
                query += "TK_THS='" & TK_THS & "',"
            Else
                TK_THS = "False"
                query += "TK_THS='" & TK_THS & "',"
            End If

            If checkBoxList.Items(24).Selected = True Then
                UM = "True"
                query += "UM='" & UM & "',"
            Else
                UM = "False"
                query += "UM='" & UM & "',"
            End If

            If checkBoxList.Items(25).Selected = True Then
                UM_ADS = "True"
                query += "UM_ADS='" & UM_ADS & "',"
            Else
                UM_ADS = "False"
                query += "UM_ADS='" & UM_ADS & "',"
            End If

            If checkBoxList.Items(26).Selected = True Then
                UM_SUP = "True"
                query += "UM_SUP='" & UM_SUP & "',"
            Else
                UM_SUP = "False"
                query += "UM_SUP='" & UM_SUP & "',"
            End If

            If checkBoxList.Items(27).Selected = True Then
                RP = "True"
                query += "RP='" & RP & "',"
            Else
                RP = "False"
                query += "RP='" & RP & "',"
            End If

            If checkBoxList.Items(28).Selected = True Then
                CT = "True"
                query += "CT='" & CT & "',"
            Else
                CT = "False"
                query += "CT='" & CT & "',"
            End If

            If checkBoxList.Items(29).Selected = True Then
                GF = "True"
                query += "GF='" & GF & "',"
            Else
                GF = "False"
                query += "GF='" & GF & "',"
            End If

            If checkBoxList.Items(30).Selected = True Then
                KB = "True"
                query += "KB='" & KB & "',"
            Else
                KB = "False"
                query += "KB='" & KB & "'"
            End If

            query += "WHERE TrusteeID='" & txtGroupID.Value & "'"
            com = New SqlCommand(query, con)
            Try
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        Else

        End If
    End Sub
End Class
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports RestSharp
Imports C5i_Controles.CONTROLES
Imports C5i_Controles.CRUD
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Threading.Tasks

Public Class Frm_Subida
    Inherits System.Web.UI.Page
    Public cadena As String = "Data Source=10.18.8.104;Initial Catalog=Grabaciones;User ID=sa;Password=admin2022*; Connection Timeout=50"
    Public cadenaRedBox As String = "Data Source=10.18.75.24;Initial Catalog=RedBox.ExportBroker;User ID=rbrexportbroker;Password=T3l3c0m.rbrPW..; Connection Timeout=50"

    Private mThreadFic As Thread
    Private mThreadFic2 As Thread
    Public valida As String = " "
    Private mProcesarFic As Frm_Subida


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        Response.Cache.SetAllowResponseInBrowserHistory(False)
        Response.Cache.SetNoStore()



        If Not IsPostBack Then


            txt_auxUsuario.Text = Session("Usuario")
            txt_auxPrivilegio.Text = Session("Privilegio")
            txt_auxSubarea.Text = Session("Subarea")


            txt_auxbarra.Text = "0"
            txt_auxin.Text = "0"
            txt_auxtotal.Text = "0"
            txt_auxi.Text = "0"

        End If



    End Sub

#Region "Modal"
    Public Sub modal(ByRef tipo As Integer, ByRef imagen As String, mensajeUsuario As String, mensajeSistema As String)
        Dim ModalUsuario = LlamarModal(tipo, imagen, mensajeUsuario, mensajeSistema)
        Lbl_MensajeUsuario.Text = ModalUsuario.Item1
        Lbl_MensajeSistema.Text = ModalUsuario.Item2
        Img_Mensaje.ImageUrl = ModalUsuario.Item3

        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "modalError", "modalError();", True)
    End Sub
#End Region

    Protected Sub Btn_BuscarFechas_Click(sender As Object, e As EventArgs) Handles Btn_BuscarFechas.Click
        If validar_fechas() = True Then
            txt_auxbarra.Text = "1"
            Lbl_Status.Text = ""
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "bloquea_buscar", "bloquea_buscar();", True)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "carga_datos", "carga_datos();", True)



        Else
            txt_auxbarra.Text = "0"
            Lbl_Status.Text = ""

            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "oculta_barraazul", "oculta_barraazul();", True)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "oculta_barra", "oculta_barra();", True)
        End If
    End Sub

    Protected Sub Btn_cargar_Click(sender As Object, e As EventArgs) Handles Btn_cargar.Click

        If validar_fechas() = True Then

            inicia_registro()
            If txt_auxtoken.Text = "" Then
                Lbl_Status.Text = "Recorridos: " & txt_auxi.Text & " Total: " & txt_auxtotal.Text & " Ingresados: " & txt_auxin.Text & " AUDIOS NO EXTRAIDOS, ERROR DE CONEXION CON SERVIDOR"

            Else
                Lbl_Status.Text = "Recorridos: " & txt_auxi.Text & " Total: " & txt_auxtotal.Text & " Ingresados: " & txt_auxin.Text

            End If
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "desbloque_buscar", "desbloque_buscar();", True)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "barra", "barra();", True)

            System.Threading.Thread.Sleep(6000)
            'logout()sql 
        Else
            txt_auxbarra.Text = "0"
            Lbl_Status.Text = "..."
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "oculta_barraazul", "oculta_barraazul();", True)
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "oculta_barra", "oculta_barra();", True)


        End If

    End Sub


    Private Sub xx()
        'Lbl_Status.Text = "Recorridos: " & txt_auxi.Text & " Total: " & txt_auxtotal.Text & " Ingresados: " & txt_auxin.Text


        'Dim i As Integer = txt_auxi.Text
        'Dim total As Integer = txt_auxtotal.Text
        'Dim j As Integer = txt_auxin.Text


        'ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "desbloque_buscar", "desbloque_buscar();", True)
        'ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "barra", "barra();", True)




    End Sub


    Private Function validar_fechas()
        Dim resultado As Boolean = False

        If Txt_FI.Text = "" Then
            modal(7, "error.png", "Seleccione fechas", "Control: Txt_FI")
        ElseIf Txt_FF.Text = "" Then
            modal(7, "error.png", "Seleccione fechas", "Control: Txt_FF")
        ElseIf Txt_FI.Text > Txt_FF.Text Then
            modal(7, "error.png", "La fecha de inicio debe de ser menor que la fecha final", "Control: Txt_FF")
        Else
            resultado = True
        End If

        Return resultado
    End Function


#Region "Registros"

    Private Sub inicia_registro()
        txt_auxin.Text = "0"
        txt_auxtotal.Text = "0"
        txt_auxi.Text = "0"
        Dim lasfechas As New Fechas

        truncate_cat_json()
        Dim dt_redbox As DataTable = Obten_rangodatosBaseRedbox(Txt_FI.Text, Txt_FF.Text)
        Dim i As Integer = 0
        Dim total As Integer = 0
        Dim j As Integer = 0
        total = CInt(dt_redbox.Rows.Count)
        'generar_token()

        'If txt_auxtoken.Text = "" Then
        '    Exit Sub
        'End If


        For Each row As DataRow In dt_redbox.Rows

            i = i + 1


            If Existe_Registro(row("NasCallId")) = 0 Then
                txt_auxbarra.Text = 1
                j = j + 1

                Copia_DatosRedBox(row("NasCallId"))



            Else
                If Existe_RegistroAudio(row("NasCallId")) = "" Then
                    If txt_auxtoken.Text <> "" Then
                        Dim folderPath As String = Server.MapPath("~/Audio/" & lasfechas.GetFechaActual())

                        'extrae_audio(row("NasCallId"), folderPath)

                        Establece_datosAudio(row("NasCallId"), txt_auxUsuario.Text, folderPath)
                    End If



                Else
                    txt_auxbarra.Text = 0
                End If




            End If

            txt_auxi.Text = i
            txt_auxin.Text = j
            txt_auxtotal.Text = total

        Next




        'logout()


    End Sub



    Private Function Obten_rangodatosBaseRedbox(ByRef fi As String, ByRef ff As String)

        Dim conno As New SqlConnection(cadenaRedBox)


        If conno.State = ConnectionState.Closed Then
            conno.Open()
        End If

        Dim cadena2 As String = String.Format("and (Metadata like '%Extension{0}:{0}10401{0}%' or Metadata like '%Extension{0}:{0}10402{0}%' or Metadata like '%Extension{0}:{0}10403{0}%') ", Chr(34))


        Dim cadena As String = "select NasCallId from Call "
        cadena = cadena & "where convert(varchar,CallStartDateTime,23)>='" & fi & "' "
        cadena = cadena & "and  convert(varchar,CallStartDateTime,23)<='" & ff & "' "
        cadena = cadena & cadena2
        cadena = cadena & "order by CallStartDateTime asc "


        Dim da As New SqlDataAdapter(cadena, conno)
        Dim dt As New DataTable

        Try
            da.Fill(dt)
            conno.Close()
        Catch ex As Exception
            ex.ToString()
            conno.Close()
        End Try
        conno.Close()
        Return dt

    End Function


    Private Function Existe_Registro(ByRef id As String)
        Dim resultado As Integer = 0
        Dim consulta As String
        consulta = " "
        consulta = consulta & "select count(*) as Total from Grabaciones where IdCall = '" & id & "' "

        Try
            Dim asigna = Seleccionar(0, cadena, consulta, 1)
            If asigna(0) = "#3RR@R:01#" Then
                modal(7, "error.png", "Error al cargar los datos", " Existe_Registro() ")
            Else
                resultado = asigna(0)
            End If
        Catch ex As Exception
            resultado = 1
            ex.ToString()
        End Try
        Return resultado
    End Function

    Private Function Existe_RegistroAudio(ByRef id As String)
        Dim resultado As String = 0
        Dim consulta As String
        consulta = " "
        consulta = consulta & "select Audio from Grabaciones where IdCall = '" & id & "' "

        Try
            Dim asigna = Seleccionar(0, cadena, consulta, 1)
            If asigna(0) = "#3RR@R:01#" Then
                modal(7, "error.png", "Error al cargar los datos", " Existe_Registro() ")
            Else
                resultado = "Existe"
            End If
        Catch ex As Exception
            resultado = "Error"
            ex.ToString()
        End Try
        Return resultado
    End Function


    Private Sub Copia_DatosRedBox(ByRef id As String)

        Dim lasfechas As New Fechas
        Dim consulta As String
        consulta = " "
        consulta = consulta & "select Metadata from Call where NasCallId = '" & id & "' "

        Try
            Dim asigna = Seleccionar(0, cadenaRedBox, consulta, 1)
            If asigna(0) = "#3RR@R:01#" Then
                modal(7, "error.png", "Error al cargar los datos", " Copia_DatosRedBox() ")
            Else
                Dim resultado As String = asigna(0)
                Dim folderPath As String = Server.MapPath("~/Audio/" & lasfechas.GetFechaActual())
                Dim n As String = id
                Inserta_metadata_bd(id, resultado)

                If txt_auxtoken.Text <> "" Then

                    mThreadFic = New Thread(Sub() Me.extrae_audio(n, folderPath))
                    mThreadFic.Start()
                    'extrae_audio(id, folderPath)

                    'Establece_datosAudio(id, txt_auxUsuario.Text, folderPath)

                End If



            End If
        Catch ex As Exception
            ex.ToString()
        End Try

    End Sub

    Private Sub Inserta_metadata_bd(ByRef idcall As String, ByRef Metadata As String)
        Dim consulta = "insert into cat_json (IdCall,Metadata) "
        consulta = consulta & "values('" & idcall & "','" & Metadata & "')   "


        Try
            Dim inserta = Insertar(cadena, consulta, 1)
            If inserta(0) = "#3RR@R:01#" Then
                modal(7, "Error.png", "Error al establecer los datos", "Inserta_metadata_bd()")
            End If
        Catch ex As Exception
            modal(7, "Error.png", "Error al establecer los datos: Inserta_metadata_bd()", ex.ToString())
        End Try

    End Sub


    Private Sub truncate_cat_json()
        Dim consulta = "truncate table cat_json "

        Try
            Dim inserta = Insertar(cadena, consulta, 1)
            If inserta(0) = "#3RR@R:01#" Then
                modal(7, "Error.png", "Error al iniciar registro de los datos", "truncate_cat_json()")
            End If
        Catch ex As Exception
            modal(7, "Error.png", "Error al iniciar registro de los datos: truncate_cat_json()", ex.ToString())
        End Try
    End Sub



#End Region

#Region "Audios"

    Private Sub generar_token()
        Dim client = New RestClient("http://10.18.8.104:1480/api/v1/sessions/login")
        Dim request = New RestRequest(Method.POST)
        request.AddHeader("username", "admin")
        request.AddHeader("password", "recorder")
        Dim response = client.Execute(request)
        Dim json As JObject = JObject.Parse(response.Content)
        txt_auxtoken.Text = json("authToken")

        If txt_auxtoken.Text = "" Then
            Lbl_Status.Text = "Error en la conexion del API, los audios no estaran disponibles"
        End If

    End Sub


    Private Sub extrae_audio(ByRef id As String, ByRef folderPath As String)
        System.Threading.Thread.Sleep(200)

        Dim client = New RestClient("http://10.18.8.104:1480/api/v1/search/callaudiowav/" & id)
        Dim request = New RestRequest(Method.GET)
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("authToken", txt_auxtoken.Text)

        Dim response As Byte() = client.DownloadData(request)



        Try
            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)

            End If


            'validacion de existencia de archivos antes de descargarlo
            If Not File.Exists(folderPath & "/" & id & ".wav") Then

                File.WriteAllBytes(folderPath & "/" & id & ".wav", response)

            End If
        Catch ex As Exception
            ex.ToString()
        End Try


    End Sub


    Private Sub Establece_datosAudio(ByRef id As String, ByRef usuario As String, ByRef folderPath As String)
        Dim lasfechas As New Fechas
        Dim ruta As String = folderPath & "\" & id & ".wav"
        Dim horafechas As String = lasfechas.GetFechaActual() & " " & lasfechas.GetHoraActual()
        Dim consulta As String = "update Grabaciones set Audio='" & ruta & "',UsuarioDescarga='" & usuario & "',FechaDescarga='" & horafechas & "' where IdCall ='" & id & "' "

        Try
            Dim asigna = Actualizar(cadena, consulta, 1)
            If asigna(0) = "#3RR@R:01#" Then
                modal(7, "Error.png", "Error al establecer los datos", "Establece_datosAudio()")
            End If
        Catch ex As Exception
            modal(7, "Error.png", "Error al establecer los datos: Establece_datosAudio()", ex.ToString())
        End Try
    End Sub


#End Region

    Private Sub genera_search()
        System.Threading.Thread.Sleep(300)
        Dim client = New RestClient("http://10.18.8.104:1480/api/v1/search")
        Dim request = New RestRequest(Method.POST)
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("authToken", txt_auxtoken.Text)
        Dim body As String = "{
                    " & vbLf & "  ""resultsToSkip"": 1000,
                    " & vbLf & "  ""startTime"": ""20210922000000"",
                    " & vbLf & "  ""endTime"": ""20211022235959""
                    " & vbLf & "}"

        request.AddParameter("application/json", body, ParameterType.RequestBody)
        Dim response = client.Execute(request)


        Dim json As JObject = JObject.Parse(response.Content)
        txt_auxSeachResult.Text = json("resultsFound")



    End Sub

    Private Sub logout()
        System.Threading.Thread.Sleep(300)
        Dim client = New RestClient("http://10.18.8.104:1480/api/v1/sessions/logout")
        Dim request = New RestRequest(Method.POST)
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("authToken", txt_auxtoken.Text)
        Dim response = client.Execute(request)
        txt_auxtoken.Text = response.Content



    End Sub


    Private Sub genera_search_status()
        System.Threading.Thread.Sleep(300)
        Dim client = New RestClient("http://10.18.8.104:1480/api/v1/search/status")
        Dim request = New RestRequest(Method.GET)
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("authToken", txt_auxtoken.Text)
        Dim response = client.Execute(request)





    End Sub



    Private Sub genera_search_results()
        System.Threading.Thread.Sleep(300)
        Dim client = New RestClient("http://10.18.8.104:1480/api/v1/search/results")

        Dim request = New RestRequest(Method.GET)
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("authToken", txt_auxtoken.Text)
        Dim response = client.Execute(request)





        Dim i As Integer = 1000
        Dim x As Integer = 0
        Dim json As JObject = JObject.Parse(response.Content)

        For Each Row In json("callIDs")
            If x < i Then



                genera_call_details(Row("callID").ToString(), x)
                x = x + 1
            End If

        Next




    End Sub


    Private Sub genera_call_details(ByRef id As String, ByRef num As String)
        Dim lasfechas As New Fechas
        Dim StartDateTime As String = "SE"
        Dim EndDateTime As String = "SE"
        Dim Duration As String = "0"
        Dim Extension As String = "0"
        Dim OtherParty As String = "0"
        Dim Direction As String = "SE"
        Dim AgentGroup As String = "SE"
        Dim ChannelName As String = "SE"
        Dim CallerNumber As String = "SE"
        Dim CalledNumber As String = "SE"
        Dim AnnotationText As String = "SE"
        Dim SipToAddress As String = "SE"
        Dim SipFromAddress As String = "SE"
        Dim CTICall As String = "SE"
        Dim ExternalCallID As String = "SE"
        Dim RBRCallGUID As String = "SE"
        Dim AnnotationTextFirst As String = "SE"
        Dim Audio As String = "SE"
        Dim UsuarioDescarga As String = txt_auxUsuario.Text
        Dim FechaDescarga As String = lasfechas.GetFechaHora().ToString()


        Dim client = New RestClient("http://10.18.8.104:1480/api/v1/search/calldetails/" & id)
        Dim request = New RestRequest(Method.GET)
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("authToken", txt_auxtoken.Text)
        Dim response = client.Execute(request)


        Dim json As JObject = JObject.Parse(response.Content)


        For Each Row In json("fields")

            Select Case Row("Key").ToString()
                Case "StartDateTime"
                    If Len(Row("Value").ToString()) > 0 Then
                        StartDateTime = Row("Value").ToString()
                    End If
                Case "EndDateTime"
                    If Len(Row("Value").ToString()) > 0 Then
                        EndDateTime = Row("Value").ToString()
                    End If
                Case "Duration"
                    If Len(Row("Value").ToString()) > 0 Then
                        Duration = Row("Value").ToString()
                    End If
                Case "Extension"
                    If Len(Row("Value").ToString()) > 0 Then
                        Extension = Row("Value").ToString()
                    End If
                Case "OtherParty"
                    If Len(Row("Value").ToString()) > 0 Then
                        OtherParty = Row("Value").ToString()
                    End If
                Case "Direction"
                    If Len(Row("Value").ToString()) > 0 Then
                        Direction = Row("Value").ToString()
                    End If
                Case "AgentGroup"
                    If Len(Row("Value").ToString()) > 0 Then
                        AgentGroup = Row("Value").ToString()
                    End If
                Case "ChannelName"
                    If Len(Row("Value").ToString()) > 0 Then
                        ChannelName = Row("Value").ToString()
                    End If
                Case "CallerNumber"
                    If Len(Row("Value").ToString()) > 0 Then
                        CallerNumber = Row("Value").ToString()
                    End If
                Case "CalledNumber"
                    If Len(Row("Value").ToString()) > 0 Then
                        CalledNumber = Row("Value").ToString()
                    End If
                Case "AnnotationText"
                    If Len(Row("Value").ToString()) > 0 Then
                        AnnotationText = Row("Value").ToString()
                    End If
                Case "SipToAddress"
                    If Len(Row("Value").ToString()) > 0 Then
                        SipToAddress = Row("Value").ToString()
                    End If
                Case "SipFromAddress"
                    If Len(Row("Value").ToString()) > 0 Then
                        SipFromAddress = Row("Value").ToString()
                    End If
                Case "CTICall"
                    If Len(Row("Value").ToString()) > 0 Then
                        CTICall = Row("Value").ToString()
                    End If
                Case "ExternalCallID"
                    If Len(Row("Value").ToString()) > 0 Then
                        ExternalCallID = Row("Value").ToString()
                    End If
                Case "RBRCallGUID"
                    If Len(Row("Value").ToString()) > 0 Then
                        RBRCallGUID = Row("Value").ToString()
                    End If
                Case "AnnotationTextFirst"
                    If Len(Row("Value").ToString()) > 0 Then
                        AnnotationTextFirst = Row("Value").ToString()
                    End If




            End Select



        Next
        Inserta_registro_bd(id, StartDateTime, EndDateTime,
                    Duration, Extension, OtherParty,
                    Direction, AgentGroup, ChannelName,
                    CallerNumber, CalledNumber,
                    SipToAddress, SipFromAddress, CTICall,
                    ExternalCallID, RBRCallGUID,
                    Audio, UsuarioDescarga, FechaDescarga)


    End Sub


    Private Sub Inserta_registro_bd(ByRef IdCall As String, ByRef StartDateTime As String, ByRef EndDateTime As String,
                                    ByRef Duration As String, ByRef Extension As String, ByRef OtherParty As String,
                                    ByRef Direction As String, ByRef AgentGroup As String, ByRef ChannelName As String,
                                    ByRef CallerNumber As String, ByRef CalledNumber As String,
                                    ByRef SipToAddress As String, ByRef SipFromAddress As String, ByRef CTICall As String,
                                    ByRef ExternalCallID As String, ByRef RBRCallGUID As String,
                                    ByRef Audio As String, ByRef UsuarioDescarga As String, ByRef FechaDescarga As String)




        Dim consulta = "insert into Grabaciones (IdCall,StartDateTime,EndDateTime,Duration,Extension,OtherParty,Direction,AgentGroup,ChannelName, "
        consulta = consulta & "CallerNumber,CalledNumber,SipToAddress,SipFromAddress,CTICall,ExternalCallID,  "
        consulta = consulta & "RBRCallGUID,Audio,UsuarioDescarga,FechaDescarga) "
        consulta = consulta & "values('" & IdCall & "','" & Convert.ToDateTime(StartDateTime).ToString("yyyy-MM-dd HH:mm:ss") & "','" & Convert.ToDateTime(EndDateTime).ToString("yyyy-MM-dd HH:mm:ss") & "','" & Duration & "','" & Extension & "','" & OtherParty & "', "
        consulta = consulta & "'" & Direction & "','" & AgentGroup & "','" & ChannelName & "','" & CallerNumber & "','" & CalledNumber & "', "
        consulta = consulta & "'" & SipToAddress & "','" & SipFromAddress & "','" & CTICall & "','" & ExternalCallID & "', "
        consulta = consulta & "'" & RBRCallGUID & "','" & Audio & "','" & UsuarioDescarga & "','" & Convert.ToDateTime(FechaDescarga).ToString("yyyy-MM-dd HH:mm:ss") & "')   "


        Dim inserta = Insertar(cadena, consulta, 1)



    End Sub


    Private Function verifica_registro(ByRef id As String) As Integer
        Dim resultas As Integer = 0

        Return resultas
    End Function

    Protected Sub Btn_terminado_Click(sender As Object, e As EventArgs) Handles Btn_terminado.Click
        'Lbl_Status.Text = "Recorridos: " & txt_auxi.Text & " Total: " & txt_auxtotal.Text & " Ingresados: " & txt_auxin.Text

        'ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "oculta_barra", "oculta_barra();", True)
        'ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "barra", "barra();", True)
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "compleado", "compleado();", True)
        modal(7, "Exito.png", "Registro Cargados", "Recorridos: " & txt_auxi.Text & " Total: " & txt_auxtotal.Text & " Ingresados: " & txt_auxin.Text)
    End Sub



End Class
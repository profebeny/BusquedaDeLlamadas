Imports System.Data.SqlClient
Imports C5i_Controles.CONTROLES
Imports C5i_Controles.CRUD
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports RestSharp
Imports System.Threading
Imports System.Threading.Tasks
Imports System.IO
Public Class Frm_Consulta
    Inherits System.Web.UI.Page
    Public cadena As String = "Data Source=10.18.75.26; Initial Catalog=BD_089_2022; User ID=SistemasPachuca; Password=SistemasPachuc@; Connection Timeout=50"
    Public cadena089 As String = "Data Source=10.18.8.237; Initial Catalog=BD_089_2022; User ID=SistemasPachuca; Password=SistemasPachuca; Connection Timeout=50"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
            Response.Cache.SetAllowResponseInBrowserHistory(False)
            Response.Cache.SetNoStore()

            txt_auxUsuario.Text = Session("Usuario")
            txt_auxPrivilegio.Text = Session("Privilegio")
            txt_auxSubarea.Text = Session("Subarea")
            txt_auxtoken.Text = ""
            recetea_chk()
        End If
    End Sub

    Public Sub modal(ByRef tipo As Integer, ByRef imagen As String, mensajeUsuario As String, mensajeSistema As String)
        Dim ModalUsuario = LlamarModal(tipo, imagen, mensajeUsuario, mensajeSistema)
        Lbl_MensajeUsuario.Text = ModalUsuario.Item1
        Lbl_MensajeSistema.Text = ModalUsuario.Item2
        Img_Mensaje.ImageUrl = ModalUsuario.Item3

        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "modalError", "modalError();", True)
    End Sub

    Private Sub recetea_chk()
        Txt_Fi.Text = ""
        Txt_Ff.Text = ""
        Txt_ext.Text = ""
        Txt_party.Text = ""
        Lbl_llamada.Text = ""
        Lbl_Status.Text = ""
        Lbl_fechag.Text = ""
        Lbl_termino.Text = ""
        Lbl_duracion.Text = ""
        Lbl_extension.Text = ""
        Lbl_Recepcion.Text = ""
        lbl_Notas.Text = ""
        lbl_folio_web.Text = ""
        Lbl_incidente.Text = ""
        Lbl_municipio.Text = ""
        Lbl_puntoreferencia.Text = ""
        Lbl_descolonia.Text = ""
        Lbl_calle.Text = ""
        Lbl_oficio.Text = ""
        Lbl_folio.Text = ""
        lbl_ticket_web.Text = ""
        Txt_fechaaudio.Text = ""
        txt_auxduracion.Text = ""
        Chk_ext.Checked = False
        Chk_party.Checked = False
        Txt_party.Enabled = False
        Txt_ext.Enabled = False
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "oculta_audio", "oculta_audio();", True)
    End Sub

    Protected Sub Chk_ext_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_ext.CheckedChanged
        If Chk_ext.Checked = False Then
            Txt_ext.Text = ""
            Txt_ext.Enabled = False
        Else
            Txt_ext.Enabled = True
        End If
    End Sub

    Protected Sub Chk_party_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_party.CheckedChanged
        If Chk_party.Checked = False Then
            Txt_party.Text = ""
            Txt_party.Enabled = False
        Else
            Txt_party.Enabled = True
        End If
    End Sub

    Protected Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click
        If validar() = True Then
            ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "historial_datatable", "historial_datatable('" & Txt_Fi.Text & "','" & Txt_Ff.Text & "','" & Txt_ext.Text & "','" & Txt_party.Text & "')", True)
            recetea_chk()
        End If
    End Sub

    Protected Sub Btn_aux_Click(sender As Object, e As EventArgs) Handles Btn_aux.Click
        Lbl_Status.Text = ""
        Lbl_llamada.Text = ""
        Lbl_fechag.Text = ""
        Lbl_termino.Text = ""
        Lbl_duracion.Text = ""
        Lbl_extension.Text = ""
        Lbl_Recepcion.Text = ""
        chat.InnerHtml = ""
        lbl_Notas.Text = ""
        lbl_folio_web.Text = ""
        Lbl_incidente.Text = ""
        Lbl_municipio.Text = ""
        Lbl_puntoreferencia.Text = ""
        Lbl_descolonia.Text = ""
        Lbl_calle.Text = ""
        Lbl_oficio.Text = ""
        Lbl_folio.Text = ""
        lbl_ticket_web.Text = ""
        Txt_fechaaudio.Text = ""
        txt_auxduracion.Text = ""
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "modalcarga", "modalcarga()", True)
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "oculta_audio", "oculta_audio();", True)

    End Sub

    Protected Sub Btn_llamada_Click(sender As Object, e As EventArgs) Handles Btn_llamada.Click
        System.Threading.Thread.Sleep(1000)
        chat.InnerHtml = ""
        txt_auxtoken.Text = ""
        Lbl_llamada.Text = "Llamada seleccionada: " & txt_auxcallid.Text
        Obten_datosllamada(txt_auxcallid.Text)
        chat_set()
        descargar_audio()
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "cerrarcarga", "cerrarcarga();", True)
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "cambiaraudio", "cambiaraudio()", True)
        ScriptManager.RegisterStartupScript(Me, Me.Page.GetType, "muestra_audio", "muestra_audio();", True)


    End Sub

    Private Function validar()
        Dim resultado As Boolean = False

        If Txt_Fi.Text = "" Then
            resultado = False
            modal(7, "Error.png", "ADVERTENCIA: ", "No ha establecido una fecha inicial")
        ElseIf Txt_Ff.Text = "" Then
            resultado = False
            modal(7, "Error.png", "ADVERTENCIA: ", "No ha establecido una fecha final")
        ElseIf Txt_Fi.Text > Txt_Ff.Text Then
            resultado = False
            modal(7, "Error.png", "ADVERTENCIA: ", "La fecha inicial no puede ser mayor a la fecha final")

        Else
            resultado = True
        End If


        Return resultado
    End Function

    Private Sub set_audio()
        Dim consulta As String = ""
        Dim asigna
        consulta = " "
        consulta = consulta & "select Audio from Grabaciones where IdCall ='" & txt_auxcallid.Text & "' "
        Try
            asigna = Seleccionar(0, cadena, consulta, 1)

            If asigna(0) = "#3RR@R:01#" Then
                modal(7, "error.png", "Error al cargar los datos", " Btn_AuxInfracciones_Click() ")
            Else
                Dim texto As String = asigna(0)
                Dim SearchForThis As String = "Audio"
                Dim FirstCharacter As Integer = texto.IndexOf(SearchForThis)

                txt_auxaudio.Text = texto.Substring(FirstCharacter)

                'C:\Users\DDTOP24\source\repos\RedBox\RedBox\Audio\2022-03-27\109145.wav
            End If


        Catch ex As Exception
            ex.ToString()
        End Try

    End Sub

    Private Sub chat_set()

        Dim codigo As String = "<h3>Conversación</h3>"
        Dim dtaudio As DataTable = Obten_conversacion(txt_auxcallid.Text)
        Dim receptor As String = Obten_receptor(txt_auxcallid.Text)
        Dim emisor As String = Obten_emisor(txt_auxcallid.Text)

        For Each row As DataRow In dtaudio.Rows
            codigo = codigo & ""
            If row("SpeakerNumber") = "0" Then
                codigo = codigo & "<div class='containerchat'>"
                codigo = codigo & "<img src='IMAGEN/avatar.png' alt='Avatar' style='width100%;'>"
                codigo = codigo & "  <p>" & row("texto") & "</p>"
                codigo = codigo & " <span class='time-right'>" & "C5i - " & receptor & "</span>"
                codigo = codigo & " </div>"
            Else
                codigo = codigo & "<div class='containerchat darker'>"
                codigo = codigo & "<img src='IMAGEN/avatar.png' alt='Avatar' class='right' style='width100%;'>"
                codigo = codigo & "  <p>" & row("texto") & "</p>"
                codigo = codigo & " <span class='time-left'>" & "Llamante: " & emisor & "</span>"
                codigo = codigo & " </div>"
            End If

        Next

        chat.InnerHtml = codigo

    End Sub

    Private Sub descargar_audio()
        Dim idcall As String = txt_auxcallid.Text
        Dim lasfechas As New Fechas



        Dim resupuesta As String = Existe_RegistroAudio(idcall).ToString()


        If resupuesta = "" Then
            generar_token()


            If txt_auxtoken.Text <> "" Then


                'Path.GetFullPath("D:\089\Audio\" & lasfechas.GetFechaActual())

                Dim folderPath As String = Server.MapPath("~/Audio/" & lasfechas.GetFechaActual())

                extrae_audio(idcall, folderPath)

                Establece_datosAudio(idcall, txt_auxUsuario.Text, folderPath)


                set_audio()

                logout()

                Lbl_Status.Text = "Audio Cargado."

                'Fecha de grabación: 2022-03-03 08:33:16.91-06:00

                Dim fecha As String = Mid(Txt_fechaaudio.Text, 1, 10)
                Dim hora As String = Mid(Txt_fechaaudio.Text, 12, 5)

                If CInt(Obten_datosbase089(fecha, hora)) = 0 Then
                    lbl_Notas.Text = "Sin registro"
                    lbl_folio_web.Text = "Sin registro"
                    Lbl_incidente.Text = "Sin registro"
                    Lbl_municipio.Text = "Sin registro"
                    Lbl_puntoreferencia.Text = "Sin registro"
                    Lbl_descolonia.Text = "Sin registro"
                    Lbl_calle.Text = "Sin registro"
                    Lbl_oficio.Text = "Sin registro"
                    Lbl_folio.Text = "Sin registro"
                    lbl_ticket_web.Text = "Sin registro"
                Else
                    Dim dttime As DateTime = Convert.ToDateTime(txt_auxduracion.Text)
                    Dim horaduracion As String = dttime.ToString("HH:mm:ss")


                    If horaduracion >= "00:00:20" Then
                        Trae_datosbase089(fecha, hora)
                    Else
                        lbl_Notas.Text = "Sin registro"
                        lbl_folio_web.Text = "Sin registro"
                        Lbl_incidente.Text = "Sin registro"
                        Lbl_municipio.Text = "Sin registro"
                        Lbl_puntoreferencia.Text = "Sin registro"
                        Lbl_descolonia.Text = "Sin registro"
                        Lbl_calle.Text = "Sin registro"
                        Lbl_oficio.Text = "Sin registro"
                        Lbl_folio.Text = "Sin registro"
                        lbl_ticket_web.Text = "Sin registro"
                    End If
                End If

            Else
                Lbl_Status.Text = "Error en la conexion del API con el servidor, el audio no se encuentra disponible, intentelo nuevamente."
                Exit Sub
            End If
        Else



            Dim texto As String = resupuesta
            Dim SearchForThis As String = "Audio"
            Dim FirstCharacter As Integer = texto.IndexOf(SearchForThis)

            txt_auxaudio.Text = texto.Substring(FirstCharacter)
            Lbl_Status.Text = "Audio Cargado."

        End If


    End Sub

    Private Sub logout()
        System.Threading.Thread.Sleep(300)
        Dim client = New RestClient("http://10.18.8.216:1480/api/v1/sessions/logout")
        Dim request = New RestRequest(Method.POST)
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("authToken", txt_auxtoken.Text)
        Dim response = client.Execute(request)
        txt_auxtoken.Text = response.Content



    End Sub

    Private Sub generar_token()
        Dim client = New RestClient("http://10.18.8.216:1480/api/v1/sessions/login")
        Dim request = New RestRequest(Method.POST)
        request.AddHeader("username", "admin")
        request.AddHeader("password", "recorder")
        Dim response = client.Execute(request)
        Dim json As JObject = JObject.Parse(response.Content)
        txt_auxtoken.Text = json("authToken")



    End Sub

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
                resultado = asigna(0)
            End If
        Catch ex As Exception
            resultado = "Error"
            ex.ToString()
        End Try
        Return resultado
    End Function

    Private Sub extrae_audio(ByRef id As String, ByRef folderPath As String)
        System.Threading.Thread.Sleep(200)

        Dim client = New RestClient("http://10.18.8.216:1480/api/v1/search/callaudiowav/" & id)
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

    Private Function Obten_conversacion(ByRef id As String)

        Dim conno As New SqlConnection(cadena)


        If conno.State = ConnectionState.Closed Then
            conno.Open()
        End If


        Dim sql As String = " "
        sql = sql & "Select SpeakerNumber,REPLACE(REPLACE(CAST(Text As NVarchar(4000)),Char(34),''),char(39),'') as texto, "
        sql = sql & "StartTime from Conversacion where IdCall ='" & id & "' "
        sql = sql & "order by StartTime asc "

        Dim da As New SqlDataAdapter(sql, conno)
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

    Private Function Obten_receptor(ByRef id As String)
        Dim resultado As String = 0
        Dim consulta As String
        consulta = " "
        consulta = consulta & "select Extension from Grabaciones where IdCall = '" & id & "' "

        Try
            Dim asigna = Seleccionar(0, cadena, consulta, 1)
            If asigna(0) = "#3RR@R:01#" Then
                modal(7, "error.png", "Error al cargar los datos", " Existe_Registro() ")
            Else
                resultado = asigna(0)
            End If
        Catch ex As Exception
            resultado = "Error"
            ex.ToString()
        End Try
        Return resultado
    End Function

    Private Function Obten_emisor(ByRef id As String)
        Dim resultado As String = 0
        Dim consulta As String
        consulta = " "
        consulta = consulta & "select OtherParty from Grabaciones where IdCall = '" & id & "' "

        Try
            Dim asigna = Seleccionar(0, cadena, consulta, 1)
            If asigna(0) = "#3RR@R:01#" Then
                modal(7, "error.png", "Error al cargar los datos", " Existe_Registro() ")
            Else
                resultado = asigna(0)
            End If
        Catch ex As Exception
            resultado = "Error"
            ex.ToString()
        End Try
        Return resultado
    End Function

    Private Function Obten_datosllamada(ByRef id As String)
        Dim resultado As String = 0
        Dim consulta As String
        consulta = " "
        consulta = consulta & "SELECT top 1 [StartDateTime],[EndDateTime],[Duration],[Extension],[OtherParty]  "
        consulta = consulta & "FROM [Grabaciones] "
        consulta = consulta & "where IdCall = '" & id & "'"

        Try
            Dim asigna = Seleccionar(4, cadena, consulta, 1)
            If asigna(0) = "#3RR@R:01#" Then
                modal(7, "error.png", "Error al cargar los datos", " Existe_Registro() ")
            Else
                Lbl_fechag.Text = "Fecha de grabación: " & Mid(asigna(0), 1, 10) & " " & Mid(asigna(0), 12, 18)
                Lbl_termino.Text = "Fecha de termino: " & Mid(asigna(1), 1, 10) & " " & Mid(asigna(1), 12, 18)
                Lbl_duracion.Text = "Duración: " & Mid(asigna(2), 1, 8)
                Lbl_extension.Text = "Extension: " & asigna(3)
                Lbl_Recepcion.Text = "Emisor: " & asigna(4)
                Txt_fechaaudio.Text = Mid(asigna(0), 1, 10) & " " & Mid(asigna(0), 12, 18)
                txt_auxduracion.Text = Mid(asigna(2), 1, 8)
            End If
        Catch ex As Exception
            resultado = "Error"
            ex.ToString()
        End Try
        Return resultado
    End Function


    Private Function Obten_datosbase089(ByRef fecha As String, ByRef hora As String)
        Dim resultado As String = "0"
        Dim consulta As String = ""
        consulta = "select count(*) from ( "
        consulta = consulta & "select folio,CONVERT( TIME,hora_captura) as [x],fecha_denuncia,descipcion_hechos  from DENUNCIAS_089   "
        consulta = consulta & "where CONVERT(date,fecha_denuncia,103)='" & fecha & "' "
        consulta = consulta & ") as u "
        consulta = consulta & "where u.x  like '" & hora & "%' "
        Try
            Dim asigna = Seleccionar(0, cadena089, consulta, 1)
            If asigna(0) = "#3RR@R:01#" Then
                modal(7, "error.png", "Error al cargar los datos", " Existe_Registro() ")
            Else
                resultado = asigna(0)


            End If
        Catch ex As Exception
            resultado = "0"
            ex.ToString()
        End Try
        Return resultado
    End Function

    Private Sub Trae_datosbase089(ByRef fecha As String, ByRef hora As String)
        Dim resultado As String = "0"
        Dim consulta As String = ""
        consulta = "select u.folio,u.x,u.fecha_denuncia,u.no_oficio,u.calle,u.des_colonia,u.des_municipio,u.descripcion,u.descipcion_hechos,u.punto_referencia,u.folio_web,u.ticket_web from ( "
        consulta = consulta & "select folio,CONVERT( TIME,hora_captura) as [x],fecha_denuncia,no_oficio,calle,des_colonia,CAT_MUNICIPIOS.des_municipio,CAT_TIPO_INCIDENTE.descripcion,descipcion_hechos,punto_referencia,folio_web,ticket_web  from DENUNCIAS_089  "
        consulta = consulta & "inner join CAT_MUNICIPIOS on CAT_MUNICIPIOS.id_municipio = DENUNCIAS_089.id_municipio "
        consulta = consulta & "inner join CAT_TIPO_INCIDENTE on CAT_TIPO_INCIDENTE.id_incidente = DENUNCIAS_089.id_incidente "
        consulta = consulta & "where CONVERT(date,fecha_denuncia,103)='" & fecha & "' "
        consulta = consulta & ") as u  "
        consulta = consulta & "where u.x  like '%" & hora & "%'"

        Try
            Dim asigna = Seleccionar(11, cadena089, consulta, 1)
            If asigna(0) = "#3RR@R:01#" Then
                modal(7, "error.png", "Error al cargar los datos", " Existe_Registro() ")
            Else
                Lbl_folio.Text = "Folio: " & asigna(0)
                Lbl_oficio.Text = "Oficio: " & asigna(3)
                Lbl_calle.Text = "Calle: " & asigna(4)
                Lbl_descolonia.Text = "Colonia: " & asigna(5)
                Lbl_municipio.Text = "Municipio: " & asigna(6)
                Lbl_incidente.Text = "Incidente: " & asigna(7)
                lbl_Notas.Text = "Nota: " & asigna(8)
                Lbl_puntoreferencia.Text = "Referencia: " & asigna(9)
                lbl_folio_web.Text = "Folio web: " & asigna(10)
                lbl_ticket_web.Text = "Ticket web: " & asigna(11)



            End If

        Catch ex As Exception
            lbl_Notas.Text = "Sin registro"
            lbl_folio_web.Text = "Sin registro"
            Lbl_incidente.Text = "Sin registro"
            Lbl_municipio.Text = "Sin registro"
            Lbl_puntoreferencia.Text = "Sin registro"
            Lbl_descolonia.Text = "Sin registro"
            Lbl_calle.Text = "Sin registro"
            Lbl_oficio.Text = "Sin registro"
            Lbl_folio.Text = "Sin registro"
            lbl_ticket_web.Text = "Sin registro"
            ex.ToString()
        End Try

    End Sub



End Class
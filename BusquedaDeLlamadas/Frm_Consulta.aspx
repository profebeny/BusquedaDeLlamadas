<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="Frm_Consulta.aspx.vb" Inherits="BusquedaDeLlamadas.Frm_Consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link href="Graphik/Graphik.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://c5i-refa.hidalgo.gob.mx/css/Menu/Cards.css" />
    
    <link rel="stylesheet" href="http://c5i-refa.hidalgo.gob.mx/css/EstiloTextos2.css"/>
    <link rel="stylesheet" href="http://c5i-refa.hidalgo.gob.mx/css/FORMULARIOS/EstiloTitulos.css"/>
    <link rel="stylesheet" href="http://c5i-refa.hidalgo.gob.mx/css/FORMULARIOS/TextBox-Labels.css"/>

    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.24/css/jquery.dataTables.css">
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/select/1.3.3/css/select.dataTables.min.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" ></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" ></script>

  
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.24/js/jquery.dataTables.js"></script>
    <script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/select/1.3.3/js/dataTables.select.min.js"></script>
    <link href="css/Modalmensajes.css" rel="stylesheet" />

       <script src="http://cdn.datatables.net/plug-ins/1.10.15/dataRender/datetime.js"></script>
   <script src=" https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.18.1/moment.min.js"></script>
    <link href="css/plantilla.css" rel="stylesheet" />
    <script>
        javascript: window.history.forward(1);
        $(document).ready(function () {
            titulomenu.innerHTML = "Consultar";


            $('#tbl_alertamientos').DataTable({
                pageLength: 15,
                lengthMenu: [[5, 10, 100], [5, 10, 100]],
                "order": [[0, "desc"]],
                columns: [
                    { data: 'IdCall' },
                    { data: 'StartDateTime' },
                    { data: 'EndDateTime' },
                    { data: 'Duration' },
                    { data: 'Extension' },
                    { data: 'OtherParty' }
                ],
                "language": {
                    "decimal": ",",
                    "thousands": ".",
                    "info": "Mostrar _START_ a _END_ de _TOTAL_ registros",
                    "infoEmpty": "Sin Información",
                    "infoPostFix": "",
                    "infoFiltered": "(Filtrado de un total de  _MAX_ registros)",
                    "loadingRecords": "Espere, se están cargando datos ...",
                    "lengthMenu": "Mostrar _MENU_ registros",
                    "paginate": {
                        "first": "Primero",
                        "last": "Letzte",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    },
                    "processing": "Procesando ...",
                    "search": "Buscar:",
                    "searchPlaceholder": "Folio, Tipo, etc.",
                    "emptyTable": "Sin información"

                },
            });
            $('#tbl_alertamientos').on('click', 'tr', function () {
                var tableAsignar = $('#tbl_alertamientos').DataTable();
                var data = tableAsignar.row(this).data();
              
                document.getElementById("<%=txt_auxcallid.ClientID%>").value = data['IdCall'];
                
                var boton = document.getElementById("<%=Btn_aux.ClientID%>");
                boton.click();
            });


        });


     
        function historial_datatable(fi, ff, ext, party) {
            var tbl_alertamientos = $('#tbl_alertamientos').DataTable();
            tbl_alertamientos.ajax.url('Modelo/Dt_Grabaciones.aspx?fi=' + fi + '&ff=' + ff + '&ext=' + ext + '&party=' + party).load();
           
        }

        function modalError() {
            $('#ModalMensaje').modal('show');

        }

        function modalcarga() {
            $('#ModalCarga').modal('show');
            var boton = document.getElementById("<%=Btn_llamada.ClientID%>");
            boton.click();
        }

        function cerrarcarga() {
           
            $('#ModalCarga').modal('hide');
        }



        function cambiaraudio() {
            var txt = document.getElementById("<%=txt_auxaudio.ClientID%>").value;
            document.getElementById("my-audio").setAttribute('src', txt);
        }

        function oculta_audio() {
            var x = document.getElementById("divaudio");
            x.style.display = "none";
        }

        function muestra_audio() {
            var x = document.getElementById("divaudio");
            x.style.display = "hide";
        }

    </script>
    <style>
        .pie_pagina {
            width: 100%;
            height: auto;
            margin-left: 0%;
            padding-bottom: 20px;
            bottom: 0;
            z-index: 1;
            bottom: 0;
            display: inline-block;
            position: fixed;
            border-radius: 0px;
            background-color:#042F41 ;
            margin-top:auto;
        }

        .pie_pagina p{
        font-size:calc(.4em + .4vw);
        text-align:center;
        font-weight:400; 
        color:#ffffff
        }

        .escudo2 {
            left: 20px;
            position: absolute;
            width: auto;
            height: 72%;
            padding-right: 1%;
        }

        .escudo {
            right: 20px;
            position: absolute;
            width: auto;
            height: 75%;
            padding-right: 1%;
        }

                .boton-modal{
            margin-left: auto;
            margin-right: auto;
            width: 170px;
            height: 190px;
            border:none;
            outline:none;
            display:block;
            background-color: transparent;
            transition: transform 1s;
        }
   
        
        .header_panel_ses{
            background-color:rgba(145,145,145,255); background: linear-gradient(180deg, rgba(145,145,145,1) 37%, rgba(86,86,86,1) 67%);
            border-radius:8px;
            font-family: Graphik !important;
            font-size:calc(.4em + .8vw)!important;
            font-weight:bold!important;
            color:#ffffff !important;
            display: flex !important;


        }

        .body_panel_ses {
            background: rgba(238, 238, 238,.9) !important;
        }
        .header_panel_elemento{
            background: url("/IMAGEN/ui/fondobtnazul.png") !important;
            font-family: Graphik !important;
            font-size:calc(.4em + .5vw)!important;
            font-weight:bold!important;
            color:#ffffff !important;
            display: flex !important;
            text-align:center;
            


        }

        .body_panel_elemento {
            background: rgba(238, 238, 238,1) !important;
            min-height:200px;
            overflow-y:auto;
        }


        .btnCerrarIncidente {
           background: url("/IMAGEN/ui/header_panel.png") !important;
            font-family: Graphik !important;
            font-size:calc(.2em + 1vw)!important;
            font-weight:bold!important;
            color:#ffffff !important;
            border: none;
            padding: 8px 25px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            -moz-border-radius: 7px;
            -webkit-border-radius: 7px;
        }

        .btnCerrarIncidente:hover {
            background: url("/IMAGEN/ui/header_panel.png") !important;
            color:#ffffff !important;
            text-decoration: none;
            -moz-border-radius: 7px;
            -webkit-border-radius: 7px;
            transition: 0.2s;
            opacity: 0.7;

        }

     .btn-primary {
            background-color:rgb(195,57,72);
            border: none;
             border-bottom:0px;
            border-color:transparent;
     }

     .btn-primary:hover {
             background-color:rgba(147,10,37,1);
             border: none;
              border-bottom:0px;
             border-color:transparent;
     }

        .btnAzul {
           background: url("/IMAGEN/ui/fondobtnazul.png") !important;
            font-family: Graphik !important;
            font-size:calc(.2em + .5vw)!important;
            font-weight:bold!important;
            color:#ffffff !important;
            border: none;
            padding: 8px 25px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            -moz-border-radius: 7px;
            -webkit-border-radius: 7px;
            min-width:70%;
            margin:5px;
        }

        .btnAzul:hover {
            background: url("/IMAGEN/ui/fondobtnazul.png") !important;
            color:#ffffff !important;
            text-decoration: none;
            -moz-border-radius: 7px;
            -webkit-border-radius: 7px;
            transition: 0.2s;
            opacity: 0.7;

        }

        .subtitulo_DatosGenerales {
            font-family: Graphik !important;
            font-size:calc(.3em + .4vw)!important;
            font-weight:bold!important;
            color:#000000 !important;
        }

        .descripcion_DatosGenerales {
            font-family: Graphik !important;
            font-size:calc(.3em + .4vw)!important;
            font-weight:400!important;
            color:#000000 !important;
        }

        .txt_form{
            width:75%;
            box-shadow: none;
            background-color: rgba(0, 32, 47, 0);
            border-radius: 0px;
            width: 94%;
            color: black;
            transition: all .5s;
            border-left-style: none;
            border-left-color: #000;
            border-right-style: none;
            border-right-color: #000;
            border-top-style: none;
            border-top-color: #000;
            border-bottom-style: solid;
            border-bottom-color: #000;
            font-size: large;
            font-weight:bold;
            text-align:center;
        }


        .containerchat {
          border: 2px solid #dedede;
          background-color: #F7F5DF;
          border-radius: 5px;
          padding: 10px;
          margin: 10px 0;
        }

        .darker {
          border-color: #ccc;
           background-color: #D5EDEB;
        }

        .containerchat::after {
          content: "";
          clear: both;
          display: table;
        }

        .containerchat img {
          float: left;
          max-width: 60px;
          width: 100%;
          margin-right: 20px;
          border-radius: 50%;
        }

        .containerchat img.right {
          float: right;
          margin-left: 20px;
          margin-right:0;
        }

        .time-right {
          float: right;
          color: #aaa;
        }

        .time-left {
          float: left;
          color: #999;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row" style="margin:20px;">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 row">
             <!--División Izquierda -->
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                      <!--Alertamientos -->
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                          <div class="panel panel-default">
                            <div class="panel-heading header_panel_ses">
                                    <div class="col-xs-10 col-sm-10 col-md-10 col-lg-10 row">
                                        <div class="col-8">
                                            Registro de LLamadas
                                        </div>
                                        
                                   </div>
                                   <div class="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                                   </div>
                               
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                    
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="panel-body body_panel_ses">

                                <div class="col-12 row" id="divfechas" >
                                    <div class="col-12" style="padding:1%;">
                                        <p style="">Seleccione el rango de fechas para consultar las llamadas registrados</p>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-6 col-lg-6" style="text-align:center">
                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="Lbl_Fi" runat="server" Text="Fecha Inicial"></asp:Label>
                                                <asp:TextBox ID="Txt_Fi" runat="server" TextMode="Date" Width="80%"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-6 col-lg-6" style="text-align:center">
                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="Lbl_Ff" runat="server" Text="Fecha Final"></asp:Label>
                                                <asp:TextBox ID="Txt_Ff" runat="server" TextMode="Date" Width="80%"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-6 col-lg-6" style="text-align:center">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <br />
                                                <asp:Label ID="Lbl_ext" runat="server" Text="Extensión"></asp:Label><br />
                                                <asp:CheckBox ID="Chk_ext" runat="server" AutoPostBack="true" Text="Habilitar/Deshabilitar" /><br />
                                                <asp:TextBox ID="Txt_ext" runat="server" Width="80%" TextMode="Number"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-6 col-lg-6" style="text-align:center">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <br />
                                                <asp:Label ID="Lbl_party" runat="server" Text="Número foraneo"></asp:Label><br />
                                                 <asp:CheckBox ID="Chk_party" runat="server" AutoPostBack="true" Text="Habilitar/Deshabilitar" /><br />
                                                <asp:TextBox ID="Txt_party" runat="server" Width="80%" TextMode="Number"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-12 col-sm-12 col-md-12 col-lg-4"></div>
                                    <div class="col-12 col-sm-12 col-md-12 col-lg-4"></div>
                                    <div class="col-12 col-sm-12 col-md-12 col-lg-4" style="text-align:center">
                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                            <ContentTemplate>
                                                <br />
                                                <asp:Button ID="Btn_Buscar" runat="server"  Text="Buscar" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    
                                </div>
                                <div class="col-12" style="padding:1%;"></div>
                                <!-- CONTENIDO DEL PANEL -->
                                        <div class="table-responsive" >
                                            <table id="tbl_alertamientos" class="display" style="font-size:7pt;vertical-align:middle;text-align:center">
                                                <thead class="" style="color:#000; vertical-align:middle;text-align:center;font-family:Graphik">
                                                    <center>
                                                        <tr>
                                                            <th>IDCall</th>
                                                            <th>Fecha de grabación</th>
                                                            <th>Fecha de termino de grabación</th>
                                                            <th>Duración</th>
                                                            <th>Extensión</th>
                                                            <th>Número foraneo</th>
                                                        </tr>
                                                    </center>
                                                </thead>
                                            </table>
                                        </div>
                                <!-- CONTENIDO DEL PANEL -->
                            </div>
                          </div> 
                    </div>

            </div>
      
            <!--División Derecha -->
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                    <!--DATOS GENERALES -->
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                          <div class="panel panel-default">
                            <div class="panel-heading header_panel_ses">
                                <div class="col-xs-11 col-sm-11 col-md-11 col-lg-11">
                                        Detalles de la LLamada
                                   </div>
                                   <div class="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                              

                                   </div>
                               </div>
                              <div class="panel-body body_panel_ses">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                 <!--DATOS GENERALES IZQUIERDA -->

                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                       <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" >
                                           <br />
                                           <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                               <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                   <ContentTemplate>
                                                       <center><asp:Label ID="Lbl_llamada" runat="server" Text=""></asp:Label></center>
                                                       <br />
                                                       <asp:Label ID="Lbl_fechag" runat="server" Text=""></asp:Label><br />
                                                       <asp:Label ID="Lbl_termino" runat="server" Text=""></asp:Label><br />
                                                       <asp:Label ID="Lbl_duracion" runat="server" Text=""></asp:Label><br />
                                                       <asp:Label ID="Lbl_extension" runat="server" Text=""></asp:Label><br />
                                                       <asp:Label ID="Lbl_Recepcion" runat="server" Text=""></asp:Label><br />
                                                       <asp:Label ID="Lbl_folio" runat="server" Text=""></asp:Label><br />
                                                       <asp:Label ID="Lbl_oficio" runat="server" Text=""></asp:Label><br />
                                                       <asp:Label ID="Lbl_calle" runat="server" Text=""></asp:Label><br />
                                                       <asp:Label ID="Lbl_descolonia" runat="server" Text=""></asp:Label><br />
                                                       <asp:Label ID="Lbl_puntoreferencia" runat="server" Text=""></asp:Label><br />
                                                       <asp:Label ID="Lbl_municipio" runat="server" Text=""></asp:Label><br />
                                                       <asp:Label ID="Lbl_incidente" runat="server" Text=""></asp:Label><br />
                                                       <asp:Label ID="lbl_folio_web" runat="server" Text=""></asp:Label><br />
                                                       <asp:Label ID="lbl_ticket_web" runat="server" Text=""></asp:Label><br />
                                                   </ContentTemplate>
                                               </asp:UpdatePanel>
                                           </div>
                                           <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="overflow-y:scroll;background-color:white; max-height:500px;">
                                                <div id="chat" runat="server"></div>
                                           </div>
                                           <br />
                                        </div>
                                        <div>
                                           <div>
                                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                        <ContentTemplate>
                                                              <center><asp:Label ID="lbl_Notas" runat="server" Text=""></asp:Label></center>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                <br />
                                            </div>


                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                <ContentTemplate>
                                                      <center><asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label></center>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>


                                            <div id="divaudio">

                                                <center><audio controls="controls" id="my-audio" controlsList="nodownload">
                                                   <source  src="assets/music1.wav"  type="audio/wav" />
                                               </audio></center>
                                           </div>
                                            <br />
                                        </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                            </div>
                          </div> 
                    </div>
                </div> 
         </div>   

    </div>


            <!--------------- MODAL PARA LOS MENSAJES DE ERRRO Y ÉXITO  --------------------->
    <div class="modal fade " id="ModalMensaje" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-headerModal">
                    <h4 class="modal-title text-center" id="exampleModalLabel">Mensaje Usuario</h4>
                    <%--<button type="button" class="closeModal" data-dismiss="modal" aria-label="Aceptar">
                            <span aria-hidden="true">&times;</span>
                        </button>--%>
                </div>
                <div class="modal-body">
                    <div class="row ">
                        <div class="col-lg-3 col-lg-3 col-lg-3">
                            <asp:UpdatePanel ID="Upl_mensaje_imgane" runat="server">
                                <ContentTemplate>
                                    <asp:Image ID="Img_Mensaje" runat="server" ImageUrl="IMAGEN/MODALMENSAJES/Exito.png" Width="80px" Height="80px" />
                                </ContentTemplate>
                            </asp:UpdatePanel>


                        </div>
                        <div class="col-lg-9 col-lg-9 col-lg-9">
                            <asp:UpdatePanel ID="Upl_mensaje_modal" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Lbl_MensajeUsuario" runat="server" Text="Label" Font-Bold="True" Font-Size="Smaller"></asp:Label><br />
                                    <br />
                                    <asp:Label ID="Lbl_MensajeSistema" runat="server" Text="Label" Font-Size="Smaller"></asp:Label><br />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="modal-footerModal">
                    <button type="button" id="Btn_Aceptar" class="btn btn-primary center-block" data-dismiss="modal" aria-orientation="horizontal">Aceptar</button>
                </div>
            </div>
        </div>
    </div>
    <!--**************** FIN PARA LOS MENSAJES DE ERRRO Y ÉXITO  ***************-->



                    <!--------------- MODAL PARA LOS MENSAJES DE ERRRO Y ÉXITO  --------------------->
    <div class="modal fade " id="ModalCarga" tabindex="50" aria-labelledby="exampleModalCarga" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-headerModal" >
                    <h4 class="modal-title text-center" style="margin-top:10px;" id="exampleModalCarga">Cargando Conversación</h4>
                </div>
                <div class="modal-body">
                    <div class="row ">
                        <div class="col-lg-12 col-lg-12 col-lg-12">
                             <center><asp:Image ID="Image1" runat="server" ImageUrl="IMAGEN/loading.gif" Width="80px" Height="80px" /></center>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div style="display:none;">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txt_auxUsuario" runat="server"></asp:TextBox>
                <asp:TextBox ID="txt_auxPrivilegio" runat="server"></asp:TextBox>
                <asp:TextBox ID="txt_auxSubarea" runat="server"></asp:TextBox>
                <asp:TextBox ID="txt_auxcallid" runat="server"></asp:TextBox>
              <asp:TextBox ID="txt_auxaudio" runat="server"></asp:TextBox>
                <asp:TextBox ID="txt_auxtoken" runat="server"></asp:TextBox>
                <asp:Button ID="Btn_aux" runat="server" Text="Button" />
                <asp:Button ID="Btn_llamada" runat="server" Text="Button" />
                <asp:TextBox ID="Txt_fechaaudio" runat="server"></asp:TextBox>
                 <asp:TextBox ID="txt_auxduracion" runat="server"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


</asp:Content>

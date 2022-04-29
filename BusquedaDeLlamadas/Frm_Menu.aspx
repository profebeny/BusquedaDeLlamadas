<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="Frm_Menu.aspx.vb" Inherits="BusquedaDeLlamadas.Frm_Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <%--<link href="css/Menu/Cards.css" rel="stylesheet" />
    <link href="css/Footer/EstiloPiePagina.css" rel="stylesheet" />
    <link href="css/MODAL_MENSAJES/Modalmensajes.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Menu/Contenedor.css" rel="stylesheet" />
    <script src="bootstrap/js/popper.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>--%>

          <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
          <link href="bootstrap3.4.1/bootstrap.min.css" rel="stylesheet" />
          <link href="Graphik/Graphik.css" rel="stylesheet" />
          <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <!-- =============== PIE DE PÁGINA  -->

    <link href="css/EstiloPiePagina2.css" rel="stylesheet" />
    <link href="bootstrap3.4.1/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="http://187.174.102.137/CDN/LOGIN/sb-admin-2.css" />
    <%--css tomados del c5i-refa --%>
    <link rel="stylesheet" href="http://c5i-refa.hidalgo.gob.mx/css/Menu/Cards.css" />

    <link rel="stylesheet" href="http://c5i-refa.hidalgo.gob.mx/css/EstiloTextos2.css" />
    <link rel="stylesheet" href="http://c5i-refa.hidalgo.gob.mx/css/FORMULARIOS/EstiloTitulos.css" />
    <link rel="stylesheet" href="http://c5i-refa.hidalgo.gob.mx/css/FORMULARIOS/TextBox-Labels.css" />
    <link rel="stylesheet" href="css/MODAL_MENSAJES/Modalmensajes.css" />

        <script>
        javascript:window.history.forward(1); //Esto es para cuando le pulse al botón de Atrás
        //javascript:window.history.back(1); //Esto para cuando le pulse al botón> de Adelante

        window.onload = function () {
            mensajes();


        }

        function mensajes() {

            
            var resumen = document.getElementById("resumen");
            var titulo = document.getElementById("titulo");
            var c5 = "<b>área de Desarrollo de Tecnologías del Centro de Control, Comando, Comunicaciones, Cómputo, Coordinación e Inteligencia (C5i) del Estado de Hidalgo</b>"
            resumen.innerHTML = "A iniciativa de la Coordinación General del Centro de Control, Comando, Comunicaciones, Cómputo, Coordinación e Inteligencia (C5i) del Estado de Hidalgo, el capital humano de la Dirección de Desarrollo de Tecnologías diseñó esta plataforma que permitiera enviar alertamientos al 9-1-1 de C5i del Estado de Hidalgo por medio una App que estará vinculada para que el personal que labora en las empresas de seguridad privada de los fraccionamiento y o negocios  autorizados por la Unidad de Registro y Supervisión de Seguridad Privada de la Secretaría de Seguridad Pública de Hidalgo, dicha  dependencia estatal es la facultada para otorgar la autorización para el funcionamiento y operación de los servicios de seguridad privada en la entidad."

          
        }

        function modaltipo() {
            $('#modalopciones').modal('show');
        }




        </script>

    <style>
        #contenedorTexto{
            margin-left: 10px;
            margin-right: 50px;
            text-align: justify;
            font-size: medium;
        }

        .entrada{
            transition: transform 1s;
        }

        .entrada:hover{
            transform: scale(1.1);                      
        }

        .salida{
            transition: transform 1s;
        }

        .salida:hover{
            transform: scale(1.1);                      
        }

        .consulta{
            transition: transform 1s;
        }

        .consulta:hover{
            transform: scale(1.1);                      
        }

        #resumen{
            background-color:#FFF;
            opacity: 0.8; 
            color:black; 
            font-size: larger;
        }

        .fondomodal {
                background-color:#D8DDE0; 
                margin-top:-1.4%; 
                margin-bottom:-1.4%;
        }


        @media (max-width: 908px) {
            #resumen {
                font-size: medium;
            }

            .fondomodal {
                margin-top:-6%; 
                margin-bottom:-1.4%;
            }


        }


       @media (max-width: 1199px) {
            .fondomodal {
                margin-top:-2%; 
                margin-bottom:-1.9%;
            }
        }


       @media (max-width: 991px) {
            .fondomodal {
                margin-top:-4%; 
                margin-bottom:-1.4%;
            }
        }


        @media (max-width: 463px) {
            .fondomodal {
                margin-top:-4%; 
                margin-bottom:-1.4%;
            }
        }

       @media (max-width: 408px) {
            .fondomodal {
                margin-top:-5%; 
                margin-bottom:-1.4%;
            }
        }


       @media (max-width: 277px) {
            .fondomodal {
                margin-top:-8%; 
                margin-bottom:-1.4%;
            }
        }


        @media (max-width: 213px) {
            .fondomodal {
                margin-top:-14%; 
                margin-bottom:-1.4%;
            }
        }

        @media (max-width: 190px) {
            .fondomodal {
                margin-top:-14%; 
                margin-bottom:-1.4%;
            }
        }


        footer {
            display:none;
        }
        #resumen{
            background-color:transparent;
            opacity: 0.8; 
            color:black; 
            font-size: larger;
        }

        .divboton {
            background-color:rgb(4,47,65);
            background: linear-gradient(180deg, rgba(12,66,96,1) 56%,rgba(0,29,49,1) 91%);
            margin-top:auto;
            margin-bottom:auto;
            border-radius:40px;
            min-width:280px;
            padding:10%;
        }

        .divboton:hover {
           cursor: pointer;
                
            filter: brightness(1.10);
        }

        .btnimagen {
        }
            .btnimagen:hover {
                  transform: scale(1.1);
            }

    </style>

 


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div class="formBox" style="overflow-x: hidden">
        <br />
        <div class="row" style="margin-bottom:55px;">
           <div class="col-6">
               <br />
               <br />
               <br />
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                   <ContentTemplate>
                     
                     <center><asp:ImageButton ID="Btn_Consultar" runat="server" ImageUrl="~/IMAGEN/lupa.png" Width=22% Height="42%" style="z-index:10;background:white;border-radius:50%;" class="btnimagen"/></center>
                      <br />
                      <div class="row d-flex justify-content-center">
                 
                            <div class="modal-body-RNS-s" style="display: flex; justify-content: center; flex-wrap: wrap;">
                                <div class="divboton" style="" onclick="modaltipo();"> 
                                      <center><asp:Label ID="Label1" runat="server" Text="Consultar" Font-Bold="True" Font-Size="large" ForeColor="White"></asp:Label></center>                        
                                </div>
                            </div>
                      </div>
                 </ContentTemplate></asp:UpdatePanel>  
               <br />
            </div>
           <div class="col-6">
                <br />
               <div id="contenedorTexto" style="background:white;padding:2%;outline:8px;outline-color:blue;">
                    <div>
                        <h1 class="text-left" id="titulo">¡Bienvenido!</h1>
                        <hr id="linea" />
                    </div>
                    <div class="container-fluid" id="resumen">                        
                    </div>
               </div>
                
           </div>
        </div>                    
    </div>

       <style>
            .imagen {
                  width: 90%;
                  height: auto;
                  
            }
            
            .imagen2 {
                  width: 76%;
                  height: auto;
            }

            .izq {
                margin-left:8%;
            }

        </style>

    <div class="modal fade bd-example-modal-lg" id="modalopciones" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">

            <div class="modal-dialog modal-lg " role="document" >
                  <div class="modal-content">

                         <div class="modal-headerModal">
                              <h4 class="modal-title text-center" style="margin-top:10px;" id="exampleModalRecargaa">Seleccione opción</h4>
                          </div>

                         <div class="modal-body" >
                             <div class="row">
                                 <div class="col-12 row">
                                     <div class="col-12 col-sm-12 col-md-12 col-lg-6" >
                                         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                             <ContentTemplate>
                                                 <asp:ImageButton ID="Btn089" runat="server"  ImageUrl="~/IMAGEN/089.png" CssClass="btnimagen" Style="width:70%;" />
                                             </ContentTemplate>
                                         </asp:UpdatePanel>
                                     </div>
                                     <div class="col-12 col-sm-12 col-md-12 col-lg-6" >
                                         <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                             <ContentTemplate>
                                                 <asp:ImageButton ID="Btn911" runat="server" ImageUrl="~/IMAGEN/911.png" CssClass="btnimagen" Style="width:70%;"/>
                                             </ContentTemplate>
                                         </asp:UpdatePanel>
                                     </div>

                                 </div>
                             </div>             

                         </div>
                         <div class="modal-footer">
                                               
                                                                                      
                         </div>
                   </div>
            </div>
        </div>





    

</asp:Content>

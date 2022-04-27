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
            var titulomenu = document.getElementById("titulomenu");
            titulomenu.innerHTML = "Menu"

        }

        function mensajes() {

            
            var resumen = document.getElementById("resumen");
            var titulo = document.getElementById("titulo");
            var c5 = "<b>área de Desarrollo de Tecnologías del Centro de Control, Comando, Comunicaciones, Cómputo, Coordinación e Inteligencia (C5i) del Estado de Hidalgo</b>"
            resumen.innerHTML = "A iniciativa de la Coordinación General del Centro de Control, Comando, Comunicaciones, Cómputo, Coordinación e Inteligencia (C5i) del Estado de Hidalgo, el capital humano de la Dirección de Desarrollo de Tecnologías diseñó esta plataforma que permitiera enviar alertamientos al 9-1-1 de C5i del Estado de Hidalgo por medio una App que estará vinculada para que el personal que labora en las empresas de seguridad privada de los fraccionamiento y o negocios  autorizados por la Unidad de Registro y Supervisión de Seguridad Privada de la Secretaría de Seguridad Pública de Hidalgo, dicha  dependencia estatal es la facultada para otorgar la autorización para el funcionamiento y operación de los servicios de seguridad privada en la entidad."

          
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
    </style>

 


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <div class="formBox" style="overflow-x: hidden">
        <br />
        <div class="row" style="margin-bottom:55px;">
           <div class="col-6">
              <asp:UpdatePanel ID="UpdatePanel13" runat="server"><ContentTemplate>
                <div  id="divepresas" runat="server"  class="row d-flex justify-content-center">
                    <asp:ImageButton ID="Btn_Procesar" runat="server" ImageUrl="~/IMAGEN/procesar.png" Width=22% Height="42%" style="z-index:10" CssClass="entrada"/>
                    <div class="modal-body-RNS-s" style="display: flex; justify-content: flex-start; flex-wrap: wrap;" > 
                        <div style="background-color:rgb(4,47,65);background: linear-gradient(180deg, rgba(12,66,96,1) 56%,rgba(0,29,49,1) 91%);margin-top:auto;margin-bottom:auto;border-radius:30px;padding-left: 70px;padding-right: 30px;margin-left:-50px;padding-top:25px;padding-bottom:25px;min-width:280px;">
                            <asp:Label ID="Label3" runat="server" Text="Procesar" Font-Bold="True" Font-Size="large" ForeColor="white" ></asp:Label>                        
                        </div>                            
                    </div>
                </div>
                </ContentTemplate></asp:UpdatePanel>  
               <br />
               <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                <div class="row d-flex justify-content-center">
                    <asp:ImageButton ID="Btn_Consultar" runat="server" ImageUrl="~/IMAGEN/consultar.png" Width=22% Height="42%" style="z-index:10" CssClass="salida"/>
                    <div class="modal-body-RNS-s" style="display: flex; justify-content: center; flex-wrap: wrap;">
                    <div style="background-color:rgb(4,47,65);background: linear-gradient(180deg, rgba(12,66,96,1) 56%,rgba(0,29,49,1) 91%);margin-top:auto;margin-bottom:auto;border-radius:30px;padding-left: 70px;padding-right: 30px;margin-left:-50px;padding-top:25px;padding-bottom:25px;min-width:280px;"> 
                            <asp:Label ID="Label1" runat="server" Text="Consultar" Font-Bold="True" Font-Size="large" ForeColor="White"></asp:Label>                        
                    </div>
                </div>
                </div>
                 </ContentTemplate></asp:UpdatePanel>  
               <br />
            </div>
           <div class="col-6">
                <br />
               <div id="contenedorTexto">
                    <div>
                        <h1 class="text-left" id="titulo">¡Bienvenido!</h1>
                        <hr id="linea" />
                    </div>
                    <div class="container-fluid" id="resumen">                        
                    </div>
               </div>
                
           </div>
        </div>                    
        <br /><br />
        
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


        <footer style="width:100%; margin-left:0%; margin-top:19px;position:page">	    
            <div>
                <img class="escudo" src="IMAGEN/LOGIN/escudo_blanco.svg" align="right" width="5%" height="4%" style="padding-top:1%; padding-right:1%"/>
		        <img class="escudo2" src="IMAGEN/LOGIN/Logo_hgo_2019.png" align="left" width="5%" height="4%"style="padding-top:1%; padding-left:5px;" />
                <p style="text-align:center" >© 2022 Gobierno del Estado de Hidalgo. Derechos Reservados<br/>
                        Secretaría de Seguridad Pública<br/>
                        Centro de Control, Comando, Comunicaciones, Cómputo, Coordinación e Inteligencia<br/>
                        Dirección de Desarrollo de Tecnologías  V 2.1
                </p>
            </div>
         </footer>	
    </div>

</asp:Content>

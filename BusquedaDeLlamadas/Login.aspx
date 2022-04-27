<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="BusquedaDeLlamadas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <title>Consulta de llamadas anonimas o consulta de llamadas</title>
    <%--<link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>--%>
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet"/>
<%--   <link href="https://187.174.102.137/CDN/CSS/sb-admin-2.css" rel="stylesheet"/>--%>
    <link href="css/sb-admin-2.css" rel="stylesheet" />
    <link href="css/EstiloPiePagina.css" rel="stylesheet" />
     <link href="css/resoluciones-login.css" rel="stylesheet" />


    <style>
  .btn-primary {
    color: #fff;
    background-color: #103b52;
    border-color: #30f5ff;
    border-width: 2px;
}

    .btn-primary:hover {
        color: #fff;
        background-color: #447a87;
        border-color: #30f5ff;
        border-width: 2px;
    }
    </style>
</head>
<body>
    <style type='text/css'>
             body { background-image: Url("/IMAGEN/fondo.png") !important; overflow-x:hidden;background-size:cover; background-repeat:no-repeat;}
    </style>

    <form id="form1" runat="server">
        <div class="container">
                    <!-- Outer Row -->
            <div class="row justify-content-center">
                <div class="col-xl-10 col-lg-12 col-md-9">
                    <div class="card o-hidden border-0 shadow-lg my-5">
                        <div class="card-body p-0">
                            <!-- Nested Row within Card Body -->
                            <div class="row">
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <div class="col-lg-6">
                                    <div class="p-5">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4" style="font-weight:900">Iniciar sesión</h1>
                                            <p>Ingresar a la plataforma</p>
                                        </div>                                       
                                        <br />
                                            <div class="form-group">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                       <asp:TextBox ID="Txt_usuario" runat="server" placeholder="Usuario" class="form-control form-control-user"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="form-group">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                       <asp:TextBox ID="txt_Password"  runat="server" TextMode="Password" placeholder="Contraseña" class="form-control form-control-user"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <asp:Label ID="lbl_validar" runat="server" Visible="true" Style="color: red; font-size:small"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />                                           
                                            <br />
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    
                                                    <asp:Button ID="Btn_Ingresar" runat="server" Text="Ingresar" class="btn btn-primary btn-user btn-block"  style="background:#05052B;border-radius:3em;" />
                                                        
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
                                            <div class="form-group" id="divlogo">
                                                <br />
                                                <center><img src="IMAGEN/c5i_logo.png"  style="width: 40%; height: auto;" /></center>
                                                <center><h6 style="margin-top:5px; margin-bottom:0px">Sistema creado por el área de</h6></center>
                                                <center><b>Desarrollo de Tecnólogias del C5i de Hidalgo.</b></center>
                                            </div>                                            
                                       <%-- <hr/>--%>
                                    </div>
                                </div>
                                <div style="background-image:url(IMAGEN/cllaportada.png); background-size:cover; background-repeat:no-repeat " class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </form>


          <footer id="pie" style="width:101.1%;  margin-bottom:0%; bottom: 0; z-index:1; margin-top:10px; position:fixed; border-top:1px solid green; border-radius:0px;margin-left:-2px; background-color:#161D2E;opacity:0.7; ">	    
             <br />   
             <div style="position:relative">
                    <img class="escudo" src="IMAGEN/escudo_blanco.svg" align="right" width="4%" height="3%" style="padding-top:-1%; padding-right:1%"/>
		            <img class="escudo2" src="IMAGEN/escudo_blanco.svg" align="left" width="4%" height="3%" style="padding-left:10px;" />
                   <p style="text-align:center;font-size:8pt; font-weight:402; color:white"> © 2021 Gobierno del Estado de Hidalgo. Derechos Reservados<br/>
                        Secretaría de Seguridad Pública<br />    
                        Centro de Control, Comando, Comunicaciones, Cómputo, Coordinación e Inteligencia<br/>
                        Dirección de Desarrollo de Tecnologías  V 1.0
                    </p>

            </div>
         </footer>	

</body>
</html>

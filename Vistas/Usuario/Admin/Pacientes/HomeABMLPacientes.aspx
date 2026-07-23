<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeABMLPacientes.aspx.cs" Inherits="Vistas.Usuario.Admin.Pacientes.HomeABMLPacientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>GESTIÓN PACIENTES</title>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style4 {
            background-color: white;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style5 {
            background-color: white;
            width: 34%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <table class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="auto-style4">
                    <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/Usuario/Admin/Home.aspx" CssClass="hylink-limpio" Style="display: block; text-align: left; margin-left: 25px;">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="lblAbmlPacientes" runat="server" CssClass="titulo" Text="GESTIÓN PACIENTES" Style="display: block; text-align: center"></asp:Label>
                </td>
                <td class="auto-style5">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;"> 	
                    <asp:HyperLink ID="lblUsuario" runat="server">Usuario: </asp:HyperLink>
                    &nbsp;<asp:HyperLink ID="lblUsuarioLogueado" runat="server" ForeColor="SteelBlue" Style="margin-right: 25px;">[lblUsuarioLogueado]</asp:HyperLink>
                    </div>
                </td>
            </tr>
        </table>

            <table class="centrado-recuadro">
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <div class="recuadro-opciones" style="color: #333333">
                        Seleccione la funcionalidad a realizar:<br />
                        <br />
                        <asp:HyperLink ID="hlAltaPaciente" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Pacientes/AltaPaciente.aspx">REGISTRAR NUEVO PACIENTE</asp:HyperLink>
                            <br />
                        <br />
                        <asp:HyperLink ID="hlListadoPacientes0" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Pacientes/AltaLogicaPaciente.aspx">REACTIVAR PACIENTE</asp:HyperLink>
                            <br />
                            <br />
                        <asp:HyperLink ID="hlBajaPaciente" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Pacientes/BajaPacientes.aspx">BAJA PACIENTE</asp:HyperLink>
                            <br />
                        <br />
                        <asp:HyperLink ID="hlListadoPacientes" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Pacientes/ListadoPacientes.aspx">LISTADO DE PACIENTES</asp:HyperLink>
                            <br />
                        <br />
                        <asp:HyperLink ID="hlModificarPaciente" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Pacientes/ModificacionPaciente.aspx">MODIFICAR PACIENTE</asp:HyperLink>
                    </td>
                    </div>
                </tr>
            </table>

    </form>
</body>
</html>
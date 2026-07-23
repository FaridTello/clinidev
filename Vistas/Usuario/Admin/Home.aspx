<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Vistas.Usuario.Admin.Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Home</title>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
    .auto-style3 {
        background-color: white;
        text-align: center;
        width: 33%;
        height: 45px;
        margin-bottom: 50px;
        font-weight: 700;
        color: #666666;
    }
    .auto-style4 {
        font-size: 35px;
        color: steelblue;
    }

        .auto-style5 {
            background-color: white;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style6 {
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

        <table class="centrado-recuadro" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td class="auto-style3">
                <asp:HyperLink ID="hlHome"
                    runat="server"
                    NavigateUrl="~/Usuario/Login.aspx"
                    Font-Bold="True" CssClass="salir" Style="display: block; text-align: left; margin-left: 25px;" Width="144px">SALIR</asp:HyperLink>
            </td>

            <td style="text-align:center" class="auto-style5">
                <asp:Label ID="lblAltaPaciente"
                    runat="server"
                    CssClass="auto-style4"
                    Text="HOME" Style="display: block; text-align: center;"></asp:Label>
            </td>

            <td class="auto-style6">
                <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
&nbsp;<asp:HyperLink ID="lblUsuarioLogueado"
                    runat="server"
                    Font-Bold="True" ForeColor="SteelBlue" Style="margin-right: 25px;">[lblUsuarioLogueado]</asp:HyperLink>
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
                        <div class="recuadro-opciones">
                        <asp:HyperLink ID="hlABMLmedico" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Medicos/ABML Médicos/HomeABMLMedicos.aspx">GESTIÓN DE MÉDICOS</asp:HyperLink>
                            <br />
                            <br />
                        <asp:HyperLink ID="hlABMLpaciente" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Pacientes/HomeABMLPacientes.aspx">GESTIÓN DE PACIENTES</asp:HyperLink>
                            <br />
                            <br />
                        <asp:HyperLink ID="hlABMLpaciente0" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Medicos/ABML Horarios/HomeABMLHorarios.aspx">GESTIÓN HORARIOS MÉDICOS</asp:HyperLink>
                            <br />
                            <br />
                        <asp:HyperLink ID="hlAsignacionTurnos" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Turnos/HomeABMLTurnos.aspx">GESTIÓN TURNOS</asp:HyperLink>
                            <br />
                            <br />
                        <asp:HyperLink ID="hlInformes" runat="server" CssClass="botones2" NavigateUrl="~/Usuario/Admin/Informes/HomeInformes.aspx">INFORMES</asp:HyperLink>
                            </div>
                    </td>
                </tr>
            </table>

    </form>
</body>
</html>
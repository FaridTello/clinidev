<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeABMLTurnos.aspx.cs" Inherits="Vistas.Usuario.Admin.Turnos.HomeABMLTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

<title>GESTIÓN DE TURNOS</title>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
<link href="~/Estilos.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style1 {
            height: 76px;
        }
        .auto-style2 {
            height: 24px;
        }
        .auto-style3 {
            font-size: 35px;
            font-weight: 700;
            color: steelblue;
            margin-left: 0px;
        }
        .auto-style4 {
            background-color: white;
            text-align: center;
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
                <asp:HyperLink ID="hlHome"
                    runat="server"
                    NavigateUrl="~/Usuario/Admin/Home.aspx"
                    Font-Bold="True" CssClass="hylink-limpio" Style="display: block; text-align: left; margin-left: 25px;" Width="85px">VOLVER</asp:HyperLink>
            </td>

            <td style="text-align:center" class="auto-style5">
                <asp:Label ID="lblAbmlMedicos"
                    runat="server"
                    CssClass="auto-style3"
                    Text="GESTIÓN TURNOS" Style="display: block; text-align: center;"></asp:Label>
            </td>

            <td class="auto-style5">
                <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
&nbsp;<asp:Label ID="lblUsuario" runat="server" Style="margin-right: 25px;" ForeColor="SteelBlue"></asp:Label>
                </div>
            </td>

        </tr>

    </table>

    <div class="contenido">

        <table class="centrado-recuadro">

            <tr>
                <td class="auto-style2">
                </td>
            </tr>

            <tr>
                <td class="auto-style1">
                    <div class="recuadro-opciones" style="#333333">
            Seleccione la funcionalidad a realizar:
        <br />
                    <br />
                    <asp:HyperLink ID="hlAltaMedico"
                        runat="server"
                        NavigateUrl="~/Usuario/Admin/Turnos/AsignarTurno.aspx" CssClass="botones2">NUEVO TURNO
                    </asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="hlAltaMedico0"
                        runat="server"
                        NavigateUrl="~/Usuario/Admin/Turnos/AltaLogicaTurnos.aspx" CssClass="botones2">REACTIVAR TURNO
                    </asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="hlBajaMedico"
                        runat="server"
                        NavigateUrl="~/Usuario/Admin/Turnos/BajaLogicaTurno.aspx" CssClass="botones2">
                        BAJA TURNO
                    </asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="hlListadoMedicos"
                        runat="server"
                        NavigateUrl="~/Usuario/Admin/Turnos/ListadoTurnos.aspx" CssClass="botones2">
                        LISTADO DE TURNOS
                    </asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="hlModificarMedico"
                        runat="server"
                        NavigateUrl="~/Usuario/Admin/Turnos/ModificarTurno.aspx" CssClass="botones2">
                        MODIFICAR TURNO
                    </asp:HyperLink>
                </div>
                </td>
            </tr>

            <tr>
                <td>
                    &nbsp;</td>
            </tr>

            <tr>
                <td>
                    &nbsp;</td>
            </tr>

            <tr>
                <td>
                    &nbsp;</td>
            </tr>

            <tr>
                <td>
                    &nbsp;</td>
            </tr>

        </table>

    </div>

</form>

</body>
</html>

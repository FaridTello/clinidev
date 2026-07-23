<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarTurno.aspx.cs" Inherits="Vistas.Usuario.Admin.Turnos.AsignarTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>NUEVO TURNO</title>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style1 {
            width: 8px;
        }
        .auto-style2 {
            background-color: white;
            text-align: center;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style3 {
            background-color: white;
            text-align: center;
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

    <table  class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0">
        <tr>

            <td class="auto-style2">
                <asp:HyperLink ID="hpAsignarTurno"
                    runat="server"
                    NavigateUrl="~/Usuario/Admin/Turnos/HomeABMLTurnos.aspx"
                    BorderStyle="None" CssClass="hylink-limpio" Style="display: block; text-align: left; margin-left: 25px;">VOLVER</asp:HyperLink>
            </td>

            <td style="text-align:center" class="auto-style2">
                <asp:Label ID="lblAsignar"
                    runat="server"
                    CssClass="titulo"
                    Text="NUEVO TURNO" Style="display: block; text-align: center;"></asp:Label>
            </td>

            <td class="auto-style3">
                <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                &nbsp;<asp:Label ID="lblUsuario" runat="server" Style="margin-right: 25px;" ForeColor="SteelBlue"></asp:Label>
                    </div>
            </td>

        </tr>
    </table>

    <div class="contenido">

        <table>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td style="color: #333333">Especialidad:&nbsp;&nbsp; </td>
                <td>
                    <asp:DropDownList ID="ddlEspecialidad"
                        runat="server"
                        AutoPostBack="True"
                        OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr><td class="auto-style1">&nbsp;</td><td colspan="2">&nbsp;</td></tr>

            <tr>
                <td class="auto-style1"><strong></strong></td>
                <td style="color: #333333">Médico:</td>
                <td>
                    <asp:DropDownList ID="ddlMedico"
                        runat="server"
                        AutoPostBack="True"
                        OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr><td class="auto-style1">&nbsp;</td><td colspan="2">&nbsp;</td></tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td style="color: #333333">Paciente:</td>
                <td>
                    <asp:DropDownList ID="ddlPaciente" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr><td class="auto-style1">&nbsp;</td><td colspan="2">&nbsp;</td></tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td style="color: #333333">Fecha:</td>
                <td>
                    <asp:TextBox ID="txtFecha"
                        runat="server"
                        TextMode="Date"
                        AutoPostBack="True"
                        OnTextChanged="txtFecha_TextChanged">
                    </asp:TextBox>
                </td>
            </tr>

            <tr><td class="auto-style1">&nbsp;</td><td colspan="2">&nbsp;</td></tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td style="color: #333333">Horario:</td>
                <td>
                    <asp:DropDownList ID="ddlHorario"
                        runat="server"
                        Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr><td class="auto-style1">&nbsp;</td><td colspan="2">&nbsp;</td></tr>

            <tr>

                <td class="auto-style1">
                    &nbsp;</td>

                <td>
                    <asp:Button ID="btnGuardar"
                        runat="server"
                        Text="Guardar"
                        Style="font-weight:700"
                        OnClick="btnGuardar_Click" CssClass="botones-grises" />
                </td>

                <td>
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>

            </tr>

        </table>

    </div>

</form>

</body>
</html>

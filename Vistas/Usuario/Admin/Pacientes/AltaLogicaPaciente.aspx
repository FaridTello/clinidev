<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaLogicaPaciente.aspx.cs" Inherits="Vistas.Usuario.Admin.Pacientes.AltaLogicaPaciente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>REACTIVAR PACIENTE</title>
    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 18px;
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
            font-size: 35px;
            font-weight: 700;
            color: steelblue;
            margin-left: 0px;
        }
        .auto-style5 {
            background-color: #dddddd;
            border-radius: 5px;
            color: steelblue;
            font-weight: 600;
            border: solid 1px steelblue;
            font-size: 20px;
            text-decoration: none;
            display: inline-block;
        }

            .auto-style5:hover {
                background-color: steelblue;
                color: white;
            }

        .auto-style6 {
            margin-left: 17px;
        }
        .auto-style7 {
            width: 82px;
        }
        .auto-style8 {
            width: 7px;
        }
        #gvAltaPacientes td, #gvAltaPacientes th {
    border: 1px solid #cccccc;
        }

        .auto-style9 {
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
                <td class="auto-style2">
                    <asp:HyperLink ID="hlABMLpaciente" runat="server"  NavigateUrl="~/Usuario/Admin/Pacientes/HomeABMLPacientes.aspx" CssClass="hylink-limpio" Style="display: block; text-align: left; margin-left: 25px;" Width="292px">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="lblBajaMed" runat="server" CssClass="auto-style3" Text="REACTIVAR PACIENTE" Style="display: block; text-align: center;"></asp:Label>
                </td>
                <td class="auto-style9">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                    &nbsp;<asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                    &nbsp;<asp:Label ID="lblUsuarioLogueado" runat="server" ForeColor="SteelBlue" Style="margin-right: 25px;"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>

      
            <table class="tabla-form">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td style="color: #333333">ID a buscar: </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtLegajoMedico" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="botones-grises" />
                    </td>
                    <td>
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr><td class="auto-style1">&nbsp;</td><td colspan="4">&nbsp;</td><td>&nbsp;</td></tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" CssClass="auto-style5" Height="30px" Width="107px" />
                    </td>
                    <td class="auto-style7">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="auto-style5" Height="30px" Width="107px" />
                    </td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr><td class="auto-style1">&nbsp;</td><td colspan="4">&nbsp;</td><td>&nbsp;</td></tr>
            </table>

            <asp:GridView ID="gvAltaPacientes" runat="server" CellPadding="4" GridLines="None" ForeColor="#333333" CssClass="auto-style6">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

    </form>
</body>
</html>
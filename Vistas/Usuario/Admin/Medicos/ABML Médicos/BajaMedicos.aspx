<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaMedicos.aspx.cs" Inherits="Vistas.Usuario.Admin.Medicos.BajaMedicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>BAJA MÉDICO
    </title>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style5 {
            width: 8px;
        }
        .auto-style6 {
            width: 89px;
        }
        .auto-style7 {
            background-color: #dddddd;
            border-radius: 5px;
            color: steelblue;
            font-weight: 600;
            border: solid 1px steelblue;
            font-size: 20px;
            text-decoration: none;
            display: inline-block;
        }
            .auto-style7:hover {
                background-color: steelblue;
                color: white;
            }
        .auto-style8 {
            margin-left: 17px;
        }
        .auto-style9 {
            margin-left: 7px;
        }
        .auto-style10 {
            width: 7px;
        }
        #gvBajaMedicos td, #gvBajaMedicos th {
    border: 1px solid #cccccc;
        }
        .auto-style12 {
            background-color: white;
            width: 318px;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style13 {
            width: 954px;
            height: 51px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

        <table class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="auto-style12">
                    <asp:HyperLink ID="hlABMLpaciente" runat="server" CssClass="hylink-limpio" NavigateUrl="~/Usuario/Admin/Medicos/ABML Médicos/HomeABMLMedicos.aspx" Style="display: block; text-align: left; margin-left: 25px;">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style12">
                    <asp:Label ID="lblBajaMed" runat="server" CssClass="titulo" Text="BAJA MÉDICO" Style="display: block; text-align: center;"></asp:Label>
                </td>
                <td class="auto-style12">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                    <asp:HyperLink ID="lblUsuario" runat="server">Usuario: </asp:HyperLink>
                    &nbsp;<asp:HyperLink ID="lblUsuarioLogueado" runat="server" Style="margin-right: 25px;" ForeColor="SteelBlue">[lblUsuarioLogueado]</asp:HyperLink>
                    </div>
                </td>
            </tr>
        </table>

        <div class="contenido">
            <table>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td class="auto-style10">
                        &nbsp;</td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td style="color: #333333">Legajo a buscar:</td>
                    <td>
                        <asp:TextBox ID="txtLegajoMedico" runat="server" CssClass="auto-style9"></asp:TextBox>
                    </td>
                    <td class="auto-style10">
                        &nbsp;</td>
                    <td class="auto-style6">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="botones-grises" />
                    </td>
                    <td>
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr><td class="auto-style5">&nbsp;</td><td colspan="4">&nbsp;</td><td>&nbsp;</td></tr>
                <tr>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" CssClass="botones-grises" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="auto-style7" Width="117px" />
                    </td>
                    <td class="auto-style10">
                        &nbsp;</td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr><td class="auto-style5">&nbsp;</td><td colspan="4">&nbsp;</td><td>&nbsp;</td></tr>
            </table>

            <asp:GridView ID="gvBajaMedicos" runat="server" CellPadding="4" GridLines="None" ForeColor="#333333" CssClass="auto-style8">
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
        </div>

    </form>
</body>
</html>
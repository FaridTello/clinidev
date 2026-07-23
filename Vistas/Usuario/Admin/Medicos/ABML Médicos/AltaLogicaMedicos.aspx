<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaLogicaMedicos.aspx.cs" Inherits="Vistas.Usuario.Admin.Medicos.AltaLogicaMedicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>REACTIVAR MÉDICO</title>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />


   

    <style type="text/css">
        .auto-style2 {
            width: 12px;
        }
        .auto-style4 {
            width: 89px;
        }
        .auto-style5 {
            width: 100%;
            height: 51px;
        }
        .auto-style6 {
            background-color: white;
            text-align: center;
            width: 33%;
            height: 45px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style7 {
            background-color: white;
            text-align: center;
            width: 34%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style8 {
            width: 115px;
        }
        .auto-style10 {
            background-color: #dddddd;
            border-radius: 5px;
            color: steelblue;
            font-weight: 600;
            border: solid 1px steelblue;
            font-size: 20px;
            text-decoration: none;
            display: inline-block;
        }

            .auto-style10:hover {
                background-color: steelblue;
                color: white;
            }

        .auto-style11 {
            width: 504px;
        }
        .auto-style12 {
            width: 7px;
        }
        .auto-style13 {
            margin-left: 17px;
        }
        .auto-style14 {
            width: 8px;
        }
        #gvAltaMedicos td, #gvAltaMedicos th {
    border: 1px solid #cccccc;
}
        .auto-style15 {
            background-color: white;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
    </style>


   

</head>
<body>
    <form id="form2" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" class="auto-style5">
            <tr>
                <td class="auto-style6">
                        <asp:HyperLink ID="hlABMLpaciente" runat="server" NavigateUrl="~/Usuario/Admin/Medicos/ABML Médicos/HomeABMLMedicos.aspx" CssClass="hylink-limpio" Style="display: block; text-align: left; margin-left: 25px;">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style15">
                        <asp:Label ID="lblBajaMed" runat="server" CssClass="titulo" Style="display: block; text-align: center;" Text="REACTIVAR MÉDICO" ></asp:Label>
                </td>
                <td class="auto-style7">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                        <asp:HyperLink ID="lblUsuario" runat="server">Usuario: </asp:HyperLink>
                        &nbsp;<asp:HyperLink ID="lblUsuarioLogueado" runat="server" ForeColor="SteelBlue" Style="margin-right: 25px;">[lblUsuarioLogueado]</asp:HyperLink>
                    </div>
                </td>
            </tr>
        </table>

        <div class="contenido">
            <table>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td class="auto-style12">
                        &nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style8" style="color: #333333">Legajo a buscar:</td>
                    <td>
                        <asp:TextBox ID="txtLegajoMedico" runat="server" Width="105px"></asp:TextBox>
                    </td>
                    <td class="auto-style12">
                        &nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="botones-grises" />
                    </td>
                    <td class="auto-style11">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr><td class="auto-style14">&nbsp;</td><td colspan="4">&nbsp;</td><td class="auto-style11">&nbsp;</td></tr>
                <tr>
                    <td class="auto-style14">
                        &nbsp;</td>
                    <td class="auto-style8">
                        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" CssClass="auto-style10" Width="115px" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="auto-style10" Width="115px" />
                    </td>
                    <td class="auto-style12">
                        &nbsp;</td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                </tr>
                <tr><td class="auto-style14">&nbsp;</td><td colspan="4">&nbsp;</td><td class="auto-style11">&nbsp;</td></tr>
            </table>

            <asp:GridView ID="gvAltaMedicos" runat="server" CellPadding="4" GridLines="None" ForeColor="#333333" CssClass="auto-style13">
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
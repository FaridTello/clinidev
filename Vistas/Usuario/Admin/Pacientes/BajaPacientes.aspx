<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaPacientes.aspx.cs" Inherits="Vistas.Usuario.Admin.Pacientes.BajaPacientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>BAJA PACIENTE</title>
    
    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style1 {
            margin-left: 17px;
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
        .auto-style4 {
            width: 9px;
        }
        .auto-style5 {
            width: 8px;
        }
        #gvBajaPaciente td, #gvBajaPaciente th {
    border: 1px solid #cccccc;
        }
        .auto-style6 {
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
    <form id="form1" runat="server">

        <table class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="auto-style2">
                    <asp:HyperLink ID="hlAtras" runat="server" NavigateUrl="~/Usuario/Admin/Pacientes/HomeABMLPacientes.aspx" CssClass="hylink-limpio" Style="display: block; text-align: left; margin-left: 25px;">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style6" >
                    <asp:Label ID="lblBaja" runat="server" CssClass="titulo" Text="BAJA PACIENTE" Style="display: block; text-align: center;"></asp:Label>
                </td>
                <td class="auto-style3">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                    &nbsp;<asp:Label ID="lblUsuario" runat="server" Font-Bold="True" Text="Usuario:"></asp:Label>
                    &nbsp;<asp:Label ID="lblUsuarioLogueado" runat="server" ForeColor="SteelBlue" Style="margin-right: 25px;"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>

        
            <table>
                <tr>
                    <td style="color: #333333" class="auto-style4">&nbsp;</td>
                    <td style="color: #333333">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="color: #333333" class="auto-style4">&nbsp;</td>
                    <td style="color: #333333">ID a buscar:&nbsp;&nbsp; </td>
                    <td>
                        <asp:TextBox ID="txtLegajoPaciente" runat="server" MaxLength="8" TextMode="Number"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="botones-grises" />
                    </td>
                </tr>
                <tr><td class="auto-style4">&nbsp;</td><td>&nbsp;</td></tr>
                <tr>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td colspan="4">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnConfirmar" runat="server" style="font-weight: 700" Text="Confirmar" OnClick="btnConfirmar_Click" CssClass="botones-grises" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" style="font-weight: 700" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="botones-grises" />
                    </td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr><td class="auto-style4">&nbsp;</td><td colspan="4">&nbsp;</td></tr>
            </table>

            <asp:GridView ID="gvBajaPaciente" runat="server" CellPadding="4" GridLines="None" ForeColor="#333333" CssClass="auto-style1">
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
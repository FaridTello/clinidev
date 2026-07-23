<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoMedicos.aspx.cs" Inherits="Vistas.Usuario.Admin.Medicos.ListadoMedicos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LISTADO DE MÉDICOS</title>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style1 {
            background-color: white;
            text-align: center;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style2 {
            background-color: white;
            text-align: center;
            width: 34%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style3 {
            width: 16px;
        }
        .auto-style4 {
            background-color: #dddddd;
            border-radius: 5px;
            color: steelblue;
            font-weight: 600;
            border: solid 1px steelblue;
            font-size: 20px;
            text-decoration: none;
            display: inline-block;
        }

            .auto-style4:hover {
                background-color: steelblue;
                color: white;
            }
        .auto-style5 {
            margin-left: 17px;
        }
        .auto-style6 {
            width: 190px;
        }
        #gvMedicos td, #gvMedicos th {
            border: 1px solid #cccccc;
        }
        .auto-style7 {
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

        <table class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="auto-style1">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Usuario/Admin/Medicos/ABML Médicos/HomeABMLMedicos.aspx" CssClass="hylink-limpio" Style="display: block; text-align: left; margin-left: 25px;">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style7">
                    <asp:Label ID="lblPacientes" runat="server" CssClass="titulo" Text="LISTADO DE MÉDICOS" Style="display: block; text-align: center;"></asp:Label>
                </td>
                <td class="auto-style2">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                    <asp:Label ID="lblUsuario" runat="server" Font-Bold="True" Text="Usuario:"></asp:Label>
                    &nbsp;<asp:Label ID="lblUsuarioLogueado" runat="server" ForeColor="SteelBlue" Style="margin-right: 25px;"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>

        <div class="contenido">
            <table class="tabla-form">
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td class="auto-style6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td style="color: #333333">Buscar por nombre:&nbsp;&nbsp; </td>
                    <td>
                        <asp:TextBox ID="txtBuscarNombre" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td style="color: #333333">Filtrar por provincia: </td>
                    <td>
                        <asp:DropDownList ID="ddlProvincia" runat="server"></asp:DropDownList>
                    </td>
                    <td class="auto-style6">
                        &nbsp;</td>
                </tr>
                <tr><td class="auto-style3">&nbsp;</td><td colspan="2">&nbsp;</td><td class="auto-style6">&nbsp;</td></tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td colspan="2">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="auto-style4" Height="30px" Width="90px" />
                        &nbsp;
                        <asp:Button ID="btnLimpiarFiltro" runat="server" Text="Limpiar Filtros" OnClick="btnLimpiarFiltro_Click" CssClass="auto-style4" Height="30px" Width="148px" />
                    </td>
                    <td class="auto-style6">
                        &nbsp;</td>
                </tr>
                <tr><td class="auto-style3">&nbsp;</td><td colspan="2">&nbsp;</td><td class="auto-style6">&nbsp;</td></tr>
            </table>

            <asp:GridView ID="gvMedicos" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvMedicos_PageIndexChanging" CellPadding="4" GridLines="None" ForeColor="#333333" CssClass="auto-style5" PageSize="5">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                    <asp:BoundField HeaderText="DNI" DataField="DNI" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                    <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" />
                    <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha de Nacimiento" />
                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo Electrónico" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                </Columns>
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
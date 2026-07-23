<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoPacientes.aspx.cs" Inherits="Vistas.Usuario.Admin.Pacientes.ListadoPacientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LISTADO DE PACIENTES</title>

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
            background-color: white;
            text-align: center;
            width: 34%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style5 {
            margin-left: 17px;
        }
        .auto-style6 {
            background-color: #dddddd;
            border-radius: 5px;
            color: steelblue;
            font-weight: 600;
            border: solid 1px steelblue;
            font-size: 20px;
            text-decoration: none;
            display: inline-block;
        }

            .auto-style6:hover {
                background-color: steelblue;
                color: white;
            }


        .auto-style7 {
            height: 13px;
        }
        .auto-style8 {
            height: 13px;
            width: 16px;
        }
        .auto-style9 {
            width: 16px;
        }
        .auto-style10 {
            height: 13px;
            width: 209px;
        }
        .auto-style11 {
            width: 209px;
        }
        .auto-style12 {
            height: 13px;
            width: 9px;
        }
        .auto-style13 {
            width: 9px;
        }
        #gvPacientes td, #gvPacientes th {
    border: 1px solid #cccccc;
        }
        .auto-style14 {
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
                <td class="auto-style3" >
                    <asp:HyperLink ID="hlABMLpaciente" runat="server"  NavigateUrl="~/Usuario/Admin/Pacientes/HomeABMLPacientes.aspx" CssClass="hylink-limpio" Style="display: block; text-align: left; margin-left: 25px;">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style14" >
                    <asp:Label ID="lblPacientes" runat="server" CssClass="titulo" Text="LISTADO DE PACIENTES" Style="display: block; text-align: center;"></asp:Label>
                </td>
                <td class="auto-style4" >
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;"> 
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                    &nbsp;<asp:Label ID="lblUsuarioLogueado" runat="server" ForeColor="SteelBlue" Style="margin-right: 25px;"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>


            <table>
                <tr>
                    <td style="color: #333333" class="auto-style8"></td>
                    <td style="color: #333333" class="auto-style7"></td>
                    <td class="auto-style7">
                    </td>
                    <td class="auto-style12">
                        &nbsp;</td>
                    <td class="auto-style10">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="color: #333333" class="auto-style9">&nbsp;</td>
                    <td style="color: #333333">Buscar por nombre:&nbsp;&nbsp;&nbsp; </td>
                    <td>
                        <asp:TextBox ID="txtBuscarNombre" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style13">
                        &nbsp;</td>
                    <td class="auto-style11">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="color: #333333" class="auto-style9">&nbsp;</td>
                    <td style="color: #333333">Filtrar por provincia:</td>
                    <td>
                        <asp:DropDownList ID="ddlProvincias" runat="server"></asp:DropDownList>
                    </td>
                    <td class="auto-style13">
                        &nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                </tr>
                <tr><td class="auto-style9">&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td class="auto-style13">&nbsp;</td><td class="auto-style11">&nbsp;</td></tr>
                <tr>
                    <td class="auto-style9" >
                        &nbsp;</td>
                    <td colspan="2" >
                        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" ViewStateMode="Enabled" CssClass="auto-style6" Height="30px" Width="90px" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnLimpiarFiltros" runat="server" OnClick="btnLimpiarFiltros_Click" Text="Limpiar Filtros" Width="152px" CssClass="auto-style6" Height="30px" />
                    </td>
                    <td class="auto-style13" >
                        &nbsp;</td>
                    <td class="auto-style11" >
                        &nbsp;</td>
                </tr>
                <tr><td class="auto-style9">&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td class="auto-style13">&nbsp;</td><td class="auto-style11">&nbsp;</td></tr>
            </table>

            <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnPageIndexChanging="gvPacientes_PageIndexChanging" OnRowEditing="gvPacientes_RowEditing" OnRowDeleting="gvPacientes_RowDeleting" AllowPaging="True" PageSize="5" CellPadding="4" GridLines="None" ForeColor="#333333" CssClass="auto-style5">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="DNI" DataField="DNI" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                    <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                    <asp:BoundField DataField="Nacionalidad" HeaderText="Nacionalidad" />
                    <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha de Nacimiento" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo Electrónico" />
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
    </form>
</body>
</html>
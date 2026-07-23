<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoHorarioMedico.aspx.cs" Inherits="Vistas.Usuario.Admin.Medicos.ABML_Horarios.ListadoHorarioMedico" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LISTADO HORARIOS</title>
    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style2 {
            margin-left: 17px;
        }
        .auto-style3 {
            width: 8px;
        }
        .auto-style5 {
            background-color: white;
            text-align: center;
            width: 34%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style6 {
            background-color: white;
            text-align: center;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style8 {
            font-size: 35px;
            font-weight: 700;
            color: steelblue;
            margin-left: 0px;
        }
        #gvHorarios td, #gvHorarios th {
    border: 1px solid #cccccc;
        }
        .auto-style9 {
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

        <table class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0"
            <tr>
                <td class="auto-style6">
                    <asp:HyperLink ID="hlHorarios" runat="server" Style="display: block; text-align: left; margin-left: 25px;" NavigateUrl="~/Usuario/Admin/Medicos/ABML Horarios/HomeABMLHorarios.aspx" CssClass="hylink-limpio" Width="237px">VOLVER</asp:HyperLink>
                </td>
                <td style="text-align: center" class="auto-style9" aria-dropeffect="none">
                    <asp:Label ID="lblListadoHorario" runat="server" CssClass="auto-style8" Text="LISTADO HORARIOS MÉDICOS" Style="display: block; text-align: center;" Font-Size="X-Large"></asp:Label>
                </td>
                <td class="auto-style5">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;"> 	
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Usuario:"></asp:Label>
                    &nbsp;<asp:Label ID="lblUsuario" runat="server" Style="margin-right: 25px;" ForeColor="SteelBlue"></asp:Label>
                        </div>
                </td>
            </tr>
        </table>

        <div class="contenido">
            <table class="tabla-form">
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="lblNombreyApellido" runat="server" Text="Nombre y Apellido:" ForeColor="#333333"></asp:Label>
                    &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombreyApellido" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="lblDia" runat="server" Text="Dia de la semana:" ForeColor="#333333"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDia" runat="server">
                            <asp:ListItem Value="-1">-- Seleccionar --</asp:ListItem>
                            <asp:ListItem Value="Lunes">Lunes</asp:ListItem>
                            <asp:ListItem Value="Martes">Martes</asp:ListItem>
                            <asp:ListItem Value="Miercoles">Miercoles</asp:ListItem>
                            <asp:ListItem Value="Jueves">Jueves</asp:ListItem>
                            <asp:ListItem Value="Viernes">Viernes</asp:ListItem>
                            <asp:ListItem Value="Sabado">Sabado</asp:ListItem>
                            <asp:ListItem Value="Domingo">Domingo</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr><td class="auto-style3">&nbsp;</td><td colspan="4">&nbsp;</td></tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td colspan="4">
                        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" CssClass="botones-grises" Width="118px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar filtros" CssClass="botones-grises" Width="139px" />
                    </td>
                </tr>
                <tr><td class="auto-style3">&nbsp;</td><td colspan="4">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    <br />
                    </td></tr>
            </table>

            <asp:GridView ID="gvHorarios" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnSelectedIndexChanged="gvHorarios_SelectedIndexChanged" CssClass="auto-style2" ForeColor="#333333" AllowPaging="True" PageSize="5" OnPageIndexChanging="gvHorarios_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="IdHorario" HeaderText="ID" />
                    <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                    <asp:BoundField DataField="Medico" HeaderText="Medico" />
                    <asp:BoundField DataField="Dia" HeaderText="Día" />
                    <asp:BoundField DataField="HorarioInicio" HeaderText="Inicio" />
                    <asp:BoundField DataField="HorarioFin" HeaderText="Fin" />
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
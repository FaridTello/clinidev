<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarHorarioMedico.aspx.cs" Inherits="Vistas.Usuario.Admin.Medicos.ABML_Horarios.ModificarHorarioMedico" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MODIFICAR HORARIO</title>
    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 8px;
        }
        .auto-style2 {
            margin-left: 17px;
        }
        .auto-style3 {
            width: 8px;
            height: 24px;
        }
        .auto-style4 {
            height: 24px;
        }
        .auto-style6 {
            background-color: white;
            text-align: center;
            width: 34%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style7 {
            background-color: white;
            text-align: center;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
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

        <table class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="auto-style7">
                    <asp:HyperLink ID="hlHorarios" runat="server" Style="display: block; text-align: left; margin-left: 25px;" NavigateUrl="~/Usuario/Admin/Medicos/ABML Horarios/HomeABMLHorarios.aspx" CssClass="hylink-limpio" Height="22px" Width="110px">VOLVER</asp:HyperLink>
                </td>
                <td style="text-align: center" class="auto-style9">
                    <asp:Label ID="lblModificarHorario" runat="server" CssClass="titulo" Text="MODIFICAR HORARIO MÉDICO" Style="display: block; text-align: center;" Font-Size="X-Large"></asp:Label>
                </td>
                <td class="auto-style6">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                    <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
&nbsp;<asp:Label ID="lblUsuario" runat="server" Style="margin-right: 25px;" ForeColor="SteelBlue"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>

        <div class="contenido">
            <table class="tabla-form">
                <tr>
                    <td class="auto-style1">
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
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="lblNombreHorario" runat="server" Text="Ingrese Id Horario Medico:" ForeColor="#333333"></asp:Label>
                    &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtIdHorarioMedico" runat="server" Width="170px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="botones-grises" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                    </td>
                    <td colspan="4" class="auto-style4">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr><td class="auto-style1">&nbsp;</td><td colspan="4">&nbsp;</td></tr>
            </table>

            <asp:GridView ID="gvHorarios" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowEditing="gvHorarios_RowEditing" OnRowCancelingEdit="gvHorarios_RowCancelingEdit" OnRowUpdating="gvHorarios_RowUpdating" AutoGenerateEditButton="True" ForeColor="#333333" CssClass="auto-style2">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="IdHorario" Visible="False">
    <EditItemTemplate>
        <asp:Label ID="lbl_eit_IdHorario" runat="server" Text='<%# Eval("IdHorario") %>'></asp:Label>
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Label ID="lbl_it_IdHorario" runat="server" Text='<%# Eval("IdHorario") %>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
                    <asp:BoundField DataField="Medico" HeaderText="Medico" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Día">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Dia" runat="server" Text='<%# Eval("Dia") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_dias" runat="server" SelectedValue='<%# Bind("Dia") %>'>
                                <asp:ListItem Value="Lunes">Lunes</asp:ListItem>
                                <asp:ListItem Value="Martes">Martes</asp:ListItem>
                                <asp:ListItem Value="Miercoles">Miercoles</asp:ListItem>
                                <asp:ListItem Value="Jueves">Jueves</asp:ListItem>
                                <asp:ListItem Value="Viernes">Viernes</asp:ListItem>
                                <asp:ListItem Value="Sabado">Sabado</asp:ListItem>
                                <asp:ListItem Value="Domingo">Domingo</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Inicio">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Inicio" runat="server" Text='<%# Eval("Inicio") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Inicio" runat="server" Text='<%# Bind("Inicio") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fin">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Fin" runat="server" Text='<%# Eval("Fin") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_Fin" runat="server" Text='<%# Bind("Fin") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Estado" HeaderText="Estado" ReadOnly="True" />
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
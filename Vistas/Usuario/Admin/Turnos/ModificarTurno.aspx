<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarTurno.aspx.cs" Inherits="Vistas.Usuario.Admin.Turnos.ModificarTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MODIFICAR TURNO</title>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
<link href="~/Estilos.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style1 {
            height: 37px;
        }
        .auto-style2 {
            margin-left: 17px;
        }
        .auto-style3 {
            height: 24px;
        }
        .auto-style4 {
            height: 24px;
            width: 8px;
        }
        .auto-style5 {
            height: 37px;
            width: 8px;
        }
        .auto-style6 {
            width: 8px;
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
        .auto-style8 {
            background-color: white;
            text-align: center;
            width: 34%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        #gvTurnos td, #gvTurnos th {
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
                <asp:HyperLink ID="hlHorarios"
                    runat="server"
                    NavigateUrl="~/Usuario/Admin/Turnos/HomeABMLTurnos.aspx"
                   Style="display: block; text-align: left; margin-left: 25px;" CssClass="hylink-limpio">VOLVER</asp:HyperLink>
            </td>

            <td style="text-align:center" class="auto-style9">
                <asp:Label ID="lblListadoHorario"
                    runat="server"
                    CssClass="titulo"
                    Text="MODIFICAR TURNO" Style="display: block; text-align: center;"></asp:Label>
            </td>

            <td class="auto-style8">
                <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
&nbsp;<asp:Label ID="lblUsuarioLogueado" runat="server" Style="margin-right: 25px;" ForeColor="SteelBlue"></asp:Label>
                </div>
            </td>

        </tr>
    </table>

    <div class="contenido">

        <table>

            <tr>

                <td class="auto-style4" style="color: #333333"></td>

                <td class="auto-style3" style="color: #333333"></td>

                <td class="auto-style3">
                </td>

                <td class="auto-style3">
                </td>

                <td class="auto-style3">
                </td>

            </tr>

            <tr>

                <td class="auto-style5" style="color: #333333">&nbsp;</td>

                <td class="auto-style1" style="color: #333333">Ingrese el ID del Turno:&nbsp;&nbsp; </td>

                <td class="auto-style1">
                    <asp:TextBox ID="txtIdTurno"
                        runat="server"
                        TextMode="Number">
                    </asp:TextBox>
                </td>

                <td class="auto-style1">
                </td>

                <td class="auto-style1">
                    <asp:Button ID="btnBuscar"
                        runat="server"
                        Text="Buscar"
                        OnClick="btnBuscar_Click" CssClass="botones-grises" />
                </td>

            </tr>

            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td colspan="4">&nbsp;</td>
            </tr>

        </table>

        <asp:GridView ID="GvTurnos"
            runat="server"
            AutoGenerateColumns="False"
            AutoGenerateEditButton="True"
            OnRowCancelingEdit="GvTurnos_RowCancelingEdit"
            OnRowEditing="GvTurnos_RowEditing"
            OnRowUpdating="GvTurnos_RowUpdating"
            CellPadding="4"
            GridLines="None" CssClass="auto-style2" ForeColor="#333333">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>

                <asp:TemplateField HeaderText="ID Turno">
                    <EditItemTemplate>
                        <asp:Label ID="lbl_eit_IdTurno" runat="server" Text='<%# Bind("IdTurno") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_IdTurno" runat="server" Text='<%# Bind("IdTurno") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Paciente">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_eit_Paciente" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Paciente" runat="server" Text='<%# Bind("Paciente") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Especialidad">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_eit_Especialidad"
                            runat="server"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="ddl_eit_Especialidad_SelectedIndexChanged">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Especialidad" runat="server" Text='<%# Bind("Especialidad") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Médico">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_eit_Medico"
                            runat="server"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="ddl_eit_Medico_SelectedIndexChanged">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Medico" runat="server" Text='<%# Bind("Medico") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fecha">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_eit_Fecha"
                            runat="server"
                            TextMode="Date"
                            AutoPostBack="True"
                            OnTextChanged="txt_eit_Fecha_TextChanged"
                            Text='<%# Bind("Fecha_Turno_T", "{0:yyyy-MM-dd}") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Fecha"
                            runat="server"
                            Text='<%# Bind("Fecha_Turno_T", "{0:dd/MM/yyyy}") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Horario">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_eit_Horario" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_it_Horario" runat="server" Text='<%# Bind("HorarioInicio") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

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

        <br />

        &nbsp;&nbsp;&nbsp;

        <asp:Label ID="lblMensaje"
            runat="server"
            Font-Bold="False"></asp:Label>

    </div>

</form>

</body>
</html>
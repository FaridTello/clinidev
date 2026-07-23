<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnosMedico.aspx.cs" Inherits="Vistas.Usuario.Medico.TurnosMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>TURNOS</title>

    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />
    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />

    <style type="text/css">
        .auto-style1 {
            width: 8px;
        }
        .auto-style2 {
            margin-left: 17px;
        }
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
        #gvTurnos td, #gvTurnos th {
    border: 1px solid #cccccc;
        }
    </style>

</head>

<body>

<form id="form1" runat="server">

    <table class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0">

        <tr>

            <td class="auto-style3">

                <asp:HyperLink ID="hlHome"
                    runat="server"
                    NavigateUrl="~/Usuario/Login.aspx"
                    Style="display: block; text-align: left; margin-left: 25px;" CssClass="hylink-limpio">VOLVER</asp:HyperLink>

            </td>

            <td style="text-align:center" class="barra-superior">

                <asp:Label ID="lblTitulo"
                    runat="server"
                    CssClass="titulo"
                    Text="TURNOS ASIGNADOS" Style="display: block; text-align: center;"></asp:Label>

            </td>

            <td class="auto-style4">

                <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;"> 
                &nbsp;<asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
&nbsp;<asp:Label ID="lblUsuario"
                    runat="server"
                    Style="margin-right: 25px;" ForeColor="SteelBlue"></asp:Label>
                </div>

            </td>

        </tr>

    </table>

    <div class="contenido">

        <table>

            <tr>

                <td style="color: #333333" class="auto-style1">&nbsp;</td>

                <td style="color: #333333">&nbsp;</td>

                <td>
                    &nbsp;</td>

                <td style="width:25px">&nbsp;</td>

                <td style="color: #333333">&nbsp;</td>

                <td>
                    &nbsp;</td>

            </tr>

            <tr>

                <td style="color: #333333" class="auto-style1">&nbsp;</td>

                <td style="color: #333333">Buscar paciente:</td>

                <td>
                    <asp:TextBox ID="txtNombreApellido" runat="server"></asp:TextBox>
                </td>

                <td style="width:25px"></td>

                <td style="color: #333333">Fecha:</td>

                <td>
                    <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
                </td>

            </tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="5">&nbsp;</td>
            </tr>

            <tr>

                <td style="color: #333333" class="auto-style1">&nbsp;</td>

                <td style="color: #333333">Presentismo:</td>

                <td>

                    <asp:DropDownList ID="ddlPresentismo" runat="server">

                        <asp:ListItem>Todos</asp:ListItem>
                        <asp:ListItem>Pendiente</asp:ListItem>
                        <asp:ListItem>Presente</asp:ListItem>
                        <asp:ListItem>Ausente</asp:ListItem>

                    </asp:DropDownList>

                </td>

                <td>

                    <asp:Button ID="btnBuscar"
                        runat="server"
                        Text="Buscar"
                        OnClick="btnBuscar_Click" CssClass="botones-grises" />

                </td>

                <td colspan="2">

                    <asp:Label ID="lblMensaje"
                        runat="server"
                        Font-Bold="True">
                    </asp:Label>

                </td>

            </tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="5">&nbsp;</td>
            </tr>

        </table>

        <asp:GridView ID="gvTurnos"
            runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="IdTurno"
            OnRowCommand="gvTurnos_RowCommand"
            OnRowEditing="gvTurnos_RowEditing"
            OnRowUpdating="gvTurnos_RowUpdating"
            OnRowCancelingEdit="gvTurnos_RowCancelingEdit"
            CellPadding="4"
            GridLines="None" ForeColor="#333333" CssClass="auto-style2">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>

                <asp:CommandField ShowEditButton="True" />

                <asp:BoundField DataField="Fecha"
                    HeaderText="Fecha"
                    ReadOnly="True" />

                <asp:BoundField DataField="HoraInicio"
                    HeaderText="Hora Inicio"
                    ReadOnly="True" />

                <asp:BoundField DataField="HoraFin"
                    HeaderText="Hora Fin"
                    ReadOnly="True" />

                <asp:BoundField DataField="DNI"
                    HeaderText="DNI"
                    ReadOnly="True" />

                <asp:BoundField DataField="Paciente"
                    HeaderText="Paciente"
                    ReadOnly="True" />

                <asp:TemplateField HeaderText="Presentismo">

    <ItemTemplate>
        <asp:Label ID="lblPresentismo"
            runat="server"
            Text='<%# Eval("Presentismo") == DBNull.Value ? "Pendiente" : Convert.ToBoolean(Eval("Presentismo")) ? "Presente" : "Ausente" %>'>
        </asp:Label>
    </ItemTemplate>

    <EditItemTemplate>
        <asp:DropDownList ID="ddlPresentismo"
            runat="server">
            <asp:ListItem Value="-1">-- Seleccionar --</asp:ListItem>
            <asp:ListItem Value="1">Presente</asp:ListItem>
            <asp:ListItem Value="0">Ausente</asp:ListItem>
        </asp:DropDownList>
    </EditItemTemplate>

</asp:TemplateField>

                <asp:TemplateField HeaderText="Observación">

                    <ItemTemplate>

                        <asp:Label ID="lblObservacion"
                            runat="server"
                            Text='<%# Eval("Observacion") %>'>
                        </asp:Label>

                    </ItemTemplate>

                    <EditItemTemplate>

                        <asp:TextBox ID="txtObservacion"
                            runat="server"
                            Width="250px"
                            Text='<%# Eval("Observacion") %>'>
                        </asp:TextBox>

                    </EditItemTemplate>

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

    </div>

</form>

</body>
</html>
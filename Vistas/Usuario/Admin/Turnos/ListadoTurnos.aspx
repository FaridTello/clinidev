<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoTurnos.aspx.cs" Inherits="Vistas.Usuario.Admin.Turnos.ListadoTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>LISTADO TURNOS</title>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style1 {
            width: 9px;
        }
        .auto-style2 {
            width: 212px;
        }
        .auto-style3 {
            margin-left: 17px;
        }
        .auto-style7 {
            width: 215px;
        }
        #gvTurnos td, #gvTurnos th {
    border: 1px solid #cccccc;
        }
        .auto-style9 {
            background-color: white;
            width: 318px;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style10 {
            width: 954px;
            height: 51px;
        }
    </style>

</head>

<body>

<form id="form1" runat="server">

    <table class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0"
        <tr>

            <td class="auto-style9">
                <asp:HyperLink ID="hlHorarios"
                    runat="server"
                    NavigateUrl="~/Usuario/Admin/Turnos/HomeABMLTurnos.aspx"
                    Style="display: block; text-align: left; margin-left: 25px;" CssClass="hylink-limpio">VOLVER</asp:HyperLink>
            </td>

            <td  class="auto-style9">
                <asp:Label ID="lblListadoHorario"
                    runat="server"
                    CssClass="titulo"
                    Text="LISTADO DE TURNOS" Style="display: block; text-align: center;"></asp:Label>
            </td>

            <td class="auto-style9">
                <div  style="display: flex; justify-content: flex-end; align-items: center; width: 100%;"> 
                <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
&nbsp<asp:Label ID="lblUsuario" runat="server" Style="margin-right: 25px;" ForeColor="SteelBlue"></asp:Label>
                    </div>
            </td>

        </tr>
    </table>

    <div class="contenido">

        <table>

            <tr>
                <td class="auto-style1" style="color: #333333">&nbsp;</td>

                <td style="color: #333333" class="auto-style7">&nbsp;</td>

                <td>
                    &nbsp;</td>

                <td>
                    &nbsp;</td>

                <td>
                    &nbsp;</td>

                <td class="auto-style2">
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style1" style="color: #333333">&nbsp;</td>

                <td style="color: #333333" class="auto-style7">Nombre y Apellido del Médico:&nbsp;&nbsp; </td>

                <td>
                    <asp:TextBox ID="txtBuscarMedico" runat="server"></asp:TextBox>
                </td>

                <td>
                    &nbsp;</td>

                <td>
                    &nbsp;</td>

                <td class="auto-style2">
                    &nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="4">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>

            <tr>

                <td class="auto-style1" style="color: #333333">&nbsp;</td>

                <td style="color: #333333" class="auto-style7">Presentismo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>

                <td>
                    <asp:DropDownList ID="ddlPresentismo" runat="server">
                        <asp:ListItem Value="-1">-- Todos --</asp:ListItem>
                        <asp:ListItem Value="1">Presente</asp:ListItem>
                        <asp:ListItem Value="0">Ausente</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td>&nbsp;</td>

                <td></td>

                <td class="auto-style2">&nbsp;</td>

            </tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="4">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBuscar"
                        runat="server"
                        Text="Buscar"
                        OnClick="btnBuscar_Click" CssClass="botones-grises" Width="130px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLimpiar"
                        runat="server"
                        Text="Limpiar filtros"
                        OnClick="btnLimpiar_Click" CssClass="botones-grises" Width="152px" />
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    </td>
            </tr>

            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td colspan="4">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>

            </table>

        <asp:GridView ID="gvTurnos"
            runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="IdTurno"
            OnPageIndexChanging="gvTurnos_PageIndexChanging"
            AllowPaging="True"
            PageSize="5"
            CellPadding="4"
            GridLines="None" CssClass="auto-style3" ForeColor="#333333">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>

                <asp:BoundField DataField="IdTurno" HeaderText="ID Turno" />
                <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                <asp:BoundField DataField="Medico" HeaderText="Médico" />
                <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
                <asp:BoundField DataField="HorarioInicio" HeaderText="Horario Inicio" />
                <asp:BoundField DataField="HorarioFin" HeaderText="Horario Fin" />
                <asp:BoundField DataField="FechaTurno" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha del Turno" />
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

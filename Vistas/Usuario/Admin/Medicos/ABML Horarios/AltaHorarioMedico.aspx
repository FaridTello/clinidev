<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaHorarioMedico.aspx.cs" Inherits="Vistas.Usuario.Admin.Medicos.Horarios.AltaHorarioMedico" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>NUEVO HORARIO MÉDICO</title>
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
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <table class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="hlHorarios" runat="server" Style="display: block; text-align: left; margin-left: 25px;" NavigateUrl="~/Usuario/Admin/Medicos/ABML Horarios/HomeABMLHorarios.aspx" CssClass="hylink-limpio">VOLVER</asp:HyperLink>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="lblPagina" runat="server" CssClass="titulo" Text="NUEVO HORARIO MEDICO" Style="display: block; text-align: center;"></asp:Label>
                </td>
                <td class="auto-style5">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                    <asp:Label ID="Label2" runat="server" Text="Usuario:"></asp:Label>
&nbsp;<asp:Label ID="lblUsuario" runat="server" ForeColor="SteelBlue" Style="margin-right: 25px;"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>

       
            <table class="tabla-form">
                <tr>
                    <td class="auto-style1">
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
                        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr><td class="auto-style1">&nbsp;</td><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="lblMedico" runat="server" Text="Medico:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMedico" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr><td class="auto-style1">&nbsp;</td><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <td style="vertical-align: top; padding-top: 5px;" class="auto-style1">
                        &nbsp;</td>
                    <td style="vertical-align: top; padding-top: 5px;">
                        <asp:Label ID="lblDiasAtencion" runat="server" Text="Dias de atencion:"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBoxList ID="cblDias" runat="server" Width="120px">
                            <asp:ListItem>Lunes</asp:ListItem>
                            <asp:ListItem>Martes</asp:ListItem>
                            <asp:ListItem>Miercoles</asp:ListItem>
                            <asp:ListItem>Jueves</asp:ListItem>
                            <asp:ListItem>Viernes</asp:ListItem>
                            <asp:ListItem>Sabado</asp:ListItem>
                            <asp:ListItem>Domingo</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr><td class="auto-style1">&nbsp;</td><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Horario INICIO:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHorarioInicio" runat="server" TextMode="Time" step="3600"></asp:TextBox>
                    </td>
                </tr>
                <tr><td class="auto-style1">&nbsp;</td><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="lblHorarioFin" runat="server" Text="Horario FIN:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHorarioFin" runat="server" TextMode="Time" step="3600"></asp:TextBox>
                    </td>
                </tr>
                <tr><td class="auto-style1">&nbsp;</td><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="botones-grises" />
                    </td>
                    <td>
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr><td class="auto-style1">&nbsp;</td><td colspan="2">&nbsp;</td></tr>
            </table>

            <asp:GridView ID="gvAsignados" runat="server" AutoGenerateColumns="False" DataKeyNames="Id_Horario_HM" OnSelectedIndexChanged="gvAsignados_SelectedIndexChanged" CellPadding="4" GridLines="None" ForeColor="#333333" CssClass="auto-style2">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Dia_HM" HeaderText="Día" />
                    <asp:BoundField DataField="Horario_Inicio_HM" HeaderText="Inicio" />
                    <asp:BoundField DataField="Horario_Fin_HM" HeaderText="Fin" />
                    <asp:BoundField DataField="Estado_HM" HeaderText="Estado" />
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
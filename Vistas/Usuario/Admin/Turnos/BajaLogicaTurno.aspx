<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaLogicaTurno.aspx.cs" Inherits="Vistas.Usuario.Admin.Turnos.BajaLogicaTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>BAJA TURNO</title>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style1 {
            width: 506px;
        }
        .auto-style2 {
            margin-left: 17px;
        }
        .auto-style3 {
            background-color: #dddddd;
            border-radius: 5px;
            color: steelblue;
            font-weight: 600;
            border: solid 1px steelblue;
            font-size: 20px;
            text-decoration: none;
            display: inline-block;
        }
            .auto-style3:hover {
                background-color: steelblue;
                color: white;
            }

        .auto-style4 {
            width: 8px;
        }
        .auto-style5 {
            width: 8px;
            height: 41px;
        }
        .auto-style6 {
            height: 41px;
        }
        .auto-style7 {
            width: 506px;
            height: 41px;
        }
        .auto-style8 {
            background-color: white;
            text-align: center;
            width: 33%;
            height: 45px;
            margin-bottom: 50px;
            font-weight: 700;
            color: #666666;
        }
        .auto-style9 {
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
        .auto-style10 {
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

            <td class="auto-style8">
                <asp:HyperLink ID="hlBajaTurno"
                    runat="server"
                    NavigateUrl="~/Usuario/Admin/Turnos/HomeABMLTurnos.aspx"
                    Style="display: block; text-align: left; margin-left: 25px;" CssClass="hylink-limpio">VOLVER</asp:HyperLink>
            </td>

            <td style="text-align:center" class="auto-style10">
                <asp:Label ID="lblListadoHorario"
                    runat="server"
                    CssClass="titulo"
                    Text="BAJA TURNO" Style="display: block; text-align: center;"></asp:Label>
            </td>

            <td class="auto-style9">
                <div  style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
&nbsp;<asp:Label ID="lblUsuario" runat="server" Style="margin-right: 25px;" ForeColor="SteelBlue"></asp:Label>
                    </div>
            </td>

        </tr>
    </table>

    <div class="contenido">

        <table>

            <tr>
                <td style="color: #333333" class="auto-style4">&nbsp;</td>

                <td style="color: #333333">&nbsp;</td>

                <td>
                    &nbsp;</td>

                <td>
                    &nbsp;</td>

                <td>
                    &nbsp;</td>

                <td class="auto-style1">
                    &nbsp;</td>
            </tr>

            <tr>
                <td style="color: #333333" class="auto-style4">&nbsp;</td>

                <td style="color: #333333">Id Turno:</td>

                <td>
                    <asp:TextBox ID="txtIdTurno"
                        runat="server"
                        TextMode="Number">
                    </asp:TextBox>
                </td>

                <td>
                    &nbsp;</td>

                <td>
                    <asp:Button ID="btnBuscar"
                        runat="server"
                        Text="Buscar"
                        OnClick="btnBuscar_Click" CssClass="botones-grises" />
                </td>

                <td class="auto-style1">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td colspan="4">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>

            <tr>

                <td class="auto-style5">
                </td>

                <td colspan="2" class="auto-style6">
                    <asp:Button ID="btnConfirmar"
                        runat="server"
                        Text="Confirmar"
                        OnClick="btnConfirmar_Click" CssClass="auto-style3" Width="109px" />
                &nbsp;
                    <asp:Button ID="btnCancelar"
                        runat="server"
                        Text="Cancelar"
                        OnClick="btnCancelar_Click" CssClass="auto-style3" Width="99px" />
                </td>

                <td class="auto-style6">
                    </td>

                <td class="auto-style6">
                    </td>

                <td class="auto-style7">
                    </td>

            </tr>

            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td colspan="4">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
            </tr>

        </table>

        <asp:GridView ID="gvTurnos"
            runat="server"
            AutoGenerateColumns="False"
            OnRowCommand="gvTurnos_RowCommand"
            CellPadding="4"
            GridLines="None" CssClass="auto-style2" ForeColor="#333333">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>

                <asp:BoundField DataField="Medico" HeaderText="Medico" />
                <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
                <asp:BoundField DataField="HorarioInicio" HeaderText="Horario Inicio" />

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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaLogicaTurnos.aspx.cs" Inherits="Vistas.Usuario.Admin.Turnos.AltaLogicaTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>REACTIVAR TURNO</title>

    <link rel="icon" href="/Imagenes/icons8-corazón-con-pulso-96 (1).png" type="image/png" />
    <link href="~/Estilos.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style1 {
            margin-left: 17px;
        }
        .auto-style2 {
            width: 374px;
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
            background-color: white;
            text-align: center;
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
        #gvTurnos td, #gvTurnos th {
    border: 1px solid #cccccc;
        }
    </style>

</head>

<body>
    <form id="form1" runat="server">

        <table  class="tabla-barra-superior" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="auto-style4">
                    <asp:HyperLink ID="HyperLink1"
                        runat="server"
                        NavigateUrl="~/Usuario/Admin/Turnos/HomeABMLTurnos.aspx"
                        Style="display: block; text-align: left; margin-left: 25px;" CssClass="hylink-limpio">VOLVER</asp:HyperLink>
                </td>

                <td style="text-align:center" class="auto-style4">
                    <asp:Label ID="lblBajaMed"
                        runat="server"
                        CssClass="titulo"
                        Text="REACTIVAR TURNO" Style="display: block; text-align: center;"></asp:Label>
                </td>

                <td class="auto-style5">
                    <div style="display: flex; justify-content: flex-end; align-items: center; width: 100%;">
                    <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
&nbsp;<asp:Label ID="lblUsuario" runat="server"  Style="margin-right: 25px;" ForeColor="SteelBlue"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>

        <div class="contenido">

            <table>

                <tr>
                    <td>&nbsp;</td>

                    <td>&nbsp;</td>

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
                    <td>&nbsp;</td>

                    <td style="#333333">ID del Turno:&nbsp;&nbsp; </td>

                    <td>
                        <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
                    </td>

                    <td>
                        &nbsp;</td>

                    <td>
                        <asp:Button ID="btnBuscar"
                            runat="server"
                            Text="Buscar"
                            OnClick="btnBuscar_Click" CssClass="botones-grises" />
                    </td>

                    <td class="auto-style2">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td colspan="4">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>

                <tr>
                    <td>
                        &nbsp;</td>

                    <td colspan="2">
                        <asp:Button ID="btnConfirmar"
                            runat="server"
                            Text="Confirmar"
                            OnClick="btnConfirmar_Click" CssClass="auto-style3" Width="111px" />
                    &nbsp;&nbsp;
                        <asp:Button ID="btnCancelar"
                            runat="server"
                            Text="Cancelar" CssClass="auto-style3" Width="105px" />
                    </td>

                    <td>
                        &nbsp;</td>

                    <td>
                        &nbsp;</td>

                    <td class="auto-style2">
                        &nbsp;</td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td colspan="4">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>

            </table>

            <asp:GridView ID="gvTurnos"
                runat="server"
                AutoGenerateColumns="False"
                DataKeyNames="Id_Turno_T"
                OnSelectedIndexChanged="gvTurnos_SelectedIndexChanged"
                CellPadding="4"
                GridLines="None" CssClass="auto-style1" ForeColor="#333333">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                <Columns>

                    <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                    <asp:BoundField DataField="Medico" HeaderText="Médico" />
                    <asp:BoundField DataField="Paciente" HeaderText="Paciente" />
                    <asp:BoundField DataField="Fecha_Turno_T" HeaderText="Fecha" />
                    <asp:BoundField DataField="Horario_Turno_T" HeaderText="Horario" />

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
